namespace AssemblyReport.UserControls
{
    partial class DescriptionGeneratorControl
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
            this.Tp_Class = new System.Windows.Forms.TabPage();
            this.Tp_Delegate = new System.Windows.Forms.TabPage();
            this.Tp_Enumerator = new System.Windows.Forms.TabPage();
            this.Tp_Structure = new System.Windows.Forms.TabPage();
            this.Tc_MemberTypeNavigation = new System.Windows.Forms.TabControl();
            this.Tp_Event = new System.Windows.Forms.TabPage();
            this.Tp_Field = new System.Windows.Forms.TabPage();
            this.Tp_Interface = new System.Windows.Forms.TabPage();
            this.Tp_Method = new System.Windows.Forms.TabPage();
            this.Tp_Property = new System.Windows.Forms.TabPage();
            this.Tp_Settings = new System.Windows.Forms.TabPage();
            this.Gb_MemberTypeConfig = new System.Windows.Forms.GroupBox();
            this.Tp_Parameters = new System.Windows.Forms.TabPage();
            this.P_Buttons = new System.Windows.Forms.Panel();
            this.Pb_MemberTypeImage = new System.Windows.Forms.PictureBox();
            this.Btn_Copy = new System.Windows.Forms.Button();
            this.L_MemberType = new System.Windows.Forms.Label();
            this.Cb_GenerateMemberType = new System.Windows.Forms.ComboBox();
            this.Btn_Generate = new System.Windows.Forms.Button();
            this.Tc_Navigation = new System.Windows.Forms.TabControl();
            this.Tp_General = new System.Windows.Forms.TabPage();
            this.Gb_MemberInformation = new System.Windows.Forms.GroupBox();
            this.Pg_MemberType = new System.Windows.Forms.PropertyGrid();
            this.Tp_Inheritance = new System.Windows.Forms.TabPage();
            this.Tb_Inheritance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cb_Inherit = new System.Windows.Forms.CheckBox();
            this.Tlp_LayoutTable = new System.Windows.Forms.TableLayoutPanel();
            this.Gp_Output = new System.Windows.Forms.GroupBox();
            this.Rtb_Output = new System.Windows.Forms.RichTextBox();
            this.parameterInfoEditorDialog = new AssemblyReport.UserControls.ParameterEditorControl();
            this.classGenerationPage = new AssemblyReport.UserControls.GeneratorPages.ClassGenerationPage();
            this.delegateGenerationPage = new AssemblyReport.UserControls.GeneratorPages.DelegateGenerationPage();
            this.enumGenerationPage = new AssemblyReport.UserControls.GeneratorPages.EnumGenerationPage();
            this.eventGenerationPage = new AssemblyReport.UserControls.GeneratorPages.EventGenerationPage();
            this.fieldGenerationPage = new AssemblyReport.UserControls.GeneratorPages.FieldGenerationPage();
            this.interfaceGenerationPage = new AssemblyReport.UserControls.GeneratorPages.InterfaceGenerationPage();
            this.methodGenerationPage = new AssemblyReport.UserControls.GeneratorPages.MethodGenerationPage();
            this.propertyGenerationPage = new AssemblyReport.UserControls.GeneratorPages.PropertyGenerationPage();
            this.structureGenerationPage = new AssemblyReport.UserControls.GeneratorPages.StructureGenerationPage();
            this.Tp_Class.SuspendLayout();
            this.Tp_Delegate.SuspendLayout();
            this.Tp_Enumerator.SuspendLayout();
            this.Tp_Structure.SuspendLayout();
            this.Tc_MemberTypeNavigation.SuspendLayout();
            this.Tp_Event.SuspendLayout();
            this.Tp_Field.SuspendLayout();
            this.Tp_Interface.SuspendLayout();
            this.Tp_Method.SuspendLayout();
            this.Tp_Property.SuspendLayout();
            this.Tp_Settings.SuspendLayout();
            this.Gb_MemberTypeConfig.SuspendLayout();
            this.Tp_Parameters.SuspendLayout();
            this.P_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_MemberTypeImage)).BeginInit();
            this.Tc_Navigation.SuspendLayout();
            this.Tp_General.SuspendLayout();
            this.Gb_MemberInformation.SuspendLayout();
            this.Tp_Inheritance.SuspendLayout();
            this.Tlp_LayoutTable.SuspendLayout();
            this.Gp_Output.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tp_Class
            // 
            this.Tp_Class.Controls.Add(this.classGenerationPage);
            this.Tp_Class.Location = new System.Drawing.Point(4, 22);
            this.Tp_Class.Name = "Tp_Class";
            this.Tp_Class.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_Class.Size = new System.Drawing.Size(364, 74);
            this.Tp_Class.TabIndex = 0;
            this.Tp_Class.Text = "Class";
            this.Tp_Class.UseVisualStyleBackColor = true;
            // 
            // Tp_Delegate
            // 
            this.Tp_Delegate.Controls.Add(this.delegateGenerationPage);
            this.Tp_Delegate.Location = new System.Drawing.Point(4, 22);
            this.Tp_Delegate.Name = "Tp_Delegate";
            this.Tp_Delegate.Size = new System.Drawing.Size(364, 74);
            this.Tp_Delegate.TabIndex = 2;
            this.Tp_Delegate.Text = "Delegate";
            this.Tp_Delegate.UseVisualStyleBackColor = true;
            // 
            // Tp_Enumerator
            // 
            this.Tp_Enumerator.Controls.Add(this.enumGenerationPage);
            this.Tp_Enumerator.Location = new System.Drawing.Point(4, 22);
            this.Tp_Enumerator.Name = "Tp_Enumerator";
            this.Tp_Enumerator.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_Enumerator.Size = new System.Drawing.Size(381, 74);
            this.Tp_Enumerator.TabIndex = 1;
            this.Tp_Enumerator.Text = "Enumerator";
            this.Tp_Enumerator.UseVisualStyleBackColor = true;
            // 
            // Tp_Structure
            // 
            this.Tp_Structure.Controls.Add(this.structureGenerationPage);
            this.Tp_Structure.Location = new System.Drawing.Point(4, 22);
            this.Tp_Structure.Name = "Tp_Structure";
            this.Tp_Structure.Size = new System.Drawing.Size(381, 74);
            this.Tp_Structure.TabIndex = 4;
            this.Tp_Structure.Text = "Structure";
            this.Tp_Structure.UseVisualStyleBackColor = true;
            // 
            // Tc_MemberTypeNavigation
            // 
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Class);
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Delegate);
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Enumerator);
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Event);
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Field);
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Interface);
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Method);
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Property);
            this.Tc_MemberTypeNavigation.Controls.Add(this.Tp_Structure);
            this.Tc_MemberTypeNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tc_MemberTypeNavigation.Location = new System.Drawing.Point(3, 16);
            this.Tc_MemberTypeNavigation.Name = "Tc_MemberTypeNavigation";
            this.Tc_MemberTypeNavigation.SelectedIndex = 0;
            this.Tc_MemberTypeNavigation.Size = new System.Drawing.Size(372, 100);
            this.Tc_MemberTypeNavigation.TabIndex = 11;
            // 
            // Tp_Event
            // 
            this.Tp_Event.Controls.Add(this.eventGenerationPage);
            this.Tp_Event.Location = new System.Drawing.Point(4, 22);
            this.Tp_Event.Name = "Tp_Event";
            this.Tp_Event.Size = new System.Drawing.Size(381, 74);
            this.Tp_Event.TabIndex = 7;
            this.Tp_Event.Text = "Event";
            this.Tp_Event.UseVisualStyleBackColor = true;
            // 
            // Tp_Field
            // 
            this.Tp_Field.Controls.Add(this.fieldGenerationPage);
            this.Tp_Field.Location = new System.Drawing.Point(4, 22);
            this.Tp_Field.Name = "Tp_Field";
            this.Tp_Field.Size = new System.Drawing.Size(381, 74);
            this.Tp_Field.TabIndex = 6;
            this.Tp_Field.Text = "Field";
            this.Tp_Field.UseVisualStyleBackColor = true;
            // 
            // Tp_Interface
            // 
            this.Tp_Interface.Controls.Add(this.interfaceGenerationPage);
            this.Tp_Interface.Location = new System.Drawing.Point(4, 22);
            this.Tp_Interface.Name = "Tp_Interface";
            this.Tp_Interface.Size = new System.Drawing.Size(381, 74);
            this.Tp_Interface.TabIndex = 3;
            this.Tp_Interface.Text = "Interface";
            this.Tp_Interface.UseVisualStyleBackColor = true;
            // 
            // Tp_Method
            // 
            this.Tp_Method.Controls.Add(this.methodGenerationPage);
            this.Tp_Method.Location = new System.Drawing.Point(4, 22);
            this.Tp_Method.Name = "Tp_Method";
            this.Tp_Method.Size = new System.Drawing.Size(381, 74);
            this.Tp_Method.TabIndex = 8;
            this.Tp_Method.Text = "Method";
            this.Tp_Method.UseVisualStyleBackColor = true;
            // 
            // Tp_Property
            // 
            this.Tp_Property.Controls.Add(this.propertyGenerationPage);
            this.Tp_Property.Location = new System.Drawing.Point(4, 22);
            this.Tp_Property.Name = "Tp_Property";
            this.Tp_Property.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_Property.Size = new System.Drawing.Size(381, 74);
            this.Tp_Property.TabIndex = 5;
            this.Tp_Property.Text = "Property";
            this.Tp_Property.UseVisualStyleBackColor = true;
            // 
            // Tp_Settings
            // 
            this.Tp_Settings.Controls.Add(this.Gb_MemberTypeConfig);
            this.Tp_Settings.Location = new System.Drawing.Point(4, 22);
            this.Tp_Settings.Name = "Tp_Settings";
            this.Tp_Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_Settings.Size = new System.Drawing.Size(384, 125);
            this.Tp_Settings.TabIndex = 1;
            this.Tp_Settings.Text = "Settings";
            this.Tp_Settings.UseVisualStyleBackColor = true;
            // 
            // Gb_MemberTypeConfig
            // 
            this.Gb_MemberTypeConfig.Controls.Add(this.Tc_MemberTypeNavigation);
            this.Gb_MemberTypeConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_MemberTypeConfig.Location = new System.Drawing.Point(3, 3);
            this.Gb_MemberTypeConfig.Name = "Gb_MemberTypeConfig";
            this.Gb_MemberTypeConfig.Size = new System.Drawing.Size(378, 119);
            this.Gb_MemberTypeConfig.TabIndex = 14;
            this.Gb_MemberTypeConfig.TabStop = false;
            this.Gb_MemberTypeConfig.Text = "Member Type Configurations";
            // 
            // Tp_Parameters
            // 
            this.Tp_Parameters.Controls.Add(this.parameterInfoEditorDialog);
            this.Tp_Parameters.Location = new System.Drawing.Point(4, 22);
            this.Tp_Parameters.Name = "Tp_Parameters";
            this.Tp_Parameters.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_Parameters.Size = new System.Drawing.Size(384, 125);
            this.Tp_Parameters.TabIndex = 2;
            this.Tp_Parameters.Text = "Parameters";
            this.Tp_Parameters.UseVisualStyleBackColor = true;
            // 
            // P_Buttons
            // 
            this.P_Buttons.Controls.Add(this.Pb_MemberTypeImage);
            this.P_Buttons.Controls.Add(this.Btn_Copy);
            this.P_Buttons.Controls.Add(this.L_MemberType);
            this.P_Buttons.Controls.Add(this.Cb_GenerateMemberType);
            this.P_Buttons.Controls.Add(this.Btn_Generate);
            this.P_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Buttons.Location = new System.Drawing.Point(3, 3);
            this.P_Buttons.Name = "P_Buttons";
            this.P_Buttons.Size = new System.Drawing.Size(392, 29);
            this.P_Buttons.TabIndex = 5;
            // 
            // Pb_MemberTypeImage
            // 
            this.Pb_MemberTypeImage.Image = global::AssemblyReport.Properties.Resources.Class;
            this.Pb_MemberTypeImage.Location = new System.Drawing.Point(3, 3);
            this.Pb_MemberTypeImage.Name = "Pb_MemberTypeImage";
            this.Pb_MemberTypeImage.Size = new System.Drawing.Size(23, 23);
            this.Pb_MemberTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Pb_MemberTypeImage.TabIndex = 4;
            this.Pb_MemberTypeImage.TabStop = false;
            // 
            // Btn_Copy
            // 
            this.Btn_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Copy.Location = new System.Drawing.Point(207, 3);
            this.Btn_Copy.Name = "Btn_Copy";
            this.Btn_Copy.Size = new System.Drawing.Size(101, 23);
            this.Btn_Copy.TabIndex = 3;
            this.Btn_Copy.Text = "Copy to Clipboard";
            this.Btn_Copy.UseVisualStyleBackColor = true;
            this.Btn_Copy.Click += new System.EventHandler(this.Btn_Copy_Click);
            // 
            // L_MemberType
            // 
            this.L_MemberType.AutoSize = true;
            this.L_MemberType.Location = new System.Drawing.Point(31, 8);
            this.L_MemberType.Name = "L_MemberType";
            this.L_MemberType.Size = new System.Drawing.Size(75, 13);
            this.L_MemberType.TabIndex = 2;
            this.L_MemberType.Text = "Member Type:";
            // 
            // Cb_GenerateMemberType
            // 
            this.Cb_GenerateMemberType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_GenerateMemberType.FormattingEnabled = true;
            this.Cb_GenerateMemberType.Location = new System.Drawing.Point(112, 5);
            this.Cb_GenerateMemberType.Name = "Cb_GenerateMemberType";
            this.Cb_GenerateMemberType.Size = new System.Drawing.Size(140, 21);
            this.Cb_GenerateMemberType.TabIndex = 1;
            this.Cb_GenerateMemberType.SelectedIndexChanged += new System.EventHandler(this.Cb_GenerateMemberType_SelectedIndexChanged);
            // 
            // Btn_Generate
            // 
            this.Btn_Generate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Generate.Location = new System.Drawing.Point(314, 3);
            this.Btn_Generate.Name = "Btn_Generate";
            this.Btn_Generate.Size = new System.Drawing.Size(75, 23);
            this.Btn_Generate.TabIndex = 0;
            this.Btn_Generate.Text = "Generate";
            this.Btn_Generate.UseVisualStyleBackColor = true;
            this.Btn_Generate.Click += new System.EventHandler(this.Btn_Generate_Click);
            // 
            // Tc_Navigation
            // 
            this.Tc_Navigation.Controls.Add(this.Tp_General);
            this.Tc_Navigation.Controls.Add(this.Tp_Inheritance);
            this.Tc_Navigation.Controls.Add(this.Tp_Parameters);
            this.Tc_Navigation.Controls.Add(this.Tp_Settings);
            this.Tc_Navigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tc_Navigation.Location = new System.Drawing.Point(3, 38);
            this.Tc_Navigation.Name = "Tc_Navigation";
            this.Tc_Navigation.SelectedIndex = 0;
            this.Tc_Navigation.Size = new System.Drawing.Size(392, 151);
            this.Tc_Navigation.TabIndex = 6;
            // 
            // Tp_General
            // 
            this.Tp_General.Controls.Add(this.Gb_MemberInformation);
            this.Tp_General.Location = new System.Drawing.Point(4, 22);
            this.Tp_General.Name = "Tp_General";
            this.Tp_General.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_General.Size = new System.Drawing.Size(384, 125);
            this.Tp_General.TabIndex = 0;
            this.Tp_General.Text = "General";
            this.Tp_General.UseVisualStyleBackColor = true;
            // 
            // Gb_MemberInformation
            // 
            this.Gb_MemberInformation.Controls.Add(this.Pg_MemberType);
            this.Gb_MemberInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_MemberInformation.Location = new System.Drawing.Point(3, 3);
            this.Gb_MemberInformation.Name = "Gb_MemberInformation";
            this.Gb_MemberInformation.Size = new System.Drawing.Size(378, 119);
            this.Gb_MemberInformation.TabIndex = 16;
            this.Gb_MemberInformation.TabStop = false;
            this.Gb_MemberInformation.Text = "Member Type Information";
            // 
            // Pg_MemberType
            // 
            this.Pg_MemberType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pg_MemberType.HelpVisible = false;
            this.Pg_MemberType.Location = new System.Drawing.Point(3, 16);
            this.Pg_MemberType.Name = "Pg_MemberType";
            this.Pg_MemberType.Size = new System.Drawing.Size(372, 100);
            this.Pg_MemberType.TabIndex = 14;
            this.Pg_MemberType.ToolbarVisible = false;
            this.Pg_MemberType.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.Pg_MemberType_PropertyValueChanged);
            // 
            // Tp_Inheritance
            // 
            this.Tp_Inheritance.Controls.Add(this.Tb_Inheritance);
            this.Tp_Inheritance.Controls.Add(this.label1);
            this.Tp_Inheritance.Controls.Add(this.Cb_Inherit);
            this.Tp_Inheritance.Location = new System.Drawing.Point(4, 22);
            this.Tp_Inheritance.Name = "Tp_Inheritance";
            this.Tp_Inheritance.Padding = new System.Windows.Forms.Padding(3);
            this.Tp_Inheritance.Size = new System.Drawing.Size(384, 125);
            this.Tp_Inheritance.TabIndex = 3;
            this.Tp_Inheritance.Text = "Inheritance";
            this.Tp_Inheritance.UseVisualStyleBackColor = true;
            // 
            // Tb_Inheritance
            // 
            this.Tb_Inheritance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_Inheritance.Location = new System.Drawing.Point(91, 23);
            this.Tb_Inheritance.Name = "Tb_Inheritance";
            this.Tb_Inheritance.Size = new System.Drawing.Size(287, 20);
            this.Tb_Inheritance.TabIndex = 2;
            this.Tb_Inheritance.Text = "System.Drawing.Design.UITypeEditor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inherited Class:";
            // 
            // Cb_Inherit
            // 
            this.Cb_Inherit.AutoSize = true;
            this.Cb_Inherit.Location = new System.Drawing.Point(6, 6);
            this.Cb_Inherit.Name = "Cb_Inherit";
            this.Cb_Inherit.Size = new System.Drawing.Size(59, 17);
            this.Cb_Inherit.TabIndex = 0;
            this.Cb_Inherit.Text = "Enable";
            this.Cb_Inherit.UseVisualStyleBackColor = true;
            this.Cb_Inherit.CheckedChanged += new System.EventHandler(this.Cb_Inherit_CheckedChanged);
            // 
            // Tlp_LayoutTable
            // 
            this.Tlp_LayoutTable.ColumnCount = 1;
            this.Tlp_LayoutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tlp_LayoutTable.Controls.Add(this.Gp_Output, 0, 2);
            this.Tlp_LayoutTable.Controls.Add(this.Tc_Navigation, 0, 1);
            this.Tlp_LayoutTable.Controls.Add(this.P_Buttons, 0, 0);
            this.Tlp_LayoutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tlp_LayoutTable.Location = new System.Drawing.Point(0, 0);
            this.Tlp_LayoutTable.Name = "Tlp_LayoutTable";
            this.Tlp_LayoutTable.RowCount = 3;
            this.Tlp_LayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.Tlp_LayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.Tlp_LayoutTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Tlp_LayoutTable.Size = new System.Drawing.Size(398, 350);
            this.Tlp_LayoutTable.TabIndex = 5;
            // 
            // Gp_Output
            // 
            this.Gp_Output.Controls.Add(this.Rtb_Output);
            this.Gp_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gp_Output.Location = new System.Drawing.Point(3, 195);
            this.Gp_Output.Name = "Gp_Output";
            this.Gp_Output.Size = new System.Drawing.Size(392, 152);
            this.Gp_Output.TabIndex = 3;
            this.Gp_Output.TabStop = false;
            this.Gp_Output.Text = "Generated Output";
            // 
            // Rtb_Output
            // 
            this.Rtb_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Rtb_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rtb_Output.Location = new System.Drawing.Point(3, 16);
            this.Rtb_Output.Name = "Rtb_Output";
            this.Rtb_Output.ReadOnly = true;
            this.Rtb_Output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Rtb_Output.Size = new System.Drawing.Size(386, 133);
            this.Rtb_Output.TabIndex = 2;
            this.Rtb_Output.Text = "";
            // 
            // parameterInfoEditorDialog
            // 
            this.parameterInfoEditorDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parameterInfoEditorDialog.Location = new System.Drawing.Point(3, 3);
            this.parameterInfoEditorDialog.Name = "parameterInfoEditorDialog";
            this.parameterInfoEditorDialog.Size = new System.Drawing.Size(378, 119);
            this.parameterInfoEditorDialog.TabIndex = 0;
            // 
            // classGenerationPage
            // 
            this.classGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classGenerationPage.Location = new System.Drawing.Point(3, 3);
            this.classGenerationPage.Name = "classGenerationPage";
            this.classGenerationPage.Size = new System.Drawing.Size(358, 68);
            this.classGenerationPage.TabIndex = 0;
            // 
            // delegateGenerationPage
            // 
            this.delegateGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delegateGenerationPage.Location = new System.Drawing.Point(0, 0);
            this.delegateGenerationPage.Name = "delegateGenerationPage";
            this.delegateGenerationPage.Size = new System.Drawing.Size(364, 74);
            this.delegateGenerationPage.TabIndex = 0;
            // 
            // enumGenerationPage
            // 
            this.enumGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.enumGenerationPage.Location = new System.Drawing.Point(3, 3);
            this.enumGenerationPage.Name = "enumGenerationPage";
            this.enumGenerationPage.Size = new System.Drawing.Size(375, 68);
            this.enumGenerationPage.TabIndex = 0;
            // 
            // eventGenerationPage
            // 
            this.eventGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventGenerationPage.Location = new System.Drawing.Point(0, 0);
            this.eventGenerationPage.Name = "eventGenerationPage";
            this.eventGenerationPage.Size = new System.Drawing.Size(381, 74);
            this.eventGenerationPage.TabIndex = 0;
            // 
            // fieldGenerationPage
            // 
            this.fieldGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldGenerationPage.Location = new System.Drawing.Point(0, 0);
            this.fieldGenerationPage.Name = "fieldGenerationPage";
            this.fieldGenerationPage.Size = new System.Drawing.Size(381, 74);
            this.fieldGenerationPage.TabIndex = 0;
            // 
            // interfaceGenerationPage
            // 
            this.interfaceGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceGenerationPage.Location = new System.Drawing.Point(0, 0);
            this.interfaceGenerationPage.Name = "interfaceGenerationPage";
            this.interfaceGenerationPage.Size = new System.Drawing.Size(381, 74);
            this.interfaceGenerationPage.TabIndex = 0;
            // 
            // methodGenerationPage
            // 
            this.methodGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.methodGenerationPage.Location = new System.Drawing.Point(0, 0);
            this.methodGenerationPage.Name = "methodGenerationPage";
            this.methodGenerationPage.Size = new System.Drawing.Size(381, 74);
            this.methodGenerationPage.TabIndex = 0;
            // 
            // propertyGenerationPage
            // 
            this.propertyGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGenerationPage.Location = new System.Drawing.Point(3, 3);
            this.propertyGenerationPage.Name = "propertyGenerationPage";
            this.propertyGenerationPage.Size = new System.Drawing.Size(375, 68);
            this.propertyGenerationPage.TabIndex = 0;
            // 
            // structureGenerationPage
            // 
            this.structureGenerationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.structureGenerationPage.Location = new System.Drawing.Point(0, 0);
            this.structureGenerationPage.Name = "structureGenerationPage";
            this.structureGenerationPage.Size = new System.Drawing.Size(381, 74);
            this.structureGenerationPage.TabIndex = 0;
            // 
            // DescriptionGeneratorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 350);
            this.Controls.Add(this.Tlp_LayoutTable);
            this.Name = "DescriptionGeneratorControl";
            this.Size = new System.Drawing.Size(398, 304);
            this.Load += new System.EventHandler(this.DescriptionGeneratorControl_Load);
            this.Tp_Class.ResumeLayout(false);
            this.Tp_Delegate.ResumeLayout(false);
            this.Tp_Enumerator.ResumeLayout(false);
            this.Tp_Structure.ResumeLayout(false);
            this.Tc_MemberTypeNavigation.ResumeLayout(false);
            this.Tp_Event.ResumeLayout(false);
            this.Tp_Field.ResumeLayout(false);
            this.Tp_Interface.ResumeLayout(false);
            this.Tp_Method.ResumeLayout(false);
            this.Tp_Property.ResumeLayout(false);
            this.Tp_Settings.ResumeLayout(false);
            this.Gb_MemberTypeConfig.ResumeLayout(false);
            this.Tp_Parameters.ResumeLayout(false);
            this.P_Buttons.ResumeLayout(false);
            this.P_Buttons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pb_MemberTypeImage)).EndInit();
            this.Tc_Navigation.ResumeLayout(false);
            this.Tp_General.ResumeLayout(false);
            this.Gb_MemberInformation.ResumeLayout(false);
            this.Tp_Inheritance.ResumeLayout(false);
            this.Tp_Inheritance.PerformLayout();
            this.Tlp_LayoutTable.ResumeLayout(false);
            this.Gp_Output.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Tp_Class;
        private System.Windows.Forms.TabPage Tp_Delegate;
        private System.Windows.Forms.TabPage Tp_Enumerator;
        private System.Windows.Forms.TabPage Tp_Structure;
        private System.Windows.Forms.TabControl Tc_MemberTypeNavigation;
        private System.Windows.Forms.TabPage Tp_Interface;
        private System.Windows.Forms.TabPage Tp_Settings;
        private System.Windows.Forms.TabPage Tp_Parameters;
        private System.Windows.Forms.Panel P_Buttons;
        private System.Windows.Forms.Button Btn_Generate;
        private System.Windows.Forms.TabControl Tc_Navigation;
        private System.Windows.Forms.TabPage Tp_General;
        private System.Windows.Forms.TableLayoutPanel Tlp_LayoutTable;
        private System.Windows.Forms.GroupBox Gp_Output;
        private System.Windows.Forms.RichTextBox Rtb_Output;
        private ParameterEditorControl parameterInfoEditorDialog;
        private GeneratorPages.ClassGenerationPage classGenerationPage;
        private System.Windows.Forms.GroupBox Gb_MemberTypeConfig;
        private GeneratorPages.DelegateGenerationPage delegateGenerationPage;
        private GeneratorPages.EnumGenerationPage enumGenerationPage;
        private GeneratorPages.InterfaceGenerationPage interfaceGenerationPage;
        private GeneratorPages.StructureGenerationPage structureGenerationPage;
        private System.Windows.Forms.TabPage Tp_Property;
        private GeneratorPages.PropertyGenerationPage propertyGenerationPage;
        private System.Windows.Forms.GroupBox Gb_MemberInformation;
        private System.Windows.Forms.PropertyGrid Pg_MemberType;
        private System.Windows.Forms.ComboBox Cb_GenerateMemberType;
        private System.Windows.Forms.Label L_MemberType;
        private System.Windows.Forms.TabPage Tp_Event;
        private System.Windows.Forms.TabPage Tp_Field;
        private System.Windows.Forms.TabPage Tp_Method;
        private GeneratorPages.EventGenerationPage eventGenerationPage;
        private GeneratorPages.FieldGenerationPage fieldGenerationPage;
        private GeneratorPages.MethodGenerationPage methodGenerationPage;
        private System.Windows.Forms.Button Btn_Copy;
        private System.Windows.Forms.PictureBox Pb_MemberTypeImage;
        private System.Windows.Forms.TabPage Tp_Inheritance;
        private System.Windows.Forms.TextBox Tb_Inheritance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Cb_Inherit;
    }
}
