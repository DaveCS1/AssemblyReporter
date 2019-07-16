#region License

// ********************************* Header *********************************\
// 
//    Class:  ListExtensions.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace AssemblyReport.Extensibility
{
    /// <summary>The <see cref="ListExtensions"/> extensions provider class.</summary>
    public static class ListExtensions
    {
        #region Public Methods and Operators

        /// <summary>Returns a new <see cref="List{T}"/> that was filtered using the blacklist.</summary>
        /// <param name="source">The source.</param>
        /// <param name="blackListFilter">The filter.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">source - The source list cannot be null. or source - The source list must contain items to get filtered. or filter - The filter list cannot be null. or filter - The filter list must contain item elements filter.</exception>
        public static List<string> Filter(this List<string> source, List<string> blackListFilter)
        {
            // Validate the parameter input
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), @"The source list cannot be null.");
            }

            if (source.Count <= 0)
            {
                throw new ArgumentNullException(nameof(source), @"The source list must contain items to get filtered.");
            }

            if (blackListFilter == null)
            {
                throw new ArgumentNullException(nameof(blackListFilter), @"The filter list cannot be null.");
            }

            if (blackListFilter.Count <= 0)
            {
                throw new ArgumentNullException(nameof(blackListFilter), @"The filter list must contain item elements filter.");
            }

            // Initialize variables
            var filteredList = source;

            // Handle each filter element
            foreach (string elementFilter in blackListFilter)
            {
                // Remove all list matches
                int unused = filteredList.RemoveAll(listElements => listElements.ToString().Equals(elementFilter));
            }

            return filteredList;
        }

        /// <summary>Returns a new <see cref="List{T}"/> that was filtered using the index value to remove every other # Nth element from the <see cref="List{T}"/>.</summary>
        /// <param name="source">The source.</param>
        /// <param name="index">The index.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">source - The source list cannot be null. or source - The source list must contain items to get filtered.</exception>
        public static List<string> FilterNth(this List<string> source, int index = 2)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), @"The source list cannot be null.");
            }

            if (source.Count <= 0)
            {
                throw new ArgumentNullException(nameof(source), @"The source list must contain items to get filtered.");
            }

            // Remove every # Nth element index item from the list to a new list
            return source.Where((x, i) => i % index == 0).ToList();
        }

        #endregion
    }
}