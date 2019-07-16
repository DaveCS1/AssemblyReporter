#region License

// ********************************* Header *********************************\
// 
//    Class:  DocumentationExtensions.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

#endregion

namespace AssemblyReport.Extensibility
{
    /// <summary>Utility class to provide documentation for various types where available with the assembly.</summary>
    public static class DocumentationExtensions
    {
        #region Static Fields

        /// <summary>A cache used to remember Xml documentation for assemblies</summary>
        private static readonly Dictionary<Assembly, XmlDocument> Cache = new Dictionary<Assembly, XmlDocument>();

        /// <summary>A cache used to store failure exceptions for assembly lookups</summary>
        private static readonly Dictionary<Assembly, Exception> FailCache = new Dictionary<Assembly, Exception>();

        #endregion

        #region Public Methods and Operators

        /// <summary>Returns the <see cref="DescriptionAttribute"/> value if one exists for the <see langword="enumerator"/>.</summary>
        /// <param name="source">The source instance.</param>
        /// <returns>The <see cref="DescriptionAttribute"/>.</returns>
        public static string GetDescription(MethodInfo source)
        {
            if (source == null)
            {
                return string.Empty;
            }

            FieldInfo fieldInfo = source.GetType().GetField(source.ToString());

            if (ReferenceEquals(fieldInfo, null))
            {
                return source.ToString();
            }

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // Check if contains any description
            if (descriptionAttributes.Length > 0)
            {
                return descriptionAttributes[0].Description;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>Returns the <see cref="DescriptionAttribute"/> value if one exists for the <see langword="enumerator"/>.</summary>
        /// <param name="source">The source instance.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetDescription(Type source)
        {
            if (ReferenceEquals(source, null))
            {
                return string.Empty;
            }

            if (source.GetCustomAttributesData().Any())
            {
                var descriptionAttributes = (DescriptionAttribute[])source.GetCustomAttributes(typeof(DescriptionAttribute), false);

                // Check if contains any description
                if (descriptionAttributes.Length > 0)
                {
                    return descriptionAttributes[0].Description;
                }
            }

            return string.Empty;
        }

        /// <summary>Provides the documentation comments for a specific method</summary>
        /// <param name="methodInfo">The MethodInfo (reflection data ) of the member to find documentation for</param>
        /// <returns>The XML fragment describing the method</returns>
        public static XmlElement GetDocumentation(MethodInfo methodInfo)
        {
            // Calculate the parameter string as this is in the member name in the XML
            string parametersString = string.Empty;

            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
            {
                if (parametersString.Length > 0)
                {
                    parametersString += ",";
                }

                parametersString += parameterInfo.ParameterType.FullName;
            }

            //AL: 15.04.2008 ==> BUG: Remove the brackets'()' if parametersString is empty
            if (parametersString.Length > 0)
            {
                return XMLFromName(methodInfo.DeclaringType, 'M', methodInfo.Name + "(" + parametersString + ")");
            }
            else
            {
                return XMLFromName(methodInfo.DeclaringType, 'M', methodInfo.Name);
            }
        }

        /// <summary>Provides the documentation comments for a specific member</summary>
        /// <param name="memberInfo">The MemberInfo (reflection data) or the member to find documentation for</param>
        /// <returns>The XML fragment describing the member</returns>
        public static XmlElement GetDocumentation(MemberInfo memberInfo)
        {
            // First character [0] of member type is prefix character in the name in the XML
            return XMLFromName(memberInfo.DeclaringType, memberInfo.MemberType.ToString()[0], memberInfo.Name);
        }

        /// <summary>Provides the documentation comments for a specific type</summary>
        /// <param name="type">Type to find the documentation for</param>
        /// <returns>The XML fragment that describes the type</returns>
        public static XmlElement GetDocumentation(Type type)
        {
            // Prefix in type names is T
            return XMLFromName(type, 'T', string.Empty);
        }

        /// <summary>Gets the documentation file path.</summary>
        /// <param name="assembly">The assembly location.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetDocumentationFilePath(Assembly assembly)
        {
            return GetDocumentationFilePath(assembly.Location);
        }

        /// <summary>Gets the documentation file path.</summary>
        /// <param name="filePath">The assembly location.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetDocumentationFilePath(string filePath)
        {
            return Path.ChangeExtension(filePath, Constants.XMLFileExtension);
        }

        /// <summary>Returns the Xml documentation summary comment for this member</summary>
        /// <param name="memberInfo">The member info.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetSummary(MemberInfo memberInfo)
        {
            XmlElement element = GetDocumentation(memberInfo);
            XmlNode summaryElm = element?.SelectSingleNode("summary");

            if (summaryElm == null)
            {
                return string.Empty;
            }

            return summaryElm.InnerText.Trim();
        }

        /// <summary>Gets the summary portion of a type's documentation or returns an empty string if not available</summary>
        /// <param name="type">The source type.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetSummary(Type type)
        {
            if (type == null)
            {
                return string.Empty;
            }

            XmlElement element = GetDocumentation(type);

            if (element != null)
            {
                XmlNode summaryElement = element.SelectSingleNode("summary");

                if (summaryElement == null)
                {
                    string description = GetDescription(type);

                    if (string.IsNullOrEmpty(description))
                    {
                        description = string.Empty;
                    }

                    return description;
                }
                else if (summaryElement.InnerXml.Contains("cref"))
                {
                    // Extract the type name text and rebuild the string.
                    string xml = summaryElement.InnerXml;

                    var ppp = xml.Split('<');
                    string prefix = ppp[0];
                    var sss = xml.Split('>');
                    string suffix = sss[sss.Length - 1];

                    string pattern = @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>";

                    MatchCollection matches = Regex.Matches(xml, pattern);

                    var names = new List<string>();

                    // Current method only valid really for 1 match there is no implementation to what maybe between a few more then it will miss the words in between.

                    foreach (Match match1 in matches)
                    {
                        foreach (Match match in Regex.Matches(match1.Value, "\"([^\"]*)\""))
                        {
                            if (match.Success)
                            {
                                // Remove the last part prefix when there. -> T:AssemblyReporter.UserControls.ReportControl

                                string yourValue = match.Groups[1].Value;

                                string empty = string.Empty;

                                if (yourValue.StartsWith("T:") || yourValue.StartsWith("M:"))
                                {
                                    empty = yourValue.Remove(0, 2);
                                }

                                var split = empty.Split('.');

                                string typeNameResult = split[split.Length - 1];

                                // Get only name not the full namespace.
                                names.Add(typeNameResult);
                            }
                        }
                    }

                    // Try to rebuild the string going in reverse splitting by match start and end index.
                    string rebuilt = prefix + names[0] + suffix;
                    return rebuilt;
                }

                return summaryElement.InnerText.Trim();
            }
            else
            {
                string description = GetDescription(type);

                if (string.IsNullOrEmpty(description))
                {
                    // TODO: Set option to generate default summary text for the type.
                    return string.Empty;
                }
                else
                {
                    return description;
                }
            }
        }

        ///// <summary>Removes the invalid XML chars.</summary>
        ///// <param name="text">The text.</param>
        ///// <returns>The <see cref="string"/>.</returns>
        //public static string RemoveInvalidXmlChars(string text)
        //{
        //    if (string.IsNullOrEmpty(text))
        //    {
        //        return text;
        //    }

        //    int length = text.Length;
        //    StringBuilder stringBuilder = new StringBuilder(length);

        //    for (int i = 0; i < length; ++i)
        //    {
        //        if (XmlConvert.IsXmlChar(text[i]))
        //        {
        //            stringBuilder.Append(text[i]);
        //        }
        //        else if ((i + 1 < length) && XmlConvert.IsXmlSurrogatePair(text[i + 1], text[i]))
        //        {
        //            stringBuilder.Append(text[i]);
        //            stringBuilder.Append(text[i + 1]);
        //            ++i;
        //        }
        //    }

        //    return stringBuilder.ToString();
        //}

        ///// <summary>Strips non-printable ascii characters Refer to http://www.w3.org/TR/xml11/#charsets for XML 1.1 Refer to http://www.w3.org/TR/2006/REC-xml-20060816/#charsets for XML 1.0</summary>
        ///// <param name="content">contents</param>
        ///// <param name="XMLVersion">XML Specification to use. Can be 1.0 or 1.1</param>
        //[Obsolete("Needs testing.")]
        //public static void StripIllegalXMLChars(string content, string XMLVersion)
        //{
        //    string pattern;
        //    switch (XMLVersion)
        //    {
        //        case "1.0":
        //            pattern = @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|7F|8[0-46-9A-F]9[0-9A-F])";
        //            break;
        //        case "1.1":
        //            pattern = @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|[19][0-9A-F]|7F|8[0-46-9A-F]|0?[1-8BCEF])";
        //            break;
        //        default:
        //            throw new Exception("Error: Invalid XML Version!");
        //    }

        //    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

        //    if (regex.IsMatch(content))
        //    {
        //        content = regex.Replace(content, string.Empty);
        //    }

        //    content = string.Empty;
        //}

        /// <summary>Obtains the documentation file for the specified assembly</summary>
        /// <param name="assembly">The assembly to find the XML document for</param>
        /// <returns>The XML document</returns>
        /// <remarks>This version uses a cache to preserve the assemblies, so that the XML file is not loaded and parsed on every single lookup</remarks>
        public static XmlDocument XmlFromAssembly(Assembly assembly)
        {
            if (FailCache.ContainsKey(assembly))
            {
                throw FailCache[assembly];
            }

            try
            {
                if (!Cache.ContainsKey(assembly))
                {
                    // load the document into the cache
                    Cache[assembly] = XmlFromAssemblyNonCached(assembly);
                }

                return Cache[assembly];
            }
            catch (Exception exception)
            {
                FailCache[assembly] = exception;
                throw;
            }
        }

        #endregion

        #region Methods

        /// <summary>Loads and parses the documentation file for the specified assembly</summary>
        /// <param name="assembly">The assembly to find the XML document for</param>
        /// <returns>The XML document</returns>
        private static XmlDocument XmlFromAssemblyNonCached(Assembly assembly)
        {
            string assemblyFilename = assembly.CodeBase;

            const string prefix = "file:///";

            if (assemblyFilename.StartsWith(prefix))
            {
                string filePath = GetDocumentationFilePath(assemblyFilename.Substring(prefix.Length));

                if (File.Exists(filePath))
                {
                    StreamReader streamReader;

                    try
                    {
                        streamReader = new StreamReader(filePath);
                    }
                    catch (FileNotFoundException exception)
                    {
                        throw new Exception("XML documentation not present (make sure it is turned on in project properties when building)", exception);
                    }

                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(streamReader);
                    return xmlDocument;
                }

                return null;
            }
            else
            {
                throw new Exception("Could not retrieve assembly documentation compiler file.", null);
            }
        }

        /// <summary>Obtains the XML Element that describes a reflection element by searching the members for a member that has a name that describes the element.</summary>
        /// <param name="type">The type or parent type, used to fetch the assembly</param>
        /// <param name="prefix">The prefix as seen in the name attribute in the documentation XML</param>
        /// <param name="name">Where relevant, the full name qualifier for the element</param>
        /// <returns>The member that has a name that describes the specified reflection element</returns>
        private static XmlElement XMLFromName(Type type, char prefix, string name)
        {
            string fullName;

            if (string.IsNullOrEmpty(name))
            {
                fullName = prefix + ":" + type.FullName;
            }
            else
            {
                fullName = prefix + ":" + type.FullName + "." + name;
            }

            string filePath = GetDocumentationFilePath(type.Assembly.Location);

            if (File.Exists(filePath))
            {
                XmlDocument xmlDocument = XmlFromAssembly(type.Assembly);
                XmlElement matchedElement = xmlDocument["doc"]?["members"]?.SelectSingleNode("member[@name='" + fullName + "']") as XmlElement;
                return matchedElement;
            }
            else
            {
                return null;
            }
        }

        /// <summary>XMLs from name0.</summary>
        /// <param name="type">The type.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="name">The name.</param>
        /// <returns>The <see cref="XmlElement"/>.</returns>
        private static XmlElement XMLFromName0(Type type, char prefix, string name)
        {
            string fullName;
            string fullTypeName = Regex.Replace(type.FullName, @"\[\[.*?\]\]", "");

            if (string.IsNullOrEmpty(name))
            {
                fullName = prefix + ":" + fullTypeName;
            }
            else
            {
                fullName = prefix + ":" + fullTypeName + "." + name;
            }

            XmlDocument xmlDocument = XmlFromAssembly(type.Assembly);

            XmlElement matchedElement = null;

            if (xmlDocument != null)
            {
                foreach (XmlNode xmlNode in (XmlElement)xmlDocument["doc"]?["members"]?.SelectSingleNode($"member[@name='{fullName}']"))
                {
                    if (!(xmlNode is XmlElement))
                    {
                        continue;
                    }

                    XmlElement xmlElement = (XmlElement)xmlNode;

                    if (!xmlElement.Attributes["name"].Value.Equals(fullName))
                    {
                        continue;
                    }

                    if (matchedElement != null)
                    {
                        //  throw new DocsByReflectionException("Multiple matches to query", null);
                    }

                    matchedElement = xmlElement;
                }
            }

            if (matchedElement == null)
            {
                // throw new DocsByReflectionException("Could not find documentation for specified element", null);
            }

            return matchedElement;
        }

        #endregion
    }
}