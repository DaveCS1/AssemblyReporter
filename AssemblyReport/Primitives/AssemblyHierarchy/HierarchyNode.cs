#region License

// ********************************* Header *********************************\
// 
//    Class:  HierarchyNode.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using AssemblyReport.Enumerators;
using AssemblyReport.Extensibility;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives.AssemblyHierarchy
{
    /// <summary>The <see cref="HierarchyNode"/> structure provides information about the <see cref="Type"/> node.</summary>
    [DebuggerDisplay("FullName = {FullName}, Count = {Count}")]
    public struct HierarchyNode : IHierarchyNode
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="HierarchyNode"/> class.</summary>
        /// <param name="source">The source type.</param>
        /// <param name="isBaseNode">Indicates whether a base node.</param>
        /// <param name="children">The children nodes.</param>
        public HierarchyNode(Type source, bool isBaseNode = false, List<HierarchyNode> children = null) : this(source, isBaseNode)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), @"The source cannot be null.");
            }
            else
            {
                if (source.IsGenericType && source.IsGenericParameter)
                {
                    var parameters = source.GetGenericParameterConstraints().Select(x => x.Name);
                    Name = $"{source.Name}<{string.Join(", ", parameters)}>";
                }
                else
                {
                    Name = source.Name;
                }
            }

            if (children != null)
            {
                Children = new List<HierarchyNode>(children);
            }
            else
            {
                Children = new List<HierarchyNode>();
            }
        }

        /// <summary>Initializes a new instance of the <see cref="HierarchyNode"/> class.</summary>
        /// <param name="nodeType">Type of the node.</param>
        /// <param name="isBaseNode">Whether its a base node.</param>
        private HierarchyNode(Type nodeType, bool isBaseNode = false) : this()
        {
            if (nodeType != null)
            {
                AssemblyName = AssemblyName.GetAssemblyName(nodeType.Assembly.Location);
                InfoType = nodeType.MemberType.ConvertToMemberInfoTypes(nodeType);
                Namespace = nodeType.Namespace;
                NodeType = nodeType;
                ImageIndex = ImageUtil.GetMemberImageIndex(InfoType);
            }
            else
            {
                AssemblyName = new AssemblyName();
                ImageIndex = 1;
                InfoType = MemberInfoTypes.Class;
            }

            AssemblyPath = string.Empty;
            Children = new List<HierarchyNode>();
            IsBaseNode = isBaseNode;
            Namespaces = new List<string>();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the name of the assembly.</summary>
        /// <value>The name of the assembly.</value>
        public AssemblyName AssemblyName { get; }

        /// <summary>Gets the assembly path.</summary>
        /// <value>The assembly path.</value>
        public string AssemblyPath { get; }

        /// <summary>Gets the children.</summary>
        /// <value>The children.</value>
        public IList<HierarchyNode> Children { get; }

        /// <summary>Gets the count.</summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return Children.Count; }
        }

        /// <summary>Gets the full name.</summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get { return Namespace + '.' + Name; }
        }

        /// <summary>Gets or sets the index of the image.</summary>
        /// <value>The index of the image.</value>
        public int ImageIndex { get; }

        /// <summary>Gets the type of the information.</summary>
        /// <value>The type of the information.</value>
        public MemberInfoTypes InfoType { get; }

        /// <summary>Gets the inherited hierarchy.</summary>
        /// <value>The inherited hierarchy.</value>
        public IList<Type> InheritedHierarchy
        {
            get { return TypesUtil.GetInheritanceHierarchy(NodeType).ToList(); }
        }

        /// <summary>Gets a value indicating whether this instance is base node.</summary>
        /// <value><c>true</c> if this instance is base node; otherwise, <c>false</c>.</value>
        public bool IsBaseNode { get; }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>Gets the namespace.</summary>
        /// <value>The namespace.</value>
        public string Namespace { get; }

        /// <summary>Gets the contained namespaces.</summary>
        /// <value>The namespaces.</value>
        public List<string> Namespaces { get; }

        /// <summary>Gets the source.</summary>
        /// <value>The source.</value>
        public Type NodeType { get; }

        /// <summary>Gets or sets the tag.</summary>
        /// <value>The tag.</value>
        public object Tag { get; set; }

        /// <summary>Gets the node type image.</summary>
        /// <value>The node type image.</value>
        public Image TypeImage
        {
            get { return ImageUtil.ResolveMemberTypeImage(InfoType); }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            // Do nothing.
        }

        #endregion
    }
}