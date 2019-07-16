#region License

// ********************************* Header *********************************\
// 
//    Class:  IBlacklistElements.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System.Collections.Generic;

#endregion

namespace AssemblyReport.Primitives.BlackListedElements
{
    /// <summary>The <see cref="IBlacklistElements"/> interface.</summary>
    public interface IBlacklistElements
    {
        #region Public Properties

        /// <summary>Gets the location.</summary>
        /// <value>The location.</value>
        string Location { get; }

        /// <summary>Gets the namespaces.</summary>
        /// <value>The namespaces.</value>
        List<string> Namespaces { get; }

        /// <summary>Gets the name of the root.</summary>
        /// <value>The name of the root.</value>
        string RootName { get; }

        /// <summary>Gets the types.</summary>
        /// <value>The types.</value>
        List<string> Types { get; }

        #endregion
    }
}