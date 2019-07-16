#region License

// ********************************* Header *********************************\
// 
//    Class:  HierarchyTree.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AssemblyReport.Extensibility;
using AssemblyReport.Primitives.AssemblyHierarchy;
using AssemblyReport.Primitives.BlackListedElements;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="HierarchyTree"/> class.</summary>
    /// <seealso cref="IHierarchyTree"/>
    public class HierarchyTree : IHierarchyTree
    {
        #region Static Fields

        /// <summary>Gets the empty value for the <see cref="HierarchyTree"/>, that represents the current object. This <see langword="static"/> field is read-only.</summary>
        public static readonly HierarchyTree Empty = new HierarchyTree();

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="HierarchyTree"/> struct.</summary>
        /// <param name="location">The assembly location.</param>
        public HierarchyTree(string location) : this()
        {
            Assembly = Assembly.LoadFile(location);

            Blacklist = new BlacklistElements(location);
            ExportedTypes = Assembly.GetExportedTypes().ToList();
            Namespaces = ReadNamespaces();
            Classes = ReadClasses();
            Delegates = ReadDelegates();
            Enumerators = ReadEnumerators();
            Events = ReadEvents();
            Interfaces = ReadInterfaces();
            Structures = ReadStructures();
        }

        /// <summary>Initializes a new instance of the <see cref="HierarchyTree"/> class.</summary>
        public HierarchyTree()
        {
            Assembly = null;

            Blacklist = new BlacklistElements();
            ExportedTypes = new List<Type>();
            Namespaces = new List<AssemblyScope.AssemblyScope>();
            Classes = new List<HierarchyNode>();
            Delegates = new List<HierarchyNode>();
            Enumerators = new List<HierarchyNode>();
            Events = new List<HierarchyNode>();
            Interfaces = new List<HierarchyNode>();
            Structures = new List<HierarchyNode>();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the assembly.</summary>
        /// <value>The assembly.</value>
        [Browsable(false)]
        public Assembly Assembly { get; }

        /// <summary>Gets the blacklist.</summary>
        /// <value>The blacklist.</value>
        [Browsable(false)]
        public BlacklistElements Blacklist { get; }

        /// <summary>Gets the classes.</summary>
        /// <value>The classes.</value>
        [Browsable(false)]
        public List<HierarchyNode> Classes { get; }

        /// <summary>Gets the delegates.</summary>
        /// <value>The delegates.</value>
        [Browsable(false)]
        public List<HierarchyNode> Delegates { get; }

        /// <summary>Gets the enumerators.</summary>
        /// <value>The enumerators.</value>
        [Browsable(false)]
        public List<HierarchyNode> Enumerators { get; }

        /// <summary>Gets the events.</summary>
        /// <value>The events.</value>
        [Browsable(false)]
        public List<HierarchyNode> Events { get; }

        /// <summary>Gets the exported types.</summary>
        /// <value>The exported types.</value>
        [Browsable(false)]
        public List<Type> ExportedTypes { get; }

        /// <summary>Gets the interfaces.</summary>
        /// <value>The interfaces.</value>
        [Browsable(false)]
        public List<HierarchyNode> Interfaces { get; }

        /// <summary>Gets a value indicating whether this instance is empty.</summary>
        /// <value>Determines whether this instance is empty.</value>
        [Browsable(false)]
        public bool IsEmpty
        {
            get { return Equals(Empty); }
        }

        /// <summary>Gets the namespaces.</summary>
        /// <value>The namespaces.</value>
        [Browsable(false)]
        public List<AssemblyScope.AssemblyScope> Namespaces { get; }

        /// <summary>Gets the structures.</summary>
        /// <value>The structures.</value>
        [Browsable(false)]
        public List<HierarchyNode> Structures { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Reads the classes.</summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public List<HierarchyNode> ReadClasses()
        {
            var list = new List<HierarchyNode>();

            foreach (Type typeDefinition in ExportedTypes)
            {
                if (typeDefinition.IsClass && typeDefinition.IsPublic && typeDefinition.IsVisible && !typeDefinition.IsGenericType)
                {
                    HierarchyNode entry = new HierarchyNode(typeDefinition, true);

                    if (!list.Contains(entry))
                    {
                        list.Add(entry);
                    }
                }
            }

            return list;
        }

        /// <summary>Reads the delegates.</summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public List<HierarchyNode> ReadDelegates()
        {
            var list = new List<HierarchyNode>();

            foreach (Type typeDefinition in ExportedTypes)
            {
                if (typeDefinition.IsDelegate() && typeDefinition.IsPublic && typeDefinition.IsVisible && !typeDefinition.IsGenericType)
                {
                    HierarchyNode entry = new HierarchyNode(typeDefinition);

                    if (!list.Contains(entry))
                    {
                        list.Add(entry);
                    }
                }
            }

            return list;
        }

        /// <summary>Reads the enumerators.</summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public List<HierarchyNode> ReadEnumerators()
        {
            var list = new List<HierarchyNode>();

            foreach (Type typeDefinition in ExportedTypes)
            {
                if (typeDefinition.IsEnum && typeDefinition.IsPublic && typeDefinition.IsVisible)
                {
                    HierarchyNode entry = new HierarchyNode(typeDefinition);

                    if (!list.Contains(entry))
                    {
                        list.Add(entry);
                    }
                }
            }

            return list;
        }

        /// <summary>Reads the events.</summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public List<HierarchyNode> ReadEvents()
        {
            var list = new List<HierarchyNode>();

            foreach (Type typeDefinition in ExportedTypes)
            {
                if (typeDefinition.IsPublic && typeDefinition.IsVisible)
                {
                    var typeEvents = typeDefinition.GetEvents().ToList();

                    if (typeEvents.Count > 0)
                    {
                        foreach (EventInfo typeEvent in typeEvents)
                        {
                            if (typeEvent.Name == typeDefinition.Name)
                            {
                                HierarchyNode entry = new HierarchyNode(typeDefinition, true);

                                if (!list.Contains(entry))
                                {
                                    list.Add(entry);
                                }
                            }
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>Reads the interfaces.</summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public List<HierarchyNode> ReadInterfaces()
        {
            var list = new List<HierarchyNode>();

            foreach (Type typeDefinition in ExportedTypes)
            {
                if (typeDefinition.IsInterface && typeDefinition.IsPublic && typeDefinition.IsVisible)
                {
                    HierarchyNode entry = new HierarchyNode(typeDefinition, true);

                    if (!list.Contains(entry))
                    {
                        list.Add(entry);
                    }
                }
            }

            return list;
        }

        /// <summary>Reads the namespaces.</summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public List<AssemblyScope.AssemblyScope> ReadNamespaces()
        {
            // Add all namespaces
            var namespacePaths = TypesUtil.GetNamespaces(Assembly.Location, Blacklist.Namespaces);
            var assemblyScopes = new List<AssemblyScope.AssemblyScope>();

            foreach (string namespaceData in namespacePaths)
            {
                var split = namespaceData.Split(Path.DirectorySeparatorChar, NamespaceData.NamespacePathSeparator);

                // Breaks up the dn into a name member and namespace only
                string typeName = split[split.Length - 1];

                // Construct namespace path
                StringBuilder namespaceTextBuilder = new StringBuilder();
                int maxNamespaces = split.Length - 1;

                for (var i = 0; i < maxNamespaces; i++)
                {
                    if (i != 0)
                    {
                        if (i == maxNamespaces - 1)
                        {
                            namespaceTextBuilder.Append($@"{split[i]}");
                        }
                        else
                        {
                            // Add namespaces
                            namespaceTextBuilder.Append($@"{split[i]}.");
                        }
                    }
                }

                string namespacePath = namespaceTextBuilder.ToString();
                assemblyScopes.Add(new AssemblyScope.AssemblyScope(Assembly.Location, namespacePath, typeName));
            }

            if ((Blacklist.Types != null) && (Blacklist.Types.Count > 0))
            {
                foreach (string blackListItem in Blacklist.Types)
                {
                    int unused = assemblyScopes.RemoveAll(x => x.FullName.ToString().Equals(blackListItem));
                }
            }

            return assemblyScopes;
        }

        /// <summary>Reads the structures.</summary>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public List<HierarchyNode> ReadStructures()
        {
            var list = new List<HierarchyNode>();

            foreach (Type typeDefinition in ExportedTypes)
            {
                if (typeDefinition.IsPublic && typeDefinition.IsVisible && typeDefinition.IsStructure())
                {
                    HierarchyNode entry = new HierarchyNode(typeDefinition, true);

                    if (!list.Contains(entry))
                    {
                        list.Add(entry);
                    }
                }
            }

            return list;
        }

        #endregion
    }
}