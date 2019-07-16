#region License

// ********************************* Header *********************************\
// 
//    Class:  AssemblyDashboard.cs
//    Copyright (c) 2019 - 2019 AssemblyReporter. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Windows.Forms;
using AssemblyReport.Primitives;
using AssemblyReporter.Extensibility;

#endregion

namespace AssemblyReporter.UserControls
{
    /// <summary>The <see cref="AssemblyDashboard"/> user control.</summary>
    /// <seealso cref="System.Windows.Forms.UserControl"/>
    public partial class AssemblyDashboard : UserControl
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="AssemblyDashboard"/> class.</summary>
        public AssemblyDashboard()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Refreshes the dashboard property grids.</summary>
        /// <param name="assemblyPropertiesInfo">The assembly properties information.</param>
        /// <param name="settings">The settings.</param>
        public void ReloadDashboardPropertyGrids(AssemblyPropertiesInfo assemblyPropertiesInfo, ReportSettings settings)
        {
            Pg_AssemblyDashboardInformation.SelectedObject = assemblyPropertiesInfo;
            Pg_AssemblyDashboardReportSettings.SelectedObject = settings;
        }

        #endregion

        #region Methods

        /// <summary>Handles the Load event of the AssemblyDashboard control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AssemblyDashboard_Load(object sender, EventArgs e)
        {
            // Update the splitter position to 1/3 of the width.
            Pg_AssemblyDashboardReportSettings.MoveSplitterTo(Pg_AssemblyDashboardReportSettings.Width / 3);
        }

        #endregion
    }
}