#region License

// ********************************* Header *********************************\
// 
//    Class:  ClassGenerationPage.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Windows.Forms;

#endregion

namespace AssemblyReport.UserControls.GeneratorPages
{
    /// <summary>The <see cref="ClassGenerationPage"/> user control.</summary>
    /// <seealso cref="System.Windows.Forms.UserControl"/>
    public partial class ClassGenerationPage : UserControl
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ClassGenerationPage"/> class.</summary>
        public ClassGenerationPage()
        {
            InitializeComponent();

            Cb_IsConstructor.Enabled = true;
            Cb_IsConstructor.Checked = false;
            Cb_IsPrivate.Enabled = false;
            Cb_IsPrivate.Checked = false;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets a value indicating whether this instance is constructor.</summary>
        /// <value><c>true</c> if this instance is constructor; otherwise, <c>false</c>.</value>
        public bool IsConstructor
        {
            get { return Cb_IsConstructor.Checked; }
        }

        /// <summary>Gets a value indicating whether this instance is private.</summary>
        /// <value><c>true</c> if this instance is private; otherwise, <c>false</c>.</value>
        public bool IsPrivate
        {
            get { return Cb_IsPrivate.Checked; }
        }

        #endregion

        #region Methods

        /// <summary>Handles the CheckedChanged event of the Cb_IsConstructor control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Cb_IsConstructor_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb_IsConstructor.Checked)
            {
                Cb_IsPrivate.Enabled = true;
            }
            else
            {
                Cb_IsPrivate.Enabled = false;
            }
        }

        #endregion
    }
}