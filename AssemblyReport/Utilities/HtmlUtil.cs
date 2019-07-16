#region License

// ********************************* Header *********************************\
// 
//    Class:  HtmlUtil.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="HtmlUtil"/> class.</summary>
    public static class HtmlUtil
    {
        #region Public Methods and Operators

        /// <summary>Generates the back to top in an array.</summary>
        /// <returns>The <see cref="string"/>.</returns>
        public static string[] GenerateBackToTop()
        {
            var backToTop = new string[2];

            //<a name="top"></a>
            backToTop[0] = string.Format(@"<a name={0}top{0}></a>", Constants.Quotes);

            // <p align=center><a href="#top">Back to top</a></p>
            backToTop[1] = string.Format(@"<p align=center><a href={0}#top{0}>Back to Top</a></p>", Constants.Quotes);

            return backToTop;
        }

        /// <summary>Generates the HTML image code.</summary>
        /// <param name="src">The source.</param>
        /// <param name="altText">The alt text.</param>
        /// <param name="size">The size.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateHTMLImageCode(string src, string altText, Size size)
        {
            return string.Format(@"<img alt={0}{2}{0} width={0}{3}{0} height={0}{4}{0} src={0}{1}{0}>", Constants.Quotes, src, altText, size.Width, size.Height);
        }

        /// <summary>Generates the HTML image code with a link.</summary>
        /// <param name="href">The href.</param>
        /// <param name="src">The source.</param>
        /// <param name="altText">The alt text.</param>
        /// <param name="size">The size.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateHTMLImageCode(string href, string src, string altText, Size size)
        {
            return string.Format(@"<a href={0}{1}{0}><img alt={0}{3}{0} width={0}{4}{0} height={0}{5}{0} src={0}{2}{0}></a>", Constants.Quotes, href, src, altText, size.Width, size.Height);
        }

        /// <summary>Generates the HTML image code.</summary>
        /// <param name="alignment">The alignment.</param>
        /// <param name="src">The source.</param>
        /// <param name="altText">The alt text.</param>
        /// <param name="size">The size.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateHTMLImageCode(HorizontalAlign alignment, string src, string altText, Size size)
        {
            StringBuilder imageBuilder = new StringBuilder();
            imageBuilder.AppendLine(string.Format(@"<p align={0}{1}{0}>", Constants.Quotes, alignment.ToString()));
            imageBuilder.AppendLine(string.Format(@"<img alt={0}{2}{0} width={0}{3}{0} height={0}{4}{0} src={0}{1}{0}></p>", Constants.Quotes, src, altText, size.Width, size.Height));
            return imageBuilder.ToString();
        }

        /// <summary>Generates the HTML image code with a link.</summary>
        /// <param name="alignment">The alignment.</param>
        /// <param name="href">The href.</param>
        /// <param name="src">The source.</param>
        /// <param name="altText">The alt text.</param>
        /// <param name="size">The size.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateHTMLImageCode(HorizontalAlign alignment, string href, string src, string altText, Size size)
        {
            StringBuilder imageBuilder = new StringBuilder();
            imageBuilder.AppendLine(string.Format(@"<p align={0}{1}{0}>", Constants.Quotes, alignment.ToString()));
            imageBuilder.AppendLine(string.Format(@"<a href={0}{1}{0}><img alt={0}{3}{0} width={0}{4}{0} height={0}{5}{0} src={0}{2}{0}></a></p>", Constants.Quotes, href, src, altText, size.Width, size.Height));
            return imageBuilder.ToString();
        }

        /// <summary>Generates the HTML text code.</summary>
        /// <param name="alignment">The alignment.</param>
        /// <param name="text">The text.</param>
        /// <param name="prefixCode">The prefix code.</param>
        /// <param name="fontStyle">The font style.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GenerateHTMLTextCode(HorizontalAlign alignment, string text, string prefixCode = "p", FontStyle fontStyle = FontStyle.Regular)
        {
            // Allow using custom prefix text to create specific types like: 'h1' or 'p'.

            // FontStyle style = FontStyle.Bold | FontStyle.Regular;

            // Add custom font styling.

            // <p align="center" style="font-style:italic;font-size:12pt">

            // <p align="center" style="font-style:italic;">
            // Features the latest project repositories as a gallery showcase.
            // </p>

            StringBuilder imageBuilder = new StringBuilder();
            imageBuilder.AppendLine(string.Format(@"<{1} align={0}{2}{0}>", Constants.Quotes, prefixCode, alignment.ToString()));

            // Create the font style.
            // imageBuilder.Append(string.Format(@"style={0}font-style:italic;{0}>", Constants.Quotes, 0));
            // imageBuilder.Append(string.Format(@"style={0}{2}{0}>", Constants.Quotes, 0));

            imageBuilder.AppendLine($@"{text}");

            imageBuilder.AppendLine($@"</{prefixCode}>");

            return imageBuilder.ToString();
        }

        /// <summary>Validates the HTTP url text and returns a formatted <see cref="Uri"/>.</summary>
        /// <param name="urlText">The URL text.</param>
        /// <param name="resultURI">The result URI.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public static bool ValidateUrlToHTTP(string urlText, out Uri resultURI)
        {
            if (!Regex.IsMatch(urlText, @"^https?:\/\/", RegexOptions.IgnoreCase))
            {
                urlText = "http://" + urlText;
            }

            if (Uri.TryCreate(urlText, UriKind.Absolute, out resultURI))
            {
                return (resultURI.Scheme == Uri.UriSchemeHttp) || (resultURI.Scheme == Uri.UriSchemeHttps);
            }

            return false;
        }

        #endregion
    }
}