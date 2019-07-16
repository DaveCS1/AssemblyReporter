#region License

// ********************************* Header *********************************\
// 
//    Class:  User32.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Runtime.InteropServices;

#endregion

namespace AssemblyReport.InteropServices.Functions
{
    /// <summary>The <see cref="User32"/> interoperability enables you to invoke unmanaged code.</summary>
    /// <remarks>
    ///     <para>Description: Multi-User Windows USER API Client DLL.</para>
    ///     <para>Entry point: <c>User32.dll</c></para>
    /// </remarks>
    public static class User32
    {
        #region Public Methods and Operators

        /// <summary>Destroys an icon and frees any memory the icon occupied.</summary>
        /// <param name="hIcon">A handle to the icon to be destroyed. The icon must not be in use.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [DllImport(ExternalDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DestroyIcon(IntPtr hIcon);

        #endregion
    }
}