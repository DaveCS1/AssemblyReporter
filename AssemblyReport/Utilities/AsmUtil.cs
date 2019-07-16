#region License

// ********************************* Header *********************************\
// 
//    Class:  AsmUtil.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.IO;
using System.Reflection;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="AsmUtil"/> class.</summary>
    public static class AsmUtil
    {
        #region Public Methods and Operators

        /// <summary>Determines whether the <seealso cref="FileInfo"/> is a common language runtime <see cref="Assembly"/> application.</summary>
        /// <param name="filePath">The file path for the <see cref="Assembly"/> file.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool IsAssembly(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), @"The file name cannot be null or empty.");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(@"The file cannot be found.", filePath);
            }

            bool result;

            // Validate to check for an assembly application file type.
            try
            {
                AssemblyName unused = AssemblyName.GetAssemblyName(filePath);
                result = true;
            }

            catch (FileNotFoundException)
            {
                result = false;
            }

            catch (BadImageFormatException)
            {
                result = false;
            }

            catch (FileLoadException)
            {
                result = false;
            }

            return result;
        }

        /// <summary>Processes the assembly.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        /// <exception cref="ArgumentNullException">path - The assembly cannot be null. or path - The assembly location cannot be found. or path - The assembly location doesn't link to a valid assembly file type.</exception>
        [Obsolete("Merge with assembly loader.")]
        public static bool ProcessAssembly(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), @"The file name cannot be null or empty.");
            }

            if (!File.Exists(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), @"The assembly location cannot be found.");
            }

            if (!IsAssembly(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), @"The assembly location doesn't link to a valid assembly file type.");
            }

            try
            {
                Assembly unused = Assembly.LoadFile(filePath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        #endregion
    }
}