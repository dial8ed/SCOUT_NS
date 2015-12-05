using System;
using System.Data;
using System.Data.SqlClient;


namespace SCOUT.Core.Data
{
    class USState : Robot
    {
        private string m_abbr;
        private string m_name;
        private decimal m_taxRate;

        // Must be loaded from the db.
        private USState()
        {
        }

        #region Properties

        public string Abbr
        {
            get { return m_abbr; }
        }

        public string Name
        {
            get { return m_name; }
        }

        public decimal TaxRate
        {
            get { return m_taxRate; }
            set
            {
                m_taxRate = value;
                MarkDirty("TaxRate");
            }
        }

        #endregion

        protected override void FillSaveCmd(SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SaveState";

            cmd.Parameters.AddWithValue("@abbr", Abbr);
            cmd.Parameters.AddWithValue("@taxRate", TaxRate);
        }

        protected override void FillDeleteCmd(SqlCommand cmd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Load(SafeDataReader dr)
        {
            m_abbr = dr.GetString("abbr");
            m_name = dr.GetString("name");
            m_taxRate = dr.GetDecimal("tax_rate");
        }
    }
}
