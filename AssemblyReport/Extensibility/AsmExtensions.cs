#region License

// ********************************* Header *********************************\
// 
//    Class:  AsmExtensions.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.Versioning;
using AssemblyReport.Primitives;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Extensibility
{
    /// <summary>The <see cref="AsmExtensions"/> class.</summary>
    public static class AsmExtensions
    {
        #region Public Methods and Operators

        /// <summary>Determines whether the specified <see cref="Assembly"/> resource file name exists.</summary>
        /// <param name="assembly">The assembly that represents a common language runtime application.</param>
        /// <param name="fileName">The file name with the file extension for the resource manifest. Example: '<c>Visual.xml</c>'</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool ContainsResourceFile(this Assembly assembly, string fileName)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new FileNotFoundException(@"The assembly file cannot be found.", assembly.Location);
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), @"The file name cannot be null or empty.");
            }

            bool resourceFileExists;

            try
            {
                string resourceBasePath = assembly.GetManifestResourceNames().SingleOrDefault(source => source.EndsWith(fileName, StringComparison.InvariantCultureIgnoreCase));
                resourceFileExists = !string.IsNullOrEmpty(resourceBasePath);
            }
            catch (ArgumentOutOfRangeException)
            {
                resourceFileExists = false;
            }
            catch (FileNotFoundException)
            {
                resourceFileExists = false;
            }
            catch (MissingManifestResourceException)
            {
                resourceFileExists = false;
            }
            catch (Exception)
            {
                resourceFileExists = false;
            }

            return resourceFileExists;
        }

        /// <summary>Determines whether the specified <see cref="Assembly"/> resource key name exists.</summary>
        /// <param name="assembly">The assembly that represents a common language runtime application.</param>
        /// <param name="fileName">The file name with the file extension for the resource manifest. Example: '<c>Visual.xml</c>'</param>
        /// <param name="key">The resource key name.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool ContainsResourceKey(this Assembly assembly, string fileName, string key)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new FileNotFoundException(@"The assembly file cannot be found.", assembly.Location);
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), @"The file name cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), @"The key cannot be null or empty.");
            }

            var keyExists = false;
            string basePath = assembly.GetResourceBasePath(fileName);

            try
            {
                if (ContainsResourceFile(assembly, fileName))
                {
                    Stream resourceStream = assembly.GetManifestResourceStream(basePath);
                    ResourceReader resourceReader = new ResourceReader(resourceStream);

                    foreach (DictionaryEntry entry in resourceReader)
                    {
                        Console.WriteLine(entry.Key);

                        // Validate key is equals.
                        if (entry.Key.Equals(key))
                        {
                            keyExists = true;
                            break;
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            catch (FileNotFoundException)
            {
            }
            catch (MissingManifestResourceException)
            {
            }
            catch (Exception)
            {
                // ignored
            }

            return keyExists;
        }

        /// <summary>Gets all attributes.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public static object[] GetAllAttributes(Assembly assembly)
        {
            var list = assembly.GetCustomAttributes(true);
            return list;
        }

        /// <summary>Gets the framework attributes.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public static TargetFrameworkAttribute GetFrameworkAttributes(Assembly assembly)
        {
            var list = GetAllAttributes(assembly);
            TargetFrameworkAttribute attribute = list.OfType<TargetFrameworkAttribute>().First();
            return attribute;
        }

        /// <summary>Gets the manifest resource base path using the specified file name of the resource.</summary>
        /// <param name="assembly">The assembly that represents a common language runtime application.</param>
        /// <param name="fileName">The file name with the file extension for the resource manifest. Example: '<c>Visual.xml</c>'</param>
        /// <returns>The <see cref="string"/>.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the embedded file '{basePath}' could not be found in assembly '{assembly.FullName}'</exception>
        public static string GetResourceBasePath(this Assembly assembly, string fileName)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new FileNotFoundException(@"The assembly file cannot be found.", assembly.Location);
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), @"The file name cannot be null or empty.");
            }

            return ResourceFactory.CreateResourceBasePath(assembly, fileName);
        }

        /// <summary>Gets the manifest resource base path using the specified file name of the resource.</summary>
        /// <param name="assembly">The assembly that represents a common language runtime application.</param>
        /// <param name="basePath">The resource base path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        /// <exception cref="FileNotFoundException">Thrown when the embedded file '{basePath}' could not be found in assembly '{assembly.FullName}'</exception>
        public static string GetResourceFileName(this Assembly assembly, string basePath)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new FileNotFoundException(@"The assembly file cannot be found.", assembly.Location);
            }

            if (string.IsNullOrEmpty(basePath))
            {
                throw new ArgumentNullException(nameof(basePath), @"The base path cannot be null or empty.");
            }

            return ResourceFactory.CreateResourceFileName(assembly, basePath);
        }

        /// <summary>Returns the names of all the <see langword="resources"/> in this <see cref="Assembly"/>.</summary>
        /// <param name="assembly">The main assembly for the <see langword="resources"/>.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public static List<string> GetResourceNames(this Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new FileNotFoundException(@"The assembly file cannot be found.", assembly.Location);
            }

            return assembly.GetManifestResourceNames().ToList();
        }

        /// <summary>Gets the manifest resource <seealso cref="Stream"/> using the specified base path.</summary>
        /// <param name="assembly">The assembly that represents a common language runtime application.</param>
        /// <param name="fileName">The resource file name.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        public static Stream GetResourceStream(this Assembly assembly, string fileName)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), @"The assembly cannot be null.");
            }

            if (!File.Exists(assembly.Location))
            {
                throw new FileNotFoundException(@"The assembly file cannot be found.", assembly.Location);
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), @"The file name cannot be null or empty.");
            }

            string basePath = assembly.GetResourceBasePath(fileName);
            return assembly.GetManifestResourceStream(basePath);
        }

        /// <summary>Resolves the root namespace.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The <see cref="Assembly"/>.</returns>
        public static string ResolveRootNamespace(this Assembly assembly)
        {
            return TypesUtil.DefaultNamespace(assembly);
        }

        #endregion
    }
}