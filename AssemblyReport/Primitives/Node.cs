#region License

// ********************************* Header *********************************\
// 
//    Class:  Node.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using AssemblyReport.Extensibility;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="Node{T}"/> class.</summary>
    /// <typeparam name="NValue">The type parameter.</typeparam>
    [DebuggerDisplay("Name = {Name}, Count = {Count}, Level = {Level}")]
    public class Node<NValue> : IEqualityComparer, IEnumerable<NValue>, IEnumerable<Node<NValue>>, INotifyPropertyChanged
    {
        #region Fields

        private readonly List<Node<NValue>> childNodes;

        private string assemblyLocation;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="Node{T}"/> class.</summary>
        /// <param name="value">The value.</param>
        public Node(NValue value) : this()
        {
            Value = value;
        }

        /// <summary>Prevents a default instance of the <see cref="Node{NValue}"/> class from being created.</summary>
        private Node()
        {
            childNodes = new List<Node<NValue>>();
            assemblyLocation = string.Empty;
        }

        #endregion

        #region Public Events

        /// <summary>Occur when a property value has changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>Gets all.</summary>
        /// <value>All.</value>
        public IEnumerable<Node<NValue>> All
        {
            get { return Root.SelfAndDescendants; }
        }

        /// <summary>Gets the ancestors.</summary>
        /// <value>The ancestors.</value>
        public IEnumerable<Node<NValue>> Ancestors
        {
            get
            {
                if (IsRoot)
                {
                    return Enumerable.Empty<Node<NValue>>();
                }

                return Parent.ToIEnumerable().Concat(Parent.Ancestors);
            }
        }

        /// <summary>Gets or sets the assembly path.</summary>
        /// <value>The assembly path.</value>
        public string AssemblyPath
        {
            get { return assemblyLocation; }

            set
            {
                if (assemblyLocation != value)
                {
                    assemblyLocation = value;
                    OnPropertyChanged(nameof(assemblyLocation));
                }
            }
        }

        /// <summary>Gets the children.</summary>
        /// <value>The children.</value>
        public IEnumerable<Node<NValue>> Children
        {
            get { return childNodes; }
        }

        /// <summary>Gets the count.</summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return childNodes.Count; }
        }

        /// <summary>Gets the descendants.</summary>
        /// <value>The descendants.</value>
        public IEnumerable<Node<NValue>> Descendants
        {
            get { return SelfAndDescendants.Skip(1); }
        }

        /// <summary>Gets a value indicating whether this instance has child.</summary>
        /// <value>The <see cref="bool"/>.</value>
        public bool HasChild
        {
            get { return Children.Any(); }
        }

        /// <summary>Gets or sets the index of the image.</summary>
        /// <value>The index of the image.</value>
        public int ImageIndex { get; set; }

        /// <summary>Gets a value indicating whether this instance is root.</summary>
        /// <value><c>true</c> if this instance is root; otherwise, <c>false</c>.</value>
        public bool IsRoot
        {
            get { return Parent == null; }
        }

        /// <summary>Gets the level.</summary>
        /// <value>The level.</value>
        public int Level
        {
            get { return Ancestors.Count(); }
        }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets the parent.</summary>
        /// <value>The parent.</value>
        public Node<NValue> Parent { get; private set; }

        /// <summary>Gets the root.</summary>
        /// <value>The root.</value>
        public Node<NValue> Root
        {
            get { return SelfAndAncestors.Last(); }
        }

        /// <summary>Gets the same level.</summary>
        /// <value>The same level.</value>
        public IEnumerable<Node<NValue>> SameLevel
        {
            get { return SelfAndSameLevel.Where(Other); }
        }

        /// <summary>Gets the self and ancestors.</summary>
        /// <value>The self and ancestors.</value>
        public IEnumerable<Node<NValue>> SelfAndAncestors
        {
            get { return this.ToIEnumerable().Concat(Ancestors); }
        }

        /// <summary>Gets the self and children.</summary>
        /// <value>The self and children.</value>
        public IEnumerable<Node<NValue>> SelfAndChildren
        {
            get { return this.ToIEnumerable().Concat(Children); }
        }

        /// <summary>Gets the self and descendants.</summary>
        /// <value>The self and descendants.</value>
        public IEnumerable<Node<NValue>> SelfAndDescendants
        {
            get { return this.ToIEnumerable().Concat(Children.SelectMany(c => c.SelfAndDescendants)); }
        }

        /// <summary>Gets the self and same level.</summary>
        /// <value>The self and same level.</value>
        public IEnumerable<Node<NValue>> SelfAndSameLevel
        {
            get { return GetNodesAtLevel(Level); }
        }

        /// <summary>Gets the self and siblings.</summary>
        /// <value>The self and siblings.</value>
        public IEnumerable<Node<NValue>> SelfAndSiblings
        {
            get
            {
                if (IsRoot)
                {
                    return this.ToIEnumerable();
                }

                return Parent.Children;
            }
        }

        /// <summary>Gets the siblings.</summary>
        /// <value>The siblings.</value>
        public IEnumerable<Node<NValue>> Siblings
        {
            get { return SelfAndSiblings.Where(Other); }
        }

        /// <summary>Gets or sets the tag.</summary>
        /// <value>The tag.</value>
        [Browsable(false)]
        public object Tag { get; set; }

        /// <summary>Gets or sets the text.</summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        public NValue Value { get; set; }

        #endregion

        #region Public Indexers

        /// <summary>Gets the <see cref="Node{NValue}"/> at the specified index.</summary>
        /// <value>The <see cref="Node{NValue}"/>.</value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Node<NValue> this[int index]
        {
            get { return childNodes[index]; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Creates the tree.</summary>
        /// <typeparam name="TId">The type of the identifier.</typeparam>
        /// <param name="values">The values.</param>
        /// <param name="idSelector">The identifier selector.</param>
        /// <param name="parentIdSelector">The parent identifier selector.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">At least one value has the samen Id and parentId [{0}]".FormatInvariant(itemWithIdAndParentIdIsTheSame)</exception>
        public static IEnumerable<Node<NValue>> CreateTree<TId>(IEnumerable<NValue> values, Func<NValue, TId> idSelector, Func<NValue, TId?> parentIdSelector)
            where TId : struct
        {
            var valuesCache = values.ToList();

            if (!valuesCache.Any())
            {
                return Enumerable.Empty<Node<NValue>>();
            }

            NValue itemWithIdAndParentIdIsTheSame = valuesCache.FirstOrDefault(v => IsSameId(idSelector(v), parentIdSelector(v)));

            if (itemWithIdAndParentIdIsTheSame != null)
            {
                throw new ArgumentException("At least one value has the same Id and parentId [{0}]".FormatInvariant(itemWithIdAndParentIdIsTheSame));
            }

            var nodes = valuesCache.Select(v => new Node<NValue>(v));
            return CreateTree(nodes, idSelector, parentIdSelector);
        }

        /// <summary>Creates the tree.</summary>
        /// <typeparam name="TId">The type of the identifier.</typeparam>
        /// <param name="rootNodes">The root nodes.</param>
        /// <param name="idSelector">The identifier selector.</param>
        /// <param name="parentIdSelector">The parent identifier selector.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">One or more values contains {0} duplicate keys. The first duplicate is: [{1}]".FormatInvariant(duplicates.Count, duplicates[0]) or A value has the parent ID [{0}] but no other nodes has this ID".FormatInvariant(parentId.Value)</exception>
        public static IEnumerable<Node<NValue>> CreateTree<TId>(IEnumerable<Node<NValue>> rootNodes, Func<NValue, TId> idSelector, Func<NValue, TId?> parentIdSelector)
            where TId : struct

        {
            var rootNodesCache = rootNodes.ToList();
            var duplicates = rootNodesCache.Duplicates(n => n).ToList();

            if (duplicates.Any())
            {
                throw new ArgumentException("One or more values contains {0} duplicate keys. The first duplicate is: [{1}]".FormatInvariant(duplicates.Count, duplicates[0]));
            }

            foreach (var rootNode in rootNodesCache)
            {
                var parentId = parentIdSelector(rootNode.Value);
                var parent = rootNodesCache.FirstOrDefault(n => IsSameId(idSelector(n.Value), parentId));

                if (parent != null)
                {
                    parent.Add(rootNode);
                }
                else if (parentId != null)
                {
                    throw new ArgumentException("A value has the parent ID [{0}] but no other nodes has this ID".FormatInvariant(parentId.Value));
                }
            }

            var result = rootNodesCache.Where(n => n.IsRoot);
            return result;
        }

        /// <summary>Adds the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Node{NValue}"/>.</returns>
        public Node<NValue> Add(NValue value, int index = -1)
        {
            var childNode = new Node<NValue>(value);
            Add(childNode, index);
            return childNode;
        }

        /// <summary>Adds the specified child node.</summary>
        /// <param name="childNode">The child node.</param>
        /// <param name="index">The index.</param>
        /// <exception cref="ArgumentException">The index can not be lower then -1 or The index ({0}) can not be higher then index of the last item. Use the AddChild() method without an index to add at the end".FormatInvariant(index) or The child node with value [{0}] can not be added because it is not a root node.".FormatInvariant(childNode.Value) or The child node with value [{0}] is the root node of the parent.".FormatInvariant(childNode.Value) or The child node with value [{0}] can not be added to itself or its descendants.".FormatInvariant(childNode.Value)</exception>
        public void Add(Node<NValue> childNode, int index = -1)
        {
            if (index < -1)
            {
                throw new ArgumentException("The index can not be lower then -1");
            }

            if (index > Children.Count() - 1)
            {
                throw new ArgumentException("The index ({0}) can not be higher then index of the last item. Use the AddChild() method without an index to add at the end".FormatInvariant(index));
            }

            if (!childNode.IsRoot)
            {
                throw new ArgumentException("The child node with value [{0}] can not be added because it is not a root node.".FormatInvariant(childNode.Value));
            }

            if (Root == childNode)
            {
                throw new ArgumentException("The child node with value [{0}] is the root node of the parent.".FormatInvariant(childNode.Value));
            }

            if (childNode.SelfAndDescendants.Any(n => this == n))
            {
                throw new ArgumentException("The child node with value [{0}] can not be added to itself or its descendants.".FormatInvariant(childNode.Value));
            }

            childNode.Parent = this;

            if (index == -1)
            {
                childNodes.Add(childNode);
            }
            else
            {
                childNodes.Insert(index, childNode);
            }
        }

        /// <summary>Adds the children.</summary>
        /// <param name="values">The values.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public Node<NValue>[] AddChildren(params NValue[] values)
        {
            return values.Select(Add).ToArray();
        }

        /// <summary>Adds the first child.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Node<NValue> AddFirstChild(NValue value)
        {
            var childNode = new Node<NValue>(value);
            AddFirstChild(childNode);
            return childNode;
        }

        /// <summary>Adds the first child.</summary>
        /// <param name="childNode">The child node.</param>
        public void AddFirstChild(Node<NValue> childNode)
        {
            Add(childNode, 0);
        }

        /// <summary>Adds the first sibling.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Node<NValue> AddFirstSibling(NValue value)
        {
            var childNode = new Node<NValue>(value);
            AddFirstSibling(childNode);
            return childNode;
        }

        /// <summary>Adds the first sibling.</summary>
        /// <param name="childNode">The child node.</param>
        public void AddFirstSibling(Node<NValue> childNode)
        {
            Parent.AddFirstChild(childNode);
        }

        /// <summary>Adds the last sibling.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Node<NValue> AddLastSibling(NValue value)
        {
            var childNode = new Node<NValue>(value);
            AddLastSibling(childNode);
            return childNode;
        }

        /// <summary>Adds the last sibling.</summary>
        /// <param name="childNode">The child node.</param>
        public void AddLastSibling(Node<NValue> childNode)
        {
            Parent.Add(childNode);
        }

        /// <summary>Adds the parent.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Node<NValue> AddParent(NValue value)
        {
            var newNode = new Node<NValue>(value);
            AddParent(newNode);
            return newNode;
        }

        /// <summary>Adds the parent.</summary>
        /// <param name="parentNode">The parent node.</param>
        /// <exception cref="ArgumentException">This node [{0}] already has a parent".FormatInvariant(Value) - parentNode</exception>
        public void AddParent(Node<NValue> parentNode)
        {
            if (!IsRoot)
            {
                throw new ArgumentException("This node [{0}] already has a parent".FormatInvariant(Value), "parentNode");
            }

            parentNode.Add(this);
        }

        /// <summary>Determines whether this instance contains the object.</summary>
        /// <param name="item">The item.</param>
        /// <returns><c>true</c> if [contains] [the specified item]; otherwise, <c>false</c>.</returns>
        public bool Contains(NValue item)
        {
            bool contains = false;

            foreach (Node<NValue> node in All)
            {
                if (node.Children.Equals(item))
                {
                    contains = true;
                    break;
                }
            }

            return contains;
        }

        /// <summary>Disconnects this instance.</summary>
        /// <exception cref="InvalidOperationException">The root node [{0}] can not get disconnected from a parent.".FormatInvariant(Value)</exception>
        public void Disconnect()
        {
            if (IsRoot)
            {
                throw new InvalidOperationException("The root node [{0}] can not get disconnected from a parent.".FormatInvariant(Value));
            }

            Parent.childNodes.Remove(this);
            Parent = null;
        }

        /// <summary>Finds the node by the value.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="Node{NValue}"/>.</returns>
        public Node<NValue> FindByValue(NValue value)
        {
            // search the list for the value
            foreach (Node<NValue> node in Children)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            // if we reached here, we didn't find a matching node
            return null;
        }

        /// <summary>Flattens this instance.</summary>
        /// <returns></returns>
        public IEnumerable<NValue> Flatten()
        {
            return new[] {Value}.Concat(childNodes.SelectMany(x => x.Flatten()));
        }

        /// <summary>Gets the child.</summary>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="Node{NValue}"/>.</returns>
        public Node<NValue> GetChild(int index)
        {
            foreach (var child in childNodes)
            {
                if (--index == 0)
                {
                    return child;
                }
            }

            return null;
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<Node<NValue>> GetEnumerator()
        {
            return childNodes.GetEnumerator();
        }

        /// <summary>Gets the nodes at level.</summary>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        public IEnumerable<Node<NValue>> GetNodesAtLevel(int level)
        {
            return Root.GetNodesAtLevelInternal(level);
        }

        /// <summary>Inserts the child.</summary>
        /// <param name="parent">The parent.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Node<NValue> InsertChild(Node<NValue> parent, NValue value)
        {
            var node = new Node<NValue>(value)
            {
                Parent = parent
            };

            parent.childNodes.Add(node);

            return node;
        }

        /// <summary>Removes the child.</summary>
        /// <param name="node">The node.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool RemoveChild(Node<NValue> node)
        {
            return childNodes.Remove(node);
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }

        #endregion

        #region Explicit Interface Methods

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator<NValue> IEnumerable<NValue>.GetEnumerator()
        {
            return childNodes.Values().GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return childNodes.GetEnumerator();
        }

        #endregion

        #region Methods

        /// <summary>Called when property changed.</summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>Determines whether [is same identifier] [the specified identifier].</summary>
        /// <typeparam name="TId">The type of the identifier.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <returns><c>true</c> if [is same identifier] [the specified identifier]; otherwise, <c>false</c>.</returns>
        private static bool IsSameId<TId>(TId id, TId? parentId)
            where TId : struct
        {
            return (parentId != null) && id.Equals(parentId.Value);
        }

        /// <summary>Gets the nodes at level internal.</summary>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        private IEnumerable<Node<NValue>> GetNodesAtLevelInternal(int level)
        {
            if (level == Level)
            {
                return this.ToIEnumerable();
            }

            return Children.SelectMany(c => c.GetNodesAtLevelInternal(level));
        }

        /// <summary>Others the specified node.</summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private bool Other(Node<NValue> node)
        {
            return !ReferenceEquals(node, this);
        }

        #endregion

        #region Equals Operator

        /// <summary>Implements the operator ==.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Node<NValue> value1, Node<NValue> value2)
        {
            if (((object)value1 == null) && ((object)value2 == null))
            {
                return true;
            }

            return ReferenceEquals(value1, value2);
        }

        /// <summary>Implements the operator !=.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Node<NValue> value1, Node<NValue> value2)
        {
            return !(value1 == value2);
        }

        /// <summary>Determines whether the specified object is equal to the current object.</summary>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <returns><see langword="true"/> if the specified object  is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            var valueThisType = obj as Node<NValue>;
            return this == valueThisType;
        }

        /// <summary>Equals the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool Equals(Node<NValue> value)
        {
            return this == value;
        }

        /// <summary>Equals the specified value1.</summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns></returns>
        public bool Equals(Node<NValue> value1, Node<NValue> value2)
        {
            return value1 == value2;
        }

        /// <summary>Determines whether the specified objects are equal.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns><see langword="true"/> if the specified objects are equal; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="T:System.ArgumentException">value 1 and 2 are of different types and neither one can handle comparisons with the other.</exception>
        bool IEqualityComparer.Equals(object value1, object value2)
        {
            var valueThisType1 = value1 as Node<NValue>;
            var valueThisType2 = value2 as Node<NValue>;

            return Equals(valueThisType1, valueThisType2);
        }

        /// <summary>Returns a hash code for the specified object.</summary>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param>
        /// <returns>A hash code for the specified object.</returns>
        /// <exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is <see langword="null"/>.</exception>
        public int GetHashCode(object obj)
        {
            return GetHashCode(obj as Node<NValue>);
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return GetHashCode(this);
        }

        /// <summary>Serves as the default hash function. </summary>
        /// <returns>A hash code for the current object.</returns>
        /// <param name="value">The value for which a hash code is to be returned.</param>
        public int GetHashCode(Node<NValue> value)
        {
            return base.GetHashCode();
        }

        #endregion
    }
}