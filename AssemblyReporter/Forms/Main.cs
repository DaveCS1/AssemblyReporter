#region License

// ********************************* Header *********************************\
// 
//    Class:  Main.cs
//    Copyright (c) 2019 - 2019 AssemblyReporter. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AssemblyReport;
using AssemblyReport.Extensibility;
using AssemblyReport.Primitives.AssemblyAnalyzer;
using AssemblyReport.Utilities;
using AssemblyReporter.Properties;
using Resources = AssemblyReport.Properties.Resources;

#endregion

namespace AssemblyReporter.Forms
{
    /// <summary>The <see cref="Main"/> form.</summary>
    /// <seealso cref="Form"/>
    public partial class Main : Form
    {
        #region Fields

        private readonly BackgroundWorker assemblyWorker;
        private readonly Stopwatch duration;
        private AssemblyAnalyzer assemblyAnalyzer;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Main"/> class.</summary>
        public Main()
        {
            InitializeComponent();

            // Initialize variables
            UpdateStatus(Resources.Analyzer_Preparing);

            // Initialize the Assembly Analyzer background worker
            assemblyWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            assemblyWorker.DoWork += AssemblyWorker_DoWork;
            assemblyWorker.ProgressChanged += AssemblyWorker_ProgressChanged;
            assemblyWorker.RunWorkerCompleted += AssemblyWorker_WorkerCompleted;

            // Initialize variables.
            duration = new Stopwatch();

            // Configure decompiler
            assemblyAnalyzer = new AssemblyAnalyzer();

            // Report settings
            assemblyDashboard.ReloadDashboardPropertyGrids(assemblyAnalyzer.AssemblyPropertiesInfo, assemblyAnalyzer.Settings);

            // Assembly tree view information explorer
            assemblyExplorer.ResetAssemblyExplorerPropertyGrid();

            // Loads settings
            Cb_BrowseAfterBuild.Checked = Settings.Default.OpenBuildDirectoryOnOutput;
        }

        #endregion

        #region Methods

        /// <summary>Assembly worker do work.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void AssemblyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            assemblyWorker.ReportProgress(1);

            // Clear tree view
            assemblyExplorer.Tv_Assembly.InvokeIfRequired(() => assemblyExplorer.Tv_Assembly.Nodes.Clear());

            assemblyWorker.ReportProgress(10);

            // Reset the assembly editor property grid item values.
            assemblyExplorer.ResetAssemblyExplorerPropertyGrid();

            assemblyWorker.ReportProgress(20);

            // Get the assembly location from the parameter.
            string assemblyPath = e.Argument.ToString();

            assemblyWorker.ReportProgress(30);

            UpdateStatus(Resources.Analyzer_Build_ReflectionHierarchy);

            // Prepare to decompile the architecture
            assemblyAnalyzer = new AssemblyAnalyzer(assemblyPath);

            assemblyWorker.ReportProgress(40);

            assemblyAnalyzer.Analyze(assemblyPath);

            // Set assembly icon.
            if (assemblyAnalyzer.Icon != null)
            {
                Pb_Icon.Image = assemblyAnalyzer.Icon;
            }

            assemblyWorker.ReportProgress(50);

            assemblyExplorer.Analyze(Tb_Location.Text);

            assemblyWorker.ReportProgress(60);

            UpdateStatus(string.Format(Resources.Analyzer_Build_Preview, Path.GetFileNameWithoutExtension(Tb_Location.Text)));

            // Construct the assembly architecture to a tree view
            TreeNode treeNode = TypesUtil.GenerateTreeView(Tb_Location.Text);

            assemblyWorker.ReportProgress(70);

            // Expand from the root node.
            treeNode.ExpandAll();

            assemblyWorker.ReportProgress(80);

            UpdateStatus(string.Format(Resources.Analyzer_Generate_Documentation, Path.GetFileNameWithoutExtension(Tb_Location.Text)));

            // Add root node to tree view.
            assemblyExplorer.Tv_Assembly.InvokeIfRequired(() => assemblyExplorer.Tv_Assembly.Nodes.Add(treeNode));

            assemblyWorker.ReportProgress(90);

            // Refresh markdown preview contents.
            markdownPreview.Rtb_Preview.InvokeIfRequired(() => markdownPreview.Rtb_Preview.Text = assemblyAnalyzer.AssemblyReport.Contents);

            assemblyWorker.ReportProgress(100);
        }

        /// <summary>Assemblies the worker progress changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void AssemblyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update progress percentage and status.
            Tspb_ProgressBar.InvokeIfRequiredToolStrip(progressBar =>
            {
                progressBar.Value = e.ProgressPercentage;
            });
            Tssl_ProgressPercent.InvokeIfRequiredToolStrip(statusLabel =>
            {
                statusLabel.Text = $@"{e.ProgressPercentage:0}%";
            });
            Tssl_Elapsed.InvokeIfRequiredToolStrip(elapsedLabel =>
            {
                elapsedLabel.Text = ControlUtil.ResolveDurationText(duration.Elapsed, @"Elapsed: ");
            });

            // Update elapsed scan duration.
            UpdateStatus($@"Scanning: {assemblyAnalyzer.AssemblyPropertiesInfo.FileName}...");
        }

        /// <summary>Assemblies the worker run assembly worker completed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void AssemblyWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Stop timer.
            duration.Stop();

            // Update the properties grid output items
            assemblyDashboard.ReloadDashboardPropertyGrids(assemblyAnalyzer.AssemblyPropertiesInfo, assemblyAnalyzer.Settings);

            // Select the top level node
            if (assemblyExplorer.Tv_Assembly.Nodes.Count > 0)
            {
                assemblyExplorer.Tv_Assembly.SelectedNode = assemblyExplorer.Tv_Assembly.Nodes[0];
            }

            // Hide tool strip scan information.
            Tspb_ProgressBar.Visible = false;
            Tssl_ProgressPercent.Visible = false;
            Tssl_Separator0Divider.Visible = false;
            Tssl_Separator1Divider.Visible = false;
            Tssl_Elapsed.Visible = false;

            // Enable build button.
            Btn_Build.Enabled = true;

            // Enable browse button.
            Btn_Browse.Enabled = true;

            // Completed scanning assembly.
            UpdateStatus(ControlUtil.ResolveDurationText(duration.Elapsed, @"Scan Took: "));
        }

        /// <summary>Occurs when the browse button was clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            // Disables the browse button.
            Btn_Browse.Enabled = false;
            Btn_Build.Enabled = false;

            using (OpenFileDialog openFileAssembly = new OpenFileDialog())
            {
                openFileAssembly.Title = @"Browse for an assembly file...";
                openFileAssembly.Filter = @"All Supported Types|*.dll;*.exe|Executable Files|*.exe|Library Files|*.dll|All Files|*.*";

                if (DialogResult.OK == openFileAssembly.ShowDialog(this))
                {
                    // Check whether the documentation file also exists in the same directory as the assembly.
                    string documentationFile = Path.Combine(Path.GetDirectoryName(openFileAssembly.FileName), Path.GetFileNameWithoutExtension(openFileAssembly.FileName) + Constants.XMLFileExtension);

                    if (File.Exists(documentationFile))
                    {
                        assemblyAnalyzer.Settings.ReadCompilerDocumentationFile(documentationFile);
                    }
                    else
                    {
                        // Ask the user to search for it since it couldn't be found in the default directory.
                        using (OpenFileDialog openFileDocumentation = new OpenFileDialog())
                        {
                            openFileDocumentation.Title = @"Browse for the assembly compiler build documentation...";
                            openFileDocumentation.Filter = @"XML Source File|*.xml";

                            if (DialogResult.OK == openFileDocumentation.ShowDialog(this))
                            {
                                assemblyAnalyzer.Settings.ReadCompilerDocumentationFile(openFileDocumentation.FileName);
                            }
                            else
                            {
                                Btn_Browse.Enabled = true;
                            }
                        }
                    }

                    LoadAssembly(openFileAssembly.FileName);
                }
                else
                {
                    Btn_Browse.Enabled = true;
                }
            }
        }

        /// <summary>Occurs when the build button was clicked.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void Btn_Build_Click(object sender, EventArgs e)
        {
            Btn_Browse.Enabled = false;
            Btn_Build.Enabled = false;

            UpdateStatus(string.Format(Resources.Analyzer_Generate_Documentation, Path.GetFileNameWithoutExtension(Tb_Location.Text)));

            assemblyAnalyzer.AssemblyReport.GenerateReport(assemblyAnalyzer.AssemblyPropertiesInfo, assemblyAnalyzer.HierarchyTree, assemblyAnalyzer.Settings);

            UpdateStatus(string.Format(Resources.Analyzer_Build_Preview, Path.GetFileNameWithoutExtension(Tb_Location.Text)));

            string report = assemblyAnalyzer.AssemblyReport.Contents;

            // Update the preview markdown text
            markdownPreview.Rtb_Preview.Text = report;

            UpdateStatus(string.Format(Resources.Report_Compiling, Path.GetFileNameWithoutExtension(Tb_Location.Text)));

            if (!assemblyAnalyzer.Settings.FileRepositoryIsUrl)
            {
                // Write the image file to the local system
                ImageUtil.ExportAllMemberTypes(assemblyAnalyzer.Settings.ImageRepository);
            }

            // Write the report to file.
            File.WriteAllText(assemblyAnalyzer.Settings.BuildPath, report);

            UpdateStatus(string.Format(Resources.Report_Compiled, Path.GetFileNameWithoutExtension(Tb_Location.Text)));

            if (Settings.Default.OpenBuildDirectoryOnOutput)
            {
                DialogResult result = MessageBox.Show(Resources.Report_OpenOutput, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    FileInfo fileInfo = new FileInfo(assemblyAnalyzer.Settings.BuildPath);
                    FileUtil.OpenFileExplorer(fileInfo.Directory, true, Path.GetFileName(fileInfo.FullName));
                }
            }

            Btn_Build.Enabled = true;
            Btn_Browse.Enabled = true;
        }

        /// <summary>Handles the CheckedChanged event of the Cb_BrowseAfterBuild control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Cb_BrowseAfterBuild_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.OpenBuildDirectoryOnOutput = Cb_BrowseAfterBuild.Checked;
            Settings.Default.Save();
        }

        /// <summary>Loads the assembly.</summary>
        /// <param name="assemblyLocation">The assembly location.</param>
        private void LoadAssembly(string assemblyLocation)
        {
            if (string.IsNullOrEmpty(assemblyLocation))
            {
                throw new ArgumentNullException(nameof(assemblyLocation), @"The assembly location cannot be null or empty.");
            }

            if (!File.Exists(assemblyLocation))
            {
                throw new FileNotFoundException(@"The assembly location cannot be found.", assemblyLocation);
            }

            if (!AsmUtil.IsAssembly(assemblyLocation))
            {
                throw new ArgumentNullException(nameof(assemblyLocation), @"The assembly location doesn't link to a valid assembly file type.");
            }

            // BUG: Validate the assembly is same '.NET Framework' version or below and not a '.NET Core' or '.NET Standard'. To validate the input and provider better feedback.

            UpdateStatus(string.Format(Resources.Analyzer_Parsing, Path.GetFileNameWithoutExtension(Tb_Location.Text)));

            // Stop any currently loaded progress and restart.
            if (assemblyWorker.IsBusy)
            {
                assemblyWorker.CancelAsync();
            }

            // Reset assembly explorer grids
            assemblyExplorer.ResetAssemblyExplorerPropertyGrid();

            // Disable buttons
            Btn_Browse.Enabled = false;
            Btn_Build.Enabled = false;

            // Set the assembly location.
            Tb_Location.Text = assemblyLocation;

            // Show the status bar progress information.
            Tspb_ProgressBar.Visible = true;
            Tssl_ProgressPercent.Visible = true;
            Tssl_Separator0Divider.Visible = true;
            Tssl_Separator1Divider.Visible = true;
            Tssl_Elapsed.Visible = true;

            // Start counting the process duration from the start.
            duration.Reset();
            duration.Start();

            // Start the assembly loading process in separate thread.
            assemblyWorker.RunWorkerAsync(assemblyLocation);
        }

        /// <summary>Handles the Load event of the Main control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Main_Load(object sender, EventArgs e)
        {
            UpdateStatus(Resources.Analyzer_Ready);
        }

        /// <summary>Handles the DragDrop event of the TextBox control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data.GetData(DataFormats.FileDrop) is string[] fileNames))
            {
                return;
            }

            LoadAssembly(fileNames[0]);
        }

        /// <summary>Handles the DragEnter event of the TextBox control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DragEventArgs"/> instance containing the event data.</param>
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        /// <summary>Updates the status.</summary>
        /// <param name="message">The message.</param>
        private void UpdateStatus(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                message = string.Empty;
            }

            Tssl_Status.InvokeIfRequiredToolStrip(statusUpdate =>
            {
                statusUpdate.Text = message;
            });
        }

        #endregion
    }
}