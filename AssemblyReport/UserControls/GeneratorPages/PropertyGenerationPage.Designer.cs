namespace AssemblyReport.UserControls.GeneratorPages
{
    partial class PropertyGenerationPage
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
            this.Rb_PropertySet = new System.Windows.Forms.RadioButton();
            this.Rb_PropertyGet = new System.Windows.Forms.RadioButton();
            this.Rb_PropertyBoth = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Rb_PropertySet
            // 
            this.Rb_PropertySet.AutoSize = true;
            this.Rb_PropertySet.Location = new System.Drawing.Point(104, 3);
            this.Rb_PropertySet.Name = "Rb_PropertySet";
            this.Rb_PropertySet.Size = new System.Drawing.Size(41, 17);
            this.Rb_PropertySet.TabIndex = 5;
            this.Rb_PropertySet.Text = "Set";
            this.Rb_PropertySet.UseVisualStyleBackColor = true;
            this.Rb_PropertySet.CheckedChanged += new System.EventHandler(this.Rb_PropertySet_CheckedChanged);
            // 
            // Rb_PropertyGet
            // 
            this.Rb_PropertyGet.AutoSize = true;
            this.Rb_PropertyGet.Location = new System.Drawing.Point(56, 3);
            this.Rb_PropertyGet.Name = "Rb_PropertyGet";
            this.Rb_PropertyGet.Size = new System.Drawing.Size(42, 17);
            this.Rb_PropertyGet.TabIndex = 4;
            this.Rb_PropertyGet.Text = "Get";
            this.Rb_PropertyGet.UseVisualStyleBackColor = true;
            this.Rb_PropertyGet.CheckedChanged += new System.EventHandler(this.Rb_PropertySet_CheckedChanged);
            // 
            // Rb_PropertyBoth
            // 
            this.Rb_PropertyBoth.AutoSize = true;
            this.Rb_PropertyBoth.Checked = true;
            this.Rb_PropertyBoth.Location = new System.Drawing.Point(3, 3);
            this.Rb_PropertyBoth.Name = "Rb_PropertyBoth";
            this.Rb_PropertyBoth.Size = new System.Drawing.Size(47, 17);
            this.Rb_PropertyBoth.TabIndex = 3;
            this.Rb_PropertyBoth.TabStop = true;
            this.Rb_PropertyBoth.Text = "Both";
            this.Rb_PropertyBoth.UseVisualStyleBackColor = true;
            this.Rb_PropertyBoth.CheckedChanged += new System.EventHandler(this.Rb_PropertySet_CheckedChanged);
            // 
            // PropertyGenerationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Rb_PropertySet);
            this.Controls.Add(this.Rb_PropertyGet);
            this.Controls.Add(this.Rb_PropertyBoth);
            this.Name = "PropertyGenerationPage";
            this.Size = new System.Drawing.Size(306, 172);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Rb_PropertySet;
        private System.Windows.Forms.RadioButton Rb_PropertyGet;
        private System.Windows.Forms.RadioButton Rb_PropertyBoth;
    }
}
