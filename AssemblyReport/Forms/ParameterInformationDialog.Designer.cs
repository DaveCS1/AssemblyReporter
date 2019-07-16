namespace AssemblyReport.Forms
{
    partial class ParameterInformationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterInformationDialog));
            this.Gb_Parameter = new System.Windows.Forms.GroupBox();
            this.L_Description = new System.Windows.Forms.Label();
            this.L_Name = new System.Windows.Forms.Label();
            this.Tb_ParameterDescription = new System.Windows.Forms.TextBox();
            this.Tb_ParameterName = new System.Windows.Forms.TextBox();
            this.Btn_OK = new System.Windows.Forms.Button();
            this.Tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.P_ButtonsPanel = new System.Windows.Forms.Panel();
            this.Btn_Clear = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Gb_Parameter.SuspendLayout();
            this.Tlp_Main.SuspendLayout();
            this.P_ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gb_Parameter
            // 
            this.Gb_Parameter.Controls.Add(this.L_Description);
            this.Gb_Parameter.Controls.Add(this.L_Name);
            this.Gb_Parameter.Controls.Add(this.Tb_ParameterDescription);
            this.Gb_Parameter.Controls.Add(this.Tb_ParameterName);
            this.Gb_Parameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_Parameter.Location = new System.Drawing.Point(3, 3);
            this.Gb_Parameter.Name = "Gb_Parameter";
            this.Gb_Parameter.Size = new System.Drawing.Size(377, 69);
            this.Gb_Parameter.TabIndex = 11;
            this.Gb_Parameter.TabStop = false;
            this.Gb_Parameter.Text = "Parameter";
            // 
            // L_Description
            // 
            this.L_Description.AutoSize = true;
            this.L_Description.Location = new System.Drawing.Point(6, 48);
            this.L_Description.Name = "L_Description";
            this.L_Description.Size = new System.Drawing.Size(63, 13);
            this.L_Description.TabIndex = 1;
            this.L_Description.Text = "Description:";
            // 
            // L_Name
            // 
            this.L_Name.AutoSize = true;
            this.L_Name.Location = new System.Drawing.Point(6, 22);
            this.L_Name.Name = "L_Name";
            this.L_Name.Size = new System.Drawing.Size(38, 13);
            this.L_Name.TabIndex = 0;
            this.L_Name.Text = "Name:";
            // 
            // Tb_ParameterDescription
            // 
            this.Tb_ParameterDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_ParameterDescription.Location = new System.Drawing.Point(75, 45);
            this.Tb_ParameterDescription.Name = "Tb_ParameterDescription";
            this.Tb_ParameterDescription.Size = new System.Drawing.Size(296, 20);
            this.Tb_ParameterDescription.TabIndex = 8;
            this.Tb_ParameterDescription.TextChanged += new System.EventHandler(this.ParameterBoxes_TextChanged);
            // 
            // Tb_ParameterName
            // 
            this.Tb_ParameterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_ParameterName.Location = new System.Drawing.Point(75, 19);
            this.Tb_ParameterName.Name = "Tb_ParameterName";
            this.Tb_ParameterName.Size = new System.Drawing.Size(296, 20);
            this.Tb_ParameterName.TabIndex = 7;
            this.Tb_ParameterName.TextChanged += new System.EventHandler(this.ParameterBoxes_TextChanged);
            // 
            // Btn_OK
            // 
            this.Btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_OK.Location = new System.Drawing.Point(137, 3);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(75, 23);
            this.Btn_OK.TabIndex = 10;
            this.Btn_OK.Text = "OK";
            this.Btn_OK.UseVisualStyleBackColor = true;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // Tlp_Main
            // 
            this.Tlp_Main.ColumnCount = 1;
            this.Tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tlp_Main.Controls.Add(this.P_ButtonsPanel, 0, 1);
            this.Tlp_Main.Controls.Add(this.Gb_Parameter, 0, 0);
            this.Tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.Tlp_Main.Name = "Tlp_Main";
            this.Tlp_Main.RowCount = 2;
            this.Tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.Tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tlp_Main.Size = new System.Drawing.Size(383, 111);
            this.Tlp_Main.TabIndex = 12;
            // 
            // P_ButtonsPanel
            // 
            this.P_ButtonsPanel.Controls.Add(this.Btn_Clear);
            this.P_ButtonsPanel.Controls.Add(this.Btn_Cancel);
            this.P_ButtonsPanel.Controls.Add(this.Btn_OK);
            this.P_ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_ButtonsPanel.Location = new System.Drawing.Point(3, 78);
            this.P_ButtonsPanel.Name = "P_ButtonsPanel";
            this.P_ButtonsPanel.Size = new System.Drawing.Size(377, 30);
            this.P_ButtonsPanel.TabIndex = 0;
            // 
            // Btn_Clear
            // 
            this.Btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Clear.Location = new System.Drawing.Point(218, 3);
            this.Btn_Clear.Name = "Btn_Clear";
            this.Btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.Btn_Clear.TabIndex = 12;
            this.Btn_Clear.Text = "Clear";
            this.Btn_Clear.UseVisualStyleBackColor = true;
            this.Btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(299, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 11;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // ParameterInformationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 111);
            this.Controls.Add(this.Tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParameterInformationDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parameter Information";
            this.Gb_Parameter.ResumeLayout(false);
            this.Gb_Parameter.PerformLayout();
            this.Tlp_Main.ResumeLayout(false);
            this.P_ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gb_Parameter;
        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.Label L_Description;
        private System.Windows.Forms.Label L_Name;
        private System.Windows.Forms.TextBox Tb_ParameterDescription;
        private System.Windows.Forms.TextBox Tb_ParameterName;
        private System.Windows.Forms.TableLayoutPanel Tlp_Main;
        private System.Windows.Forms.Panel P_ButtonsPanel;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Clear;
    }
}
