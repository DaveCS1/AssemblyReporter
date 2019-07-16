#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownBase.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.IO;
using System.Text;

#endregion

namespace AssemblyReport.Primitives.Markdown
{
    /// <summary>The <see cref="MarkdownBase"/> base class.</summary>
    public abstract class MarkdownBase : IDisposable
    {
        #region Constants

        /// <summary>The markdown file name to use when none specified.</summary>
        public const string EmptyFileName = "Untitled";

        /// <summary>The markdown extension.</summary>
        public const string Extension = "md";

        /// <summary>All the possible file type extensions known as markdown type.</summary>
        public const string FileTypeExtensions = "Markdown File (*.markdown, *.md, *.mdown, *.mdwn, *.mkd, *.mkdn, *.mmd)|*.markdown;*.md;*.mdown;*.mdwn;*.mdwn;*.mkd;*.mkdn;*.mmd";

        #endregion

        #region Static Fields

        /// <summary>The markdown file extension.</summary>
        public static readonly string FileExtension = '.' + Extension;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownBase"/> class.</summary>
        /// <param name="name">The name of markdown file name (Name: 'Untitled' when null or empty).</param>
        /// <param name="path">The working directory path.</param>
        protected MarkdownBase(string name, string path) : this()
        {
            if (string.IsNullOrEmpty(name))
            {
                name = EmptyFileName;
            }

            Name = name;
            Directory = new DirectoryInfo(path);

            Read();
        }

        /// <summary>Initializes a new instance of the <see cref="MarkdownBase"/> class.</summary>
        /// <param name="name">The name of markdown file name (Name: 'Untitled' when null or empty).</param>
        protected MarkdownBase(string name) : this(name, string.Empty)
        {
        }

        /// <summary>Prevents a default instance of the <see cref="MarkdownBase"/> class from being created.</summary>
        private MarkdownBase()
        {
            Contents = string.Empty;
            Directory = null;
            Name = string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the text contents.</summary>
        /// <value>The text.</value>
        public string Contents { get; set; }

        /// <summary>Gets or sets the directory.</summary>
        /// <value>The directory.</value>
        public DirectoryInfo Directory { get; set; }

        /// <summary>Gets a value indicating whether this markdown file exists.</summary>
        /// <value>The <see cref="bool"/>.</value>
        public bool Exists
        {
            get { return File.Exists(Location); }
        }

        /// <summary>Gets the file name with extension.</summary>
        /// <value>The name.</value>
        public string FileName
        {
            get { return Name + FileExtension; }
        }

        /// <summary>Gets the full file location of the markdown file with the extension.</summary>
        /// <value>The file location.</value>
        public string Location
        {
            get
            {
                if (Directory != null)
                {
                    return Directory.FullName + Path.DirectorySeparatorChar + FileName;
                }

                return FileName;
            }
        }

        /// <summary>Gets or sets the name of the file without the extension.</summary>
        /// <value>The name of the file.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the markdown settings.</summary>
        /// <value>The settings.</value>
        public MarkdownSettings Settings { get; set; }

        /// <summary>Gets the size of the file in bytes.</summary>
        /// <value>The file size in bytes.</value>
        public long Size
        {
            get
            {
                if (File.Exists(Location))
                {
                    return new FileInfo(Location).Length;
                }

                // 1 byte = 1 character in size.
                return Contents.Length;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Contents = string.Empty;
            Name = string.Empty;
            Directory = null;
        }

        /// <summary>Reads the contents from the location.</summary>
        public void Read()
        {
            if (Exists)
            {
                // Read the file path to text.
                Contents = File.ReadAllText(Location);
            }
        }

        /// <summary>Saves the contents to the location.</summary>
        public void Save()
        {
            File.WriteAllText(Location, Contents, Encoding.Default);
        }

        #endregion
    }
}