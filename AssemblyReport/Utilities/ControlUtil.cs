#region License

// ********************************* Header *********************************\
// 
//    Class:  ControlUtil.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Globalization;
using System.Windows.Forms;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="ControlUtil"/> class.</summary>
    public static class ControlUtil
    {
        #region Public Methods and Operators

        /// <summary>Invokes if required the control.</summary>
        /// <param name="control">The control.</param>
        /// <param name="action">The action.</param>
        public static void InvokeIfRequired<TControl>(TControl control, MethodInvoker action) where TControl : Control
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), @"The control cannot be null.");
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), @"The action cannot be null.");
            }

            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        /// <summary>Invokes if required the 'Tool Strip Menu Item' control.</summary>
        /// <param name="control">The ToolStripMenu item control.</param>
        /// <param name="action">The action.</param>
        public static void InvokeIfRequiredToolStrip<TControl>(TControl control, Action<TControl> action) where TControl : ToolStripItem
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), @"The tool strip control cannot be null.");
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), @"The action cannot be null.");
            }

            if ((control.GetCurrentParent() != null) && control.GetCurrentParent().InvokeRequired)
            {
                control.GetCurrentParent().Invoke(new Action(() => action(control)));
            }
            else
            {
                action(control);
            }
        }

        /// <summary>Gets the elapsed duration to formatted text.</summary>
        /// <param name="elapsed">The elapsed duration.</param>
        /// <param name="prefix">The text prefix.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ResolveDurationText(TimeSpan elapsed, string prefix = @"Duration: ")
        {
            // Update timer stopwatch duration.
            TimeSpan stopwatchElapsed = elapsed;

            // Format the elapsed scan time.
            string ticksText = $@"({stopwatchElapsed.ToString("fff", CultureInfo.InvariantCulture)}) tick(s)";
            string secondsText = $@"{stopwatchElapsed.TotalSeconds:0.###} Second(s)";

            // string hoursText = $@"{stopwatchElapsed.TotalHours:00000000}h";
            string scanDurationText = $@"{prefix}{secondsText} [{ticksText}]";

            return scanDurationText;
        }

        #endregion
    }
}