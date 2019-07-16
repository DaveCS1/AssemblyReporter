#region License

// ********************************* Header *********************************\
// 
//    Class:  ExternalDll.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

namespace AssemblyReport.InteropServices
{
    /// <summary>Represents the <see cref="ExternalDll"/> class.</summary>
    /// <remarks>The name of the unmanaged dynamic-link library (<c>DLL</c>) entry point.</remarks>
    public static class ExternalDll
    {
        #region Constants

        /// <summary>Security Descriptor Editor.</summary>
        public const string AclUI = "aclui" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>ADs Router Layer DLL.</summary>
        public const string Activeds = "activeds" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Advanced Windows 32 Base API.</summary>
        public const string AdvApi32 = "advapi32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Authorization Framework.</summary>
        public const string Authz = "authz" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows Cryptographic Primitives Library (Wow64).</summary>
        public const string Bcrypt = "bcrypt" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft Cabinet File API.</summary>
        public const string Cabinet = "cabinet" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft .NET Runtime Common Language Runtime.</summary>
        public const string Clr = "clr" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>User Experience Controls Library.</summary>
        public const string ComCtl32 = "comctl32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Common Dialogs DLL.</summary>
        public const string ComDlg32 = "comdlg32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>ApiSet Stub DLL.</summary>
        public const string CoreDll = "coredll" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Credential Manager User Interface.</summary>
        public const string CredUI = "credui" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Crypto API32.</summary>
        public const string Crypt32 = "crypt32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft Desktop Window Manager API.</summary>
        public const string DwmApi = "dwmapi" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>GDI Client DLL.</summary>
        public const string Gdi32 = "gdi32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft GDI+.</summary>
        public const string GdiPlus = "gdiplus" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft HTML Help Control.</summary>
        public const string HhCtrl = "hhctrl" + FileExtensionSeparator + ActiveXControlExtension;

        /// <summary>Multi-User Windows IMM32 API Client DLL.</summary>
        public const string Imm32 = "imm32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>IP Helper API.</summary>
        public const string IpHlpApi = "Iphlpapi" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows NT BASE API Client DLL.</summary>
        public const string Kernel32 = "kernel32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows NT BASE API Client DLL.</summary>
        public const string KernelBase = "kernelbase" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Load and Unload Performance Counters.</summary>
        public const string LoadPerf = "loadperf" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Multiple Provider Router DLL.</summary>
        public const string Mpr = "mpr" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Message Queuing Runtime.</summary>
        public const string Mqrt = "mqrt" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft .NET Runtime Execution Engine.</summary>
        public const string Mscoree = "mscoree" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows Installer.</summary>
        public const string Msi = "msi" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Task Scheduler interface DLL.</summary>
        public const string MsTask = "mstask" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows NCrypt Router.</summary>
        public const string Ncrypt = "ncrypt" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Net Win32 API DLL.</summary>
        public const string NetApi32 = "netapi32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Unicode Normalization DLL.</summary>
        public const string Normaliz = "normaliz" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>NT Layer DLL.</summary>
        public const string NtDll = "ntdll" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Active Directory Domain Services API.</summary>
        public const string NtdsApi = "ntdsapi" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Oracle Call Interface.</summary>
        public const string Oci = "oci" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>ODBC Driver Manager.</summary>
        public const string Odbc32 = "odbc32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft OLE for Windows.</summary>
        public const string Ole32 = "ole32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Active Accessibility Core Component.</summary>
        public const string OleAcc = "oleacc" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft for OLE technologies.</summary>
        public const string OleAut32 = "oleaut32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows support to perform OLE (Object Linking and Embedding) operations. OLEPro32 stands for Object Linking and Embedding Property Support Library 32.</summary>
        public const string OlePro32 = "olepro32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft performance counter extension for .NET Runtime.</summary>
        public const string PerfCounter = "perfcounter" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Power Profile Helper DLL.</summary>
        public const string PowrProf = "powrprof" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft Property System.</summary>
        public const string PropSys = "propsys" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Process Status Helper.</summary>
        public const string PsApi = "psapi" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Security Support Provider Interface.</summary>
        public const string Secur32 = "secur32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>The SHcore.</summary>
        public const string ShCore = "SHCore" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows Shell Common Dll.</summary>
        public const string Shell32 = "shell32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Shell Light-weight Utility Library.</summary>
        public const string ShlwApi = "shlwapi" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Token Binding Protocol.</summary>
        public const string TokenBinding = "tokenbinding" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Multi-User Windows USER API Client DLL.</summary>
        public const string User32 = "user32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Microsoft UxTheme Library.</summary>
        public const string UxTheme = "uxtheme" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Version Checking and File Installation Libraries.</summary>
        public const string Version = "version" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>VSM enclave runtime DLL.</summary>
        public const string VertDll = "vertdll" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Virtual Disk API DLL.</summary>
        public const string VirtDisk = "virtdisk" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Internet Extensions for Win32.</summary>
        public const string WinInet = "wininet" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>MCI API DLL.</summary>
        public const string WinMM = "winmm" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows Spooler Driver.</summary>
        public const string Winspool = "winspool" + FileExtensionSeparator + DeviceDriverExtension;

        /// <summary>Windows Lockdown Policy.</summary>
        public const string Wldp = "wldp" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows Socket 2.0 32-Bit DLL.</summary>
        public const string Ws2_32 = "ws2_32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>Windows Remote Desktop Session Host Server SDK APIs.</summary>
        public const string WtsApi32 = "wtsapi32" + FileExtensionSeparator + ApplicationExtension;

        /// <summary>The (<c>*.ocx</c>) file extension.</summary>
        private const string ActiveXControlExtension = "ocx";

        /// <summary>The (<c>*.dll</c>) file extension.</summary>
        private const string ApplicationExtension = "dll";

        /// <summary>The (<c>*.ocx</c>) file extension.</summary>
        private const string DeviceDriverExtension = "drv";

        /// <summary>The file extension separator.</summary>
        private const string FileExtensionSeparator = ".";

        #endregion
    }
}