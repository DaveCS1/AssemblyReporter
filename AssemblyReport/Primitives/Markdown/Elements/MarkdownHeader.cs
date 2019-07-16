#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownHeader.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

namespace AssemblyReport.Primitives.Markdown.Elements
{
    /// <summary>The <see cref="MarkdownHeader"/> class.</summary>
    /// <seealso cref="MarkdownElement"/>
    public class MarkdownHeader : MarkdownElement
    {
        #region Constants

        /// <summary>The header.</summary>
        public const string Header = "#";

        /// <summary>The maximum value.</summary>
        public const int MaxValue = 6;

        /// <summary>The minimum value.</summary>
        public const int MinValue = 1;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownElement"/> class.</summary>
        /// <param name="text">The header text.</param>
        /// <param name="size">The header size (Min: 1 - Max: 6).</param>
        public MarkdownHeader(string text, int size) : this()
        {
            if (string.IsNullOrEmpty(text))
            {
                text = string.Empty;
            }

            // Set the size range.
            if (size < MinValue)
            {
                size = MinValue;
            }

            if (size > MaxValue)
            {
                size = MaxValue;
            }

            // Initialize variables.
            Size = size;
            MarkdownContentText = text;

            // Generate the header value.
            CreateHeader();
        }

        /// <summary>Initializes a new instance of the <see cref="MarkdownElement"/> class.</summary>
        /// <param name="text">The header text.</param>
        public MarkdownHeader(string text) : this(text, MinValue)
        {
        }

        /// <summary>Prevents a default instance of the <see cref="MarkdownHeader"/> class from being created.</summary>
        private MarkdownHeader() : base("Header")
        {
            Size = MinValue;
            Value = string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the header size (Min: 1 - Max: 6).</summary>
        /// <value>The header size.</value>
        public int Size { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Creates the header using the specified size.</summary>
        /// <param name="text">The header text.</param>
        /// <param name="size">The header size (Min: 1 - Max: 6).</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateHeader(string text, int size = MinValue)
        {
            if (string.IsNullOrEmpty(text))
            {
                text = string.Empty;
            }

            // Set the size range.
            if (size < MinValue)
            {
                size = MinValue;
            }

            if (size > MaxValue)
            {
                size = MaxValue;
            }

            string headerSizePrefix = string.Empty;

            // Set the header size prefix text.
            for (var i = 0; i < size; i++)
            {
                headerSizePrefix += Header;
            }

            return headerSizePrefix + " " + text;
        }

        /// <summary>Creates the header using the specified size.</summary>
        public void CreateHeader()
        {
            Value = CreateHeader(MarkdownContentText, Size);
        }

        #endregion
    }
}