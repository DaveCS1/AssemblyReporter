#region License

// ********************************* Header *********************************\
// 
//    Class:  DirectoryPathEditor.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#endregion

namespace AssemblyReport.UITypeEditor
{
    /// <summary>The <see cref="DirectoryPathEditor"/> class.</summary>
    /// <seealso cref="BasePathEditor"/>
    public class DirectoryPathEditor : BasePathEditor
    {
        #region Public Properties

        /// <summary>Gets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; private set; }

        /// <summary>Gets a value indicating whether [show new folder button].</summary>
        /// <value><c>true</c> if [show new folder button]; otherwise, <c>false</c>.</value>
        public bool ShowNewFolderButton { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information. </param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services. </param>
        /// <param name="value">The object to edit. </param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context == null) || (provider == null))
            {
                return base.EditValue(context, provider, value);
            }

            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (editorService == null)
            {
                return base.EditValue(context, provider, value);
            }

            Location = Convert.ToString(value);
            DirectoryInfo = Directory.GetParent(Location);
            RootFolder = DefaultRootFolder;

            Description = string.Empty;
            ShowNewFolderButton = false;

            // Validate the custom attributes.
            if (context.PropertyDescriptor != null)
            {
                // Get all the arguments of the specific type to a list.
                var argumentsAttributes = context.PropertyDescriptor.Attributes.OfType<ArgumentsAttribute>().ToList();

                // Handle when the arguments list contains items.
                if (argumentsAttributes.Any())
                {
                    // Get the first argument in the list index.
                    ArgumentsAttribute argumentsAttribute = argumentsAttributes.First();

                    // Initialize new values
                    Location = argumentsAttribute.Location;
                    DirectoryInfo = Directory.GetParent(Location);
                    RootFolder = argumentsAttribute.RootFolder;

                    // Pass variables to properties
                    Description = argumentsAttribute.Description;
                    ShowNewFolderButton = argumentsAttribute.ShowNewFolderButton;
                }
            }

            // Open the specified directory / folder browser dialog.
            Location = OpenFolderBrowserDialog();

            // Validate the file path.
            if (!string.IsNullOrEmpty(Location))
            {
                return Location;
            }
            else
            {
                return base.EditValue(context, provider, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>Displays the folder browser dialog.</summary>
        private string OpenFolderBrowserDialog()
        {
            string location;

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = Description,
                RootFolder = RootFolder,
                ShowNewFolderButton = ShowNewFolderButton
                // SelectedPath = Location
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                location = folderBrowserDialog.SelectedPath;
            }
            else
            {
                location = string.Empty;
            }

            return location;
        }

        #endregion

        /// <summary>The <see cref="ArgumentsAttribute"/> attribute class.</summary>
        /// <seealso cref="Attribute"/>
        public new class ArgumentsAttribute : BasePathEditor.ArgumentsAttribute
        {
            #region Constructors and Destructors

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="description">The description.</param>
            public ArgumentsAttribute(string description) : this(description, true, "", DefaultRootFolder)
            {
            }

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="description">The description.</param>
            /// <param name="location">The default location path.</param>
            /// <param name="rootFolder">The root folder.</param>
            public ArgumentsAttribute(string description, string location, Environment.SpecialFolder rootFolder) : this(description, true, location, rootFolder)
            {
            }

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="description">The description.</param>
            /// <param name="showNewFolderButton">The show new folder button.</param>
            /// <param name="location">The default location path.</param>
            /// <param name="rootFolder">The root folder.</param>
            public ArgumentsAttribute(string description, bool showNewFolderButton, string location, Environment.SpecialFolder rootFolder) : base(location, rootFolder)
            {
                Description = description;
                ShowNewFolderButton = showNewFolderButton;
            }

            #endregion

            #region Public Properties

            /// <summary>Gets the description.</summary>
            /// <value>The description.</value>
            public string Description { get; private set; }

            /// <summary>Gets a value indicating whether [show new folder button].</summary>
            /// <value><c>true</c> if [show new folder button]; otherwise, <c>false</c>.</value>
            public bool ShowNewFolderButton { get; private set; }

            #endregion
        }
    }
}