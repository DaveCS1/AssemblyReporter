#region License

// ********************************* Header *********************************\
// 
//    Class:  ParameterGenerator.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

namespace AssemblyReport.Primitives.DescriptionGenerator
{
    /// <summary>The <see cref="DescriptionGeneratorBase"/> class.</summary>
    public partial class DescriptionGeneratorBase
    {
        #region Public Methods and Operators

        /// <summary>Generates the parameter.</summary>
        /// <param name="paramInfo">The parameter information.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateParameter(ParamInfo paramInfo)
        {
            return GenerateParameter(paramInfo.Name, paramInfo.Description);
        }

        /// <summary>Generates the parameter.</summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateParameter(string name, string description)
        {
            return string.Format("{0} <{2} name={1}{3}{1}>{4}</{2}>", CommentDocumentation, Constants.Quotes, ParamTag, name, description);
        }

        #endregion
    }
}