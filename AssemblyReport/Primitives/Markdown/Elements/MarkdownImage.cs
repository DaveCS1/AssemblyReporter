#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownImage.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System.IO;
using System.Text;

#endregion

namespace AssemblyReport.Primitives.Markdown.Elements
{
    /// <summary>The <see cref="MarkdownImage"/> class.</summary>
    /// <seealso cref="MarkdownElement"/>
    public class MarkdownImage : MarkdownElement
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownImage"/> class.</summary>
        /// <param name="alternateText">The alternate text.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="hoverText">The hover text.</param>
        public MarkdownImage(string alternateText, string imagePath, string hoverText) : this()
        {
            // Initialize variables.
            AlternateText = alternateText;
            HoverText = hoverText;
            ImagePath = imagePath;

            // Generate the image value.
            CreateImage();
        }

        /// <summary>Initializes a new instance of the <see cref="MarkdownElement"/> class.</summary>
        /// <param name="imagePath">The image path.</param>
        public MarkdownImage(string imagePath) : this(Path.GetFileNameWithoutExtension(imagePath), imagePath, Path.GetFileNameWithoutExtension(imagePath))
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MarkdownElement"/> class.</summary>
        /// <param name="imagePath">The image path.</param>
        /// <param name="alternateText">The alternate text.</param>
        public MarkdownImage(string imagePath, string alternateText) : this(alternateText, imagePath, Path.GetFileNameWithoutExtension(imagePath))
        {
        }

        /// <summary>Prevents a default instance of the <see cref="MarkdownHeader"/> class from being created.</summary>
        private MarkdownImage() : base("Image")
        {
            AlternateText = string.Empty;
            HoverText = string.Empty;
            ImagePath = string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the alternate text.</summary>
        /// <value>The alternate text.</value>
        public string AlternateText { get; set; }

        /// <summary>Gets or sets the hover text.</summary>
        /// <value>The hover text.</value>
        public string HoverText { get; set; }

        /// <summary>Gets or sets the image path.</summary>
        /// <value>The image path.</value>
        public string ImagePath { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Creates the image text.</summary>
        /// <param name="alternateText">The alternate text.</param>
        /// <param name="imagePath">The image path.</param>
        /// <param name="hoverText">The hover text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateImage(string alternateText, string imagePath, string hoverText)
        {
            return string.Format(@"![{1}]({2} {0}{3}{0})", Constants.Quotes, alternateText, imagePath, hoverText);
        }

        /// <summary>Creates the image reference text to link to the file path.</summary>
        /// <param name="alternateText">The alternate text.</param>
        /// <param name="sourceUrl">The url link path to a website or file.</param>
        /// <param name="hoverText">The mouse hover text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateImageReference(string alternateText, string sourceUrl, string hoverText)
        {
            return string.Format(@"![{1}]({2} {0}{3}{0})", Constants.Quotes, alternateText, sourceUrl, hoverText);
        }

        /// <summary>Creates the type of the image.</summary>
        /// <param name="alternateText">The alternate text.</param>
        /// <param name="imageReference">The image reference.</param>
        /// <param name="urlReference">The URL reference.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateImageType(string alternateText, string imageReference, string urlReference)
        {
            return string.Format(@"[![{0}][{1}]][{2}]", alternateText, imageReference, urlReference);
        }

        /// <summary>Creates the type of the image.</summary>
        /// <param name="markdownTypeId">The markdown type identifier.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateImageType(MarkdownTypeId markdownTypeId)
        {
            return string.Format(@"[![{0}][{1}]][{2}]", markdownTypeId.AlternateText, markdownTypeId.ImageReference, markdownTypeId.SourceReference);
        }

        /// <summary>Creates the type of the image.</summary>
        /// <param name="markdownTypeId">The markdown type identifier.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateImageType0(MarkdownTypeId markdownTypeId)
        {
            return string.Format(@"![{0}]", markdownTypeId.ImageReference);
        }

        /// <summary>Creates the image type source.</summary>
        /// <param name="markdownTypeId">The markdown type identifier.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateImageTypeSource(MarkdownTypeId markdownTypeId)
        {
            return CreateImageTypeSource($@"{markdownTypeId.AlternateText}", $@"{markdownTypeId.RelativeImagePath}", $@"{markdownTypeId.HoverTextSource}");
        }

        /// <summary>Creates the image type source.</summary>
        /// <param name="altText">The alt text.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="hoverText">The hover text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateImageTypeSource(string altText, string imageSource, string hoverText)
        {
            string imageReference = MarkdownReference.CreateReference($@"{altText}", imageSource, hoverText);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(imageReference);

            return builder.ToString();
        }

        /// <summary>Creates the image URL type source.</summary>
        /// <param name="altText">The alt text.</param>
        /// <param name="altTextSource">The alt text source.</param>
        /// <param name="altTextImage">The alt text image.</param>
        /// <param name="contentSource">The content source.</param>
        /// <param name="imageSource">The image source.</param>
        /// <param name="hoverSourceText">The hover source text.</param>
        /// <param name="hoverImageText">The hover image text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateImageUrlTypeSource(string altText, string altTextSource, string altTextImage, string contentSource, string imageSource, string hoverSourceText, string hoverImageText)
        {
            string urlReference = MarkdownReference.CreateReference($@"{altTextSource}", contentSource, hoverSourceText);
            string imageReference = MarkdownReference.CreateReference($@"{altTextImage}", imageSource, hoverImageText);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(urlReference);
            builder.AppendLine(imageReference);

            return builder.ToString();
        }

        /// <summary>Creates the image text.</summary>
        public void CreateImage()
        {
            Value = CreateImage(AlternateText, ImagePath, HoverText);
        }

        #endregion
    }
}