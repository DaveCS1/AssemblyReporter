#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownTable.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace AssemblyReport.Primitives.Markdown.Elements
{
    /// <summary>The <see cref="MarkdownTable"/> class.</summary>
    /// <seealso cref="MarkdownElement"/>
    public class MarkdownTable : MarkdownElement
    {
        #region Constants

        /// <summary>The minimum value.</summary>
        public const int MinValue = 1;

        /// <summary>The table separator.</summary>
        public const char TableSeparator = '|';

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownEmphasis"/> class.</summary>
        /// <param name="columns">The table columns.</param>
        /// <param name="rows">The table rows.</param>
        public MarkdownTable(List<string> columns, List<string> rows) : this()
        {
            if (columns.Count <= MinValue)
            {
                throw new ArgumentNullException(nameof(columns), @"Markdown table requires a minimum of 1 column.");
            }

            if (rows.Count <= MinValue)
            {
                throw new ArgumentNullException(nameof(columns), @"Markdown table requires a minimum of 1 row.");
            }

            Columns = columns;
            Rows = rows;

            CreateTable();
        }

        /// <summary>Prevents a default instance of the <see cref="MarkdownEmphasis"/> class from being created.</summary>
        private MarkdownTable() : base("Table")
        {
            Columns = new List<string>();
            Rows = new List<string>();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the table columns.</summary>
        /// <value>The columns.</value>
        public List<string> Columns { get; set; }

        /// <summary>Gets or sets the table rows.</summary>
        /// <value>The rows.</value>
        public List<string> Rows { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Creates the markdown table.</summary>
        /// <param name="columns">The table columns.</param>
        /// <param name="rows">The table rows.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateTable(List<string> columns, List<string> rows)
        {
            // Build the table
            StringBuilder tableBuilder = new StringBuilder();

            // Create columns
            for (var x = 0; x < columns.Count; x++)
            {
                if (x == 0)
                {
                    tableBuilder.Append($"{columns[x]} {TableSeparator}");
                }
                else if (x == columns.Count - 1)
                {
                    tableBuilder.AppendLine($" {columns[x]}");
                }
                else
                {
                    tableBuilder.Append($" {columns[x]} {TableSeparator}");
                }
            }

            // Create rows
            tableBuilder.AppendLine($"{rows[0]}");

            for (var y = 1; y < rows.Count; y++)
            {
                tableBuilder.AppendLine($"{rows[y]}");
            }

            return tableBuilder.ToString();
        }

        /// <summary>Creates the table.</summary>
        public void CreateTable()
        {
            MarkdownContentText = CreateTable(Columns, Rows);
        }

        #endregion
    }
}