#region License

// ********************************* Header *********************************\
// 
//    Class:  FileUtil.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

#endregion

#region Namespace

using System;
using System.Diagnostics;
using System.IO;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="FileUtil"/> class.</summary>
    public static class FileUtil
    {
        #region Public Properties

        /// <summary>The Windows directory info.</summary>
        public static DirectoryInfo System
        {
            get { return new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.System)); }
        }

        /// <summary>The Windows directory info.</summary>
        public static DirectoryInfo Windows
        {
            get { return System.Parent; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Opens the Windows File Explorer at the specified directory. Optional allows setting a selected file.</summary>
        /// <param name="directory">The directory path.</param>
        /// <param name="selectFile">Toggle file selection.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool OpenFileExplorer(DirectoryInfo directory, bool selectFile = false, string fileName = "")
        {
            return OpenFileExplorer(directory.FullName, selectFile, fileName);
        }

        /// <summary>Opens the Windows File Explorer at the specified directory. Optional allows setting a selected file.</summary>
        /// <param name="directoryPath">The directory path.</param>
        /// <param name="selectFile">Toggle file selection.</param>
        /// <param name="fileName">The file name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool OpenFileExplorer(string directoryPath, bool selectFile = false, string fileName = "")
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                return false;
            }

            if (!Directory.Exists(directoryPath))
            {
                return false;
            }

            string argument = string.Empty;

            try
            {
                // Selects the validated file path.
                if (selectFile)
                {
                    string filePath = Path.Combine(directoryPath, fileName);

                    // Validate the file Selection.
                    if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                    {
                        argument = "/select, \"" + filePath + "\"";
                    }
                }

                Process.Start(Path.Combine(Windows.FullName, Constants.FileExplorer), argument);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        /// <summary>Gets the bytes from file.</summary>
        /// <param name="fullFilePath">The full file path.</param>
        /// <returns>The <see cref="byte"/>.</returns>
        public static byte[] ReadBytesFromFile(string fullFilePath)
        {
            // this method is limited to 2^32 byte files (4.2 GB)

            FileStream fs = File.OpenRead(fullFilePath);

            try
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                return bytes;
            }
            finally
            {
                fs.Close();
            }
        }

        #endregion
    }
}