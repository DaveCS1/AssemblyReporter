#region License

// ********************************* Header *********************************\
// 
//    Class:  Program.cs
//    Copyright (c) 2019 - 2019 AssemblyReporter. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Windows.Forms;
using AssemblyReporter.Forms;

#endregion

namespace AssemblyReporter
{
    internal static class Program
    {
        #region Methods

        /// <summary>The main entry point for the application.</summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        #endregion
    }
}