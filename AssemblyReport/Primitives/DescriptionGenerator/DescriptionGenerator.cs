#region License

// ********************************* Header *********************************\
// 
//    Class:  DescriptionGenerator.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

#endregion

namespace AssemblyReport.Primitives.DescriptionGenerator
{
    /// <summary>The <see cref="DescriptionGenerator"/> class.</summary>
    /// <seealso cref="DescriptionGeneratorBase"/>
    public class DescriptionGenerator : DescriptionGeneratorBase
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="DescriptionGenerator"/> class.</summary>
        /// <param name="summary">The summary text.</param>
        /// <param name="remarks">The remarks text.</param>
        public DescriptionGenerator(string summary, string remarks) : base(summary, remarks)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DescriptionGenerator"/> class.</summary>
        /// <param name="summary">The summary text.</param>
        public DescriptionGenerator(string summary) : this(summary, string.Empty)
        {
        }

        #endregion
    }
}