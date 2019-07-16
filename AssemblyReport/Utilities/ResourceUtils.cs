#region License

// ********************************* Header *********************************\
// 
//    Class:  ResourceUtils.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using AssemblyReport.Extensibility;
using AssemblyReport.Primitives;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="ResourceUtils"/> class.</summary>
    public static class ResourceUtils
    {
        #region Public Methods and Operators

        /// <summary>Extract the resource file from an <seealso cref="Assembly"/> and returns the content as an <seealso cref="Image"/>.</summary>
        /// <param name="assembly">The main assembly for the resources.</param>
        /// <param name="resourceBasePath">The resource base path to the file with its namespaces.</param>
        /// <exception cref="BadImageFormatException">Thrown when the resource base path cannot be found.</exception>
        public static Image ExtractToImage(Assembly assembly, string resourceBasePath)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new ArgumentNullException(nameof(assembly.Location), @"The assembly location cannot be found.");
            }

            if (string.IsNullOrEmpty(resourceBasePath))
            {
                throw new ArgumentNullException(nameof(resourceBasePath), @"The resource base path cannot be null or empty.");
            }

            if (!NamespaceData.IsValidNamespace(resourceBasePath))
            {
                throw new BadImageFormatException(@"Invalid operation when extracting image from resources, possibly invalid namespace path.", resourceBasePath);
            }

            Image extractedImage = null;
            string fileName = ResourceFactory.CreateResourceFileName(assembly, resourceBasePath);

            if (assembly.ContainsResourceFile(fileName))
            {
                using (Stream resourceStream = assembly.GetManifestResourceStream(resourceBasePath))
                {
                    if (resourceStream == null)
                    {
                        throw new FileNotFoundException(@"Cannot find the resource name in the manifest stream.", fileName);
                    }

                    if (!resourceStream.CanRead)
                    {
                        throw new ArgumentNullException(nameof(resourceStream), @"The resource stream is not readable.");
                    }

                    extractedImage = Image.FromStream(resourceStream);
                }
            }

            return extractedImage;
        }

        #endregion
    }
}