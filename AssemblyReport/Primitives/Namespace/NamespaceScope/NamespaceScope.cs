#region License

// ********************************* Header *********************************\
// 
//    Class:  NamespaceScope.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AssemblyReport.Extensibility;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="NamespaceScope"/> class.</summary>
    [DebuggerDisplay("IsNamespace = {IsNamespace}, FullPath = {FullPath}")]
    public class NamespaceScope : INamespaceScope
    {
        #region Static Fields

        /// <summary>Gets the empty value for the <see cref="NamespaceScope"/>, that represents the current object. This <see langword="static"/> field is read-only.</summary>
        public static readonly NamespaceScope Empty = new NamespaceScope();

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="NamespaceScope"/> class.</summary>
        /// <param name="namespaceObject">The object namespace type.</param>
        public NamespaceScope(Type namespaceObject) : this()
        {
            // Validate the object type
            if (namespaceObject != null)
            {
                Input = namespaceObject.Namespace;
                Location = namespaceObject.Assembly.Location;
                ObjectType = namespaceObject;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="NamespaceScope"/> class.</summary>
        /// <param name="location">The assembly file location.</param>
        /// <param name="input">The full namespace path.</param>
        public NamespaceScope(string location, string input) : this()
        {
            Input = input;
            Location = location;
        }

        /// <summary>Initializes a new instance of the <see cref="NamespaceScope"/> class.</summary>
        public NamespaceScope()
        {
            Input = string.Empty;
            ObjectType = null;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the result.</summary>
        /// <value>The result.</value>
        public string FullPath
        {
            get
            {
                StringBuilder resultBuilder = new StringBuilder();

                // Loop thru each valid namespace object data to resolve only valid paths
                for (var index = 0; index < SplitPaths.Count; index++)
                {
                    NamespaceData namespaceData = SplitPaths[index];

                    // Validate namespace
                    if (namespaceData.IsNamespace)
                    {
                        if (index == 0)
                        {
                            // Handle first index
                            if (SplitPaths.Count > 1)
                            {
                                resultBuilder.Append($@"{namespaceData.Path}{NamespaceData.NamespacePathSeparator}");
                            }
                            else
                            {
                                resultBuilder.Append($@"{namespaceData.Path}");
                            }
                        }
                        else if (index == SplitPaths.Count - 1)
                        {
                            // Handle last index   
                            resultBuilder.Append($@"{namespaceData.Path}");
                        }
                        else
                        {
                            // Handle in between indexes
                            resultBuilder.Append($@"{namespaceData.Path}{NamespaceData.NamespacePathSeparator}");
                        }
                    }
                }

                return resultBuilder.ToString();
            }
        }

        /// <summary>Gets the full path.</summary>
        /// <value>The full path.</value>
        public string Input { get; }

        /// <summary>Gets a value indicating whether this instance is empty.</summary>
        /// <value>Determines whether this instance is empty.</value>
        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        /// <summary>Gets the whether the input is a namespace.</summary>
        /// <value>The is namespace toggle.</value>
        public bool IsNamespace
        {
            get { return NamespaceData.IsValidNamespace(FullPath); }
        }

        /// <summary>Gets the location.</summary>
        /// <value>The location.</value>
        public string Location { get; }

        /// <summary>Gets the name of the member.</summary>
        /// <value>The name of the member.</value>
        public string MemberName
        {
            get
            {
                string memberName;

                if (!string.IsNullOrEmpty(FullPath))
                {
                    var namespacePathSplit = FullPath.Split(NamespaceData.NamespacePathSeparator);
                    memberName = namespacePathSplit[namespacePathSplit.Length - 1];
                }
                else
                {
                    memberName = string.Empty;
                }

                return memberName;
            }
        }

        /// <summary>Gets the namespace path.</summary>
        /// <value>The namespace path.</value>
        public string NamespacePath
        {
            get
            {
                string namespacePath;

                if (!string.IsNullOrEmpty(FullPath))
                {
                    if (SplitPaths.Count > 1)
                    {
                        namespacePath = FullPath.Remove(FullPath.Length - MemberName.Length - 1);
                    }
                    else
                    {
                        namespacePath = FullPath;
                    }
                }
                else
                {
                    namespacePath = string.Empty;
                }

                return namespacePath;
            }
        }

        /// <summary>Gets the type of the object.</summary>
        /// <value>The type of the object.</value>
        public Type ObjectType { get; }

        /// <summary>Gets the split paths.</summary>
        /// <value>The split paths.</value>
        public List<NamespaceData> SplitPaths
        {
            get { return string.IsNullOrEmpty(Input) ? new List<NamespaceData>(0) : ResolveDataPaths(Location, Input); }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Combines the namespace paths in to a <see cref="string"/>.</summary>
        /// <param name="path1">The first path to combine.</param>
        /// <param name="path2">The second path to combine.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CombineNamespacePaths(string path1, string path2)
        {
            return TextUtil.PathCombine(NamespaceData.NamespacePathSeparator, path1, path2);
        }

        /// <summary>Combines the namespace paths in to a <see cref="string"/>.</summary>
        /// <param name="paths">The first path to combine.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CombineNamespacePaths(params string[] paths)
        {
            return TextUtil.PathCombine(NamespaceData.NamespacePathSeparator, paths);
        }

        /// <summary>Resolves the specified namespace full path to a <see cref="List{T}"/>.</summary>
        /// <param name="assemblyLocation">The assembly file location.</param>
        /// <param name="fullPath">The full path of the namespace.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public static List<NamespaceData> ResolveDataPaths(string assemblyLocation, string fullPath)
        {
            if (string.IsNullOrEmpty(fullPath))
            {
                return new List<NamespaceData>();
            }

            var namespaceData = new List<NamespaceData>();

            // Validate the input
            if (string.IsNullOrEmpty(fullPath))
            {
                return namespaceData;
            }
            else
            {
                string optimizedPath;

                if (fullPath.Contains(Path.DirectorySeparatorChar))
                {
                    // Remove the first index separated by a DirectorySeparatorChar
                    int indexStartSeparator = fullPath.IndexOf(Path.DirectorySeparatorChar) + 1;

                    string substring = fullPath.Substring(indexStartSeparator);

                    optimizedPath = substring.Replace(Path.DirectorySeparatorChar, NamespaceData.NamespacePathSeparator);
                }
                else
                {
                    string rootName = $@"{Assembly.LoadFile(assemblyLocation).ResolveRootNamespace()} ({FileVersionInfo.GetVersionInfo(assemblyLocation).ProductVersion}).";

                    int i = fullPath.IndexOf(rootName, StringComparison.Ordinal);

                    if (i == -1)
                    {
                        optimizedPath = fullPath;
                    }
                    else
                    {
                        optimizedPath = fullPath.Replace(rootName, "");
                    }
                }

                // Split the paths
                var splitPaths = optimizedPath.Split(NamespaceData.NamespacePathSeparator);

                // Loop thru each split path and add the data
                namespaceData.AddRange(splitPaths.Select(paths => new NamespaceData(paths)));

                // Return the data list
                return namespaceData;
            }
        }

        #endregion
    }
}