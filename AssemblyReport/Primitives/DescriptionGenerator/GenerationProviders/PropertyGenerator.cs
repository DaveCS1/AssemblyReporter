#region License

// ********************************* Header *********************************\
// 
//    Class:  PropertyGenerator.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

#endregion

#region Namespace

using System;
using System.Text;

#endregion

namespace AssemblyReport.Primitives.DescriptionGenerator
{
    /// <summary>The <see cref="DescriptionGeneratorBase"/> class.</summary>
    public partial class DescriptionGeneratorBase
    {
        #region Public Methods and Operators

        /// <summary>Generates the property.</summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="type">The type.</param>
        /// <param name="get">if set to <c>true</c> [get].</param>
        /// <param name="set">if set to <c>true</c> [set].</param>
        /// <param name="remarks">The remarks text to display.</param>
        /// <returns>The <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">propertyName - The property name cannot be null or empty!</exception>
        public static string GenerateProperty(string propertyName, Type type, bool get, bool set, string remarks)
        {
            return GenerateProperty(propertyName, type.Name, get, set, remarks);
        }

        /// <summary>Generates the property.</summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="typeName">The type name.</param>
        /// <param name="get">if set to <c>true</c> [get].</param>
        /// <param name="set">if set to <c>true</c> [set].</param>
        /// <param name="remarks">The remarks text to display.</param>
        /// <returns>The <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">propertyName - The property name cannot be null or empty!</exception>
        public static string GenerateProperty(string propertyName, string typeName, bool get, bool set, string remarks)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName), @"The property name cannot be null or empty!");
            }

            StringBuilder propertyBuilder = new StringBuilder();

            // Handle the Get & Set accessors
            string accessorText;

            if (get && set)
            {
                accessorText = $@"Gets or sets the {propertyName}.";
            }
            else if (get)
            {
                accessorText = $@"Gets the {propertyName}.";
            }
            else if (set)
            {
                accessorText = $@"Sets the {propertyName}.";
            }
            else
            {
                accessorText = string.Empty;
            }

            // Get the summary text
            string summaryText = GenerateSummary(accessorText, remarks);
            propertyBuilder.AppendLine(summaryText);

            // Get the value text
            string valueText = GenerateValue($@"The {propertyName} value.");
            propertyBuilder.AppendLine(valueText);

            return propertyBuilder.ToString();
        }

        /// <summary>Generates the value tag with the specified text contents.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateValue(string text)
        {
            return GenerateTag(ValueTag, text);
        }

        #endregion
    }
}