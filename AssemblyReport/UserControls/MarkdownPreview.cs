#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownPreview.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System.Windows.Forms;

#endregion

namespace AssemblyReport.UserControls
{
    /// <summary>The <see cref="MarkdownPreview"/> user control.</summary>
    /// <seealso cref="System.Windows.Forms.UserControl"/>
    public partial class MarkdownPreview : UserControl
    {
        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownPreview"/> class.</summary>
        public MarkdownPreview()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the text preview.</summary>
        /// <value>The text preview.</value>
        public string TextPreview
        {
            get { return Rtb_Preview.Text; }
        }

        #endregion
    }
}