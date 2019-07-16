#region License

// ********************************* Header *********************************\
// 
//    Class:  TypesUtil.cs
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
using System.Windows.Forms;
using AssemblyReport.Extensibility;
using AssemblyReport.Primitives.AssemblyHierarchy;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="TypesUtil"/> class.</summary>
    public static class TypesUtil
    {
        #region Public Methods and Operators

        /// <summary>Creates the using text.</summary>
        /// <param name="namespaces">The namespaces.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateUsingText(IEnumerable<string> namespaces)
        {
            return namespaces.Aggregate(string.Empty, (u, n) => u + "using " + n + ";" + Environment.NewLine);
        }

        /// <summary>Returns the default root namespace name.</summary>
        /// <param name="assemblyLocation">The assembly location.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string DefaultNamespace(string assemblyLocation)
        {
            if (string.IsNullOrEmpty(assemblyLocation))
            {
                throw new ArgumentNullException(nameof(assemblyLocation), @"The assembly location cannot be null or empty.");
            }

            if (!File.Exists(assemblyLocation))
            {
                throw new FileNotFoundException(@"The assembly file cannot be found.", assemblyLocation);
            }

            if (!AsmUtil.IsAssembly(assemblyLocation))
            {
                throw new ArgumentNullException(nameof(assemblyLocation), @"The assembly location doesn't link to an assembly file.");
            }

            string defaultNamespace = string.Empty;

            try
            {
                AssemblyName name = AssemblyName.GetAssemblyName(assemblyLocation);
                defaultNamespace = name.Name;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return defaultNamespace;
        }

        /// <summary>Returns the default root namespace name.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string DefaultNamespace(Assembly assembly)
        {
            return DefaultNamespace(assembly.Location);
        }

        /// <summary>Filters to top level.</summary>
        /// <param name="namespaces">The namespaces.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        public static IEnumerable<string> FilterToTopLevel(IEnumerable<string> namespaces)
        {
            return namespaces.Select(n => n.Split('.').First()).Distinct();
        }

        /// <summary>Generates a <see cref="TreeNode"/> element from the <see cref="Assembly"/> types.</summary>
        /// <param name="location">The assembly location.</param>
        /// <returns>The <see cref="TreeNode"/>.</returns>
        public static TreeNode GenerateTreeView(string location)
        {
            Assembly assembly = Assembly.LoadFile(location);

            string rootName = $@"{assembly.ResolveRootNamespace()} ({FileVersionInfo.GetVersionInfo(location).ProductVersion})";
            TreeNode mainTreeNode = new TreeNode(rootName, 0, 0);

            // Load all the namespace groups
            var namespaceGroups = assembly.GetTypes().Where(type => (type.IsClass && type.IsVisible && type.IsPublic && !type.IsGenericType && !type.IsNested && !type.IsGenericParameter && !type.IsGenericTypeDefinition) || // Only include the public specified class types.
                                                                    type.IsStructure() || (type.IsEnum && !type.IsNested) || type.IsDelegate() || type.IsInterface).GroupBy(typeGroup => typeGroup.Namespace); // Organize by namespace.

            // Loop through each namespace group
            foreach (var groupContainer in namespaceGroups)
            {
                // Add namespace to node
                TreeNode treeNode = mainTreeNode.Nodes.Add(groupContainer.Key, groupContainer.Key, 1, 1);

                // Loop thru each namespace group
                foreach (Type type in groupContainer)
                {
                    // Add the type in the group to the tree node
                    HierarchyNode hierarchyNode = new HierarchyNode(type);

                    // The class type info item to node
                    TreeNode unused = treeNode.Nodes.Add(type.Name, type.Name, hierarchyNode.ImageIndex, hierarchyNode.ImageIndex);
                }
            }

            return mainTreeNode;
        }

        /// <summary>Gets the base types by desc.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="Stack{T}"/>.</returns>
        public static Stack<Type> GetBaseTypesByDesc(Type type)
        {
            var result = new Stack<Type>();

            Type current = type.BaseType;

            while (current != null)
            {
                result.Push(current);
                current = current.BaseType;
            }

            return result;
        }

        /// <summary>Gets the enumerator values to text (Ex: Item1, Item2, Item3.).</summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetEnumeratorValues(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type), @"The type cannot be a null value.");
            }

            if (type.IsEnum)
            {
                var names = Enum.GetNames(type);
                string enumValues = string.Empty;

                for (var index = 0; index < names.Length; index++)
                {
                    string valueName = names[index];

                    if (index == names.Length - 1)
                    {
                        enumValues += valueName;
                    }
                    else
                    {
                        enumValues += valueName + ", ";
                    }
                }

                return enumValues;
            }

            return string.Empty;
        }

        /// <summary>Gets the inheritance hierarchy.</summary>
        /// <param name="type">The type.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        public static IEnumerable<Type> GetInheritanceHierarchy(Type type)
        {
            for (Type current = type; current != null; current = current.BaseType)
            {
                yield return current;
            }
        }

        /// <summary>Gets the namespaces contained in the assembly.</summary>
        /// <param name="assemblyPath">The assembly location.</param>
        /// <param name="blackList">The black list.</param>
        /// <returns>The <see cref="IEnumerable{T}"/>.</returns>
        public static List<string> GetNamespaces(string assemblyPath, List<string> blackList)
        {
            var list = Assembly.LoadFile(assemblyPath).GetTypes().Select(type => type.Namespace).Where(value => !string.IsNullOrEmpty(value)).Distinct().ToList();

            if ((blackList != null) && (blackList.Count > 0))
            {
                foreach (string blackListItem in blackList)
                {
                    int unused = list.RemoveAll(x => x.ToString().Equals(blackListItem));
                }
            }

            return list;
        }

        /// <summary>Gets the top level namespace.</summary>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public static string GetTopLevelNamespace(Type t)
        {
            string ns = t.Namespace ?? "";
            int firstDot = ns.IndexOf('.');
            return firstDot == -1 ? ns : ns.Substring(0, firstDot);
        }

        /// <summary>Gets the types in the specified namespace.</summary>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <param name="nameSpace">The name space.</param>
        /// <returns>The <see cref="Type"/>.</returns>
        public static Type[] GetTypesInNamespace(string assemblyPath, string nameSpace)
        {
            return Assembly.LoadFile(assemblyPath).GetTypes().Where(itemType => string.Equals(itemType.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        /// <summary>Validates whether the namespace exists in the assemblies.</summary>
        /// <param name="assemblies">The assemblies.</param>
        /// <param name="namespaceName">The namespace name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool NamespaceExists(this IEnumerable<Assembly> assemblies, string namespaceName)
        {
            foreach (Assembly assembly in assemblies)
            {
                if (assembly.GetTypes().Any(type => type.Namespace == namespaceName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>Searches the specified member name.</summary>
        /// <param name="memberName">Name of the member.</param>
        /// <returns></returns>
        public static Type Search(string memberName)
        {
            Type type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).FirstOrDefault(x => x.Name == memberName);
            return type;
        }

        #endregion
    }
}