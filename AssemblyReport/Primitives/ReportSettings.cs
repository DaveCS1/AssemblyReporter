#region License

// ********************************* Header *********************************\
// 
//    Class:  ReportSettings.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using AssemblyReport.Extensibility;
using AssemblyReport.UITypeEditor;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="ReportSettings"/> class.</summary>
    [RefreshProperties(RefreshProperties.All)]
    public class ReportSettings : INotifyPropertyChanged, IDisposable
    {
        #region Constants

        /// <summary>The default images folder name.</summary>
        private const string DefaultImagesFolderName = @"Images";

        #endregion

        #region Fields

        private string buildOutputPath;
        private string documentationPath;
        private bool fileRepositoryIsUrl;
        private string imageRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ReportSettings"/> class.</summary>
        /// <param name="assemblyProperties">The assembly properties.</param>
        /// <param name="hierarchy">The assembly hierarchy.</param>
        /// <exception cref="ArgumentNullException">location - The assembly location cannot be null or empty.</exception>
        public ReportSettings(AssemblyPropertiesInfo assemblyProperties, HierarchyTree hierarchy) : this()
        {
            // Initialize
            AssemblyPropertiesInfo = assemblyProperties;
            Hierarchy = hierarchy;

            if (File.Exists(AssemblyPropertiesInfo.Location))
            {
                // Input parameter options
                string compilerDocumentationPath = Path.ChangeExtension(AssemblyPropertiesInfo.Location, Constants.XMLFileExtension);
                string buildPath = Path.ChangeExtension(AssemblyPropertiesInfo.Location, Constants.MarkdownFileExtension);
                string imageDirectoryPath = new DirectoryInfo(Path.Combine(AssemblyPropertiesInfo.AssemblyDirectory.FullName, DefaultImagesFolderName)).FullName;

                // Input parameter options
                documentationPath = compilerDocumentationPath;
                buildOutputPath = buildPath;
                imageRepository = imageDirectoryPath;

                ScanMissingDocumentation();
            }

            MissingDescription = ReadMissingDescriptions();
        }

        /// <summary>Initializes a new instance of the <see cref="ReportSettings"/> class.</summary>
        public ReportSettings()
        {
            fileRepositoryIsUrl = false;

            // Count the amount of missing summary documentations for the exported types
            MissingDocumentation = new List<Type>();
            MissingDescription = Convert.ToString(0);

            // Input parameter options
            string defaultFileName = Path.GetFileName(Assembly.GetCallingAssembly().Location);
            string defaultLocation = Environment.CurrentDirectory;
            string defaultFilePath = Path.Combine(defaultLocation, defaultFileName);

            // Set default text
            documentationPath = Path.ChangeExtension(defaultFilePath, Constants.XMLFileExtension);
            buildOutputPath = Path.ChangeExtension(defaultFilePath, Constants.MarkdownFileExtension);
            imageRepository = Path.Combine(defaultLocation, DefaultImagesFolderName);
        }

        #endregion

        #region Public Events

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>Gets the assembly properties information.</summary>
        /// <value>The assembly properties information.</value>
        [Browsable(false)]
        public AssemblyPropertiesInfo AssemblyPropertiesInfo { get; }

        /// <summary>Gets or sets the build path.</summary>
        /// <value>The build path.</value>
        [Category(CategoryConstants.Settings)]
        [DisplayName("Build Path")]
        [Editor(typeof(FilePathEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [FilePathEditor.ArgumentsAttribute(FilePathEditor.ArgumentsAttribute.PathEditorType.SaveDialog, @"Markdown Document|*.md", @"The Assembly report save location...")]
        [RefreshProperties(RefreshProperties.All)]
        public string BuildPath
        {
            get
            {
                if (string.IsNullOrEmpty(buildOutputPath))
                {
                    return string.Empty;
                }
                else
                {
                    return buildOutputPath;
                }
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                if (value.Equals(buildOutputPath))
                {
                    return;
                }

                buildOutputPath = value;
                OnPropertyChanged(nameof(BuildPath));
            }
        }

        /// <summary>Gets or sets the compiler documentation path.</summary>
        /// <value>The compiler documentation path.</value>
        [Browsable(true)]
        [Category(CategoryConstants.Settings)]
        [DisplayName("Compiler Documentation Path")]
        [Editor(typeof(FilePathEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [FilePathEditor.ArgumentsAttribute(FilePathEditor.ArgumentsAttribute.PathEditorType.OpenDialog, @"XML Documentation|*.xml", @"Browse for the Assembly Compiler Documentation...")]
        [RefreshProperties(RefreshProperties.All)]
        public string CompilerDocumentationPath
        {
            get
            {
                if (string.IsNullOrEmpty(documentationPath))
                {
                    return string.Empty;
                }
                else
                {
                    return documentationPath;
                }
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                if (value.Equals(documentationPath))
                {
                    return;
                }

                if (File.Exists(value))
                {
                    documentationPath = value;
                    OnPropertyChanged(nameof(CompilerDocumentationPath));
                }
            }
        }

        /// <summary>Gets the exported list.</summary>
        /// <value>The exported list.</value>
        [Browsable(false)]
        public List<Type> ExportedList
        {
            get
            {
                if ((Hierarchy != null) && !Hierarchy.IsEmpty)
                {
                    return Hierarchy.ExportedTypes;
                }

                return new List<Type>();
            }
        }

        /// <summary>Gets the exported types.</summary>
        /// <value>The exported types.</value>
        [Category(CategoryConstants.Statistics)]
        [DisplayName("Exported Types")]
        [ReadOnly(true)]
        public int ExportedTypes
        {
            get
            {
                if (ExportedList != null)
                {
                    return ExportedList.Count;
                }

                return 0;
            }
        }

        /// <summary>Gets or sets a value indicating whether [file repository is URL].</summary>
        /// <value><c>true</c> if [file repository is URL]; otherwise, <c>false</c>.</value>
        [Category(CategoryConstants.Type)]
        [DisplayName("File Repository is URL")]
        [RefreshProperties(RefreshProperties.All)]
        public bool FileRepositoryIsUrl
        {
            get
            {
                OnPropertyChanged(nameof(FileRepositoryIsUrl));
                return fileRepositoryIsUrl;
            }

            set
            {
                fileRepositoryIsUrl = value;

                if (fileRepositoryIsUrl)
                {
                    bool validated = TextUtil.IsValidURL(imageRepository);

                    if (!validated)
                    {
                        Uri uriResult;
                        bool valid = HtmlUtil.ValidateUrlToHTTP($@"www.example.org/{DefaultImagesFolderName}", out uriResult);

                        if (valid)
                        {
                            imageRepository = uriResult.AbsoluteUri;
                        }
                    }
                }
                else
                {
                    imageRepository = Path.Combine(Environment.CurrentDirectory, DefaultImagesFolderName);
                }

                OnPropertyChanged(nameof(FileRepositoryIsUrl));
            }
        }

        /// <summary>Gets the hierarchy tree.</summary>
        /// <value>The hierarchy tree.</value>
        [Browsable(false)]
        public HierarchyTree Hierarchy { get; }

        /// <summary>Gets or sets the image repository.</summary>
        /// <value>The image repository.</value>
        [Browsable(true)]
        [Category(CategoryConstants.Settings)]
        [DisplayName("Image Repository")]
        [RefreshProperties(RefreshProperties.All)]
        public string ImageRepository
        {
            get
            {
                if (string.IsNullOrEmpty(imageRepository))
                {
                    return string.Empty;
                }
                else
                {
                    return imageRepository;
                }
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }

                if (value.Equals(imageRepository))
                {
                    return;
                }

                // Handle the type of input.
                if (FileRepositoryIsUrl)
                {
                    bool validated = TextUtil.IsValidURL(value);

                    if (validated)
                    {
                        imageRepository = value;
                    }
                }
                else
                {
                    if (Directory.Exists(value))
                    {
                        imageRepository = value;
                        OnPropertyChanged(nameof(ImageRepository));
                    }
                }
            }
        }

        /// <summary>Gets the missing description.</summary>
        /// <value>The missing description.</value>
        [Browsable(true)]
        [Category(CategoryConstants.Statistics)]
        [DisplayName("Missing Documentation")]
        [ReadOnly(true)]
        public string MissingDescription { get; }

        /// <summary>Gets the missing documentation.</summary>
        /// <value>The missing documentation.</value>
        [Browsable(false)]
        public List<Type> MissingDocumentation { get; }

        /// <summary>Gets the missing documentation types.</summary>
        /// <value>The missing documentation types.</value>
        [Browsable(false)]
        [Category(CategoryConstants.Statistics)]
        [DisplayName("Missing Documentation")]
        [ReadOnly(false)]
        [TypeConverter(typeof(StringListConverter))]
        public List<string> MissingDocumentationTypes
        {
            get
            {
                if ((MissingDocumentation != null) && (MissingDocumentation.Count > 0))
                {
                    var stringList = new List<string>();

                    foreach (Type missingType in MissingDocumentation)
                    {
                        stringList.Add(missingType.FullName);
                    }

                    return stringList;
                }

                return new List<string>();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
        }

        /// <summary>Called when [property changed].</summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>Reads the compiler documentation file.</summary>
        /// <param name="filePath">The file path.</param>
        public void ReadCompilerDocumentationFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), @"The compiler documentation path cannot be null or empty.");
            }

            if (File.Exists(filePath))
            {
                documentationPath = filePath;
                OnPropertyChanged(nameof(CompilerDocumentationPath));
            }
        }

        /// <summary>Scans the missing documentation.</summary>
        public void ScanMissingDocumentation()
        {
            // Loop thru each exported type.
            foreach (Type type in ExportedList)
            {
                if (!type.IsNested)
                {
                    string summary = DocumentationExtensions.GetSummary(type);

                    if (string.IsNullOrEmpty(summary))
                    {
                        MissingDocumentation.Add(type);
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>Reads the missing descriptions.</summary>
        /// <returns></returns>
        private string ReadMissingDescriptions()
        {
            if ((MissingDocumentation != null) && (MissingDocumentation.Count > 0))
            {
                StringBuilder missingBuilder = new StringBuilder();
                missingBuilder.AppendLine($@"Items [{MissingDocumentation.Count}]:");

                for (var i = 0; i < MissingDocumentation.Count; i++)
                {
                    Type typeMissingDocumentation = MissingDocumentation[i];

                    string formatted = $"{i} - {typeMissingDocumentation.FullName}";
                    missingBuilder.AppendLine(formatted);
                }

                return missingBuilder.ToString();
            }
            else
            {
                return Convert.ToString(0);
            }
        }

        #endregion
    }
}