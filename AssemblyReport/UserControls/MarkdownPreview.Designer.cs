namespace AssemblyReport.UserControls
{
    partial class MarkdownPreview
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
            this.Rtb_Preview = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Rtb_Preview
            // 
            this.Rtb_Preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rtb_Preview.Location = new System.Drawing.Point(0, 0);
            this.Rtb_Preview.Name = "Rtb_Preview";
            this.Rtb_Preview.ReadOnly = true;
            this.Rtb_Preview.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Rtb_Preview.Size = new System.Drawing.Size(301, 224);
            this.Rtb_Preview.TabIndex = 1;
            this.Rtb_Preview.Text = "";
            // 
            // MarkdownPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Rtb_Preview);
            this.Name = "MarkdownPreview";
            this.Size = new System.Drawing.Size(301, 224);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// The RTB preview.
        /// </summary>
        public System.Windows.Forms.RichTextBox Rtb_Preview;
    }
}
