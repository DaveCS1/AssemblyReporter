#region License

// ********************************* Header *********************************\
// 
//    Class:  SummaryGenerator.cs
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
    public partial class DescriptionGeneratorBase
    {
        #region Public Methods and Operators

        /// <summary>Generates the summary description with remarks.</summary>
        /// <param name="summary">The summary text.</param>
        /// <param name="remarks">The remarks text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateSummary(string summary, string remarks)
        {
            if (string.IsNullOrEmpty(summary))
            {
                throw new ArgumentNullException(nameof(summary), @"The summary text cannot be null or empty!");
            }

            string description;

            string summaryText = GenerateTag(SummaryTag, summary);

            // Handle the remarks text generation if it contains any valid text contents
            if (string.IsNullOrEmpty(remarks))
            {
                description = summaryText;
            }
            else
            {
                string remarksText = GenerateTag(RemarksTag, remarks);
                description = $@"{summaryText}{Environment.NewLine}{remarksText}";
            }

            return description;
        }

        /// <summary>Generates the summary description.</summary>
        /// <param name="summary">The summary text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateSummary(string summary)
        {
            if (string.IsNullOrEmpty(summary))
            {
                throw new ArgumentNullException(nameof(summary), @"The summary text cannot be null or empty!");
            }

            return GenerateSummary(summary, string.Empty);
        }

        #endregion
    }
}