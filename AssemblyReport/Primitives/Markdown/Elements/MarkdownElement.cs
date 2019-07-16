#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownElement.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;

#endregion

namespace AssemblyReport.Primitives.Markdown.Elements
{
    /// <summary>The <see cref="MarkdownElement"/> class.</summary>
    /// <seealso cref="IDisposable"/>
    public abstract class MarkdownElement : IDisposable
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownElement"/> class.</summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">name - The markdown element name cannot be null or empty.</exception>
        protected MarkdownElement(string name) : this()
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), @"The markdown element name cannot be null or empty.");
            }

            Name = name;
        }

        /// <summary>Prevents a default instance of the <see cref="MarkdownElement"/> class from being created.</summary>
        private MarkdownElement()
        {
            MarkdownContentText = string.Empty;
            Name = string.Empty;
            Value = string.Empty;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the markdown content text.</summary>
        /// <value>The content text.</value>
        public string MarkdownContentText { get; set; }

        /// <summary>Gets the name of the element.</summary>
        /// <value>The element name.</value>
        public string Name { get; }

        /// <summary>Gets the element text value.</summary>
        /// <value>The text value.</value>
        public string Value { get; internal set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Creates a comment.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string CreateComment(string text)
        {
            return string.Format(@"[comment]: # {0}{1}{0}", Constants.Quotes, text);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            // Do nothing.
        }

        #endregion
    }
}