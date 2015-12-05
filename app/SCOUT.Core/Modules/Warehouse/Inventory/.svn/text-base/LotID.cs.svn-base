/* ===================================================================== */

using System;
using System.Data;
using System.Data.SqlClient;

//using SCOUT.Core;
using System.Windows.Forms;
using SCOUT.Core.Data;

/* ===================================================================== */

namespace SCOUT.Core.Data
{
    /* ================================================================= */

    public enum LotIDType
    {
        Invalid = 0,
        IDVer1,         // Version 1 lot IDs
        IDVer2          // Version 2 lot IDs
    }

    /* ================================================================= */

	/// <summary>
	/// LotID utility functions.
	/// </summary>
	public sealed class LotID
	{
        /* ============================================================= */

		private LotID()
		{
		    // Signleton
		}

        /* ============================================================= */

        /// <summary>
        /// Splits the DateTime values from a Version 1 lot ID
        /// </summary>
        /// <note>This function does not check the validity 
        /// of the lot ID</note>
        /// <param name="lotId"></param>
        /// <returns>Returns an extraced DateTime value.</returns>
        private static DateTime V1LotSplitTime(string lotId)
        {
            int usec, sec, min, hour;
            int month, day, year;

            try
            {
                year  = Int32.Parse(lotId.Substring(1 , 2)) + 2000;
                month = Int32.Parse(lotId.Substring(3 , 2));
                day   = Int32.Parse(lotId.Substring(5 , 2));
                hour  = Int32.Parse(lotId.Substring(7 , 2));
                min   = Int32.Parse(lotId.Substring(9 , 2));
                sec   = Int32.Parse(lotId.Substring(11, 2));
                usec  = Int32.Parse(lotId.Substring(13, 3));
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }

            return new DateTime(year, month, day, hour, min, sec, usec);
        }

        /* ============================================================= */

        /// <summary>
        /// Splits the DateTime values from a Version 2 lot ID
        /// </summary>
        /// <note>This function does not check the validity
        /// of the lot ID</note>
        /// <param name="lotId"></param>
        /// <returns>Returns an extracted DateTime value.</returns>
        private static DateTime V2LotSplitTime(string lotId)
        {
            int i, usec, sec, min, hour;
            int month, dom, doy, year;
            UInt64 l = 0;
            string w;
            char c;

            w = lotId.Substring(1, 12).ToUpper();

            for (i = 0; i < 12; ++i)
            {
                l <<= 4;
                c = w[i];

                if ((c >= '0') && (c <= '9'))
                    l += (ulong)(c - '0');
                else
                    l += (ulong)(c - 'A') + 10;
            }

            /*
             * Should now have a number that we can use 
             * to extract a date time value from.
             * 
             * Note that this shifting is different to acocunt
             * for the serial number which we've ignored here.
             */
            usec = (int)((l >>  0) & 0x03FF); // 10 bits
            sec  = (int)((l >> 12) & 0x001F); // 5 bits
            min  = (int)((l >> 17) & 0x001F); // 5 bits
            hour = (int)((l >> 22) & 0x001F); // 5 bits
            doy  = (int)((l >> 27) & 0x01FF); // 9 bits

            // Year - 8bits
            year = (int)((l >> 36) & 0x0FFF) + 1850;

            /*
             *  ..... Apparently we can't specify the day of the 
             * year to the counstructor....  So now we need to find out
             * what month and day of the month is so we can call the 
             * constructor.....
             */
            month = 0;
            dom = doy;

            for (;;)
            {
                if (++month > 12)
                    return DateTime.MinValue;   // Invalid DOY

                i = DateTime.DaysInMonth(year, month);

                if (i >= dom)
                    break;

                dom -= i;
            }

            return new DateTime(year, month, dom, 
                hour, min, sec, usec);
        }

        /* ============================================================= */

        /// <summary>
        /// Checks to see what type of LotID has been given.
        /// </summary>
        /// <param name="lotId">The LotID to check.</param>
        /// <returns>A LotID version or Invalid</returns>
        public static LotIDType GetLotIDType(string lotId)
        {
            DateTime dt;
            string w;

            // Some basic checks on our lot IDs.
            if (lotId.Length != 16)
                return LotIDType.Invalid;

            // Lots must begin with an L
            w = lotId.Substring(0, 1).ToUpper();
            if (w != "L")
                return LotIDType.Invalid;

            /*
             * Version 2 lot IDs have the timestamp in the 
             * first 12 hex numbers.
             * 
             * See if we can get a valid date out of this.
             */
            dt = V2LotSplitTime(lotId);
            if (dt.Year < 2005) // Version 2 was developed in 2007
            {
                // Not a valid Version 2 LotID.

                // Try for Version 1
                dt = V1LotSplitTime(lotId);
                if (dt.Year < 1850)
                    return LotIDType.Invalid;

                return LotIDType.IDVer1;
            }

            return LotIDType.IDVer2;
        }

        /// <summary>
        /// Generates a new Lot ID with a starting serial number of 0.
        /// 
        /// Lot IDs are generated based on the current time.  We query
        /// the SQL server to get a consistant time across all requests.
        /// </summary>
        /// <returns>String representing the Lot ID</returns>
        public static string Generate()
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
            ln  = 0; // Serial number (12 bits)

            ln |= (UInt64)dt.Millisecond << 12;  // 10 bits

            ln |= (UInt64)dt.Second    << 24; // 5 bits
            ln |= (UInt64)dt.Minute    << 29; // 5 bits
            ln |= (UInt64)dt.Hour      << 34; // 5 bits
            ln |= (UInt64)dt.DayOfYear << 39; // 9 bits

            // 12 bits
            ln |= ((UInt64)(dt.Year - 1850) & 0x0FFF) << 48;

            /*
             *  We lop off the most significant nibble, so we can fit the
             * 'L' into that space.
             */
            for (i = 0; i < 15; ++i)
            {
                j = (uint)(ln & 0x0F);
                ln >>= 4;

                rval = dig[j].ToString() + rval;
            }

            return ("L" + rval);
        }

        /// <summary>
        /// Gets the next available Lot ID so we can split a Lot.
        /// 
        /// The returned LotID is reserved in the database for our use.
        /// </summary>
        /// <param name="lotid">The LOT to split on.</param>
        /// <returns>A new unique Lot ID</returns>
        public static string GetNextLotID(string lotId)
        {
            // Used for quickly converting a number to Hex
            char[] dig = new char[] 
            {
                '0', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
            };

            // First make sure we aren't trying to do anything foolish here.
            LotIDType ty = GetLotIDType(lotId);

            if (ty == LotIDType.Invalid)
                throw new Exception("Invalid LOT ID.");

            if (ty == LotIDType.IDVer1)
                throw new Exception("Cannot split version 1 lots.");
            
            // The serial number is in the lowest three characters.
            string timePart = lotId.Substring(0, 13);
            string serlPart = "";
            int serial, i, j;
            
            SqlConnection cn = new SqlConnection(Helpers.CnnStr());
            SqlCommand cmd = new SqlCommand();
            SqlParameter prm = new SqlParameter();
            
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetNextLotSerial";
            cmd.Parameters.AddWithValue("@lot_base", timePart);
            prm.Direction = ParameterDirection.ReturnValue;
            prm.DbType = DbType.Int32;
            cmd.Parameters.Add(prm);

            cmd.ExecuteScalar();

            if (prm.Value == null)
                throw new Exception("Unable to split lot.");
            
            serial = Int32.Parse(prm.Value.ToString());
            for (i = 0; i < 3; ++i)
            {
                j = serial & 0xF;
                serial >>= 4;

                serlPart = dig[j].ToString() + serlPart;
            }

            return (timePart + serlPart);
        }

        
	}
}
