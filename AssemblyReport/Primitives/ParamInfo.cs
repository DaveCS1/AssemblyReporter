#region License

// ********************************* Header *********************************\
// 
//    Class:  ParamInfo.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="ParamInfo"/> struct.</summary>
    public struct ParamInfo
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="ParamInfo"/> struct.</summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public ParamInfo(string name, string description) : this()
        {
            Description = description;
            Name = name;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; }

        /// <summary>Gets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; }

        #endregion
    }
}