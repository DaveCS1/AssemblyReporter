#region License

// ********************************* Header *********************************\
// 
//    Class:  XMLUtil.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.IO;
using System.Reflection;
using System.Xml;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="XMLUtil"/> class.</summary>
    public static class XMLUtil
    {
        #region Public Methods and Operators

        /// <summary>Reads the documentation file if it exists alongside the assembly.</summary>
        /// <param name="assembly">The assembly to parse.</param>
        /// <returns>The <see cref="XmlDocument"/>.</returns>
        public static XmlDocument ReadDocumentationXML(Assembly assembly)
        {
            string path = assembly.Location.Substring(0, assembly.Location.LastIndexOf(".", StringComparison.Ordinal)) + ".XML";

            XmlDocument xmlDocumentation = new XmlDocument();

            if (File.Exists(path))
            {
                xmlDocumentation.Load(path);

                return xmlDocumentation;
            }

            return null;
        }

        #endregion
    }
}