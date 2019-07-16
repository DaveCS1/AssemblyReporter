#region License

// ********************************* Header *********************************\
// 
//    Class:  DescriptionGeneratorBase.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;

#endregion

namespace AssemblyReport.Primitives.DescriptionGenerator
{
    /// <summary>The <see cref="DescriptionGeneratorBase"/> class.</summary>
    public abstract partial class DescriptionGeneratorBase
    {
        #region Constants

        /// <summary>The basic code comment prefix.</summary>
        public const string CommentCode = "//";

        /// <summary>The XML comment prefix.</summary>
        public const string CommentDocumentation = "///";

        /// <summary>The parameter tag.</summary>
        public const string ParamTag = "param";

        /// <summary>The remarks tag.</summary>
        public const string RemarksTag = "remarks";

        /// <summary>The returns tag.</summary>
        public const string ReturnsTag = "returns";

        /// <summary>The see also code reference tag.</summary>
        public const string SeeAlsoCodeReference = "seealso cref";

        /// <summary>The see code reference tag.</summary>
        public const string SeeCodeReference = "see cref";

        /// <summary>The summary tag.</summary>
        public const string SummaryTag = "summary";

        /// <summary>The value tag.</summary>
        public const string ValueTag = "value";

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="DescriptionGeneratorBase"/> class.</summary>
        /// <param name="summary">The summary.</param>
        protected DescriptionGeneratorBase(string summary) : this(summary, string.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DescriptionGeneratorBase"/> class.</summary>
        /// <param name="summary">The summary.</param>
        /// <param name="remarks">The remarks.</param>
        protected DescriptionGeneratorBase(string summary, string remarks) : this()
        {
            Remarks = remarks;
            Result = string.Empty;
            Summary = summary;
        }

        /// <summary>Prevents a default instance of the <see cref="DescriptionGeneratorBase"/> class from being created.</summary>
        private DescriptionGeneratorBase()
        {
            Remarks = string.Empty;
            Summary = string.Empty;
        }

        #endregion

        #region Enums

        /// <summary>The <see cref="CodeReferenceTypes"/> enum.</summary>
        public enum CodeReferenceTypes
        {
            /// <summary>The see.</summary>
            See = 0,

            /// <summary>The see also.</summary>
            SeeAlso = 1
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the remarks.</summary>
        /// <value>The remarks.</value>
        public string Remarks { get; set; }

        /// <summary>Gets the result.</summary>
        /// <value>The result.</value>
        public string Result { get; internal set; }

        /// <summary>Gets the summary.</summary>
        /// <value>The summary.</value>
        public string Summary { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Generates the see CREF section.</summary>
        /// <param name="type">The type.</param>
        /// <param name="referenceType">The reference type.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateCodeReference(Type type, CodeReferenceTypes referenceType)
        {
            return GenerateCodeReference(type.Name.ToLower(), referenceType);
        }

        /// <summary>Generates the 'see cref' section.</summary>
        /// <param name="text">The text.</param>
        /// <param name="referenceType">The reference type.</param>
        /// <returns>The <see cref="string"/> <seealso cref="string"/> .</returns>
        public static string GenerateCodeReference(string text, CodeReferenceTypes referenceType)
        {
            // Handle the code reference type to use
            string referenceText;

            switch (referenceType)
            {
                case CodeReferenceTypes.See:
                {
                    referenceText = SeeCodeReference;
                    break;
                }
                case CodeReferenceTypes.SeeAlso:
                {
                    referenceText = SeeAlsoCodeReference;
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(referenceType), referenceType, null);
                }
            }

            return string.Format("<{1}={0}{2}{0}/>", Constants.Quotes, referenceText, text);
        }

        /// <summary>Generates the documentation tag using the specified contents.</summary>
        /// <param name="tagName">The tag name.</param>
        /// <param name="contents">The tag contents.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateTag(string tagName, string contents)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                throw new ArgumentNullException(nameof(tagName), @"The tag name cannot be null or empty!");
            }

            return string.Format("{0} <{1}>{2}</{1}>", CommentDocumentation, tagName, contents);
        }

        #endregion
    }
}