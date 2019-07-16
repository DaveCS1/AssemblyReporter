#region License

// ********************************* Header *********************************\
// 
//    Class:  AssemblyExplorer.cs
//    Copyright (c) 2019 - 2019 AssemblyReporter. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.IO;
using System.Windows.Forms;
using AssemblyReport.Primitives.AssemblyScope;
using AssemblyReport.Utilities;
using AssemblyReporter.Forms;

#endregion

namespace AssemblyReporter.UserControls
{
    /// <summary>The <see cref="AssemblyExplorer"/> user control.</summary>
    /// <seealso cref="System.Windows.Forms.UserControl"/>
    public partial class AssemblyExplorer : UserControl
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="AssemblyExplorer"/> class.</summary>
        public AssemblyExplorer()
        {
            InitializeComponent();

            Tsmi_OpenExplorer.Enabled = false;
            Tsmi_GenerateDescription.Enabled = false;
            AssemblyScope = new AssemblyScope();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the location.</summary>
        /// <value>The location.</value>
        public string AssemblyLocation { get; private set; }

        /// <summary>Gets the assembly scope.</summary>
        /// <value>The assembly scope.</value>
        public AssemblyScope AssemblyScope { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Analyzes the specified assembly path.</summary>
        /// <param name="assemblyPath">The assembly path.</param>
        public void Analyze(string assemblyPath)
        {
            AssemblyLocation = assemblyPath;

            Tsmi_OpenExplorer.Enabled = true;
        }

        /// <summary>Reset the assembly explorer property grid.</summary>
        public void ResetAssemblyExplorerPropertyGrid()
        {
            Pg_AssemblyTypeInfo.SelectedObject = new AssemblyScope();
        }

        #endregion

        #region Methods

        /// <summary>Handles the Click event of the generate description menu item.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Tsmi_GenerateDescription_Click(object sender, EventArgs e)
        {
            // Get parent control
            TabPage tabPage = (TabPage)Parent;

            TabControl tabControl = (TabControl)tabPage.Parent;

            TableLayoutPanel layoutPanel = (TableLayoutPanel)tabControl.Parent;

            Main main = (Main)layoutPanel.Parent;

            // Get parent control tab and switch to the description generator page
            main.Tc_Main.SelectTab("Tp_DescriptionGenerator");

            // Reload the generator control using the specified data
            main.descriptionGeneratorControl.Analyze(AssemblyScope);
        }

        /// <summary>Handles the Click event of the open menu item.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Tsmi_OpenExplorer_Click(object sender, EventArgs e)
        {
            string location = AssemblyLocation;

            if (!string.IsNullOrEmpty(location) && File.Exists(location))
            {
                FileInfo fileInfo = new FileInfo(AssemblyLocation);
                FileUtil.OpenFileExplorer(fileInfo.Directory, true, fileInfo.Name);
            }
        }

        /// <summary>Handles the AfterSelect event of the Tv_List control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void Tv_Assembly_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get the selected node member info name.
            string selectedNodeText = e.Node.Text;

            // Resolve namespace path
            string namespacePath = e.Node.Parent != null ? e.Node.Parent.Text : string.Empty;

            AssemblyScope = new AssemblyScope(AssemblyLocation, namespacePath, e.Node.Text);

            // Handle when the top node is selected.
            if (selectedNodeText.Equals(Tv_Assembly.TopNode.Text))
            {
                // Disable generate description button for top root level node.
                Tsmi_GenerateDescription.Enabled = false;
            }
            else
            {
                if (string.IsNullOrEmpty(AssemblyScope.Description))
                {
                    // Validate its a valid type and not a namespace or folder item type.
                    if (AssemblyScope.TypeInfo != null)
                    {
                        // Enable generate description button for the type.
                        Tsmi_GenerateDescription.Enabled = true;
                    }
                    else
                    {
                        // Disable generate description button for the namespace type.
                        Tsmi_GenerateDescription.Enabled = false;
                    }
                }
                else
                {
                    // Disable generate description button for the namespace type.
                    Tsmi_GenerateDescription.Enabled = false;
                }
            }

            Pg_AssemblyTypeInfo.SelectedObject = AssemblyScope;
        }

        #endregion
    }
}