#region License

// ********************************* Header *********************************\
// 
//    Class:  ResourceFactory.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.IO;
using System.Linq;
using System.Reflection;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="ResourceFactory"/> class.</summary>
    public static class ResourceFactory
    {
        #region Public Methods and Operators

        /// <summary>Gets the manifest resource base path using the specified file name of the resource.</summary>
        /// <param name="assembly">The assembly that represents a common language runtime application.</param>
        /// <param name="resourceFileName">The file name with the file extension for the resource manifest. Example: '<c>Visual.xml</c>'</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateResourceBasePath(Assembly assembly, string resourceFileName)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new ArgumentNullException(nameof(assembly.Location), @"The assembly location cannot be found.");
            }

            if (string.IsNullOrEmpty(resourceFileName))
            {
                throw new ArgumentNullException(nameof(resourceFileName), @"The resource file name cannot be null or empty.");
            }

            string resourceBasePath = string.Empty;

            try
            {
                resourceBasePath = assembly.GetManifestResourceNames().SingleOrDefault(source => source.EndsWith(resourceFileName, StringComparison.InvariantCultureIgnoreCase));

                if (string.IsNullOrEmpty(resourceBasePath))
                {
                    resourceBasePath = string.Empty;
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return resourceBasePath;
        }

        /// <summary>Gets the manifest resource file name using the specified base path of the resource file.</summary>
        /// <param name="assembly">The assembly that represents a common language runtime application.</param>
        /// <param name="resourceBasePath">The full file path including the name with the file extension for the resource file. Example: '<c>VisualPlus.Resources.Themes.Visual.xml</c>'</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateResourceFileName(Assembly assembly, string resourceBasePath)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new ArgumentNullException(nameof(assembly.Location), @"The assembly path cannot be found.");
            }

            if (string.IsNullOrEmpty(resourceBasePath))
            {
                throw new ArgumentNullException(nameof(resourceBasePath), @"The resource base path cannot be null or empty.");
            }

            string resourceFileName = string.Empty;

            try
            {
                var split = resourceBasePath.Split(NamespaceData.NamespacePathSeparator);

                if (split.Length < 2)
                {
                    throw new ArgumentException(@"Expected more than one dot '.' in the manifest resource name.", nameof(resourceBasePath));
                }

                string extension = split[split.Length - 1];
                string fileName = split[split.Length - 2];

                string fullFileName = fileName + NamespaceData.NamespacePathSeparator + extension;
                resourceFileName = fullFileName;
            }
            catch (InvalidOperationException)
            {
            }
            catch (Exception)
            {
                // ignored
            }

            return resourceFileName;
        }

        #endregion
    }
}