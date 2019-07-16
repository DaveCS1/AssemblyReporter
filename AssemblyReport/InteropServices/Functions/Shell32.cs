#region License

// ********************************* Header *********************************\
// 
//    Class:  Shell32.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace AssemblyReport.InteropServices.Functions
{
    /// <summary>The <see cref="Shell32"/> interoperability enables you to invoke unmanaged code.</summary>
    /// <remarks>
    ///     <para>Description: Windows Shell Common Dll.</para>
    ///     <para>Entry point: <c>Shell32.dll</c></para>
    /// </remarks>
    public static class Shell32
    {
        #region Public Methods and Operators

        /// <summary>Gets a handle to an icon stored as a resource in a file or an icon stored in a file's associated executable file.</summary>
        /// <param name="hInst">A handle to the instance of the calling application.</param>
        /// <param name="lpIconPath">Pointer to a string that, on entry, specifies the full path and file name of the file that contains the icon. The function extracts the icon handle from that file, or from an executable file associated with that file.</param>
        /// <param name="lpiIcon">Pointer to a WORD value that, on entry, specifies the index of the icon whose handle is to be obtained.</param>
        /// <returns>The <see cref="IntPtr"/>.</returns>
        [DllImport(ExternalDll.Shell32)]
        public static extern IntPtr ExtractAssociatedIcon(IntPtr hInst, StringBuilder lpIconPath, out ushort lpiIcon);

        /// <summary>This function retrieves icon handles from the specified executable file or dynamic-link library (DLL).</summary>
        /// <param name="fileName">Long pointer to a null-terminated string that specifies the name of an executable file or DLL file from which to extract icons.</param>
        /// <param name="iconStartingIndex">Specifies the zero-based index of the first icon to extract. For example, if this value is zero, the function extracts the first icon in the specified file.</param>
        /// <param name="largeIcons">Pointer to an array to receive handles to large icons extracted from the file. If this parameter is NULL, no large icons are extracted from the file.</param>
        /// <param name="smallIcons">Pointer to an array to receive handles to small icons extracted from the file. If this parameter is NULL, no small icons are extracted from the file.</param>
        /// <param name="iconCount">Specifies the number of icons to extract from the file. For Windows CE 2.10 and later, the nIcons parameter must be 1.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [DllImport(ExternalDll.Shell32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int ExtractIconEx(string fileName, int iconStartingIndex, IntPtr[] largeIcons, IntPtr[] smallIcons, int iconCount);

        #endregion
    }
}