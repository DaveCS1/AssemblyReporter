#region License

// ********************************* Header *********************************\
// 
//    Class:  Extensions.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

#endregion

#region Namespace

using System;
using System.Windows.Forms;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Extensibility
{
    /// <summary>The extensions provider class.</summary>
    public static class Extensions
    {
        #region Public Methods and Operators

        /// <summary>Invokes if required.</summary>
        /// <param name="control">The control.</param>
        /// <param name="action">The action.</param>
        public static void InvokeIfRequired<TControl>(this TControl control, MethodInvoker action) where TControl : Control
        {
            ControlUtil.InvokeIfRequired(control, action);
        }

        /// <summary>Invokes if required the 'Tool Strip Menu Item' control.</summary>
        /// <param name="control">The ToolStripMenu item control.</param>
        /// <param name="action">The action.</param>
        public static void InvokeIfRequiredToolStrip<TControl>(this TControl control, Action<TControl> action) where TControl : ToolStripItem
        {
            ControlUtil.InvokeIfRequiredToolStrip(control, action);
        }

        #endregion
    }
}