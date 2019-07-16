#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownEmphasis.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;

#endregion

namespace AssemblyReport.Primitives.Markdown.Elements
{
    /// <summary>The <see cref="MarkdownEmphasis"/> class.</summary>
    /// <seealso cref="MarkdownElement"/>
    public class MarkdownEmphasis : MarkdownElement
    {
        #region Constants

        /// <summary>The bold.</summary>
        public const string Bold = "**";

        /// <summary>The italic.</summary>
        public const string Italic = "*";

        /// <summary>The strikethrough.</summary>
        public const string Strikethrough = "~~";

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownEmphasis"/> class.</summary>
        /// <param name="text">The emphasis text.</param>
        /// <param name="emphasisType">Type of emphasis.</param>
        public MarkdownEmphasis(string text, EmphasisType emphasisType) : this()
        {
            if (string.IsNullOrEmpty(text))
            {
                text = string.Empty;
            }

            MarkdownContentText = text;
            Emphasis = emphasisType;

            CreateEmphasis();
        }

        /// <summary>Prevents a default instance of the <see cref="MarkdownEmphasis"/> class from being created.</summary>
        private MarkdownEmphasis() : base("Emphasis")
        {
            Emphasis = EmphasisType.Bold;
        }

        #endregion

        #region Enums

        /// <summary>The <see cref="EmphasisType"/> enum.</summary>
        public enum EmphasisType
        {
            /// <summary>The bold type.</summary>
            Bold,

            /// <summary>The italic type.</summary>
            Italic,

            /// <summary>The strike through type.</summary>
            Strikethrough
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the emphasis.</summary>
        /// <value>The emphasis.</value>
        public EmphasisType Emphasis { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Creates the emphasis using the specified text.</summary>
        /// <param name="text">The text.</param>
        /// <param name="emphasis">The emphasis type to use.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateEmphasis(string text, EmphasisType emphasis)
        {
            if (string.IsNullOrEmpty(text))
            {
                text = string.Empty;
            }

            // Sets the emphasis.
            string outputText;

            switch (emphasis)
            {
                case EmphasisType.Bold:
                {
                    outputText = Bold + text + Bold;
                    break;
                }
                case EmphasisType.Italic:
                {
                    outputText = Italic + text + Italic;
                    break;
                }
                case EmphasisType.Strikethrough:
                {
                    outputText = Strikethrough + text + Strikethrough;
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(emphasis), emphasis, null);
                }
            }

            return outputText;
        }

        /// <summary>Creates the emphasis.</summary>
        public void CreateEmphasis()
        {
            Value = CreateEmphasis(MarkdownContentText, Emphasis);
        }

        #endregion
    }
}