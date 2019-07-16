#region License

// ********************************* Header *********************************\
// 
//    Class:  PropertyGenerationPage.cs
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
    /// <summary>The <see cref="PropertyGenerationPage"/> user control.</summary>
    /// <seealso cref="System.Windows.Forms.UserControl"/>
    public partial class PropertyGenerationPage : UserControl
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="PropertyGenerationPage"/> class.</summary>
        public PropertyGenerationPage()
        {
            InitializeComponent();

            // Initialize variables
            Rb_PropertyBoth.Checked = true;
            Rb_PropertyGet.Checked = false;
            Rb_PropertySet.Checked = false;

            ReadSettings();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets a value indicating whether this <see cref="PropertyGenerationPage"/> is get.</summary>
        /// <value><c>true</c> if get; otherwise, <c>false</c>.</value>
        public bool Get { get; private set; }

        /// <summary>Gets a value indicating whether this <see cref="PropertyGenerationPage"/> is set.</summary>
        /// <value><c>true</c> if set; otherwise, <c>false</c>.</value>
        public bool Set { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Reads the page settings.</summary>
        public void ReadSettings()
        {
            // Process the radio buttons options
            if (Rb_PropertyBoth.Checked)
            {
                Get = true;
                Set = true;
            }
            else if (Rb_PropertyGet.Checked)
            {
                Get = true;
                Set = false;
            }
            else if (Rb_PropertySet.Checked)
            {
                Get = false;
                Set = true;
            }
        }

        #endregion

        #region Methods

        /// <summary>Handles the CheckedChanged event of the Rb_PropertySet control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Rb_PropertySet_CheckedChanged(object sender, EventArgs e)
        {
            ReadSettings();
        }

        #endregion
    }
}