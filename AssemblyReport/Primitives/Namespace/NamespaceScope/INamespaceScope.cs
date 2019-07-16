#region License

// ********************************* Header *********************************\
// 
//    Class:  INamespaceScope.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="INamespaceScope"/> interface.</summary>
    public interface INamespaceScope
    {
        #region Public Properties

        /// <summary>Gets the full path.</summary>
        /// <value>The full path.</value>
        string FullPath { get; }

        /// <summary>Gets the input.</summary>
        /// <value>The input.</value>
        string Input { get; }

        /// <summary>Gets a value indicating whether this instance is empty.</summary>
        /// <value>Determines whether this instance is empty.</value>
        bool IsEmpty { get; }

        /// <summary>Gets the whether the input is a namespace.</summary>
        /// <value>The is namespace toggle.</value>
        bool IsNamespace { get; }

        /// <summary>Gets the type of the object.</summary>
        /// <value>The type of the object.</value>
        Type ObjectType { get; }

        /// <summary>Gets the split paths.</summary>
        /// <value>The split paths.</value>
        List<NamespaceData> SplitPaths { get; }

        #endregion
    }
}