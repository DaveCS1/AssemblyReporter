#region License

// ********************************* Header *********************************\
// 
//    Class:  AssemblyPropertiesInfo.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>Exposes instance methods for creating, moving, and enumerating through directories and subdirectories. This class cannot be inherited.</summary>
    [ComVisible(true)]
    [DebuggerDisplay("Root Name = {RootName}, Location = {Location}")]
    [RefreshProperties(RefreshProperties.All)]
    [Serializable]
    public class AssemblyPropertiesInfo : INotifyPropertyChanged, IDisposable
    {
        #region Constants

        /// <summary>The empty text field.</summary>
        public const string EmptyTextField = @"...";

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="AssemblyPropertiesInfo"/> class.</summary>
        /// <param name="assemblyPath">The assembly file path.</param>
        public AssemblyPropertiesInfo(string assemblyPath) : this()
        {
            if (string.IsNullOrEmpty(assemblyPath))
            {
                throw new ArgumentNullException(nameof(assemblyPath), @"The file name cannot be null or empty.");
            }

            if (!File.Exists(assemblyPath))
            {
                throw new FileNotFoundException(@"The assembly file name cannot be found!", assemblyPath);
            }

            if (!AsmUtil.IsAssembly(assemblyPath))
            {
                throw new ArgumentNullException(nameof(assemblyPath), @"The file name is not an assembly file (*.DLL;*.EXE).");
            }

            Location = assemblyPath;
            AssemblyDirectory = new DirectoryInfo(Path.GetDirectoryName(assemblyPath));

            if (File.Exists(assemblyPath))
            {
                // Update the assembly file version information.
                FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assemblyPath);
                ProductName = fileVersionInfo.ProductName;
                FileDescription = fileVersionInfo.FileDescription;
                CompanyName = fileVersionInfo.CompanyName;
                LegalCopyright = fileVersionInfo.LegalCopyright;
                LegalTrademarks = fileVersionInfo.LegalTrademarks;
                OriginalFileName = fileVersionInfo.OriginalFilename;
                ProductVersion = fileVersionInfo.ProductVersion;
                FileVersion = fileVersionInfo.FileVersion;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="AssemblyPropertiesInfo"/> class.</summary>
        public AssemblyPropertiesInfo()
        {
            AssemblyDirectory = default;
            Location = EmptyTextField;

            // Load properties
            ProductName = EmptyTextField;
            FileDescription = EmptyTextField;
            CompanyName = EmptyTextField;
            LegalCopyright = EmptyTextField;
            LegalTrademarks = EmptyTextField;
            OriginalFileName = EmptyTextField;
            ProductVersion = new Version(1, 0, 0, 0).ToString();
            FileVersion = new Version(1, 0, 0, 0).ToString();
        }

        #endregion

        #region Public Events

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>Gets the directory.</summary>
        /// <value>The directory.</value>
        [Browsable(false)]
        public DirectoryInfo AssemblyDirectory { get; }

        /// <summary>Gets the name of the company.</summary>
        /// <value>The name of the company.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Company")]
        public string CompanyName { get; }

        /// <summary>Gets a value indicating whether the file or directory exists.</summary>
        /// <returns><see langword="true"/> if the file or directory exists; otherwise, <see langword="false"/>.</returns>
        [Browsable(false)]
        public bool Exists
        {
            get
            {
                if (!string.IsNullOrEmpty(Location))
                {
                    return File.Exists(Location);
                }

                return false;
            }
        }

        /// <summary>Gets the file description.</summary>
        /// <value>The file description.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Description")]
        public string FileDescription { get; }

        /// <summary>For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the <see langword="Name"/> property gets the name of the directory.</summary>
        /// <returns>A string that is the name of the parent directory, the name of the last directory in the hierarchy, or the name of a file, including the file name extension.</returns>
        [Category(CategoryConstants.Assembly)]
        [DisplayName("File Name")]
        public string FileName
        {
            get
            {
                if (!string.IsNullOrEmpty(Location))
                {
                    return Path.GetFileName(Location);
                }

                return EmptyTextField;
            }
        }

        /// <summary>Gets the size of the file.</summary>
        /// <value>The size of the file.</value>
        [Category(CategoryConstants.Assembly)]
        [DisplayName("File Size")]
        public string FileSize
        {
            get
            {
                if (!File.Exists(Location))
                {
                    return @"0 B";
                }
                else
                {
                    return CalculateSize(Location);
                }
            }
        }

        /// <summary>Gets the file version.</summary>
        /// <value>The file version.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("File Version")]
        public string FileVersion { get; }

        /// <summary>Gets the icon.</summary>
        /// <value>The icon.</value>
        [Browsable(false)]
        public Image Icon
        {
            get
            {
                if (!string.IsNullOrEmpty(Location))
                {
                    Bitmap iconBitmap = null;
                    IconExtractor extractor = new IconExtractor(Location);

                    if (extractor.Default != null)
                    {
                        iconBitmap = extractor.Default.ToBitmap();
                    }

                    return iconBitmap;
                }

                return null;
            }
        }

        /// <summary>Gets a value indicating whether this instance is assembly.</summary>
        /// <value><c>true</c> if this instance is assembly; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsAssembly
        {
            get
            {
                if (!string.IsNullOrEmpty(Location))
                {
                    return AsmUtil.IsAssembly(Location);
                }

                return false;
            }
        }

        /// <summary>Gets the legal copyright.</summary>
        /// <value>The legal copyright.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Copyright")]
        public string LegalCopyright { get; }

        /// <summary>Gets the legal trademarks.</summary>
        /// <value>The legal trademarks.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Trademarks")]
        public string LegalTrademarks { get; }

        /// <summary>Gets or sets the assembly location.</summary>
        /// <value>The assembly location.</value>
        [Category(CategoryConstants.Assembly)]
        [DisplayName("Location")]
        public string Location { get; }

        /// <summary>Gets the name of the assembly.</summary>
        /// <value>The name of the assembly.</value>
        [Category(CategoryConstants.Assembly)]
        [DisplayName("Name")]
        public string Name
        {
            get
            {
                if (File.Exists(Location))
                {
                    return Path.GetFileNameWithoutExtension(Location);
                }
                else
                {
                    return EmptyTextField;
                }
            }
        }

        /// <summary>Gets the name of the original file.</summary>
        /// <value>The name of the original file.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Original File Name")]
        public string OriginalFileName { get; }

        /// <summary>Gets the name of the product.</summary>
        /// <value>The name of the product.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Product Title")]
        public string ProductName { get; }

        /// <summary>Gets the product version.</summary>
        /// <value>The product version.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Product Version")]
        public string ProductVersion { get; }

        /// <summary>Gets the name of the root.</summary>
        /// <value>The name of the root.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Root Namespace")]
        public string RootName
        {
            get
            {
                if (!string.IsNullOrEmpty(Location) && File.Exists(Location))
                {
                    return TypesUtil.DefaultNamespace(Location);
                }

                return EmptyTextField;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
        }

        #endregion

        #region Methods

        /// <summary>Called when [property changed].</summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>Calculates the size.</summary>
        /// <param name="location">The location.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string CalculateSize(string location)
        {
            string[] sizes = {"B", "KB", "MB", "GB", "TB"};
            double length = new FileInfo(Location).Length;

            var order = 0;
            const int lengthModifier = 1024;

            while ((length >= lengthModifier) && (order < sizes.Length - 1))
            {
                order++;
                length = length / lengthModifier;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would show a single decimal place, and no space.
            return $"{length:0.##} {sizes[order]}";
        }

        #endregion
    }
}