namespace AssemblyReporter.UserControls
{
    partial class AssemblyExplorer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyExplorer));
            this.Sc_Main = new System.Windows.Forms.SplitContainer();
            this.Gp_Information = new System.Windows.Forms.GroupBox();
            this.Pg_AssemblyTypeInfo = new System.Windows.Forms.PropertyGrid();
            this.Gb_HierarchyExplorer = new System.Windows.Forms.GroupBox();
            this.Tv_Assembly = new System.Windows.Forms.TreeView();
            this.Cms_AssemblyTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tsmi_OpenExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.Tss_ContextMenuItem0 = new System.Windows.Forms.ToolStripSeparator();
            this.Tsmi_GenerateDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.Il_AssemblyTree = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Sc_Main)).BeginInit();
            this.Sc_Main.Panel1.SuspendLayout();
            this.Sc_Main.Panel2.SuspendLayout();
            this.Sc_Main.SuspendLayout();
            this.Gp_Information.SuspendLayout();
            this.Gb_HierarchyExplorer.SuspendLayout();
            this.Cms_AssemblyTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sc_Main
            // 
            this.Sc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sc_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.Sc_Main.IsSplitterFixed = true;
            this.Sc_Main.Location = new System.Drawing.Point(0, 0);
            this.Sc_Main.Name = "Sc_Main";
            this.Sc_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Sc_Main.Panel1
            // 
            this.Sc_Main.Panel1.Controls.Add(this.Gp_Information);
            this.Sc_Main.Panel1MinSize = 118;
            // 
            // Sc_Main.Panel2
            // 
            this.Sc_Main.Panel2.Controls.Add(this.Gb_HierarchyExplorer);
            this.Sc_Main.Panel2MinSize = 175;
            this.Sc_Main.Size = new System.Drawing.Size(400, 300);
            this.Sc_Main.SplitterDistance = 118;
            this.Sc_Main.TabIndex = 2;
            // 
            // Gp_Information
            // 
            this.Gp_Information.Controls.Add(this.Pg_AssemblyTypeInfo);
            this.Gp_Information.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gp_Information.Location = new System.Drawing.Point(0, 0);
            this.Gp_Information.Name = "Gp_Information";
            this.Gp_Information.Size = new System.Drawing.Size(400, 118);
            this.Gp_Information.TabIndex = 3;
            this.Gp_Information.TabStop = false;
            this.Gp_Information.Text = "Information";
            // 
            // Pg_AssemblyTypeInfo
            // 
            this.Pg_AssemblyTypeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pg_AssemblyTypeInfo.HelpVisible = false;
            this.Pg_AssemblyTypeInfo.Location = new System.Drawing.Point(3, 16);
            this.Pg_AssemblyTypeInfo.Name = "Pg_AssemblyTypeInfo";
            this.Pg_AssemblyTypeInfo.Size = new System.Drawing.Size(394, 99);
            this.Pg_AssemblyTypeInfo.TabIndex = 1;
            this.Pg_AssemblyTypeInfo.ToolbarVisible = false;
            // 
            // Gb_HierarchyExplorer
            // 
            this.Gb_HierarchyExplorer.Controls.Add(this.Tv_Assembly);
            this.Gb_HierarchyExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_HierarchyExplorer.Location = new System.Drawing.Point(0, 0);
            this.Gb_HierarchyExplorer.Name = "Gb_HierarchyExplorer";
            this.Gb_HierarchyExplorer.Size = new System.Drawing.Size(400, 178);
            this.Gb_HierarchyExplorer.TabIndex = 1;
            this.Gb_HierarchyExplorer.TabStop = false;
            this.Gb_HierarchyExplorer.Text = "Hierarchy Explorer";
            // 
            // Tv_Assembly
            // 
            this.Tv_Assembly.ContextMenuStrip = this.Cms_AssemblyTree;
            this.Tv_Assembly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tv_Assembly.FullRowSelect = true;
            this.Tv_Assembly.ImageIndex = 0;
            this.Tv_Assembly.ImageList = this.Il_AssemblyTree;
            this.Tv_Assembly.Location = new System.Drawing.Point(3, 16);
            this.Tv_Assembly.Name = "Tv_Assembly";
            this.Tv_Assembly.SelectedImageIndex = 0;
            this.Tv_Assembly.ShowNodeToolTips = true;
            this.Tv_Assembly.Size = new System.Drawing.Size(394, 159);
            this.Tv_Assembly.TabIndex = 0;
            this.Tv_Assembly.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tv_Assembly_AfterSelect);
            // 
            // Cms_AssemblyTree
            // 
            this.Cms_AssemblyTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsmi_OpenExplorer,
            this.Tss_ContextMenuItem0,
            this.Tsmi_GenerateDescription});
            this.Cms_AssemblyTree.Name = "Cms_AssemblyExplorer";
            this.Cms_AssemblyTree.Size = new System.Drawing.Size(220, 76);
            this.Cms_AssemblyTree.Text = "Assembly Explorer Menu";
            // 
            // Tsmi_OpenExplorer
            // 
            this.Tsmi_OpenExplorer.Image = global::AssemblyReport.Properties.Resources.Folder;
            this.Tsmi_OpenExplorer.Name = "Tsmi_OpenExplorer";
            this.Tsmi_OpenExplorer.Size = new System.Drawing.Size(219, 22);
            this.Tsmi_OpenExplorer.Text = "Open Folder in File Explorer";
            this.Tsmi_OpenExplorer.Click += new System.EventHandler(this.Tsmi_OpenExplorer_Click);
            // 
            // Tss_ContextMenuItem0
            // 
            this.Tss_ContextMenuItem0.Name = "Tss_ContextMenuItem0";
            this.Tss_ContextMenuItem0.Size = new System.Drawing.Size(216, 6);
            // 
            // Tsmi_GenerateDescription
            // 
            this.Tsmi_GenerateDescription.Image = global::AssemblyReport.Properties.Resources.ResourceXml;
            this.Tsmi_GenerateDescription.Name = "Tsmi_GenerateDescription";
            this.Tsmi_GenerateDescription.Size = new System.Drawing.Size(219, 22);
            this.Tsmi_GenerateDescription.Text = "Generate Description";
            this.Tsmi_GenerateDescription.ToolTipText = "Generates a description summary for the type.";
            this.Tsmi_GenerateDescription.Click += new System.EventHandler(this.Tsmi_GenerateDescription_Click);
            // 
            // Il_AssemblyTree
            // 
            this.Il_AssemblyTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Il_AssemblyTree.ImageStream")));
            this.Il_AssemblyTree.TransparentColor = System.Drawing.Color.Transparent;
            this.Il_AssemblyTree.Images.SetKeyName(0, "Solution.png");
            this.Il_AssemblyTree.Images.SetKeyName(1, "NameSpace.png");
            this.Il_AssemblyTree.Images.SetKeyName(2, "Class.png");
            this.Il_AssemblyTree.Images.SetKeyName(3, "Delegate.png");
            this.Il_AssemblyTree.Images.SetKeyName(4, "Enumerator.png");
            this.Il_AssemblyTree.Images.SetKeyName(5, "Event.png");
            this.Il_AssemblyTree.Images.SetKeyName(6, "Interface.png");
            this.Il_AssemblyTree.Images.SetKeyName(7, "Method.png");
            this.Il_AssemblyTree.Images.SetKeyName(8, "Structure.png");
            this.Il_AssemblyTree.Images.SetKeyName(9, "Constructor.png");
            this.Il_AssemblyTree.Images.SetKeyName(10, "Field.png");
            this.Il_AssemblyTree.Images.SetKeyName(11, "Property.png");
            // 
            // AssemblyExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Sc_Main);
            this.Name = "AssemblyExplorer";
            this.Size = new System.Drawing.Size(400, 300);
            this.Sc_Main.Panel1.ResumeLayout(false);
            this.Sc_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Sc_Main)).EndInit();
            this.Sc_Main.ResumeLayout(false);
            this.Gp_Information.ResumeLayout(false);
            this.Gb_HierarchyExplorer.ResumeLayout(false);
            this.Cms_AssemblyTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Sc_Main;
        private System.Windows.Forms.GroupBox Gp_Information;
        private System.Windows.Forms.GroupBox Gb_HierarchyExplorer;
        private System.Windows.Forms.ContextMenuStrip Cms_AssemblyTree;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_OpenExplorer;
        private System.Windows.Forms.ToolStripSeparator Tss_ContextMenuItem0;
        private System.Windows.Forms.ImageList Il_AssemblyTree;
        public System.Windows.Forms.PropertyGrid Pg_AssemblyTypeInfo;
        public System.Windows.Forms.TreeView Tv_Assembly;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_GenerateDescription;
    }
}
