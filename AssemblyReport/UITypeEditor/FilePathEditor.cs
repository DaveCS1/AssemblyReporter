#region License

// ********************************* Header *********************************\
// 
//    Class:  FilePathEditor.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#endregion

namespace AssemblyReport.UITypeEditor
{
    /// <summary>The <see cref="FilePathEditor"/> class.</summary>
    /// <seealso cref="BasePathEditor"/>
    public class FilePathEditor : BasePathEditor
    {
        #region Public Properties

        /// <summary>Gets the type of the editor.</summary>
        /// <value>The type of the editor.</value>
        public ArgumentsAttribute.PathEditorType EditorType { get; private set; }

        /// <summary>Gets the name of the file.</summary>
        /// <value>The name of the file.</value>
        public string FileName { get; private set; }

        /// <summary>Gets the file names.</summary>
        /// <value>The file names.</value>
        public List<string> FileNames { get; private set; }

        /// <summary>Gets the filter.</summary>
        /// <value>The filter.</value>
        public string Filter { get; private set; }

        /// <summary>Gets the initial directory.</summary>
        /// <value>The initial directory.</value>
        public string InitialDirectory { get; private set; }

        /// <summary>Gets the multi select.</summary>
        /// <value>The multi select.</value>
        public bool MultiSelect { get; private set; }

        /// <summary>Gets a value indicating whether [support multi dotted extensions].</summary>
        /// <value><c>true</c> if [support multi dotted extensions]; otherwise, <c>false</c>.</value>
        public bool SupportMultiDottedExtensions { get; private set; }

        /// <summary>Gets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information. </param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services. </param>
        /// <param name="value">The object to edit. </param>
        /// <returns>The new value of the object. If the value of the object has not changed, this should return the same object it was passed.</returns>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((context?.Instance == null) || (provider == null))
            {
                return base.EditValue(context, provider, value);
            }

            IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            if (editorService == null)
            {
                return base.EditValue(context, provider, value);
            }

            Location = Convert.ToString(value);
            DirectoryInfo = new DirectoryInfo(Location);
            RootFolder = DefaultRootFolder;

            EditorType = ArgumentsAttribute.PathEditorType.OpenDialog;
            FileNames = new List<string>();
            FileName = string.Empty;
            Filter = string.Empty;
            InitialDirectory = string.Empty;
            MultiSelect = false;
            SupportMultiDottedExtensions = false;
            Title = string.Empty;

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
                    EditorType = argumentsAttribute.EditorType;
                    InitialDirectory = argumentsAttribute.InitialDirectory;
                    FileNames = argumentsAttribute.FileNames;
                    FileName = argumentsAttribute.FileName;
                    Filter = argumentsAttribute.Filter;
                    MultiSelect = argumentsAttribute.MultiSelect;
                    SupportMultiDottedExtensions = argumentsAttribute.SupportMultiDottedExtensions;
                    Title = argumentsAttribute.Title;
                }
            }

            // Open the specified dialog.
            Location = PrepareDialog();

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

        /// <summary>Opens the file.</summary>
        /// <returns>The <see cref="string"/>.</returns>
        private string OpenFile()
        {
            string location;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                FileName = FileName,
                Filter = Filter,
                Title = Title,
                Multiselect = MultiSelect,
                SupportMultiDottedExtensions = SupportMultiDottedExtensions,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Handle multi select
                if (MultiSelect)
                {
                    FileNames = openFileDialog.FileNames.ToList();
                    FileName = FileNames.FirstOrDefault();
                    location = FileName;
                }
                else
                {
                    FileName = openFileDialog.FileName;
                    FileNames = new List<string> {FileName};
                    location = FileName;
                }
            }
            else
            {
                location = string.Empty;
            }

            return location;
        }

        /// <summary>Prepares the dialog.</summary>
        private string PrepareDialog()
        {
            string location;

            // Determine the dialog type to use.
            switch (EditorType)
            {
                case ArgumentsAttribute.PathEditorType.OpenDialog:
                {
                    location = OpenFile();
                    break;
                }
                case ArgumentsAttribute.PathEditorType.SaveDialog:
                {
                    location = SaveFile();
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            return location;
        }

        /// <summary>Saves the file.</summary>
        /// <returns>The <see cref="string"/>.</returns>
        private string SaveFile()
        {
            string location;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = FileName,
                Filter = Filter,
                Title = Title,
                SupportMultiDottedExtensions = SupportMultiDottedExtensions
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                location = saveFileDialog.FileName;
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
            #region Constants

            /// <summary>The all files filter.</summary>
            public const string AllFilesFilter = "All Files|*.*";

            /// <summary>The assembly files filter.</summary>
            public const string AssemblyFilesFilter = "Assembly Files|*.exe;*.dll|Executable|*.exe|Dynamic Link Libraries|*.dll";

            /// <summary>The executable files filter.</summary>
            public const string ExecutableFilesFilter = "All Supported Executables|*.bin;*.exe;*.scr|Executable File|*.exe|Binary Executable|*.bin|Screensaver Executable|*.scr";

            #endregion

            #region Constructors and Destructors

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="editorType">The editor type dialog to use.</param>
            /// <param name="filter">The file filter to use.</param>
            /// <param name="title">The title.</param>
            public ArgumentsAttribute(PathEditorType editorType, string filter, string title) : this(editorType, filter, title, "", false, true, "", "", DefaultRootFolder)
            {
            }

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="editorType">The editor type dialog to use.</param>
            /// <param name="filter">The file filter to use.</param>
            /// <param name="title">The title.</param>
            /// <param name="fileName">The file name to use.</param>
            public ArgumentsAttribute(PathEditorType editorType, string filter, string title, string fileName) : this(editorType, filter, title, fileName, false, true, "", "", DefaultRootFolder)
            {
            }

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="editorType">The editor type dialog to use.</param>
            /// <param name="filter">The file filter to use.</param>
            /// <param name="title">The title.</param>
            /// <param name="fileName">The file name to use.</param>
            /// <param name="location">The default location path.</param>
            /// <param name="rootFolder">The root folder.</param>
            public ArgumentsAttribute(PathEditorType editorType, string filter, string title, string fileName, string location, Environment.SpecialFolder rootFolder) : this(editorType, filter, title, fileName, false, location, rootFolder)
            {
            }

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="editorType">The editor type dialog to use.</param>
            /// <param name="filter">The file filter to use.</param>
            /// <param name="title">The title.</param>
            /// <param name="fileName">The file name to use.</param>
            /// <param name="multiSelect">The multi select toggle.</param>
            /// <param name="location">The default location path.</param>
            /// <param name="rootFolder">The root folder.</param>
            public ArgumentsAttribute(PathEditorType editorType, string filter, string title, string fileName, bool multiSelect, string location, Environment.SpecialFolder rootFolder) : this(editorType, filter, title, fileName, multiSelect, true, location, rootFolder)
            {
            }

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="editorType">The editor type dialog to use.</param>
            /// <param name="filter">The file filter to use.</param>
            /// <param name="title">The title.</param>
            /// <param name="fileName">The file name to use.</param>
            /// <param name="multiSelect">The multi select toggle.</param>
            /// <param name="supportMultiDottedExtensions">Support multi dotted extensions toggle.</param>
            /// <param name="location">The default location path.</param>
            /// <param name="rootFolder">The root folder.</param>
            public ArgumentsAttribute(PathEditorType editorType, string filter, string title, string fileName, bool multiSelect, bool supportMultiDottedExtensions, string location, Environment.SpecialFolder rootFolder) : this(editorType, filter, title, fileName, multiSelect, supportMultiDottedExtensions, "", location, rootFolder)
            {
            }

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="editorType">The editor type dialog to use.</param>
            /// <param name="filter">The file filter to use.</param>
            /// <param name="title">The title.</param>
            /// <param name="fileName">The file name to use.</param>
            /// <param name="multiSelect">The multi select toggle.</param>
            /// <param name="supportMultiDottedExtensions">Support multi dotted extensions toggle.</param>
            /// <param name="initialDirectory">The initial directory.</param>
            /// <param name="location">The default location path.</param>
            /// <param name="rootFolder">The root folder.</param>
            public ArgumentsAttribute(PathEditorType editorType, string filter, string title, string fileName, bool multiSelect, bool supportMultiDottedExtensions, string initialDirectory, string location, Environment.SpecialFolder rootFolder) : base(location, rootFolder)
            {
                EditorType = editorType;
                FileName = fileName;
                FileNames = new List<string> {fileName};
                Filter = filter;
                Title = title;

                if (!string.IsNullOrEmpty(initialDirectory))
                {
                    InitialDirectory = initialDirectory;
                }
                else
                {
                    InitialDirectory = Environment.GetFolderPath(DefaultRootFolder);
                }

                MultiSelect = multiSelect;
                SupportMultiDottedExtensions = supportMultiDottedExtensions;
            }

            #endregion

            #region Enums

            /// <summary>The <see cref="PathEditorType"/> enum.</summary>
            public enum PathEditorType
            {
                /// <summary>The open dialog.</summary>
                OpenDialog = 0,

                /// <summary>The save dialog.</summary>
                SaveDialog = 1
            }

            #endregion

            #region Public Properties

            /// <summary>Gets the type of the editor.</summary>
            /// <value>The type of the editor.</value>
            public PathEditorType EditorType { get; private set; }

            /// <summary>Gets the name of the file.</summary>
            /// <value>The name of the file.</value>
            public string FileName { get; private set; }

            /// <summary>Gets the file names.</summary>
            /// <value>The file names.</value>
            public List<string> FileNames { get; private set; }

            /// <summary>Gets the filter.</summary>
            /// <value>The filter.</value>
            public string Filter { get; private set; }

            /// <summary>Gets the initial directory.</summary>
            /// <value>The initial directory.</value>
            public string InitialDirectory { get; private set; }

            /// <summary>Gets the multi select.</summary>
            /// <value>The multi select.</value>
            public bool MultiSelect { get; private set; }

            /// <summary>Gets a value indicating whether multi dotted extensions support.</summary>
            /// <value>The toggle for multi dotted extensions support.</value>
            public bool SupportMultiDottedExtensions { get; private set; }

            /// <summary>Gets the title.</summary>
            /// <value>The title.</value>
            public string Title { get; private set; }

            #endregion
        }
    }
}