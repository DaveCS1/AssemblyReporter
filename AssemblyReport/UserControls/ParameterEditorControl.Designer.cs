namespace AssemblyReport.UserControls
{
    partial class ParameterEditorControl
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
            this.Lv_Parameters = new System.Windows.Forms.ListView();
            this.Ch_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ch_Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cms_Parameters = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tsmi_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Tss_CmsParametersSeparator0 = new System.Windows.Forms.ToolStripSeparator();
            this.Tsmi_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.Tss_CmsParametersSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Tsmi_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.Cms_Parameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lv_Parameters
            // 
            this.Lv_Parameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ch_Name,
            this.Ch_Description});
            this.Lv_Parameters.ContextMenuStrip = this.Cms_Parameters;
            this.Lv_Parameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lv_Parameters.FullRowSelect = true;
            this.Lv_Parameters.GridLines = true;
            this.Lv_Parameters.HideSelection = false;
            this.Lv_Parameters.Location = new System.Drawing.Point(0, 0);
            this.Lv_Parameters.Name = "Lv_Parameters";
            this.Lv_Parameters.Size = new System.Drawing.Size(464, 362);
            this.Lv_Parameters.TabIndex = 13;
            this.Lv_Parameters.UseCompatibleStateImageBehavior = false;
            this.Lv_Parameters.View = System.Windows.Forms.View.Details;
            // 
            // Ch_Name
            // 
            this.Ch_Name.Text = "Name";
            this.Ch_Name.Width = 137;
            // 
            // Ch_Description
            // 
            this.Ch_Description.Text = "Description";
            this.Ch_Description.Width = 254;
            // 
            // Cms_Parameters
            // 
            this.Cms_Parameters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsmi_Add,
            this.Tss_CmsParametersSeparator0,
            this.Tsmi_Remove,
            this.Tss_CmsParametersSeparator1,
            this.Tsmi_Clear});
            this.Cms_Parameters.Name = "Cms_Parameters";
            this.Cms_Parameters.Size = new System.Drawing.Size(118, 82);
            // 
            // Tsmi_Add
            // 
            this.Tsmi_Add.Image = global::AssemblyReport.Properties.Resources.Add;
            this.Tsmi_Add.Name = "Tsmi_Add";
            this.Tsmi_Add.Size = new System.Drawing.Size(117, 22);
            this.Tsmi_Add.Text = "Add";
            this.Tsmi_Add.Click += new System.EventHandler(this.Tsmi_Add_Click);
            // 
            // Tss_CmsParametersSeparator0
            // 
            this.Tss_CmsParametersSeparator0.Name = "Tss_CmsParametersSeparator0";
            this.Tss_CmsParametersSeparator0.Size = new System.Drawing.Size(114, 6);
            // 
            // Tsmi_Remove
            // 
            this.Tsmi_Remove.Image = global::AssemblyReport.Properties.Resources.Remove;
            this.Tsmi_Remove.Name = "Tsmi_Remove";
            this.Tsmi_Remove.Size = new System.Drawing.Size(117, 22);
            this.Tsmi_Remove.Text = "Remove";
            this.Tsmi_Remove.Click += new System.EventHandler(this.Tsmi_Remove_Click);
            // 
            // Tss_CmsParametersSeparator1
            // 
            this.Tss_CmsParametersSeparator1.Name = "Tss_CmsParametersSeparator1";
            this.Tss_CmsParametersSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // Tsmi_Clear
            // 
            this.Tsmi_Clear.Image = global::AssemblyReport.Properties.Resources.Clear;
            this.Tsmi_Clear.Name = "Tsmi_Clear";
            this.Tsmi_Clear.Size = new System.Drawing.Size(117, 22);
            this.Tsmi_Clear.Text = "Clear";
            this.Tsmi_Clear.Click += new System.EventHandler(this.Tsmi_Clear_Click);
            // 
            // ParameterEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lv_Parameters);
            this.Name = "ParameterEditorControl";
            this.Size = new System.Drawing.Size(464, 362);
            this.Cms_Parameters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader Ch_Name;
        private System.Windows.Forms.ColumnHeader Ch_Description;
        private System.Windows.Forms.ContextMenuStrip Cms_Parameters;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_Remove;
        private System.Windows.Forms.ToolStripSeparator Tss_CmsParametersSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_Clear;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_Add;
        private System.Windows.Forms.ToolStripSeparator Tss_CmsParametersSeparator0;
        private System.Windows.Forms.ListView Lv_Parameters;
    }
}
