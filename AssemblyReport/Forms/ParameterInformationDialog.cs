#region License

// ********************************* Header *********************************\
// 
//    Class:  ParameterInformationDialog.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Windows.Forms;
using AssemblyReport.Primitives;

#endregion

namespace AssemblyReport.Forms
{
    /// <summary>The <see cref="ParameterInformationDialog"/> dialog form.</summary>
    /// <seealso cref="System.Windows.Forms.Form"/>
    public partial class ParameterInformationDialog : Form
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ParameterInformationDialog"/> class.</summary>
        public ParameterInformationDialog()
        {
            InitializeComponent();

            // Initialize default buttons states
            Btn_OK.Enabled = false;
            Btn_Clear.Enabled = false;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the parameter information.</summary>
        /// <value>The parameter information.</value>
        public ParamInfo ParameterInfo { get; private set; }

        #endregion

        #region Methods

        /// <summary>Handles the Click event of the Btn_Cancel control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>Handles the Click event of the Btn_Clear control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Btn_Clear.Enabled = false;
            Btn_OK.Enabled = false;
            Tb_ParameterName.Text = string.Empty;
            Tb_ParameterDescription.Text = string.Empty;
        }

        /// <summary>Handles the Click event of the Btn_OK control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Btn_OK_Click(object sender, EventArgs e)
        {
            // Create parameter info item to return
            ParameterInfo = new ParamInfo(Tb_ParameterName.Text, Tb_ParameterDescription.Text);

            Btn_Clear.Enabled = false;
            Tb_ParameterName.Text = string.Empty;
            Tb_ParameterDescription.Text = string.Empty;
        }

        /// <summary>Handles the TextChanged event of the Parameter Boxes control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ParameterBoxes_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Tb_ParameterName.Text) && !string.IsNullOrEmpty(Tb_ParameterDescription.Text))
            {
                Btn_OK.Enabled = true;
                Btn_Clear.Enabled = true;
            }
            else
            {
                Btn_OK.Enabled = false;
                Btn_Clear.Enabled = false;
            }

            if (!string.IsNullOrEmpty(Tb_ParameterName.Text) || !string.IsNullOrEmpty(Tb_ParameterDescription.Text))
            {
                Btn_Clear.Enabled = true;
            }
            else
            {
                Btn_Clear.Enabled = false;
            }
        }

        #endregion
    }
}