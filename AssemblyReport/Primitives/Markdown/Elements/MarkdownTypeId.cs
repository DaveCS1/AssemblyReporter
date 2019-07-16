#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownTypeId.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.IO;
using AssemblyReport.Enumerators;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives.Markdown.Elements
{
    /// <summary>The <see cref="MarkdownTypeId"/> class.</summary>
    public class MarkdownTypeId : MarkdownReference
    {
        #region Constants

        /// <summary>The image reference.</summary>
        public const string ImageRef = @" Image";

        /// <summary>The public modifier.</summary>
        public const string PublicModifier = @"Public";

        /// <summary>The source reference.</summary>
        public const string SourceRef = @" Source";

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownReference"/> class.</summary>
        /// <param name="memberInfo">The member info type.</param>
        /// <param name="id">The source url path of the image, website or link to file.</param>
        /// <param name="settings">The report settings.</param>
        /// <exception cref="ArgumentNullException">name - The markdown element name cannot be null or empty.</exception>
        public MarkdownTypeId(MemberInfoTypes memberInfo, string id, ReportSettings settings) : base($@"{id} Image", Path.Combine(settings.ImageRepository, $@"{id}{Constants.ImageFilePNGExtension}"), $@"Public {id}")
        {
            MemberInfo = memberInfo;
            ID = id;
            Settings = settings;

            ImageReference = $@"{id}{ImageRef}";
            SourceReference = $@"{id}{SourceRef}";

            ImageType = MarkdownImage.CreateImageType0(this);
            ImageTypeSource = MarkdownImage.CreateImageTypeSource(this);
        }

        #endregion

        #region Public Properties

        /// <summary>The alt text image.</summary>
        public string AltTextImage
        {
            get { return $@"Public {ID}{ImageRef}"; }
        }

        /// <summary>The alt text source.</summary>
        public string AltTextSource
        {
            get { return $@"Public {ID}{SourceRef}"; }
        }

        /// <summary>The hover text image</summary>
        public string HoverTextImage
        {
            get { return $@"Public {ID}"; }
        }

        /// <summary>The hover text source</summary>
        public string HoverTextSource
        {
            get { return $@"Public {ID}"; }
        }

        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        public string ID { get; }

        /// <summary>Gets the image reference.</summary>
        /// <value>The image reference.</value>
        public string ImageReference { get; }

        /// <summary>The image source</summary>
        public string ImageSource
        {
            get { return SourceUrl; }
        }

        /// <summary>Gets the type of the image.</summary>
        /// <value>The type of the image.</value>
        public string ImageType { get; }

        /// <summary>Gets the image type source.</summary>
        /// <value>The image type source.</value>
        public string ImageTypeSource { get; }

        /// <summary>Gets the member information.</summary>
        /// <value>The member information.</value>
        public MemberInfoTypes MemberInfo { get; }

        /// <summary>Relatives the image path.</summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string RelativeImagePath
        {
            get
            {
                // Remove any prefix characters like: '..\\' for example.
                string relativePath = TextUtil.GetRelativePath(ImageSource, Settings.BuildPath);

                const string RelativePrefix = @"..\";

                string path;

                if (relativePath.StartsWith(RelativePrefix))
                {
                    path = relativePath.Substring(RelativePrefix.Length);
                }
                else
                {
                    path = relativePath;
                }

                return path;
            }
        }

        /// <summary>Gets the settings.</summary>
        /// <value>The settings.</value>
        public ReportSettings Settings { get; }

        /// <summary>Gets the source reference.</summary>
        /// <value>The source reference.</value>
        public string SourceReference { get; }

        #endregion
    }
}