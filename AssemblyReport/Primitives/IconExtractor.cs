#region License

// ********************************* Header *********************************\
// 
//    Class:  IconExtractor.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using AssemblyReport.InteropServices.Functions;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>Creates a new instance of the IconExtractor class.</summary>
    public class IconExtractor : IDisposable
    {
        #region Fields

        private List<Icon> icons;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the IconExtractor class.</summary>
        /// <param name="path">The full path to the file containing icons.</param>
        public IconExtractor(string path) : this(path, IconSize.Large)
        {
        }

        /// <summary>Initializes a new instance of the IconExtractor class.</summary>
        /// <param name="path">The full path to the file containing icons.</param>
        /// <param name="size">An IconSize value indicating whether to retreive 16x16 or 32x32 icons.</param>
        public IconExtractor(string path, IconSize size)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), @"The icon path cannot be null or empty.");
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException(@"The icon file path cannot be found.", path);
            }

            IconSource = path;
            var nullPointers = new IntPtr[0];
            Count = Shell32.ExtractIconEx(path, -1, nullPointers, nullPointers, 1);
            icons = new List<Icon>(Count);

            var largeIcons = size == IconSize.Large ? new IntPtr[Count] : null;
            var smallIcons = size == IconSize.Small ? new IntPtr[Count] : null;

            Shell32.ExtractIconEx(path, 0, largeIcons, smallIcons, Count);
            var extractedIcons = largeIcons ?? smallIcons;

            if ((extractedIcons != null) && (extractedIcons.Length > 0))
            {
                foreach (IntPtr handle in extractedIcons)
                {
                    if (handle != IntPtr.Zero)
                    {
                        icons.Add((Icon)Icon.FromHandle(handle).Clone());
                        User32.DestroyIcon(handle);
                    }
                }
            }
        }

        #endregion

        #region Enums

        /// <summary>Determines the size of extracted icons.</summary>
        public enum IconSize
        {
            /// <summary>32 x 32</summary>
            Large = 0,

            /// <summary>16 x 16</summary>
            Small = 1
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the total number of icons contained in the current IconExtractor.</summary>
        public int Count { get; private set; }

        /// <summary>Gets the default icon located in the first index.</summary>
        /// <value>The default icon.</value>
        public Icon Default
        {
            get
            {
                if (Count > 0)
                {
                    return this[0];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>Gets the full path to the file containing the icons in the current IconExtractor.</summary>
        public string IconSource { get; private set; }

        #endregion

        #region Public Indexers

        /// <summary>Gets the icon at the specified index.</summary>
        /// <param name="index">The zero-based index of the icon to get.</param>
        public Icon this[int index]
        {
            get { return icons[index]; }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>Releases all resources used by this IconExtractor.</summary>
        public void Dispose()
        {
            icons.ForEach(icon => icon.Dispose());
        }

        /// <summary>Returns all icons contained in the current IconExtractor.</summary>
        /// <returns>A collection of icons.</returns>
        public IEnumerable<Icon> GetAll()
        {
            return icons.AsEnumerable();
        }

        #endregion
    }
}