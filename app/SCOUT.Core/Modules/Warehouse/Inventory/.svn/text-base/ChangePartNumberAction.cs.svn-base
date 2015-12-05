using System.Data;
using System.Data.SqlClient;
using SCOUT.Core.Data;
using System;

namespace SCOUT.Core.Data
{
    /// <summary>
    /// Action for changing a LOT's part number.
    /// </summary>
    public class ChangePartNumberAction : RobotAction
    {
        private StockLot m_stockLot = null;
        private Part m_part = null;

        public ChangePartNumberAction()
        {
        }

        #region Properties

        public StockLot StockLot
        {
            get { return m_stockLot; }
            set { m_stockLot = value; }
        }

        public Part Part
        {
            get { return m_part; }
            set { m_part = value; }
        }

        #endregion

        protected override void ValidateRules(BrokenRules Verify)
        {
            base.ValidateRules(Verify);

            Verify.IsTrue(m_stockLot != null, 
                "INVSTKLOT", "Invalid LOT", "StockLot");

            Verify.IsTrue(m_part != null, 
                "INVSTKITEM", "Invalid Part Number", "Part");

            if ((m_part != null) && (m_stockLot != null))
            {
                Part p = Part.GetPart(m_stockLot.PartId);

                Verify.IsTrue(m_stockLot.PartId != m_part.Id,
                    "CPNA_SameStkRefID", 
                    "The part number must be different than that of the lot.",
                    "Part");
   
            }
        }

        protected override void FillExecuteCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_ChangeLOTPartNumber";

            cmd.Parameters.AddWithValue("@LOTID", 
                m_stockLot.LotID);

            cmd.Parameters.AddWithValue("@part_id", 
                m_part.Id);

            cmd.Parameters.AddWithValue("@USER",
                Security.UserSecurity.CurrentUser.Login);
        }
    }
}
