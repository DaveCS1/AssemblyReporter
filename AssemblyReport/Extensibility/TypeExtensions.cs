#region License

// ********************************* Header *********************************\
// 
//    Class:  TypeExtensions.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Linq;

#endregion

namespace AssemblyReport.Extensibility
{
    /// <summary>The <see cref="TypeExtensions"/> extensions provider class.</summary>
    public static class TypeExtensions
    {
        #region Public Methods and Operators

        /// <summary>Returns a human-friendly representation of the Type's name.</summary>
        /// <param name="type">The Type.</param>
        /// <returns>A human-friendly representation of the Type's name.</returns>
        public static string GetFriendlyName(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(@"type", @"type should not be null.");
            }

            if (!type.IsGenericType || type.IsGenericParameter)
            {
                return type.Name;
            }

            const StringComparison sc = StringComparison.Ordinal;
            string name = type.Name.Substring(0, type.Name.IndexOf("`", sc));
            string[] arguments = type.GetGenericArguments().Select(arg => arg.GetFriendlyName()).ToArray();

            return string.Concat(name, '<', string.Join(", ", arguments), '>');
        }

        /// <summary>Determines whether this instance is delegate.</summary>
        /// <param name="type">The source type.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsDelegate(this Type type)
        {
            return type.BaseType == typeof(MulticastDelegate);
        }

        /// <summary>Determines whether the specified type is structure.</summary>
        /// <param name="type">The source type.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsStructure(this Type type)
        {
            return type.IsValueType && type.IsVisible && !type.IsEnum;
        }

        #endregion
    }
}