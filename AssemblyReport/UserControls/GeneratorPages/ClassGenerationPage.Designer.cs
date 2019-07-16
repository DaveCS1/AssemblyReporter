namespace AssemblyReport.UserControls.GeneratorPages
{
    partial class ClassGenerationPage
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
            this.Cb_IsConstructor = new System.Windows.Forms.CheckBox();
            this.Cb_IsPrivate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Cb_IsConstructor
            // 
            this.Cb_IsConstructor.AutoSize = true;
            this.Cb_IsConstructor.Location = new System.Drawing.Point(3, 3);
            this.Cb_IsConstructor.Name = "Cb_IsConstructor";
            this.Cb_IsConstructor.Size = new System.Drawing.Size(91, 17);
            this.Cb_IsConstructor.TabIndex = 0;
            this.Cb_IsConstructor.Text = "Is Constructor";
            this.Cb_IsConstructor.UseVisualStyleBackColor = true;
            this.Cb_IsConstructor.CheckedChanged += new System.EventHandler(this.Cb_IsConstructor_CheckedChanged);
            // 
            // Cb_IsPrivate
            // 
            this.Cb_IsPrivate.AutoSize = true;
            this.Cb_IsPrivate.Location = new System.Drawing.Point(3, 26);
            this.Cb_IsPrivate.Name = "Cb_IsPrivate";
            this.Cb_IsPrivate.Size = new System.Drawing.Size(70, 17);
            this.Cb_IsPrivate.TabIndex = 1;
            this.Cb_IsPrivate.Text = "Is Private";
            this.Cb_IsPrivate.UseVisualStyleBackColor = true;
            // 
            // ClassGenerationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Cb_IsPrivate);
            this.Controls.Add(this.Cb_IsConstructor);
            this.Name = "ClassGenerationPage";
            this.Size = new System.Drawing.Size(272, 110);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Cb_IsConstructor;
        private System.Windows.Forms.CheckBox Cb_IsPrivate;
    }
}
