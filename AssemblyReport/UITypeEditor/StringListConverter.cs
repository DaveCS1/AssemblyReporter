#region License

// ********************************* Header *********************************\
// 
//    Class:  StringListConverter.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

#endregion

namespace AssemblyReport.UITypeEditor
{
    /// <summary>The <see cref="StringListConverter"/> class.</summary>
    /// <seealso cref="System.ComponentModel.ExpandableObjectConverter"/>
    [ComVisible(true)]
    public class StringListConverter : ExpandableObjectConverter
    {
        #region Public Methods and Operators

        /// <summary>Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. </param>
        /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from. </param>
        /// <returns><see langword="true"/> if this converter can perform the conversion; otherwise, <see langword="false"/>.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // Sets the property to read only.
            return true;
        }

        /// <summary>Converts the given value object to the specified type, using the specified context and culture information.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. </param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If <see langword="null"/> is passed, the current culture is assumed. </param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert. </param>
        /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to. </param>
        /// <returns>An <see cref="T:System.Object"/> that represents the converted value.</returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is <see langword="null"/>. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if ((destinationType == typeof(string)) && value is List<string> list)
            {
                return $@"Count: {list.Count}";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        /// <summary>Returns whether the collection of standard values returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exclusive list of possible values, using the specified context.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. </param>
        /// <returns><see langword="true"/> if the <see cref="T:System.ComponentModel.TypeConverter.StandardValuesCollection"/> returned from <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> is an exhaustive list of possible values; <see langword="false"/> if other values are possible.</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true; // Drop-down vs combo
        }

        /// <summary>Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.</summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context. </param>
        /// <returns><see langword="true"/> if <see cref="M:System.ComponentModel.TypeConverter.GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, <see langword="false"/>.</returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true; // Display drop
        }

        #endregion
    }
}