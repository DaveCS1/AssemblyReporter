#region License

// ********************************* Header *********************************\
// 
//    Class:  INamespaceData.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="INamespaceData"/> interface.</summary>
    public interface INamespaceData
    {
        #region Public Properties

        /// <summary>Gets a value indicating whether this instance is empty.</summary>
        /// <value>Determines whether this instance is empty.</value>
        bool IsEmpty { get; }

        /// <summary>Gets a value indicating whether this instance is namespace.</summary>
        /// <value>Indicates whether this instance is a valid namespace path.</value>
        bool IsNamespace { get; }

        /// <summary>Gets the path.</summary>
        /// <value>The path.</value>
        string Path { get; }

        #endregion
    }
}