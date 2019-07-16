#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownReference.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;

#endregion

namespace AssemblyReport.Primitives.Markdown.Elements
{
    /// <summary>The <see cref="MarkdownReference"/> class.</summary>
    public class MarkdownReference : MarkdownElement
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownReference"/> class.</summary>
        /// <param name="altText">The alternate text to show on broken images or links.</param>
        /// <param name="sourceUrl">The source url path of the image, website or link to file.</param>
        /// <param name="hoverText">The hover text.</param>
        /// <exception cref="ArgumentNullException">name - The markdown element name cannot be null or empty.</exception>
        public MarkdownReference(string altText, string sourceUrl, string hoverText) : base("Reference")
        {
            AlternateText = altText;
            SourceUrl = sourceUrl;
            HoverText = hoverText;

            CreateReference();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the alternate text.</summary>
        /// <value>The alternate text.</value>
        public string AlternateText { get; set; }

        /// <summary>Gets or sets the hover text.</summary>
        /// <value>The hover text.</value>
        public string HoverText { get; set; }

        /// <summary>Gets or sets the source URL.</summary>
        /// <value>The source URL.</value>
        public string SourceUrl { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Creates the image reference text to link to the file path.</summary>
        /// <param name="alternateText">The alternate text.</param>
        /// <param name="sourceUrl">The url link path to a website or file.</param>
        /// <param name="hoverText">The mouse hover text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateReference(string alternateText, string sourceUrl, string hoverText)
        {
            return string.Format(@"[{1}]: {2} {0}{3}{0}", Constants.Quotes, alternateText, sourceUrl, hoverText);
        }

        /// <summary>Creates the reference.</summary>
        public void CreateReference()
        {
            Value = CreateReference(AlternateText, SourceUrl, HoverText);
        }

        #endregion
    }
}