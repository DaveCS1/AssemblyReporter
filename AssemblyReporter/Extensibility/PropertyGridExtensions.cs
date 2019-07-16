#region License

// ********************************* Header *********************************\
// 
//    Class:  PropertyGridExtensions.cs
//    Copyright (c) 2019 - 2019 AssemblyReporter. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Reflection;
using System.Windows.Forms;

#endregion

namespace AssemblyReporter.Extensibility
{
    /// <summary>The <see cref="PropertyGridExtensions"/> provider class.</summary>
    public static class PropertyGridExtensions
    {
        #region Public Methods and Operators

        /// <summary>Moves the property grid splitter to the specified position.</summary>
        /// <param name="propertyGrid">The PropertyGrid that will have its splitter moved.</param>
        /// <param name="position">The new position of the splitter.</param>
        public static void MoveSplitterTo(this PropertyGrid propertyGrid, int position)
        {
            // There is an internal class known as 'System.Windows.Forms.PropertyGridInternal.PropertyGridView'.
            // Which contains the 'MoveSplitterTo' method. We can invoke the 'MoveSplitterTo' method with the
            // specified position using reflection.

            // The 'System.Windows.Forms.PropertyGridInternal.PropertyGridView' is always the 3rd control in the
            // 'PropertyGrid' control collection.
            Control propertyGridView = propertyGrid.Controls[2];
            Type propertyGridViewType = propertyGridView.GetType();

            // The method to invoke is defined as: 'private void MoveSplitterTo(int position)'.
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            MethodInfo methodInfo = propertyGridViewType.GetMethod("MoveSplitterTo", flags);
            methodInfo?.Invoke(propertyGridView, new object[] {position});
        }

        #endregion
    }
}