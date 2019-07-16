using AssemblyReporter.UserControls;

namespace AssemblyReporter.Forms
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Pb_Icon = new System.Windows.Forms.PictureBox();
            this.L_Location = new System.Windows.Forms.Label();
            this.Tb_Location = new System.Windows.Forms.TextBox();
            this.Btn_Browse = new System.Windows.Forms.Button();
            this.Tc_Main = new System.Windows.Forms.TabControl();
            this.Tp_Dashboard = new System.Windows.Forms.TabPage();
            this.assemblyDashboard = new AssemblyReporter.UserControls.AssemblyDashboard();
            this.Tp_AssemblyExplorer = new System.Windows.Forms.TabPage();
            this.assemblyExplorer = new AssemblyReporter.UserControls.AssemblyExplorer();
            this.Tp_MarkdownPreview = new System.Windows.Forms.TabPage();
            this.markdownPreview = new AssemblyReport.UserControls.MarkdownPreview();
            this.Tp_DescriptionGenerator = new System.Windows.Forms.TabPage();
            this.descriptionGeneratorControl = new AssemblyReport.UserControls.DescriptionGeneratorControl();
            this.Tp_Settings = new System.Windows.Forms.TabPage();
            this.Gb_Notify = new System.Windows.Forms.GroupBox();
            this.Cb_BrowseAfterBuild = new System.Windows.Forms.CheckBox();
            this.Tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.P_Assembly = new System.Windows.Forms.Panel();
            this.Gp_PictureBox = new System.Windows.Forms.GroupBox();
            this.Btn_Build = new System.Windows.Forms.Button();
            this.Tssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tssl_Separator0Divider = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tssl_Elapsed = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tssl_Separator1Divider = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tspb_ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.Tssl_ProgressPercent = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS_Main = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_Icon)).BeginInit();
            this.Tc_Main.SuspendLayout();
            this.Tp_Dashboard.SuspendLayout();
            this.Tp_AssemblyExplorer.SuspendLayout();
            this.Tp_MarkdownPreview.SuspendLayout();
            this.Tp_DescriptionGenerator.SuspendLayout();
            this.Tp_Settings.SuspendLayout();
            this.Gb_Notify.SuspendLayout();
            this.Tlp_Main.SuspendLayout();
            this.P_Assembly.SuspendLayout();
            this.Gp_PictureBox.SuspendLayout();
            this.SS_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pb_Icon
            // 
            this.Pb_Icon.Image = global::AssemblyReporter.Properties.Resources.Application;
            this.Pb_Icon.Location = new System.Drawing.Point(6, 13);
            this.Pb_Icon.Name = "Pb_Icon";
            this.Pb_Icon.Size = new System.Drawing.Size(32, 32);
            this.Pb_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pb_Icon.TabIndex = 3;
            this.Pb_Icon.TabStop = false;
            // 
            // L_Location
            // 
            this.L_Location.AutoSize = true;
            this.L_Location.Location = new System.Drawing.Point(54, 22);
            this.L_Location.Name = "L_Location";
            this.L_Location.Size = new System.Drawing.Size(51, 13);
            this.L_Location.TabIndex = 2;
            this.L_Location.Text = "Location:";
            // 
            // Tb_Location
            // 
            this.Tb_Location.AllowDrop = true;
            this.Tb_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_Location.Location = new System.Drawing.Point(111, 19);
            this.Tb_Location.Name = "Tb_Location";
            this.Tb_Location.ReadOnly = true;
            this.Tb_Location.Size = new System.Drawing.Size(351, 20);
            this.Tb_Location.TabIndex = 1;
            this.Tb_Location.Text = "Drag n\' drop the Assembly here...";
            this.Tb_Location.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox_DragDrop);
            this.Tb_Location.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox_DragEnter);
            // 
            // Btn_Browse
            // 
            this.Btn_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Browse.Image = global::AssemblyReporter.Properties.Resources.Folder;
            this.Btn_Browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Browse.Location = new System.Drawing.Point(468, 14);
            this.Btn_Browse.Name = "Btn_Browse";
            this.Btn_Browse.Size = new System.Drawing.Size(76, 28);
            this.Btn_Browse.TabIndex = 0;
            this.Btn_Browse.Text = "Browse...";
            this.Btn_Browse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Browse.UseVisualStyleBackColor = true;
            this.Btn_Browse.Click += new System.EventHandler(this.Btn_Browse_Click);
            // 
            // Tc_Main
            // 
            this.Tc_Main.Controls.Add(this.Tp_Dashboard);
            this.Tc_Main.Controls.Add(this.Tp_AssemblyExplorer);
            this.Tc_Main.Controls.Add(this.Tp_MarkdownPreview);
            this.Tc_Main.Controls.Add(this.Tp_DescriptionGenerator);
            this.Tc_Main.Controls.Add(this.Tp_Settings);
            this.Tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tc_Main.Location = new System.Drawing.Point(3, 66);
            this.Tc_Main.Name = "Tc_Main";
            this.Tc_Main.SelectedIndex = 0;
            this.Tc_Main.Size = new System.Drawing.Size(628, 395);
            this.Tc_Main.TabIndex = 4;
            // 
            // Tp_Dashboard
            // 
            this.Tp_Dashboard.Controls.Add(this.assemblyDashboard);
            this.Tp_Dashboard.Location = new System.Drawing.Point(4, 22);
            this.Tp_Dashboard.Name = "Tp_Dashboard";
            this.Tp_Dashboard.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_Dashboard.Size = new System.Drawing.Size(620, 369);
            this.Tp_Dashboard.TabIndex = 0;
            this.Tp_Dashboard.Text = "Dashboard";
            this.Tp_Dashboard.UseVisualStyleBackColor = true;
            // 
            // assemblyDashboard
            // 
            this.assemblyDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyDashboard.Location = new System.Drawing.Point(3, 3);
            this.assemblyDashboard.Name = "assemblyDashboard";
            this.assemblyDashboard.Size = new System.Drawing.Size(614, 363);
            this.assemblyDashboard.TabIndex = 0;
            // 
            // Tp_AssemblyExplorer
            // 
            this.Tp_AssemblyExplorer.Controls.Add(this.assemblyExplorer);
            this.Tp_AssemblyExplorer.Location = new System.Drawing.Point(4, 22);
            this.Tp_AssemblyExplorer.Name = "Tp_AssemblyExplorer";
            this.Tp_AssemblyExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_AssemblyExplorer.Size = new System.Drawing.Size(620, 369);
            this.Tp_AssemblyExplorer.TabIndex = 4;
            this.Tp_AssemblyExplorer.Text = "Assembly Explorer";
            this.Tp_AssemblyExplorer.UseVisualStyleBackColor = true;
            // 
            // assemblyExplorer
            // 
            this.assemblyExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyExplorer.Location = new System.Drawing.Point(3, 3);
            this.assemblyExplorer.Name = "assemblyExplorer";
            this.assemblyExplorer.Size = new System.Drawing.Size(614, 363);
            this.assemblyExplorer.TabIndex = 0;
            // 
            // Tp_MarkdownPreview
            // 
            this.Tp_MarkdownPreview.Controls.Add(this.markdownPreview);
            this.Tp_MarkdownPreview.Location = new System.Drawing.Point(4, 22);
            this.Tp_MarkdownPreview.Name = "Tp_MarkdownPreview";
            this.Tp_MarkdownPreview.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_MarkdownPreview.Size = new System.Drawing.Size(620, 369);
            this.Tp_MarkdownPreview.TabIndex = 5;
            this.Tp_MarkdownPreview.Text = "Markdown Preview";
            this.Tp_MarkdownPreview.UseVisualStyleBackColor = true;
            // 
            // markdownPreview
            // 
            this.markdownPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markdownPreview.Location = new System.Drawing.Point(3, 3);
            this.markdownPreview.Name = "markdownPreview";
            this.markdownPreview.Size = new System.Drawing.Size(614, 363);
            this.markdownPreview.TabIndex = 0;
            // 
            // Tp_DescriptionGenerator
            // 
            this.Tp_DescriptionGenerator.Controls.Add(this.descriptionGeneratorControl);
            this.Tp_DescriptionGenerator.Location = new System.Drawing.Point(4, 22);
            this.Tp_DescriptionGenerator.Name = "Tp_DescriptionGenerator";
            this.Tp_DescriptionGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_DescriptionGenerator.Size = new System.Drawing.Size(620, 369);
            this.Tp_DescriptionGenerator.TabIndex = 6;
            this.Tp_DescriptionGenerator.Text = "Description Generator";
            this.Tp_DescriptionGenerator.UseVisualStyleBackColor = true;
            // 
            // descriptionGeneratorControl
            // 
            this.descriptionGeneratorControl.AutoScroll = true;
            this.descriptionGeneratorControl.AutoScrollMinSize = new System.Drawing.Size(0, 350);
            this.descriptionGeneratorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionGeneratorControl.Location = new System.Drawing.Point(3, 3);
            this.descriptionGeneratorControl.Name = "descriptionGeneratorControl";
            this.descriptionGeneratorControl.Size = new System.Drawing.Size(614, 363);
            this.descriptionGeneratorControl.TabIndex = 0;
            // 
            // Tp_Settings
            // 
            this.Tp_Settings.Controls.Add(this.Gb_Notify);
            this.Tp_Settings.Location = new System.Drawing.Point(4, 22);
            this.Tp_Settings.Name = "Tp_Settings";
            this.Tp_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_Settings.Size = new System.Drawing.Size(620, 369);
            this.Tp_Settings.TabIndex = 7;
            this.Tp_Settings.Text = "Settings";
            this.Tp_Settings.UseVisualStyleBackColor = true;
            // 
            // Gb_Notify
            // 
            this.Gb_Notify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Gb_Notify.Controls.Add(this.Cb_BrowseAfterBuild);
            this.Gb_Notify.Location = new System.Drawing.Point(6, 6);
            this.Gb_Notify.Name = "Gb_Notify";
            this.Gb_Notify.Size = new System.Drawing.Size(608, 126);
            this.Gb_Notify.TabIndex = 1;
            this.Gb_Notify.TabStop = false;
            this.Gb_Notify.Text = "Notifications";
            // 
            // Cb_BrowseAfterBuild
            // 
            this.Cb_BrowseAfterBuild.AutoSize = true;
            this.Cb_BrowseAfterBuild.Location = new System.Drawing.Point(6, 19);
            this.Cb_BrowseAfterBuild.Name = "Cb_BrowseAfterBuild";
            this.Cb_BrowseAfterBuild.Size = new System.Drawing.Size(143, 17);
            this.Cb_BrowseAfterBuild.TabIndex = 0;
            this.Cb_BrowseAfterBuild.Text = "Browse output after build";
            this.Cb_BrowseAfterBuild.UseVisualStyleBackColor = true;
            this.Cb_BrowseAfterBuild.CheckedChanged += new System.EventHandler(this.Cb_BrowseAfterBuild_CheckedChanged);
            // 
            // Tlp_Main
            // 
            this.Tlp_Main.ColumnCount = 1;
            this.Tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tlp_Main.Controls.Add(this.P_Assembly, 0, 0);
            this.Tlp_Main.Controls.Add(this.Tc_Main, 0, 1);
            this.Tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.Tlp_Main.Name = "Tlp_Main";
            this.Tlp_Main.RowCount = 2;
            this.Tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.Tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.Tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tlp_Main.Size = new System.Drawing.Size(634, 464);
            this.Tlp_Main.TabIndex = 5;
            // 
            // P_Assembly
            // 
            this.P_Assembly.Controls.Add(this.Gp_PictureBox);
            this.P_Assembly.Controls.Add(this.Btn_Build);
            this.P_Assembly.Controls.Add(this.L_Location);
            this.P_Assembly.Controls.Add(this.Btn_Browse);
            this.P_Assembly.Controls.Add(this.Tb_Location);
            this.P_Assembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Assembly.Location = new System.Drawing.Point(3, 3);
            this.P_Assembly.Name = "P_Assembly";
            this.P_Assembly.Size = new System.Drawing.Size(628, 57);
            this.P_Assembly.TabIndex = 0;
            // 
            // Gp_PictureBox
            // 
            this.Gp_PictureBox.Controls.Add(this.Pb_Icon);
            this.Gp_PictureBox.Location = new System.Drawing.Point(3, 1);
            this.Gp_PictureBox.Name = "Gp_PictureBox";
            this.Gp_PictureBox.Size = new System.Drawing.Size(45, 51);
            this.Gp_PictureBox.TabIndex = 1;
            this.Gp_PictureBox.TabStop = false;
            // 
            // Btn_Build
            // 
            this.Btn_Build.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Build.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Build.Enabled = false;
            this.Btn_Build.Image = global::AssemblyReporter.Properties.Resources.Build;
            this.Btn_Build.Location = new System.Drawing.Point(550, 3);
            this.Btn_Build.Name = "Btn_Build";
            this.Btn_Build.Size = new System.Drawing.Size(75, 50);
            this.Btn_Build.TabIndex = 1;
            this.Btn_Build.Text = "Build";
            this.Btn_Build.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Build.UseVisualStyleBackColor = false;
            this.Btn_Build.Click += new System.EventHandler(this.Btn_Build_Click);
            // 
            // Tssl_Status
            // 
            this.Tssl_Status.BackColor = System.Drawing.Color.Transparent;
            this.Tssl_Status.Name = "Tssl_Status";
            this.Tssl_Status.Size = new System.Drawing.Size(619, 17);
            this.Tssl_Status.Spring = true;
            this.Tssl_Status.Text = "#Status#";
            // 
            // Tssl_Separator0Divider
            // 
            this.Tssl_Separator0Divider.BackColor = System.Drawing.Color.Transparent;
            this.Tssl_Separator0Divider.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Tssl_Separator0Divider.Name = "Tssl_Separator0Divider";
            this.Tssl_Separator0Divider.Size = new System.Drawing.Size(10, 17);
            this.Tssl_Separator0Divider.Text = "|";
            this.Tssl_Separator0Divider.Visible = false;
            // 
            // Tssl_Elapsed
            // 
            this.Tssl_Elapsed.BackColor = System.Drawing.Color.Transparent;
            this.Tssl_Elapsed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Tssl_Elapsed.Name = "Tssl_Elapsed";
            this.Tssl_Elapsed.Size = new System.Drawing.Size(60, 17);
            this.Tssl_Elapsed.Text = "Elapsed: #";
            this.Tssl_Elapsed.Visible = false;
            // 
            // Tssl_Separator1Divider
            // 
            this.Tssl_Separator1Divider.BackColor = System.Drawing.Color.Transparent;
            this.Tssl_Separator1Divider.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Tssl_Separator1Divider.Name = "Tssl_Separator1Divider";
            this.Tssl_Separator1Divider.Size = new System.Drawing.Size(10, 17);
            this.Tssl_Separator1Divider.Text = "|";
            this.Tssl_Separator1Divider.Visible = false;
            // 
            // Tspb_ProgressBar
            // 
            this.Tspb_ProgressBar.Name = "Tspb_ProgressBar";
            this.Tspb_ProgressBar.Size = new System.Drawing.Size(100, 16);
            this.Tspb_ProgressBar.Step = 1;
            this.Tspb_ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Tspb_ProgressBar.Visible = false;
            // 
            // Tssl_ProgressPercent
            // 
            this.Tssl_ProgressPercent.BackColor = System.Drawing.Color.Transparent;
            this.Tssl_ProgressPercent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Tssl_ProgressPercent.Name = "Tssl_ProgressPercent";
            this.Tssl_ProgressPercent.Size = new System.Drawing.Size(23, 17);
            this.Tssl_ProgressPercent.Text = "0%";
            this.Tssl_ProgressPercent.Visible = false;
            // 
            // SS_Main
            // 
            this.SS_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tssl_Status,
            this.Tssl_Separator0Divider,
            this.Tssl_Elapsed,
            this.Tssl_Separator1Divider,
            this.Tspb_ProgressBar,
            this.Tssl_ProgressPercent});
            this.SS_Main.Location = new System.Drawing.Point(0, 464);
            this.SS_Main.Name = "SS_Main";
            this.SS_Main.Size = new System.Drawing.Size(634, 22);
            this.SS_Main.TabIndex = 6;
            this.SS_Main.Text = "statusStrip1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(634, 486);
            this.Controls.Add(this.Tlp_Main);
            this.Controls.Add(this.SS_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 525);
            this.Name = "Main";
            this.Text = "Assembly Reporter";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pb_Icon)).EndInit();
            this.Tc_Main.ResumeLayout(false);
            this.Tp_Dashboard.ResumeLayout(false);
            this.Tp_AssemblyExplorer.ResumeLayout(false);
            this.Tp_MarkdownPreview.ResumeLayout(false);
            this.Tp_DescriptionGenerator.ResumeLayout(false);
            this.Tp_Settings.ResumeLayout(false);
            this.Gb_Notify.ResumeLayout(false);
            this.Gb_Notify.PerformLayout();
            this.Tlp_Main.ResumeLayout(false);
            this.P_Assembly.ResumeLayout(false);
            this.P_Assembly.PerformLayout();
            this.Gp_PictureBox.ResumeLayout(false);
            this.SS_Main.ResumeLayout(false);
            this.SS_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L_Location;
        private System.Windows.Forms.TextBox Tb_Location;
        private System.Windows.Forms.Button Btn_Browse;
        private System.Windows.Forms.PictureBox Pb_Icon;
        private System.Windows.Forms.TabPage Tp_Dashboard;
        private System.Windows.Forms.TableLayoutPanel Tlp_Main;
        private System.Windows.Forms.Panel P_Assembly;
        private System.Windows.Forms.Button Btn_Build;
        private System.Windows.Forms.TabPage Tp_AssemblyExplorer;
        private System.Windows.Forms.GroupBox Gp_PictureBox;
        private System.Windows.Forms.ToolStripStatusLabel Tssl_Status;
        private System.Windows.Forms.ToolStripProgressBar Tspb_ProgressBar;
        private System.Windows.Forms.TabPage Tp_MarkdownPreview;
        private System.Windows.Forms.ToolStripStatusLabel Tssl_ProgressPercent;
        private System.Windows.Forms.ToolStripStatusLabel Tssl_Separator1Divider;
        private System.Windows.Forms.ToolStripStatusLabel Tssl_Separator0Divider;
        private System.Windows.Forms.ToolStripStatusLabel Tssl_Elapsed;
        private AssemblyExplorer assemblyExplorer;
        private AssemblyReport.UserControls.MarkdownPreview markdownPreview;
        private UserControls.AssemblyDashboard assemblyDashboard;
        private System.Windows.Forms.TabPage Tp_DescriptionGenerator;
        private System.Windows.Forms.StatusStrip SS_Main;
        private System.Windows.Forms.TabPage Tp_Settings;
        private System.Windows.Forms.GroupBox Gb_Notify;
        private System.Windows.Forms.CheckBox Cb_BrowseAfterBuild;
        internal System.Windows.Forms.TabControl Tc_Main;
        internal AssemblyReport.UserControls.DescriptionGeneratorControl descriptionGeneratorControl;
    }
}

