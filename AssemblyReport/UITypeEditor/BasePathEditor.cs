#region License

// ********************************* Header *********************************\
// 
//    Class:  BasePathEditor.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Windows.Forms.Design;

#endregion

namespace AssemblyReport.UITypeEditor
{
    /// <summary>The <see cref="BasePathEditor"/> class.</summary>
    /// <seealso cref="System.Drawing.Design.UITypeEditor"/>
    public abstract class BasePathEditor : System.Drawing.Design.UITypeEditor
    {
        #region Constants

        /// <summary>The default root folder.</summary>
        public const Environment.SpecialFolder DefaultRootFolder = Environment.SpecialFolder.Desktop;

        #endregion

        #region Public Properties

        /// <summary>Gets the directory information.</summary>
        /// <value>The directory information.</value>
        public DirectoryInfo DirectoryInfo { get; internal set; }

        /// <summary>Gets the location.</summary>
        /// <value>The location.</value>
        public string Location { get; internal set; }

        /// <summary>Gets the root folder.</summary>
        /// <value>The root folder.</value>
        public Environment.SpecialFolder RootFolder { get; internal set; }

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
                }
            }

            // Open the specified directory / folder browser dialog.
            Location = Convert.ToString(value);

            //  Console.WriteLine(@"Directory Path Editor - REACHED: " + Location);

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

        /// <summary>Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information. </param>
        /// <returns>
        ///     A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"/> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"/> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> will return
        ///     <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"/>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        #endregion

        /// <summary>The <see cref="ArgumentsAttribute"/> attribute class.</summary>
        /// <seealso cref="Attribute"/>
        public abstract class ArgumentsAttribute : Attribute
        {
            #region Constructors and Destructors

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="location">The default location path.</param>
            protected ArgumentsAttribute(string location) : this(location, DefaultRootFolder)
            {
            }

            /// <summary>Initializes a new instance of the <see cref="ArgumentsAttribute"/> class.</summary>
            /// <param name="location">The default location path.</param>
            /// <param name="rootFolder">The root folder.</param>
            protected ArgumentsAttribute(string location, Environment.SpecialFolder rootFolder)
            {
                if (!string.IsNullOrEmpty(location))
                {
                    Location = location;
                }
                else
                {
                    Location = Environment.GetFolderPath(DefaultRootFolder);
                }

                RootFolder = rootFolder;
            }

            #endregion

            #region Public Properties

            /// <summary>Gets the location.</summary>
            /// <value>The location.</value>
            public string Location { get; private set; }

            /// <summary>Gets the root folder.</summary>
            /// <value>The root folder.</value>
            public Environment.SpecialFolder RootFolder { get; private set; }

            #endregion
        }
    }
}