#region License

// ********************************* Header *********************************\
// 
//    Class:  MemberInfoTypes.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Runtime.InteropServices;

#endregion

namespace AssemblyReport.Enumerators
{
    /// <summary>Marks each type of member that is defined as a derived class of <see cref="MemberInfoTypes"/>.</summary>
    [Flags]
    [ComVisible(true)]
    [Serializable]
    public enum MemberInfoTypes
    {
        /// <summary>Specifies that the member is a class.</summary>
        Class = 1,

        /// <summary>Specifies that the member is a delegate.</summary>
        Delegate = 2,

        /// <summary>Specifies that the member is a enumerator.</summary>
        Enumerator = 3,

        /// <summary>Specifies that the member is an event.</summary>
        Event = 4,

        /// <summary>Specifies that the member is a field.</summary>
        Field = 5,

        /// <summary>Specifies that the member is a interface.</summary>
        Interface = 6,

        /// <summary>Specifies that the member is a method.</summary>
        Method = 7,

        /// <summary>Specifies that the member is a property.</summary>
        Property = 8,

        /// <summary>Specifies that the member is a structure.</summary>
        Structure = 9
    }
}