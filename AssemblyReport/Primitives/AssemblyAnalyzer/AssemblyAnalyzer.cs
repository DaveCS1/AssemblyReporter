#region License

// ********************************* Header *********************************\
// 
//    Class:  AssemblyAnalyzer.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using AssemblyReport.Primitives.Markdown;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives.AssemblyAnalyzer
{
    /// <summary>The <see cref="AssemblyAnalyzer"/> class.</summary>
    /// <seealso cref="IDisposable"/>
    [DebuggerDisplay("Types Count = {Count}, Root Name = {AssemblyPropertiesInfo.RootName}, Location = {AssemblyPropertiesInfo.Location}")]
    public class AssemblyAnalyzer : IAssemblyAnalyzer
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="AssemblyAnalyzer"/> class.</summary>
        /// <param name="assemblyPath">The assembly file path.</param>
        public AssemblyAnalyzer(string assemblyPath) : this()
        {
            // Validate the assembly path
            if (string.IsNullOrEmpty(assemblyPath))
            {
                throw new ArgumentNullException(nameof(assemblyPath), @"The file name cannot be null or empty.");
            }

            if (!File.Exists(assemblyPath))
            {
                throw new FileNotFoundException(@"The assembly file name cannot be found!", assemblyPath);
            }

            if (!AsmUtil.IsAssembly(assemblyPath))
            {
                throw new ArgumentNullException(nameof(assemblyPath), @"The file name is not an assembly file (*.DLL;*.EXE).");
            }

            // Initialize
            Location = assemblyPath;
            AssemblyPropertiesInfo = new AssemblyPropertiesInfo(assemblyPath);
            HierarchyTree = new HierarchyTree(assemblyPath);
            AssemblyReport = new MarkdownReport(AssemblyPropertiesInfo, HierarchyTree, Settings);
            Settings = new ReportSettings(AssemblyPropertiesInfo, HierarchyTree);
        }

        /// <summary>Initializes a new instance of the <see cref="AssemblyAnalyzer"/> class.</summary>
        public AssemblyAnalyzer()
        {
            AssemblyPropertiesInfo = new AssemblyPropertiesInfo();
            HierarchyTree = new HierarchyTree();
            Location = string.Empty;
            Settings = new ReportSettings();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the assembly information.</summary>
        /// <value>The assembly information.</value>
        public AssemblyPropertiesInfo AssemblyPropertiesInfo { get; private set; }

        /// <summary>Gets or sets the assembly report.</summary>
        /// <value>The assembly report.</value>
        public MarkdownReport AssemblyReport { get; set; }

        /// <summary>Gets the count.</summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return HierarchyTree.ExportedTypes.Count; }
        }

        /// <summary>Gets the hierarchy types.</summary>
        /// <value>The hierarchy types.</value>
        public HierarchyTree HierarchyTree { get; private set; }

        /// <summary>Gets the assembly icon.</summary>
        /// <value>The icon.</value>
        [Browsable(false)]
        public Image Icon
        {
            get
            {
                Image icon;

                if (AssemblyPropertiesInfo != null)
                {
                    if (AssemblyPropertiesInfo.Icon != null)
                    {
                        // Returns the assembly icon.
                        icon = AssemblyPropertiesInfo.Icon;
                    }
                    else
                    {
                        icon = null;
                    }
                }
                else
                {
                    icon = null;
                }

                return icon;
            }
        }

        /// <summary>Gets the location.</summary>
        /// <value>The location.</value>
        public string Location { get; private set; }

        /// <summary>Gets or sets the settings.</summary>
        /// <value>The settings.</value>
        public ReportSettings Settings { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Analyze the Assembly.</summary>
        /// <param name="assemblyPath">The assembly to analyze.</param>
        public void Analyze(string assemblyPath)
        {
            try
            {
                // Update the assembly path to analyze start scanning

                Location = assemblyPath;
                AssemblyPropertiesInfo = new AssemblyPropertiesInfo(assemblyPath);
                HierarchyTree = new HierarchyTree(assemblyPath);
                AssemblyReport = new MarkdownReport(AssemblyPropertiesInfo, HierarchyTree, Settings);
                Settings = new ReportSettings(AssemblyPropertiesInfo, HierarchyTree);

                // Generate a new assembly report.
                AssemblyReport.GenerateReport(AssemblyPropertiesInfo, HierarchyTree, Settings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            // Do nothing.
        }

        #endregion
    }
}