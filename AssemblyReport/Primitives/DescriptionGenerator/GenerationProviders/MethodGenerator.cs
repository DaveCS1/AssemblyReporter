#region License

// ********************************* Header *********************************\
// 
//    Class:  MethodGenerator.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Text;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives.DescriptionGenerator
{
    /// <summary>The <see cref="DescriptionGeneratorBase"/> class.</summary>
    public partial class DescriptionGeneratorBase
    {
        #region Public Methods and Operators

        /// <summary>Generates the method.</summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="returnTypeName">The name of return type.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="remarks">The remarks text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateMethod(string methodName, string returnTypeName, List<ParamInfo> parameters, string remarks)
        {
            return GenerateMethod(methodName, returnTypeName, parameters, CodeReferenceTypes.See, remarks);
        }

        /// <summary>Generates the method.</summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="remarks">The remarks text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateMethod(string methodName, Type returnType, List<ParamInfo> parameters, string remarks)
        {
            return GenerateMethod(methodName, returnType, parameters, CodeReferenceTypes.See, remarks);
        }

        /// <summary>Generates the method.</summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="referenceType">The reference type.</param>
        /// <param name="remarks">The remarks text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateMethod(string methodName, Type returnType, List<ParamInfo> parameters, CodeReferenceTypes referenceType, string remarks)
        {
            return GenerateMethod(methodName, returnType.Name.ToLower(), parameters, referenceType, remarks);
        }

        /// <summary>Generates the method.</summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="returnTypeName">The name of return type.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="referenceType">The reference type.</param>
        /// <param name="remarks">The remarks text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateMethod(string methodName, string returnTypeName, List<ParamInfo> parameters, CodeReferenceTypes referenceType, string remarks)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException(nameof(methodName), @"The method name cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(returnTypeName))
            {
                throw new ArgumentNullException(nameof(returnTypeName), @"The return type name cannot be null or empty!");
            }

            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters), @"The parameters list cannot be null!");
            }

            var words = TextUtil.SplitWords(methodName);

            // Handle the summary generation based on method words count.
            string summary;

            switch (words.Count)
            {
                case 0:
                case 1:
                {
                    summary = $@"{methodName} this instance.";
                    break;
                }
                case 2:
                {
                    summary = $@"{words[0]} the {words[1]}.";
                    break;
                }
                case 3:
                {
                    summary = $@"{words[0]} the {words[1]} {words[2]}.";
                    break;
                }

                default:
                {
                    summary = $@"{methodName} this instance.";
                    break;
                }
            }

            // Generate the summary text
            StringBuilder methodBuilder = new StringBuilder();
            methodBuilder.AppendLine(GenerateSummary(summary, remarks));

            // Generate the parameters text
            foreach (ParamInfo paramInfo in parameters)
            {
                methodBuilder.AppendLine(GenerateParameter(paramInfo));
            }

            // Generate the returns text for all types except 'void' types ignore
            if (!returnTypeName.Equals(typeof(void).Name.ToLower()))
            {
                methodBuilder.AppendLine(GenerateReturns(returnTypeName, referenceType));
            }

            return methodBuilder.ToString();
        }

        /// <summary>Generates the returns tag.</summary>
        /// <param name="returnTypeName">The name of return type.</param>
        /// <param name="referenceType">The reference type.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateReturns(string returnTypeName, CodeReferenceTypes referenceType)
        {
            string codeReference = GenerateCodeReference(returnTypeName, referenceType);
            return GenerateTag(ReturnsTag, $@"The {codeReference}.");
        }

        /// <summary>Generates the returns tag.</summary>
        /// <param name="returnType">Type of the return.</param>
        /// <param name="referenceType">The reference type.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateReturns(Type returnType, CodeReferenceTypes referenceType)
        {
            return GenerateReturns(returnType.Name.ToLower(), referenceType);
        }

        #endregion
    }
}