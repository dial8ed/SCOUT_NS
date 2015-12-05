/*
 * Windows API structures.
 */
using System;
using System.Runtime.InteropServices;

namespace SCOUT.WinForms.Core.WinApi
{
    /// <summary>
    /// Win32 point structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct TOOLINFO
    {
        public int cbSize;
        public int uFlags;
        public IntPtr hWnd;
        public IntPtr uId;
        public RECT rect;
        public IntPtr hInst;
        public IntPtr lpszText;
        public IntPtr lParam;
        public IntPtr lpReserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LOGFONT
    {
        public int lfHeight;
        public int lfWidth;
        public int lfEscapement;
        public int lfOrientation;
        public int lfWeight;
        public byte lfItalic;
        public byte lfUnderline;
        public byte lfStrikeOut;
        public byte lfCharSet;
        public byte lfOutPrecision;
        public byte lfClipPrecision;
        public byte lfQuality;
        public byte lfPitchAndFamily;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] lfFaceName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NONCLIENTMETRICS
    {
        public int cbSize;
        public int iBorderWidth;
        public int iScrollWidth;
        public int iScrollHeight;
        public int iCaptionWidth;
        public int iCaptionHeight;
        public LOGFONT lfCaptionFont;
        public int iSmCaptionWidth;
        public int iSmCaptionHeight;
        public LOGFONT lpSmCaptionFont;
        public int iMenuWidth;
        public int iMenuHeight;
        public LOGFONT lfMenuFont;
        public LOGFONT lfStatusFont;
        public LOGFONT lpMessageFont;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_DEFAULTS
    {
        public string pDatatype;
        public IntPtr pDevmode;
        public int DesiredAccess;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DOCINFO
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDocName;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pOutputFile;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDataType;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PRINTER_INFO_1
    {
        public Int32 Flags;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDescription;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pName;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string pComment;
    }

    [StructLayout(LayoutKind.Sequential,
        CharSet = CharSet.Auto)]
    public class OSVERSIONINFO
    {
        public int dwOSVersionInfoSize;
        public int dwMajorVersion;
        public int dwMinorVersion;
        public int dwBuildNumber;
        public int dwPlatformId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szCSDVersion;

        public OSVERSIONINFO()
        {
            dwOSVersionInfoSize = Marshal.SizeOf(this);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESSENTRY32
    {
        public int dwSize;
        public int cntUsage;
        public int th32ProcessID;
        public IntPtr th32DefaultHeapID;
        public int th32ModuleID;
        public int cntThreads;
        public int th32ParentProcessID;
        public long pcPriClassBase;
        public int dwFlags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[] szExeFile;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }
}