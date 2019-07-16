#region License

// ********************************* Header *********************************\
// 
//    Class:  NodeExtensions.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AssemblyReport.Primitives;

#endregion

namespace AssemblyReport.Extensibility
{
    /// <summary>The <see cref="NodeExtensions"/> class.</summary>
    public static class NodeExtensions
    {
        #region Public Methods and Operators

        /// <summary>Duplicate the specified selector.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Duplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var grouped = source.GroupBy(selector);
            var moreThen1 = grouped.Where(i => i.IsMultiple());

            return moreThen1.SelectMany(i => i);
        }

        /// <summary>Formats the invariant.</summary>
        /// <param name="text">The text.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static string FormatInvariant(this string text, params object[] parameters)
        {
            // This is not the "real" implementation, but that would go out of Scope
            return string.Format(CultureInfo.InvariantCulture, text, parameters);
        }

        /// <summary>Determines whether this instance is multiple.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns><c>true</c> if the specified source is multiple; otherwise, <c>false</c>.</returns>
        public static bool IsMultiple<T>(this IEnumerable<T> source)
        {
            if (source != null)
            {
                using (var enumerator = source.GetEnumerator())
                {
                    return enumerator.MoveNext() && enumerator.MoveNext();
                }
            }

            return false;
        }

        /// <summary>Converts to IEnumerable.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static IEnumerable<T> ToIEnumerable<T>(this T item)
        {
            yield return item;
        }

        /// <summary>Values the specified nodes.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodes">The nodes.</param>
        /// <returns></returns>
        public static IEnumerable<T> Values<T>(this IEnumerable<Node<T>> nodes)
        {
            return nodes.Select(n => n.Value);
        }

        #endregion
    }
}