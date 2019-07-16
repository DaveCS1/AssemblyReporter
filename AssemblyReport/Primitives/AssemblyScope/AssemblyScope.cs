#region License

// ********************************* Header *********************************\
// 
//    Class:  AssemblyScope.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using AssemblyReport.Enumerators;
using AssemblyReport.Extensibility;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives.AssemblyScope
{
    /// <summary>The <see cref="AssemblyScope"/> structure.</summary>
    [DebuggerDisplay("FullName = {FullName}, Description = {Description}")]
    public class AssemblyScope : IAssemblyScope
    {
        #region Static Fields

        /// <summary>Gets the empty value for the <see cref="AssemblyScope"/>, that represents the current object. This <see langword="static"/> field is read-only.</summary>
        public static readonly AssemblyScope Empty = new AssemblyScope();

        #endregion

        #region Fields

        private string name;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="AssemblyScope"/> struct.</summary>
        public AssemblyScope(Type type) : this(type.Assembly.Location, type.Namespace, type.Name)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="AssemblyScope"/> struct.</summary>
        /// <param name="filePath">The file path to the assembly.</param>
        /// <param name="namespaceText">The namespace text.</param>
        /// <param name="name">The name.</param>
        public AssemblyScope(string filePath, string namespaceText, string name) : this()
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                Assembly assembly = Assembly.LoadFile(filePath);

                Location = filePath;
                Root = assembly.ResolveRootNamespace();

                if (string.IsNullOrEmpty(namespaceText))
                {
                    if (!Root.Equals(name))
                    {
                        namespaceText = Root;
                    }
                }

                string comboPath = NamespaceScope.CombineNamespacePaths(namespaceText, name);
                NamespaceInformation = new NamespaceScope(filePath, comboPath);

                if (NamespaceInformation.IsNamespace)
                {
                    if (!string.IsNullOrEmpty(NamespaceInformation.FullPath))
                    {
                        TypeInfo = assembly.GetType(NamespaceInformation.FullPath);
                    }
                    else
                    {
                        TypeInfo = null;
                    }
                }
            }
        }

        /// <summary>Initializes a new instance of the <see cref="AssemblyScope"/> struct.</summary>
        public AssemblyScope()
        {
            TypeInfo = null;
            Location = string.Empty;
            Root = string.Empty;
            Name = string.Empty;
            NamespaceInformation = new NamespaceScope();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the description.</summary>
        /// <value>The description.</value>
        [Category(CategoryConstants.Identification)]
        [DisplayName("Description")]
        [Description("Returns the description information for the type.")]
        [ReadOnly(true)]
        public string Description
        {
            get
            {
                string description;

                if (TypeInfo != null)
                {
                    description = DocumentationExtensions.GetSummary(TypeInfo);
                }
                else
                {
                    if (NamespaceInformation != null)
                    {
                        description = $@"The {NamespaceInformation.MemberName} namespace.";
                    }
                    else
                    {
                        description = string.Empty;
                    }
                }

                return description;
            }
        }

        /// <summary>Gets the full name.</summary>
        /// <value>The full name.</value>
        [Category(CategoryConstants.Identification)]
        [DisplayName("Full Name")]
        [Description("The full name of type.")]
        [ReadOnly(true)]
        public string FullName
        {
            get
            {
                if (NamespaceInformation != null)
                {
                    return NamespaceInformation.FullPath;
                }

                return string.Empty;
            }
        }

        /// <summary>Gets a value indicating whether this instance is empty.</summary>
        /// <value>Determines whether this instance is empty.</value>
        [Browsable(false)]
        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        /// <summary>Gets the location.</summary>
        /// <value>The location.</value>
        [Browsable(false)]
        public string Location { get; }

        /// <summary>Gets the member types.</summary>
        /// <value>The member types.</value>
        [Category(CategoryConstants.Identification)]
        [DisplayName("Member Type")]
        [Description("The member info type.")]
        [ReadOnly(true)]
        public MemberInfoTypes MemberType
        {
            get
            {
                MemberInfoTypes memberType;

                if (TypeInfo != null)
                {
                    memberType = TypeInfo.MemberType.ConvertToMemberInfoTypes(TypeInfo);
                }
                else
                {
                    memberType = MemberInfoTypes.Class;
                }

                return memberType;
            }
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        [Category(CategoryConstants.Type)]
        [DisplayName("Name")]
        [Description("The name of the type.")]
        [ReadOnly(true)]
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name) || name.Equals("..."))
                {
                    if (NamespaceInformation != null)
                    {
                        name = NamespaceInformation.MemberName;
                        return name;
                    }
                }
                else
                {
                    return name;
                }

                return string.Empty;
            }

            private set { name = value; }
        }

        /// <summary>Gets the namespace.</summary>
        /// <value>The namespace.</value>
        [Category(CategoryConstants.Type)]
        [DisplayName("Namespace")]
        [Description("The namespace of the type.")]
        [ReadOnly(true)]
        public string Namespace
        {
            get
            {
                if (NamespaceInformation != null)
                {
                    return NamespaceInformation.NamespacePath;
                }

                return string.Empty;
            }
        }

        /// <summary>Gets the namespace information.</summary>
        /// <value>The namespace information.</value>
        [Browsable(false)]
        public NamespaceScope NamespaceInformation { get; }

        /// <summary>Gets the root namespace.</summary>
        /// <value>The root namespace.</value>
        [Browsable(false)]
        public string Root { get; }

        /// <summary>Gets the type information.</summary>
        /// <value>The type information.</value>
        [Browsable(false)]
        public Type TypeInfo { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Resolves the type of the member.</summary>
        /// <param name="fullPath">The full path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ResolveMemberType(string fullPath)
        {
            var split = fullPath.Split(Path.DirectorySeparatorChar);
            return split[split.Length - 1];
        }

        /// <summary>Resolves the specified input to a <see cref="Type"/>.</summary>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <param name="namespacePath">The namespace path.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>The <see cref="Type"/>.</returns>
        public static Type ResolveType(string assemblyPath, string namespacePath, string typeName)
        {
            if (string.IsNullOrEmpty(assemblyPath))
            {
                throw new ArgumentNullException(nameof(assemblyPath), @"The assembly path cannot be null or empty when resolving a Type.");
            }

            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentNullException(nameof(typeName), @"The type name cannot be null or empty when resolving a Type.");
            }

            if (!AsmUtil.IsAssembly(assemblyPath))
            {
                throw new ArgumentNullException(nameof(assemblyPath), @"The assembly path doesn't link to an Assembly executable type file path.");
            }

            return ResolveType(Assembly.LoadFile(assemblyPath), namespacePath, typeName);
        }

        /// <summary>Resolves the specified input to a <see cref="Type"/>.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="namespacePath">The namespace path.</param>
        /// <param name="typeName">Name of the type.</param>
        /// <returns>The <see cref="Type"/>.</returns>
        public static Type ResolveType(Assembly assembly, string namespacePath, string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
            {
                throw new ArgumentNullException(nameof(typeName), @"The type name cannot be null or empty when resolving a Type.");
            }

            // Combine the path
            string fullPath = NamespaceScope.CombineNamespacePaths(namespacePath, typeName);

            // Resolve the type
            Type type = assembly.GetType(fullPath);

            return type;
        }

        /// <summary>Updates the scope name.</summary>
        /// <param name="scopeName">The name.</param>
        public void UpdateName(string scopeName)
        {
            name = scopeName;
        }

        #endregion
    }
}