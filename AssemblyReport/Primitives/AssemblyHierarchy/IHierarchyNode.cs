#region License

// ********************************* Header *********************************\
// 
//    Class:  IHierarchyNode.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using AssemblyReport.Enumerators;

#endregion

namespace AssemblyReport.Primitives.AssemblyHierarchy
{
    /// <summary>The <see cref="IHierarchyNode"/> interface.</summary>
    public interface IHierarchyNode : IDisposable
    {
        #region Public Properties

        /// <summary>Gets the name of the assembly.</summary>
        /// <value>The name of the assembly.</value>
        AssemblyName AssemblyName { get; }

        /// <summary>Gets the assembly path.</summary>
        /// <value>The assembly path.</value>
        string AssemblyPath { get; }

        /// <summary>Gets the children.</summary>
        /// <value>The children.</value>
        IList<HierarchyNode> Children { get; }

        /// <summary>Gets the count.</summary>
        /// <value>The count.</value>
        int Count { get; }

        /// <summary>Gets the full name.</summary>
        /// <value>The full name.</value>
        string FullName { get; }

        /// <summary>Gets or sets the index of the image.</summary>
        /// <value>The index of the image.</value>
        int ImageIndex { get; }

        /// <summary>Gets the type of the information.</summary>
        /// <value>The type of the information.</value>
        MemberInfoTypes InfoType { get; }

        /// <summary>Gets the inherited hierarchy.</summary>
        /// <value>The inherited hierarchy.</value>
        IList<Type> InheritedHierarchy { get; }

        /// <summary>Gets a value indicating whether this instance is base node.</summary>
        /// <value><c>true</c> if this instance is base node; otherwise, <c>false</c>.</value>
        bool IsBaseNode { get; }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>Gets the namespace.</summary>
        /// <value>The namespace.</value>
        string Namespace { get; }

        /// <summary>Gets the namespaces.</summary>
        /// <value>The namespaces.</value>
        List<string> Namespaces { get; }

        /// <summary>Gets the type of the node.</summary>
        /// <value>The type of the node.</value>
        Type NodeType { get; }

        /// <summary>Gets or sets the tag.</summary>
        /// <value>The tag.</value>
        object Tag { get; set; }

        /// <summary>Gets the type image.</summary>
        /// <value>The type image.</value>
        Image TypeImage { get; }

        #endregion
    }
}