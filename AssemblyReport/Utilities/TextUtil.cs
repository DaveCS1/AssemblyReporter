#region License

// ********************************* Header *********************************\
// 
//    Class:  TextUtil.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AssemblyReport.InteropServices.Functions;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="TextUtil"/> class.</summary>
    public static class TextUtil
    {
        #region Public Methods and Operators

        /// <summary>Files the path to file URL.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string FilePathToFileUrl(string filePath)
        {
            StringBuilder uri = new StringBuilder();

            foreach (char v in filePath)
            {
                if (((v >= 'a') && (v <= 'z')) || ((v >= 'A') && (v <= 'Z')) || ((v >= '0') && (v <= '9')) ||
                    (v == '+') || (v == '/') || (v == ':') || (v == '.') || (v == '-') || (v == '_') || (v == '~') ||
                    (v > '\xFF'))
                {
                    uri.Append(v);
                }
                else if ((v == Path.DirectorySeparatorChar) || (v == Path.AltDirectorySeparatorChar))
                {
                    uri.Append(Path.AltDirectorySeparatorChar);
                }
                else
                {
                    uri.Append($"%{(int)v:X2}");
                }
            }

            if ((uri.Length >= 2) && (uri[0] == Path.AltDirectorySeparatorChar) && (uri[1] == Path.AltDirectorySeparatorChar)) // UNC path
            {
                uri.Insert(0, "file:");
            }
            else
            {
                uri.Insert(0, "file:///");
            }

            return uri.ToString();
        }

        /// <summary>Gets the parent URI string.</summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetParentUriString(Uri uri)
        {
            return uri.AbsoluteUri.Remove(uri.AbsoluteUri.Length - uri.Segments.Last().Length);
        }

        /// <summary>Returns a relative path string from a full path based on a base path provided.</summary>
        /// <param name="fullPath">The path to convert. Can be either a file or a directory</param>
        /// <param name="basePath">The base path on which relative processing is based. Should be a directory.</param>
        /// <returns>String of the relative path. Examples of returned values: test.txt, ..\test.txt, ..\..\..\test.txt, ., .., subdir\test.txt Example: @"c:\temp\templates\subdir\test.txt", @"c:\temp\templates"</returns>
        public static string GetRelativePath(string fullPath, string basePath)
        {
            // Require trailing backslash for path
            if (!basePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                basePath += Path.DirectorySeparatorChar.ToString();
            }

            Uri baseUri = new Uri(basePath);
            Uri fullUri = new Uri(fullPath);

            Uri relativeUri = baseUri.MakeRelativeUri(fullUri);

            // Uris use forward slashes so convert back to backward slashes
            return relativeUri.ToString().Replace(Path.AltDirectorySeparatorChar.ToString(), Path.DirectorySeparatorChar.ToString());
        }

        /// <summary>Creates a relative path from one file or folder to another.</summary>
        /// <param name="fromPath">Contains the directory that defines the start of the relative path.</param>
        /// <param name="toPath">Contains the path that defines the endpoint of the relative path.</param>
        /// <returns>The relative path from the start directory to the end path.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="fromPath"/> or <paramref name="toPath"/> is <c>null</c>.</exception>
        /// <exception cref="UriFormatException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static string GetRelativeURIPath(string fromPath, string toPath)
        {
            if (string.IsNullOrEmpty(fromPath))
            {
                throw new ArgumentNullException(nameof(fromPath));
            }

            if (string.IsNullOrEmpty(toPath))
            {
                throw new ArgumentNullException(nameof(toPath));
            }

            Uri fromUri = new Uri(AppendDirectorySeparatorChar(fromPath));
            Uri toUri = new Uri(AppendDirectorySeparatorChar(toPath));

            if (fromUri.Scheme != toUri.Scheme)
            {
                return toPath;
            }

            Uri relativeUri = fromUri.MakeRelativeUri(toUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (string.Equals(toUri.Scheme, Uri.UriSchemeFile, StringComparison.OrdinalIgnoreCase))
            {
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }

        /// <summary>Determines whether the specified full path is parent.</summary>
        /// <param name="fullPath">The full path.</param>
        /// <param name="baseName">Name of the base.</param>
        /// <returns><c>true</c> if the specified full path is parent; otherwise, <c>false</c>.</returns>
        public static bool IsParent(string fullPath, string baseName)
        {
            var fullPathSegments = SeparatePath(fullPath);
            var baseSegments = SeparatePath(baseName);
            var index = 0;

            while ((fullPathSegments.Count > index) && (baseSegments.Count > index) && string.Equals(fullPathSegments[index].Trim(), baseSegments[index].Trim(), StringComparison.CurrentCultureIgnoreCase))
            {
                index++;
            }

            return index == baseSegments.Count - 1;
        }

        /// <summary>Returns true if <paramref name="path"/> starts with the path <paramref name="baseDirPath"/>. The comparison is case-insensitive, handles / and \ slashes as folder separators and only matches if the base dir folder name is matched exactly ("c:\foobar\file.txt" is not a sub path of "c:\foo").</summary>
        public static bool IsSubPathOf(string path, string baseDirPath)
        {
            string normalizedPath = Path.GetFullPath(path.Replace('/', '\\').WithEnding("\\"));

            string normalizedBaseDirPath = Path.GetFullPath(baseDirPath.Replace('/', '\\').WithEnding("\\"));

            return normalizedPath.StartsWith(normalizedBaseDirPath, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>Determines whether [is valid URL] [the specified URL].</summary>
        /// <param name="urlPath">The URL.</param>
        /// <returns><c>true</c> if [is valid URL] [the specified URL]; otherwise, <c>false</c>.</returns>
        public static bool IsValidURL(string urlPath)
        {
            const string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(urlPath);
        }

        /// <summary>Combines the paths in to a <see cref="string"/> using the specified separator.</summary>
        /// <param name="pathSeparator">The path separator to use.</param>
        /// <param name="path1">The first path to combine.</param>
        /// <param name="path2">The second path to combine.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string PathCombine(char pathSeparator, string path1, string path2)
        {
            if (string.IsNullOrEmpty(path1))
            {
                if (string.IsNullOrEmpty(path2))
                {
                    return string.Empty;
                }
                else
                {
                    return path2;
                }
            }

            if (string.IsNullOrEmpty(path2))
            {
                if (string.IsNullOrEmpty(path1))
                {
                    return string.Empty;
                }
                else
                {
                    return path1;
                }
            }

            return $@"{path1}{pathSeparator}{path2}";
        }

        /// <summary>Combines the paths in to a <see cref="string"/> using the specified separator.</summary>
        /// <param name="pathSeparator">The path separator to use.</param>
        /// <param name="paths">An array of parts to the path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string PathCombine(char pathSeparator, params string[] paths)
        {
            StringBuilder fullPath = new StringBuilder();

            if (paths == null)
            {
                throw new ArgumentNullException(nameof(paths), @"The paths to combine cannot be null.");
            }

            if (paths.Length < 2)
            {
                throw new ArgumentNullException(nameof(paths), @"The paths array contains less than 2 items to combine! (Minimum of >2 or more paths required)");
            }

            var index = 0;

            // Loop thru each element item
            foreach (string path in paths)
            {
                if (index == paths.Length - 1)
                {
                    // Handle last index
                    fullPath.Append($@"{path}");
                }
                else
                {
                    // Handle initial or in-between index
                    fullPath.Append($@"{path}{pathSeparator}");
                }

                index++;
            }

            return fullPath.ToString();
        }

        /// <summary>Gets the rightmost <paramref name="length"/> characters from a string.</summary>
        /// <param name="value">The string to retrieve the substring from.</param>
        /// <param name="length">The number of characters to retrieve.</param>
        /// <returns>The substring.</returns>
        public static string Right(string value, int length)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), length, @"Length is less than zero");
            }

            return length < value.Length ? value.Substring(value.Length - length) : value;
        }

        /// <summary>Separates the path.</summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public static List<string> SeparatePath(string path)
        {
            var separators = new[]
            {
                Path.DirectorySeparatorChar,
                Path.AltDirectorySeparatorChar
            };

            var separatePath = path.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();
            return separatePath;
        }

        /// <summary>Splits the new lines.</summary>
        /// <param name="input">The input.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string[] SplitNewLines(string input)
        {
            return input.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
        }

        /// <summary>Returns the <see cref="string"/> as spaced into words by every uppercase.</summary>
        /// <param name="text">The text to split into words.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string SplitToWords(string text)
        {
            string output = string.Empty;

            // Loop thru each letter in the text
            foreach (char letter in text)
            {
                // Handle when the letter is uppercase and set the split
                if (char.IsUpper(letter) && (output.Length > 0))
                {
                    output += $@" {letter}";
                }
                else
                {
                    output += letter;
                }
            }

            return output;
        }

        /// <summary>Returns the <see cref="string"/> as spaced into words by every uppercase.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public static List<string> SplitWords(string text)
        {
            string wordsSpaced = SplitToWords(text);
            var wordsSplit = wordsSpaced.Split(' ');
            return wordsSplit.ToList();
        }

        /// <summary>Converts to the long file path.</summary>
        /// <param name="shortPath">The short file path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ToLongPath(string shortPath)
        {
            StringBuilder longPath = new StringBuilder(byte.MaxValue);
            Kernel32.GetLongPathName(shortPath, longPath, longPath.Capacity);
            return longPath.ToString();
        }

        /// <summary>Converts to the short file path.</summary>
        /// <param name="longPath">The long file path.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ToShortenPath(string longPath)
        {
            StringBuilder shortPath = new StringBuilder(byte.MaxValue);
            Kernel32.GetShortPathName(longPath, shortPath, shortPath.Capacity);
            return shortPath.ToString();
        }

        /// <summary>Returns <paramref name="str"/> with the minimal concatenation of <paramref name="ending"/> (starting from end) that results in satisfying .EndsWith(ending).</summary>
        /// <example>"hel".WithEnding("llo") returns "hello", which is the result of "hel" + "lo".</example>
        public static string WithEnding(this string str, string ending)
        {
            if (str == null)
            {
                return ending;
            }

            string result = str;

            // Right() is 1-indexed, so include these cases
            // * Append no characters
            // * Append up to N characters, where N is ending length
            for (int i = 0; i <= ending.Length; i++)
            {
                string tmp = result + Right(ending, i);

                if (tmp.EndsWith(ending))
                {
                    return tmp;
                }
            }

            return result;
        }

        #endregion

        #region Methods

        private static string AppendDirectorySeparatorChar(string path)
        {
            // Append a slash only if the path is a directory and does not have a slash.
            if (!Path.HasExtension(path) && !path.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                return path + Path.DirectorySeparatorChar;
            }

            return path;
        }

        #endregion
    }
}