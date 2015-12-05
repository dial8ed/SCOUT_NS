using System;
using System.Collections.Generic;
using System.Text;
using System.Deployment;
using System.Windows.Forms;

namespace SCOUT.WinForms
{
    static public class VersionInfo
    {
        static private bool s_inited = false;

        static private int s_major; // First number
        static private int s_minor; // Second number
        static private int s_rev;   // Thrid number

        static private int s_build; // The "build" number

        static private void initInfo()
        {
            if (s_inited)
                return;

            string[] parts = Application.ProductVersion.Split('.');

            Int32.TryParse(parts[0], out s_major);
            Int32.TryParse(parts[1], out s_minor);
            Int32.TryParse(parts[2], out s_rev);

            Int32.TryParse(parts[3], out s_build);

            s_inited = true;
        }

        [Obsolete("Use 'Build' property")]
        static public int BuildNo
        {
            get { return Build; }
        }

        static public int Build
        {
            get
            {
                initInfo();
                return s_build; 
            }
        }

        static public int Major
        {
            get
            {
                initInfo();
                return s_major;
            }
        }

        static public int Minor
        {
            get
            {
                initInfo();
                return s_minor;
            }
        }

        static public int Revision
        {
            get 
            {
                initInfo();
                return s_rev;
            }
        }
    }
}
