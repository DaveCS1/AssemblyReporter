#region License

// ********************************* Header *********************************\
// 
//    Class:  DescriptionGeneratorControl.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.ComponentModel;
using System.Windows.Forms;
using AssemblyReport.Enumerators;
using AssemblyReport.Primitives;
using AssemblyReport.Primitives.AssemblyScope;
using AssemblyReport.Primitives.DescriptionGenerator;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.UserControls
{
    /// <summary>The <see cref="DescriptionGeneratorControl"/> user control.</summary>
    /// <seealso cref="System.Windows.Forms.UserControl"/>
    public partial class DescriptionGeneratorControl : UserControl
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="DescriptionGeneratorControl"/> class.</summary>
        public DescriptionGeneratorControl()
        {
            InitializeComponent();

            // Initialize variables
            Btn_Copy.Enabled = false;
            Btn_Generate.Enabled = false;
            Tb_Inheritance.Enabled = false;
            Cb_Inherit.Checked = true;
            Cb_GenerateMemberType.DataSource = Enum.GetNames(typeof(MemberInfoTypes));
            AssemblyScope = new AssemblyScope(string.Empty, string.Empty, string.Empty);
            GeneratorDescriptor = new GeneratorDescriptor(string.Empty, typeof(string).Name.ToLower());
            RefreshPropertyGrid(AssemblyScope);
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the assembly scope.</summary>
        /// <value>The assembly scope.</value>
        public AssemblyScope AssemblyScope { get; private set; }

        /// <summary>Gets the generated result.</summary>
        /// <value>The generated result.</value>
        public string GeneratedResult
        {
            get { return Rtb_Output.Text; }
        }

        /// <summary>Gets the generator descriptor.</summary>
        /// <value>The generator descriptor.</value>
        [Browsable(false)]
        public GeneratorDescriptor GeneratorDescriptor { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Analyzes the specified assembly scope.</summary>
        /// <param name="assemblyScope">The assembly scope.</param>
        public void Analyze(AssemblyScope assemblyScope)
        {
            // Passes in a scoped path of the assembly to parse. Can be used to automate and fill the default
            // text fields and settings with some preset data from the node.
            AssemblyScope = assemblyScope;

            // Set the selected member category
            Cb_GenerateMemberType.Text = assemblyScope.MemberType.ToString();

            // Refresh the property grid items
            RefreshPropertyGrid(assemblyScope);

            // Try to generate a basic summary when a type name is available for use
            if (!string.IsNullOrEmpty(GeneratorDescriptor.Name))
            {
                Btn_Generate.Enabled = true;
                Generate();
            }
        }

        /// <summary>Refreshes the property grid.</summary>
        /// <param name="assemblyScope">The assembly scope.</param>
        public void RefreshPropertyGrid(AssemblyScope assemblyScope)
        {
            // Set the generate with some new data
            GeneratorDescriptor = new GeneratorDescriptor(assemblyScope.Name);

            // Update the property grid item values
            Pg_MemberType.SelectedObject = GeneratorDescriptor;
        }

        #endregion

        #region Methods

        /// <summary>Handles the Click event of the Btn_Copy control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Btn_Copy_Click(object sender, EventArgs e)
        {
            // Create a copy of the description summary to the clipboard overriding whatever was in there before.
            Clipboard.SetText(Rtb_Output.Text, TextDataFormat.Text);
        }

        /// <summary>Handles the Click event of the Btn_Generate control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Btn_Generate_Click(object sender, EventArgs e)
        {
            Generate();
        }

        /// <summary>Occurs when the member type combo box selection index has been changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        private void Cb_GenerateMemberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = Cb_GenerateMemberType.SelectedValue.ToString();

            // Resolve member type image selection
            Pb_MemberTypeImage.Image = ImageUtil.ResolveMemberTypeImage((MemberInfoTypes)Enum.Parse(typeof(MemberInfoTypes), selectedText));

            try
            {
                Tc_MemberTypeNavigation.SelectTab("Tp_" + selectedText);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        /// <summary>Handles the CheckedChanged event of the Cb_Inherit control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Cb_Inherit_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb_Inherit.Checked)
            {
                Tb_Inheritance.Enabled = true;
            }
            else
            {
                Tb_Inheritance.Enabled = false;
            }
        }

        /// <summary>Handles the Load event of the DescriptionGeneratorControl control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DescriptionGeneratorControl_Load(object sender, EventArgs e)
        {
            // Try to generate a basic summary when a type name is available for use
            if (!string.IsNullOrEmpty(GeneratorDescriptor.Name))
            {
                Btn_Generate.PerformClick();
            }
        }

        /// <summary>Generates this instance.</summary>
        private void Generate()
        {
            string generatedText;

            string memberInfoTypeName = Cb_GenerateMemberType.SelectedItem.ToString();

            MemberInfoTypes memberInfoTypes = (MemberInfoTypes)Enum.Parse(typeof(MemberInfoTypes), memberInfoTypeName);

            string cref = DescriptionGeneratorBase.GenerateCodeReference($@"{GeneratorDescriptor.Name}", DescriptionGeneratorBase.CodeReferenceTypes.See);

            var parametersList = parameterInfoEditorDialog.Items;

            // Handle the generation provider methods to use
            switch (memberInfoTypes)
            {
                case MemberInfoTypes.Class:
                {
                    // Handles the class or constructor description generation
                    if (classGenerationPage.IsConstructor)
                    {
                        generatedText = DescriptionGeneratorBase.GenerateConstructor(GeneratorDescriptor.Name, classGenerationPage.IsPrivate, parametersList, GeneratorDescriptor.Remarks);
                    }
                    else
                    {
                        generatedText = DescriptionGeneratorBase.GenerateSummary($@"The {cref} class.", GeneratorDescriptor.Remarks);
                    }

                    if (Cb_Inherit.Checked)
                    {
                        string inheritText = DescriptionGeneratorBase.GenerateCodeReference(Tb_Inheritance.Text, DescriptionGeneratorBase.CodeReferenceTypes.SeeAlso);
                        generatedText += string.Format("{0}{1} {2}", Environment.NewLine, DescriptionGeneratorBase.CommentDocumentation, inheritText);
                    }

                    break;
                }
                case MemberInfoTypes.Event:
                {
                    generatedText = DescriptionGeneratorBase.GenerateEvent(GeneratorDescriptor.Name, parametersList, GeneratorDescriptor.Remarks);
                    break;
                }
                case MemberInfoTypes.Field:
                {
                    generatedText = DescriptionGeneratorBase.GenerateSummary($@"The {cref}.", GeneratorDescriptor.Remarks);
                    break;
                }
                case MemberInfoTypes.Method:
                {
                    generatedText = DescriptionGeneratorBase.GenerateMethod(GeneratorDescriptor.Name, GeneratorDescriptor.ReturnTypeName, parametersList, GeneratorDescriptor.Remarks);
                    break;
                }
                case MemberInfoTypes.Property:
                {
                    generatedText = DescriptionGeneratorBase.GenerateProperty(GeneratorDescriptor.Name, GeneratorDescriptor.ReturnTypeName, propertyGenerationPage.Get, propertyGenerationPage.Set, GeneratorDescriptor.Remarks);
                    break;
                }
                case MemberInfoTypes.Delegate:
                {
                    generatedText = DescriptionGeneratorBase.GenerateDelegate(GeneratorDescriptor.Name, GeneratorDescriptor.Remarks);
                    break;
                }
                case MemberInfoTypes.Enumerator:
                {
                    generatedText = DescriptionGeneratorBase.GenerateSummary($@"The {cref} enumerator.");
                    break;
                }
                case MemberInfoTypes.Structure:
                {
                    generatedText = DescriptionGeneratorBase.GenerateSummary($@"The {cref} structure.");

                    if (Cb_Inherit.Checked)
                    {
                        string inheritText = DescriptionGeneratorBase.GenerateCodeReference(Tb_Inheritance.Text, DescriptionGeneratorBase.CodeReferenceTypes.SeeAlso);
                        generatedText += Environment.NewLine + inheritText;
                    }

                    break;
                }
                case MemberInfoTypes.Interface:
                {
                    generatedText = DescriptionGeneratorBase.GenerateSummary($@"The {cref} interface.");

                    if (Cb_Inherit.Checked)
                    {
                        string inheritText = DescriptionGeneratorBase.GenerateCodeReference(Tb_Inheritance.Text, DescriptionGeneratorBase.CodeReferenceTypes.SeeAlso);
                        generatedText += Environment.NewLine + inheritText;
                    }

                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            Rtb_Output.Text = generatedText;
            Btn_Copy.Enabled = true;
        }

        /// <summary>Handles the PropertyValueChanged event of the Pg_MemberType control.</summary>
        /// <param name="s">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyValueChangedEventArgs"/> instance containing the event data.</param>
        private void Pg_MemberType_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            GeneratorDescriptor = (GeneratorDescriptor)((PropertyGrid)s).SelectedObject;

            if (!string.IsNullOrEmpty(GeneratorDescriptor.Name))
            {
                Btn_Generate.Enabled = true;
            }
            else
            {
                Btn_Generate.Enabled = false;
            }
        }

        #endregion
    }
}