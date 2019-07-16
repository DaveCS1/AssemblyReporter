#region License

// ********************************* Header *********************************\
// 
//    Class:  IHierarchyTree.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using AssemblyReport.Primitives.AssemblyHierarchy;
using AssemblyReport.Primitives.BlackListedElements;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="IHierarchyTree"/> interface.</summary>
    public interface IHierarchyTree
    {
        #region Public Properties

        /// <summary>Gets the assembly.</summary>
        /// <value>The assembly.</value>
        [Browsable(false)]
        Assembly Assembly { get; }

        /// <summary>Gets the blacklist.</summary>
        /// <value>The blacklist.</value>
        [Browsable(false)]
        BlacklistElements Blacklist { get; }

        /// <summary>Gets the classes.</summary>
        /// <value>The classes.</value>
        [Browsable(false)]
        List<HierarchyNode> Classes { get; }

        /// <summary>Gets the delegates.</summary>
        /// <value>The delegates.</value>
        [Browsable(false)]
        List<HierarchyNode> Delegates { get; }

        /// <summary>Gets the enumerators.</summary>
        /// <value>The enumerators.</value>
        [Browsable(false)]
        List<HierarchyNode> Enumerators { get; }

        /// <summary>Gets the events.</summary>
        /// <value>The events.</value>
        [Browsable(false)]
        List<HierarchyNode> Events { get; }

        /// <summary>Gets the exported types.</summary>
        /// <value>The exported types.</value>
        List<Type> ExportedTypes { get; }

        /// <summary>Gets the interfaces.</summary>
        /// <value>The interfaces.</value>
        [Browsable(false)]
        List<HierarchyNode> Interfaces { get; }

        /// <summary>Gets the namespaces.</summary>
        /// <value>The namespaces.</value>
        [Browsable(false)]
        List<AssemblyScope.AssemblyScope> Namespaces { get; }

        /// <summary>Gets the structures.</summary>
        /// <value>The structures.</value>
        [Browsable(false)]
        List<HierarchyNode> Structures { get; }

        #endregion
    }
}