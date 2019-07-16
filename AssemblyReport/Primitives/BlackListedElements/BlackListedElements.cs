#region License

// ********************************* Header *********************************\
// 
//    Class:  BlackListedElements.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System.Collections.Generic;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives.BlackListedElements
{
    /// <summary>The <see cref="BlacklistElements"/> struct.</summary>
    /// <seealso cref="IBlacklistElements"/>
    public struct BlacklistElements : IBlacklistElements
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="BlacklistElements"/> struct.</summary>
        /// <param name="assemblyLocation">The assembly location.</param>
        public BlacklistElements(string assemblyLocation)
        {
            // Initialize variables
            Location = assemblyLocation;
            RootName = TypesUtil.DefaultNamespace(assemblyLocation);

            // Declare default blacklist filter item namespaces
            Namespaces = new List<string>
            {
                $@"{RootName}.Properties"
            };

            // Declare default blacklist filter item types
            Types = new List<string>
            {
                $@"{RootName}.Properties",
                $@"{RootName}.Settings"
            };
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the location.</summary>
        /// <value>The location.</value>
        public string Location { get; }

        /// <summary>Gets the namespaces.</summary>
        /// <value>The namespaces.</value>
        public List<string> Namespaces { get; }

        /// <summary>Gets the name of the root.</summary>
        /// <value>The name of the root.</value>
        public string RootName { get; }

        /// <summary>Gets the types.</summary>
        /// <value>The types.</value>
        public List<string> Types { get; }

        #endregion
    }
}