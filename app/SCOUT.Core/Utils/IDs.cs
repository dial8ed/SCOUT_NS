using System;
using System.Data.SqlClient;
using SCOUT.Core.Data;

namespace SCOUT.Core.Utils
{
    public class IDs
    {     
        public static string Generate(char prefix)
        {
            // Used for quickly converting a number to Hex
            char[] dig = new char[] 
            {
                '0', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
            };

            // Connect to the SQL database server so we can get its time.
            SqlConnection cn = new SqlConnection(Helpers.CnnStr());
            SqlCommand cmd = new SqlCommand();
            string rval = "";

            UInt64 ln;
            uint i, j;

            System.DateTime dt;


            cmd.Connection = cn;
            cmd.CommandText = "SELECT GETUTCDATE()";

            cn.Open();
            dt = (DateTime)cmd.ExecuteScalar();
            cn.Close();

            // Build the lot number starting with a serial number of 0
            ln = 0; // Serial number (12 bits)

            ln |= (UInt64)dt.Millisecond << 12;  // 10 bits

            ln |= (UInt64)dt.Second << 24; // 5 bits
            ln |= (UInt64)dt.Minute << 29; // 5 bits
            ln |= (UInt64)dt.Hour << 34; // 5 bits
            ln |= (UInt64)dt.DayOfYear << 39; // 9 bits

            // 12 bits
            ln |= ((UInt64)(dt.Year - 1850) & 0x0FFF) << 48;

            /*
             *  We lop off the most significant nibble, so we can fit the
             * 'prefix' into that space.
             */
            for (i = 0; i < 15; ++i)
            {
                j = (uint)(ln & 0x0F);
                ln >>= 4;

                rval = dig[j].ToString() + rval;
            }

            return (prefix + rval);
        }
        
    }
}