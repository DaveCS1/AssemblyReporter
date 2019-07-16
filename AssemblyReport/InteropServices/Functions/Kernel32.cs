#region License

// ********************************* Header *********************************\
// 
//    Class:  Kernel32.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace AssemblyReport.InteropServices.Functions
{
    /// <summary>The <see cref="Kernel32"/> interoperability enables you to invoke unmanaged code.</summary>
    /// <remarks>
    ///     <para>Description: Windows NT BASE API Client DLL.</para>
    ///     <para>Entry point: <c>Kernel32.dll</c></para>
    /// </remarks>
    public static class Kernel32
    {
        #region Public Methods and Operators

        /// <summary>Retrieves the long path form of the specified path.</summary>
        /// <param name="path">The name of the file.</param>
        /// <param name="longPath">A pointer to a buffer that receives the null-terminated string for the drive and path.</param>
        /// <param name="longPathLength">The size of the buffer to receive the null-terminated string for the drive and path, in TCHARs.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [DllImport(ExternalDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetLongPathName([MarshalAs(UnmanagedType.LPTStr)] string path, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder longPath, int longPathLength);

        /// <summary>Retrieves the short path form of the specified path.</summary>
        /// <param name="path">The name of the file.</param>
        /// <param name="shortPath">A pointer to a buffer that receives the null-terminated string for the drive and path.</param>
        /// <param name="shortPathLength">The size of the buffer to receive the null-terminated string for the drive and path, in TCHARs.</param>
        /// <returns>The <see cref="int"/>.</returns>
        [DllImport(ExternalDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetShortPathName([MarshalAs(UnmanagedType.LPTStr)] string path, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder shortPath, int shortPathLength);

        #endregion
    }
}