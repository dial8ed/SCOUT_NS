using System;
using System.Data;
using System.Data.SqlClient;

namespace SCOUT.Core.Data
{
    public class StockLot : Robot
    {
        #region Member Variables

        [NotUndoable]
        private Part m_part = null;
        private int m_partId;

        private string m_lotId;
        private string m_sn;
        private string m_description;
        private int m_quantity;
        private string m_condition;
        private string m_asn;
        private int m_poNumber;
        private string m_recvBy;

        #endregion

        #region Static Methods

        static public StockLot GetStockLot(string LotID)
        {
            SqlConnection cn = new SqlConnection(Helpers.CnnStr());
	    SafeDataReader dr = null;
            StockLot rval = null;
            SqlTransaction tr;
            
            cn.Open();
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = tr;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetLotDetails";

                cmd.Parameters.AddWithValue("@LOTID", LotID);

                dr = new SafeDataReader(cmd.ExecuteReader());

                if (dr.Read())
                {
                    rval = new StockLot();
                    rval.Load(dr);
                }

                dr.Close();
                tr.Commit();
            }
            catch
            {
		if ((dr != null) && !dr.IsClosed)
		    dr.Close();

                tr.Rollback();
                throw;
            }
            finally
            {
		if ((dr != null) && !dr.IsClosed)
		    dr.Close();

                cn.Close();
            }

            return rval;
        }

        //[Obsolete("Use GetStockLot")]
        static public DataTable GetLotDetails(string LotID)
        {
            Query q = new StoredProc("usp_GetLotDetails");
            q.Parameters.AddWithValue("@LOTID", LotID);

            return q.ExecuteDataTable();
        }

        #endregion

        #region Utility

        private void LoadPart()
        {
            if ((m_part != null) && (m_part.Id == m_partId))
                return;

            m_part = Part.GetPart(m_partId);
        }

        #endregion

        #region Properties

        public string LotID
        {
            get { return m_lotId; }
        }

        public string SN
        {
            get { return m_sn; }
        }

        [Obsolete("Use PartNumber")]
        public string StkRefID
        {
            get { return PartNumber; }
        }

        public string PartNumber
        {
            get
            {
                LoadPart();
                return m_part.PartNumber;
            }
        }

        public int PartId
        { 
            get { return m_partId; } 
        }

        public string Description
        {
            get { return m_description; }
        }

        public int Quantity
        {
            get { return m_quantity; }
        }

        public string Condition
        {
            get { return m_condition; }
        }

        public string ASN
        {
            get { return m_asn; }
        }

        public int PONumber
        {
            get { return m_poNumber; }
        }

        public string ReceivedBy
        {
            get { return m_recvBy;  }
        }

	public int SOReservedOn
	{
	    get
	    {

	        return 0;
		Query q = new 
		    Select("id").From("so_items").Where("lotid = @lotid");

		int id;

		q.Parameters.AddWithValue("@lotid", m_lotId);
		id = q.ExecuteSingle<int>();

		return id;
	    }
	}

	public bool IsReserved
	{
	    get { return (SOReservedOn != 0); }
	}

        #endregion

        #region Robot Overrides

        protected override void FillSaveCmd(SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void FillDeleteCmd(SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void Load(SafeDataReader dr)
        {
            m_lotId = dr.GetString("LOTID");
            m_sn = dr.GetString("SN");
            m_description = dr.GetString("DESCRIPTION");
            m_quantity = dr.GetInt32("QTY");
            m_condition = dr.GetString("CONDITION");
            m_asn = dr.GetString("ASN");
            m_poNumber = dr.GetInt32("PORDERNBR");
            m_recvBy = dr.GetString("RECVBY");
            m_partId = dr.GetInt32("part_id");
        }

        #endregion
    }
}
