using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using SCOUT.WinForms.Core.WinApi;

namespace SCOUT.WinForms.Core
{
    public class Printer
    {
        private readonly string m_name;
        private readonly bool m_isDefault;
        
        internal string m_comment = "";

        internal Printer(string name, bool isDefault)
        {
            m_name = name;
            m_isDefault = isDefault;
        }

        public string Name { get { return m_name; } }
        public bool IsDefault { get { return m_isDefault; } }
        public string Comment { get { return m_comment; } }

        public override string ToString()
        {
            return Name;
        }

    }

    /// <summary>
    /// Various utility functions.
    /// </summary>
    public class Util
    {
        private Util()
        {
            // Singleton
        }

        public static StringFormat GetStringAlignment(ContentAlignment ca)
        {
            StringFormat strfmt = new StringFormat();

            switch (ca)
            {
                case ContentAlignment.BottomCenter:
                    strfmt.Alignment = StringAlignment.Center;
                    strfmt.LineAlignment = StringAlignment.Far;
                    break;

                case ContentAlignment.BottomLeft:
                    strfmt.Alignment = StringAlignment.Near;
                    strfmt.LineAlignment = StringAlignment.Far;
                    break;
                    
                case ContentAlignment.BottomRight:
                    strfmt.Alignment = StringAlignment.Far;
                    strfmt.LineAlignment = StringAlignment.Far;
                    break;

                case ContentAlignment.MiddleCenter:
                    strfmt.Alignment = StringAlignment.Center;
                    strfmt.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.MiddleLeft:
                    strfmt.Alignment = StringAlignment.Near;
                    strfmt.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.MiddleRight:
                    strfmt.Alignment = StringAlignment.Far;
                    strfmt.LineAlignment = StringAlignment.Center;
                    break;

                case ContentAlignment.TopCenter:
                    strfmt.Alignment = StringAlignment.Center;
                    strfmt.LineAlignment = StringAlignment.Near;
                    break;

                case ContentAlignment.TopLeft:
                    strfmt.Alignment = StringAlignment.Near;
                    strfmt.LineAlignment = StringAlignment.Near;
                    break;

                case ContentAlignment.TopRight:
                    strfmt.Alignment = StringAlignment.Far;
                    strfmt.LineAlignment = StringAlignment.Near;
                    break;
            }

            strfmt.FormatFlags |= StringFormatFlags.NoWrap;

            return strfmt;
        }

        public static Rectangle AlignImageToRect(Image img, 
                                                 Rectangle r,
                                                 ContentAlignment ca)
        {
            switch (ca)
            {
                case ContentAlignment.BottomCenter:
                    r.X = (r.Width - img.Width) / 2;
                    r.Y = r.Height - img.Height;
                    break;

                case ContentAlignment.BottomLeft:
                    r.X = 0;
                    r.Y = r.Height - img.Height;
                    break;
                    
                case ContentAlignment.BottomRight:
                    r.X = r.Width - img.Width;
                    r.Y = r.Height - img.Height;
                    break;

                case ContentAlignment.MiddleCenter:
                    r.X = (r.Width - img.Width) / 2;
                    r.Y = (r.Height - img.Height) / 2;
                    break;

                case ContentAlignment.MiddleLeft:
                    r.X = 0;
                    r.Y = (r.Height - img.Height) / 2;
                    break;

                case ContentAlignment.MiddleRight:
                    r.X = r.Width - img.Width;
                    r.Y = (r.Height - img.Height) / 2;
                    break;

                case ContentAlignment.TopCenter:
                    r.X = (r.Width - img.Width) / 2;
                    r.Y = 0;
                    break;

                case ContentAlignment.TopLeft:
                    r.X = 0;
                    r.Y = 0;
                    break;

                case ContentAlignment.TopRight:
                    r.X = r.Width - img.Width;
                    r.Y = 0;
                    break;
            }

            return r;
        }

        /// <summary>
        /// Gets the default font for drawing menu items.
        /// </summary>
        /// <note>
        /// If the font cannot be created then a generic 
        /// 8 point Sans Serif font is returned.
        /// </note>
        /// <returns></returns>
        public static Font GetMenuFont()
        {
            WinApi.NONCLIENTMETRICS ncm = new WinApi.NONCLIENTMETRICS();
            bool res;

            ncm.cbSize = Marshal.SizeOf(typeof(WinApi.NONCLIENTMETRICS));
            res = WinApi.Call.SystemParametersInfo(
                WinApi.Constant.SPI_GETNONCLIENTMETRICS, ncm.cbSize, 
                ref ncm, 0);

            if (res)
                return Font.FromLogFont(ncm.lfMenuFont);
            
            return new Font(FontFamily.GenericSansSerif, 8);
        }

        /// <summary>
        /// Convert integer to hexidecimal string.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string IntToHex(int val)
        {
            string rval = "";
            
            for ( ; val > 0; val >>= 4)
            {
                int p = val & 15;

                if (p < 10)
                    rval = p + rval;
                else
                {
                    char c = (char)('A' + (p - 10));
                    rval = c + rval;
                }
            }

            return rval;
        }

        /// <summary>
        /// Convert integer to hexidecimal string with padded zeros.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="pad"></param>
        /// <returns></returns>
        public static string IntToHex(int val, int pad)
        {
            string rval = "";

            for ( ; val > 0; val >>= 4)
            {
                int p = val & 15;
                --pad;
                
                if (p < 10)
                    rval = p + rval;
                else
                {
                    char c = (char)('A' + (p - 10));
                    rval = c + rval;
                }
            }

            for ( ; pad > 0; --pad)
                rval = '0' + rval;

            return rval;
        }

        /// <summary>
        /// Converts a hex string to an integer.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int HexToInt(string hex)
        {
            int rval = 0;

            for (int i = 0; i < hex.Length; ++i)
            {
                char c = hex[i];
                rval <<= 4;
                
                if ((c >= '0') && (c <= '9'))
                    rval |= (c - '0');
                else if ((c >= 'A') && (c <= 'F'))
                {
                    rval |= (c - 'A') + 10;
                }
                else if ((c >= 'a') && (c <= 'f'))
                {
                    rval |= (c - 'a') + 10;
                }
                else
                {
                    throw new 
                        Exception("Invalid character code in hex conversion");
                }
            }

            return rval;
        }

        /// <summary>
        /// Encodes a string so that it can be passed as a parameter in a URL.
        /// </summary>
        /// <param name="str">String to encode</param>
        /// <returns>An encoded string</returns>
        public static string UriEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < str.Length; ++i)
            {
                char c = str[i];

                if ((c >= 'A') && (c <= 'Z') ||
                    (c >= 'a') && (c <= 'z') ||
                    (c >= '0') && (c <= '9') ||
                    (c == ',') || 
                    (c == '.')
                    )
                {
                    sb.Append(c);
                }
                else if (c == ' ')
                    sb.Append('+');
                else
                {
                    sb.Append('%');
                    sb.Append(IntToHex(c, 2));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Decodes a URI string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UriDecode(string str)
        {
            StringBuilder sb = new StringBuilder();
            char c;

            for (int i = 0; i < str.Length; ++i)
            {
                c = str[i];

                if (c == '%')
                {
                    string dig = str.Substring(i + 1, 2);
                    i += 2;
                    c = (char)HexToInt(dig);
                    sb.Append(c);
                }
                else if (c == '+')
                    sb.Append(' ');
                else
                    sb.Append(c);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets the current location of the mouse cursor in screen cordinates.
        /// </summary>
        /// <returns></returns>
        public static Point MouseLocation
        {
            get
            {
                WinApi.POINT wp = new WinApi.POINT();
                WinApi.Call.GetCursorPos(ref wp);
                return new Point(wp.x, wp.y);
            }
        }

        /// <summary>
        /// Checks to see if a character is alpha, numeric, or an underscore.
        /// </summary>
        /// <param name="c">Character to check.</param>
        /// <returns>True if the character is alpha, numeric, or an
        /// underscore.</returns>
        public static bool IsAlNum(char c)
        {
            return
                ((c >= '0') && (c <= '9')) ||
                ((c >= 'A') && (c <= 'Z')) ||
                ((c >= 'a') && (c <= 'z')) ||
                ((c == '_'));
        }

        public static Icon GetSystemIcon(int IconName)
        {
            IntPtr hIcon = WinApi.Call.LoadIcon(IntPtr.Zero, IconName);
            return Icon.FromHandle(hIcon);
        }

        public static string GetDefaultPrinterName()
        {
            Int32 length = 256;
            IntPtr bytes = Marshal.AllocCoTaskMem(length);

            if (!WinApi.Call.GetDefaultPrinter(bytes, ref length))
                return "";

            return Marshal.PtrToStringUni(bytes);
        }

        public static Printer[] GetPrinterList()
        {
            int recSize = Marshal.SizeOf(typeof(WinApi.PRINTER_INFO_1));
            string defPrinter = GetDefaultPrinterName();
            ArrayList rval = new ArrayList();
            Exception ExcecptToThrow = null;
            WinApi.PRINTER_INFO_1 rec;
            IntPtr list = IntPtr.Zero;

            const int flags = 0x6;

            int outSize = 0;
            int outRecs = 0;
            int inSize;
            
            WinApi.Call.EnumPrinters(flags, null, 1, IntPtr.Zero,
                                     0, ref outSize, ref outRecs);

            inSize = outSize;
            list = Marshal.AllocCoTaskMem(inSize);

            if (!WinApi.Call.EnumPrinters(flags, null, 1, list, inSize,
                                          ref outSize, ref outRecs))
            {
                ExcecptToThrow = 
                    new Exception("Unable to get list of printers.");
                goto DoneGetPrinterList;
            }

            for (int i = 0; i < outRecs; ++i)
            {
                IntPtr r = new IntPtr(list.ToInt32() + (i * recSize));
                Printer p;

                rec = (WinApi.PRINTER_INFO_1)Marshal.PtrToStructure(r, 
                                                                    typeof(WinApi.PRINTER_INFO_1));

                p = new Printer(rec.pName, rec.pName == defPrinter);
                p.m_comment = rec.pComment;

                rval.Add(p);
            }
            
            DoneGetPrinterList:
            if (list != IntPtr.Zero)
                Marshal.FreeCoTaskMem(list);

            if (ExcecptToThrow != null)
                throw ExcecptToThrow;

            return (Printer[])rval.ToArray(typeof(Printer));
        }
    }

    public class PrinterStream : System.IO.Stream
    {
        private readonly string m_prnName;
        private readonly string m_docName;

        private IntPtr m_hPrinter;

        // Unmanaged buffer information.
        //    WARNING!!!!  BE SURE TO FREE THIS!
        private IntPtr m_umBuffer   = IntPtr.Zero;
        private Int32  m_umBufferSz = 0;

        public PrinterStream(string PrinterName, string DocName)
        {
            DOCINFO di;
            Int32 err;

            m_prnName = PrinterName;
            m_docName = DocName;

            di.pOutputFile = "";
            di.pDocName = m_docName;
            di.pDataType = "RAW";

            if (!Core.WinApi.Call.OpenPrinter(m_prnName, out m_hPrinter, IntPtr.Zero))
            {
                err = Marshal.GetLastWin32Error();
                throw new System.IO.IOException(string.Format(
                                                    "Unable to open printer device {0}\nError code: {1}", 
                                                    m_prnName, err));
            }

            if (!WinApi.Call.StartDocPrinter(m_hPrinter, 1, ref di))
            {
                err = Marshal.GetLastWin32Error();

                WinApi.Call.ClosePrinter(m_hPrinter);
                m_hPrinter = IntPtr.Zero;

                throw new System.IO.IOException(string.Format(
                                                    "Unable to start document on printer {0}\nError code: {1}", 
                                                    m_prnName, err));
            }

            if (!WinApi.Call.StartPagePrinter(m_hPrinter))
            {
                err = Marshal.GetLastWin32Error();

                WinApi.Call.EndDocPrinter(m_hPrinter);
                WinApi.Call.ClosePrinter(m_hPrinter);
                m_hPrinter = IntPtr.Zero;

                throw new System.IO.IOException(string.Format(
                                                    "Unable to start page on printer {0}\nError code: {1}", 
                                                    m_prnName, err));
            }
        }

        ~PrinterStream()
        {
            // Paranoia
            FreeHandles();
        }

        private void FreeHandles()
        {
            if (m_hPrinter != IntPtr.Zero)
            {
                WinApi.Call.EndPagePrinter(m_hPrinter);
                WinApi.Call.EndDocPrinter(m_hPrinter);
                WinApi.Call.ClosePrinter(m_hPrinter);

                m_hPrinter = IntPtr.Zero;
            }

            if (m_umBuffer != IntPtr.Zero)
            {
                // Free up unmanaged buffer.
                Marshal.FreeCoTaskMem(m_umBuffer);

                m_umBuffer = IntPtr.Zero;
                m_umBufferSz = 0;
            }
        }

        public override void Close()
        {
            FreeHandles();
            base.Close();
        }

        public override bool CanRead  { get { return false; } }
        public override bool CanSeek  { get { return false; } }
        public override bool CanWrite { get { return true; } }

        public override void Flush()
        {
            /* dummy */
        }

        /// <summary>
        /// Ensure large enough unmanaged buffer.
        /// </summary>
        /// <param name="sz">Requested size</param>
        private void CheckBuffSize(Int32 sz)
        {
            if (m_umBufferSz < sz)
            {
                // Give us some padding.
                sz = sz * 2;
                int over = sz & 15;

                if (over > 0)
                    sz += 16 - over;

                if (m_umBuffer != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(m_umBuffer);

                m_umBuffer = Marshal.AllocCoTaskMem(sz);
                m_umBufferSz = sz;
            }
        }

        public void Write(byte[] buffer)
        {
            Write(buffer, 0, buffer.Length);
        }

        public void Write(byte[] buffer, int count)
        {
            Write(buffer, 0, count);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Int32 wSz = 0;
            bool rval;

            CheckBuffSize(count);

            Marshal.Copy(buffer, offset, m_umBuffer, count);
            rval = WinApi.Call.WritePrinter(m_hPrinter, m_umBuffer, count,
                                            ref wSz);

            if (!rval || (wSz < count))
            {
                Int32 err = Marshal.GetLastWin32Error();

                rval = false;
                throw new System.IO.IOException("Unable to write to printer " +
                                                m_prnName + "\nError code: " + err);
            }
        }

        #region Unsupported items

        public override IAsyncResult BeginRead(byte[] buffer, 
                                               int offset, int count, AsyncCallback callback, object state)
        {
            throw new NotSupportedException();
        }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override long Position
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}