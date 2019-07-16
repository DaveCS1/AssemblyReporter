#region License

// ********************************* Header *********************************\
// 
//    Class:  NamespaceData.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="NamespaceData"/> struct.</summary>
    [DebuggerDisplay("IsNamespace = {IsNamespace}, Path = {Path}")]
    public struct NamespaceData : INamespaceData
    {
        #region Constants

        /// <summary>The namespace path separator.</summary>
        public const char NamespacePathSeparator = '.';

        #endregion

        #region Static Fields

        /// <summary>Gets the empty value for the <see cref="NamespaceData"/>, that represents the current object. This <see langword="static"/> field is read-only.</summary>
        public static readonly NamespaceData Empty = new NamespaceData(string.Empty);

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="NamespaceData"/> struct.</summary>
        /// <param name="fullPath">The full path.</param>
        public NamespaceData(string fullPath) : this()
        {
            Path = fullPath;
            IsNamespace = IsValidNamespace(fullPath);
        }

        #endregion

        #region Public Properties

        /// <summary>Gets a value indicating whether this instance is empty.</summary>
        /// <value>Determines whether this instance is empty.</value>
        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        /// <summary>Gets a value indicating whether this instance is namespace.</summary>
        /// <value>Indicates whether this instance is a valid namespace path.</value>
        public bool IsNamespace { get; set; }

        /// <summary>Gets or sets the path.</summary>
        /// <value>The path.</value>
        public string Path { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Resolves the namespace path from the <see cref="Type"/>.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="NamespaceData"/>.</returns>
        public static NamespaceData GetNamespaceData(Type type)
        {
            return new NamespaceData(GetNamespacePath(type));
        }

        /// <summary>Resolves the namespace path from the <see cref="Type"/>.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetNamespacePath(Type type)
        {
            return type == null ? string.Empty : type.Namespace;
        }

        /// <summary>Determines whether the namespace full path is a valid <see cref="string"/> format encoded.</summary>
        /// <param name="fullPath">The full base path.</param>
        /// <returns>The <seealso cref="bool"/>.</returns>
        public static bool IsValidNamespace(string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath))
            {
                return false;
            }

            // Split the string from '.' and check each part for validity.
            var splitPath = fullPath.Split(NamespacePathSeparator);

            // Loop thru each namespace separate path.
            return splitPath.All(CodeGenerator.IsValidLanguageIndependentIdentifier);
        }

        #endregion
    }
}