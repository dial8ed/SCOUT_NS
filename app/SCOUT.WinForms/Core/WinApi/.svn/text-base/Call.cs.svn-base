/*
 * Windows API calls.
 */
using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace SCOUT.WinForms.Core.WinApi
{
    public static class Call
    {
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd,
                                                 ref POINT pnt);

        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd,
                                                 ref POINT pnt);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(int uiAction,
                                                       int uiParam, ref NONCLIENTMETRICS pvParam,
                                                       int fWinIni);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(IntPtr lpModuleName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetCursorPos(ref POINT pnt);

        [DllImport("winspool.drv",
            EntryPoint = "OpenPrinterW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool OpenPrinter(string src,
                                              out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.drv",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv",
            EntryPoint = "StartDocPrinterW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter,
                                                  Int32 level, ref DOCINFO pDocInfo);

        [DllImport("winspool.drv",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool WritePrinter(IntPtr hPrinter,
                                               IntPtr pBytes,
                                               Int32 dwCount,
                                               ref Int32 dwWritten);

        [DllImport("winspool.drv",
            EntryPoint = "GetDefaultPrinterW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool GetDefaultPrinter(IntPtr pszBuffer,
                                                    ref Int32 pcchBuffer);

        [DllImport("winspool.drv",
            EntryPoint = "EnumPrintersW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool EnumPrinters(
            Int32 flags, string name, Int32 level,
            IntPtr pPrinterEum, Int32 cbBuf,
            ref Int32 pcbNeeded,
            ref Int32 pcReturned);

        [DllImport("kernel32.dll",
            EntryPoint = "CreateEventW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern SafeWaitHandle CreateEvent(
            IntPtr lpEventAttributes,
            bool bManualReset,
            bool bInitialState,
            string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ResetEvent(SafeWaitHandle hEvent);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetEvent(SafeWaitHandle hEvent);

        [DllImport("kernel32.dll",
            SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll",
            SetLastError = true)]
        public static extern int WaitForSingleObject(IntPtr hHandle,
                                                     int dwMilliseconds);

        [DllImport("wininet.dll",
            EntryPoint = "InternetOpenW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern IntPtr InternetOpen(
            string lpszAgent,
            int dwAccessType,
            IntPtr lpszProxyName,
            IntPtr lpszProxyBypass,
            int dwFlags);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetCloseHandle(IntPtr handle);

        [DllImport("wininet.dll",
            EntryPoint = "InternetOpenUrlW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern IntPtr InternetOpenUrl(
            IntPtr hInternet,
            string lpszUrl,
            string lpszHeaders,
            int dwHeadersLength,
            int dwFlags,
            object dwContext);

        [DllImport("kernel32.dll",
            EntryPoint = "GetVersionExW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool GetVersionEx(
            [In, Out] OSVERSIONINFO lpVersionInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int GetCurrentProcessId();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateToolhelp32Snapshot(
            int dwFlags, int th32ProcessID);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Process32First(IntPtr hSnapshot,
                                                 ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Process32Next(IntPtr hSnapShot,
                                                ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess,
                                                bool bInheritHandle, int dwProcessID);

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern bool EnumProcessModules(
            IntPtr hProcess, ref IntPtr lphModule,
            int cb, ref int lpcbNeeded);

        [DllImport("psapi.dll",
            EntryPoint = "GetModuleFileNameExW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern int GetModuleFileNameEx(
            [In] IntPtr hProcess,
            [In] IntPtr hModule,
            [Out] StringBuilder lpFileName,
            [In, MarshalAs(UnmanagedType.U4)] int nSize);

        [DllImport("user32.dll",
            EntryPoint = "LoadIconW",
            CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern IntPtr LoadIcon(
            IntPtr hInstance, int lpIconName);

        [DllImport("UxTheme")]
        public static extern bool IsThemeActive();

        [DllImport("UxTheme")]
        public static extern bool IsAppThemed();
    }
}