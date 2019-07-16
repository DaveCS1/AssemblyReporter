namespace AssemblyReporter.UserControls
{
    partial class AssemblyDashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Sc_Dashboard = new System.Windows.Forms.SplitContainer();
            this.Pg_AssemblyDashboardReportSettings = new System.Windows.Forms.PropertyGrid();
            this.Pg_AssemblyDashboardInformation = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.Sc_Dashboard)).BeginInit();
            this.Sc_Dashboard.Panel1.SuspendLayout();
            this.Sc_Dashboard.Panel2.SuspendLayout();
            this.Sc_Dashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sc_Dashboard
            // 
            this.Sc_Dashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sc_Dashboard.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.Sc_Dashboard.IsSplitterFixed = true;
            this.Sc_Dashboard.Location = new System.Drawing.Point(0, 0);
            this.Sc_Dashboard.Name = "Sc_Dashboard";
            this.Sc_Dashboard.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Sc_Dashboard.Panel1
            // 
            this.Sc_Dashboard.Panel1.Controls.Add(this.Pg_AssemblyDashboardReportSettings);
            this.Sc_Dashboard.Panel1MinSize = 115;
            // 
            // Sc_Dashboard.Panel2
            // 
            this.Sc_Dashboard.Panel2.Controls.Add(this.Pg_AssemblyDashboardInformation);
            this.Sc_Dashboard.Panel2MinSize = 175;
            this.Sc_Dashboard.Size = new System.Drawing.Size(300, 400);
            this.Sc_Dashboard.SplitterDistance = 115;
            this.Sc_Dashboard.TabIndex = 9;
            // 
            // Pg_AssemblyDashboardReportSettings
            // 
            this.Pg_AssemblyDashboardReportSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pg_AssemblyDashboardReportSettings.HelpVisible = false;
            this.Pg_AssemblyDashboardReportSettings.Location = new System.Drawing.Point(0, 0);
            this.Pg_AssemblyDashboardReportSettings.Name = "Pg_AssemblyDashboardReportSettings";
            this.Pg_AssemblyDashboardReportSettings.Size = new System.Drawing.Size(300, 115);
            this.Pg_AssemblyDashboardReportSettings.TabIndex = 6;
            this.Pg_AssemblyDashboardReportSettings.ToolbarVisible = false;
            // 
            // Pg_AssemblyDashboardInformation
            // 
            this.Pg_AssemblyDashboardInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pg_AssemblyDashboardInformation.HelpVisible = false;
            this.Pg_AssemblyDashboardInformation.Location = new System.Drawing.Point(0, 0);
            this.Pg_AssemblyDashboardInformation.Name = "Pg_AssemblyDashboardInformation";
            this.Pg_AssemblyDashboardInformation.Size = new System.Drawing.Size(300, 281);
            this.Pg_AssemblyDashboardInformation.TabIndex = 7;
            this.Pg_AssemblyDashboardInformation.ToolbarVisible = false;
            // 
            // AssemblyDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Sc_Dashboard);
            this.Name = "AssemblyDashboard";
            this.Size = new System.Drawing.Size(300, 400);
            this.Load += new System.EventHandler(this.AssemblyDashboard_Load);
            this.Sc_Dashboard.Panel1.ResumeLayout(false);
            this.Sc_Dashboard.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Sc_Dashboard)).EndInit();
            this.Sc_Dashboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Sc_Dashboard;
        public System.Windows.Forms.PropertyGrid Pg_AssemblyDashboardReportSettings;
        public System.Windows.Forms.PropertyGrid Pg_AssemblyDashboardInformation;
    }
}
