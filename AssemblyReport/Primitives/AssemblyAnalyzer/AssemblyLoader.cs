#region License

// ********************************* Header *********************************\
// 
//    Class:  AssemblyLoader.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.IO;
using System.Reflection;

#endregion

namespace AssemblyReport.Primitives.AssemblyAnalyzer
{
    /// <summary>The <see cref="AssemblyLoader"/> class.</summary>
    public class AssemblyLoader
    {
        #region Public Properties

        /// <summary>Gets the assembly directory.</summary>
        /// <value>The assembly directory.</value>
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Loads the specified asm full path.</summary>
        /// <param name="asmFullPath">The asm full path.</param>
        /// <returns>The <see cref="Assembly"/>.</returns>
        public static Assembly Load(string asmFullPath)
        {
            return Assembly.LoadFile(asmFullPath);
        }

        #endregion
    }
}