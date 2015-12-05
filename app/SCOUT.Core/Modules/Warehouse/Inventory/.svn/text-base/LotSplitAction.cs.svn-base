using System.Data;

namespace SCOUT.Core.Data
{
    public class LotSplitAction : RobotAction
    {
        #region Member Variables

        private StockLot m_stockLot;

        private string m_reason = "";
        private int m_quantity = 1;

        private string m_newLotId = "";

        #endregion

        #region Properties

        public StockLot StockLot
        {
            get { return m_stockLot; }
            set { m_stockLot = value; }
        }

        public string NewLotId
        {
            get { return m_newLotId; }
        }

        public string Reason
        {
            get { return m_reason; }
            set { m_reason = value; }
        }

        public int Quantity
        {
            get { return m_quantity; }
            set { m_quantity = value; }
        }

        #endregion

        #region RobotAction overrides

        protected override void ValidateRules(BrokenRules Verify)
        {
            base.ValidateRules(Verify);

            Verify.IsNotNull(m_stockLot, "SPLITLOTEMTYLOT", 
                "Lot is required.", "StockLot");

            Verify.IsNotNull(m_reason, "SPLITLOTEMPTYREASON",
                "Reason is required.", "Reason");

            if (m_stockLot != null)
            {
                Verify.IsTrue(
                    (m_quantity > 0) && (m_quantity < m_stockLot.Quantity),
                    "SPLITLOTINVALQUANT", 
                    "Invalid quantity", "Quantity");
            }
        }

        protected override void FillExecuteCmd(System.Data.SqlClient.SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SplitLot";

            m_newLotId = LotID.GetNextLotID(m_stockLot.LotID);

            cmd.Parameters.AddWithValue("@newlotid", m_newLotId);
            cmd.Parameters.AddWithValue("@oldlotid", m_stockLot.LotID);
            cmd.Parameters.AddWithValue("@reason", m_reason);
            cmd.Parameters.AddWithValue("@quantity", m_quantity);
            cmd.Parameters.AddWithValue("@user", Security.UserSecurity.CurrentUser.Login);
        }

        #endregion
    }
}
