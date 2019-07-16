#region License

// ********************************* Header *********************************\
// 
//    Class:  GeneratorDescriptor.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System.ComponentModel;
using System.Diagnostics;

#endregion

namespace AssemblyReport.Primitives
{
    /// <summary>The <see cref="GeneratorDescriptor"/> class.</summary>
    [DebuggerDisplay("Name = {name}, Remarks = {remarks}")]
    [RefreshProperties(RefreshProperties.All)]
    public class GeneratorDescriptor : INotifyPropertyChanged
    {
        #region Fields

        private string name;
        private string remarks;
        private string returnTypeName;

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="GeneratorDescriptor"/> class.</summary>
        /// <param name="name">The name.</param>
        public GeneratorDescriptor(string name) : this(name, string.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GeneratorDescriptor"/> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="returnTypeName">Name of the return type.</param>
        public GeneratorDescriptor(string name, string returnTypeName) : this(name, returnTypeName, string.Empty)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="GeneratorDescriptor"/> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="returnTypeName">Name of the return type.</param>
        /// <param name="remarks">The remarks.</param>
        public GeneratorDescriptor(string name, string returnTypeName, string remarks) : this()
        {
            this.name = name;
            this.remarks = remarks;
            this.returnTypeName = returnTypeName;
        }

        /// <summary>Initializes a new instance of the <see cref="GeneratorDescriptor"/> class.</summary>
        public GeneratorDescriptor()
        {
            name = string.Empty;
            remarks = string.Empty;
            returnTypeName = string.Empty;
        }

        #endregion

        #region Public Events

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Category(CategoryConstants.Identification)]
        [DisplayName("Name")]
        [RefreshProperties(RefreshProperties.All)]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>Gets or sets the remarks.</summary>
        /// <value>The remarks.</value>
        [Category(CategoryConstants.Information)]
        [DisplayName("Remarks")]
        [RefreshProperties(RefreshProperties.All)]
        public string Remarks
        {
            get { return remarks; }
            set
            {
                remarks = value;
                OnPropertyChanged(nameof(Remarks));
            }
        }

        /// <summary>Gets or sets the name of the return type.</summary>
        /// <value>The name of the return type.</value>
        [Category(CategoryConstants.Settings)]
        [DisplayName("Return Type Name")]
        [RefreshProperties(RefreshProperties.All)]
        public string ReturnTypeName
        {
            get { return returnTypeName; }
            set
            {
                returnTypeName = value;
                OnPropertyChanged(nameof(ReturnTypeName));
            }
        }

        #endregion

        #region Methods

        /// <summary>Called when [property changed].</summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}