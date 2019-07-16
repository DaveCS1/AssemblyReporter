#region License

// ********************************* Header *********************************\
// 
//    Class:  ParameterEditorControl.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AssemblyReport.Forms;
using AssemblyReport.Primitives;

#endregion

namespace AssemblyReport.UserControls
{
    /// <summary>The <see cref="ParameterEditorControl"/> user control.</summary>
    /// <seealso cref="System.Windows.Forms.UserControl"/>
    public partial class ParameterEditorControl : UserControl
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ParameterEditorControl"/> class.</summary>
        public ParameterEditorControl()
        {
            InitializeComponent();

            // Initialize default buttons states
            Tsmi_Remove.Enabled = false;
            Tsmi_Clear.Enabled = false;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the count.</summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return Lv_Parameters.Items.Count; }
        }

        /// <summary>Gets the items.</summary>
        /// <value>The items.</value>
        public List<ParamInfo> Items
        {
            get
            {
                var items = new List<ParamInfo>();

                // Loop thru each list item
                foreach (ListViewItem listItem in Lv_Parameters.Items)
                {
                    items.Add(new ParamInfo(listItem.Text, listItem.SubItems[1].Text));
                }

                return items;
            }
        }

        #endregion

        #region Methods

        /// <summary>Handles the Click event of the Tsmi_Add control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Tsmi_Add_Click(object sender, EventArgs e)
        {
            using (ParameterInformationDialog dialogDescriptionGenerator = new ParameterInformationDialog())
            {
                DialogResult dialogResult = dialogDescriptionGenerator.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    ParamInfo result = dialogDescriptionGenerator.ParameterInfo;

                    // Create list item
                    ListViewItem item = new ListViewItem(result.Name);
                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item, result.Description);
                    item.SubItems.Add(subItem);

                    // Add item to list
                    var found = false;

                    // Loop thru each item to validate it exists in list items
                    foreach (ListViewItem listItem in Lv_Parameters.Items)
                    {
                        if (listItem.Text.Equals(item.Text))
                        {
                            found = true;
                            break;
                        }
                    }

                    // Add item if not found to list
                    if (!found)
                    {
                        Lv_Parameters.Items.Add(item);

                        Tsmi_Remove.Enabled = true;
                        Tsmi_Clear.Enabled = true;
                    }
                }
            }
        }

        /// <summary>Handles the Click event of the Tsmi_Clear control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Tsmi_Clear_Click(object sender, EventArgs e)
        {
            Lv_Parameters.Items.Clear();
            Tsmi_Remove.Enabled = false;
            Tsmi_Clear.Enabled = false;
        }

        /// <summary>Handles the Click event of the Tsmi_Remove control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Tsmi_Remove_Click(object sender, EventArgs e)
        {
            if (Lv_Parameters.SelectedIndices.Count > 0)
            {
                Lv_Parameters.Items.RemoveAt(Lv_Parameters.SelectedIndices[0]);

                if (Count > 0)
                {
                    Tsmi_Remove.Enabled = true;
                    Tsmi_Clear.Enabled = true;
                }
                else
                {
                    Tsmi_Remove.Enabled = false;
                    Tsmi_Clear.Enabled = false;
                }
            }
        }

        #endregion
    }
}