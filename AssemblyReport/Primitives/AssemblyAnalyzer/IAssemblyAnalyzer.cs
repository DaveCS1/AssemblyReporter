#region License

// ********************************* Header *********************************\
// 
//    Class:  IAssemblyAnalyzer.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;

#endregion

namespace AssemblyReport.Primitives.AssemblyAnalyzer
{
    /// <summary>The <see cref="IAssemblyAnalyzer"/> interface.</summary>
    public interface IAssemblyAnalyzer : IDisposable
    {
        #region Public Properties

        /// <summary>Gets the hierarchy types.</summary>
        /// <value>The hierarchy types.</value>
        HierarchyTree HierarchyTree { get; }

        /// <summary>Gets the location.</summary>
        /// <value>The location.</value>
        string Location { get; }

        #endregion
    }
}