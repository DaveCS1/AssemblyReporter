#region License

// ********************************* Header *********************************\
// 
//    Class:  ConstructorGenerator.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace AssemblyReport.Primitives.DescriptionGenerator
{
    /// <summary>The <see cref="DescriptionGeneratorBase"/> class.</summary>
    public partial class DescriptionGeneratorBase
    {
        #region Public Methods and Operators

        /// <summary>Generates the constructor.</summary>
        /// <param name="type">The type.</param>
        /// <param name="isPrivate">Indicates whether to return a private or public text format.</param>
        /// <param name="parameters">The list of parameters.</param>
        /// <param name="remarks">The remarks text to display.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateConstructor(Type type, bool isPrivate, List<ParamInfo> parameters, string remarks)
        {
            return GenerateConstructor(type.Name, isPrivate, parameters, remarks);
        }

        /// <summary>Generates the constructor.</summary>
        /// <param name="name">The name of the type.</param>
        /// <param name="isPrivate">Indicates whether to return a private or public text format.</param>
        /// <param name="parameters">The list of parameters.</param>
        /// <param name="remarks">The remarks text to display.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateConstructor(string name, bool isPrivate, List<ParamInfo> parameters, string remarks)
        {
            StringBuilder constructorText = new StringBuilder();

            string codeReferenceText = GenerateCodeReference(name, CodeReferenceTypes.See);

            if (isPrivate)
            {
                string privateSummary = GenerateSummary($@"Prevents a default instance of the {codeReferenceText} class from being created.");
                constructorText.AppendLine(privateSummary);
            }
            else
            {
                string publicSummary = GenerateSummary($@"Initializes a new instance of the {codeReferenceText} class.");
                constructorText.AppendLine(publicSummary);
            }

            // Generate the parameters text
            foreach (ParamInfo paramInfo in parameters)
            {
                constructorText.AppendLine(GenerateParameter(paramInfo));
            }

            return constructorText.ToString();
        }

        #endregion
    }
}