using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("STKTRANS")]
    public class Transaction : VPLiteObject
    {
        private int m_transId = 0;
        private string m_transType = "";
        private InventoryItem m_item;
        private int m_qty = 0;
        private string m_transRef;
        private DateTime m_transDate = DateTime.Now;
        private string m_transBy = Security.UserSecurity.CurrentUser.Login;
        private string m_comments = "";
        private Part m_part;
        private string m_departLocation = "";
        private string m_arrivalLocation = "";
        private string m_partNumber = "";
        private string m_program = "";
        private string m_consumedInLotId;

        public event EventHandler<EventArgs> Saved;
       
        public Transaction(Session session) : base(session)
        {
           
        }

        [Persistent("TRANSID")]
        [Key(AutoGenerate = true)]
        public int TransId
        {
            get { return m_transId; }
            set { SetPropertyValue("TransId", ref m_transId, value); }
        }

        [Persistent("TRANSTYPE")]
        public string TransType
        {
            get { return m_transType; }
            set { SetPropertyValue("TransType", ref m_transType, value); }
        }

        [Persistent("LOTID")]
        public virtual InventoryItem Item
        {
            get { return m_item; }
            set
            {
                SetPropertyValue("LotId", ref m_item, value);
                if (m_item != null)
                    Program = m_item.ShopfloorProgram;
            }
        }

        [Persistent("QTY")]
        public int Qty
        {
            get { return m_qty; }
            set { SetPropertyValue("Qty", ref m_qty, value); }
        }

        [Persistent("TRANSREF")]
        public string TransRef
        {
            get { return m_transRef; }
            set { SetPropertyValue("TransRef", ref m_transRef, value); }
        }

        [Persistent("TRANSDATE")]
        public DateTime TransDate
        {
            get { return m_transDate; }
            set { SetPropertyValue("TransDate", ref m_transDate, value); }
        }

        [Persistent("TRANSBY")]
        public string TransBy
        {
            get { return m_transBy; }
            set { SetPropertyValue("TransBy", ref m_transBy, value); }
        }

        [Persistent("COMMENTS")]
        public string Comments
        {
            get { return m_comments; }
            set { SetPropertyValue("Comments", ref m_comments, value); }
        }

        [Persistent("part_id")]
        public Part Part
        {
            get { return m_part; }
            set { SetPropertyValue("Part", ref m_part, value); }
        }

        [Persistent("depart_location")]
        public string DepartLocation
        {
            get { return m_departLocation; }
            set { SetPropertyValue("DepartLocation", ref m_departLocation, value); }
        }

        [Persistent("arrival_location")]
        public string ArrivalLocation
        {
            get { return m_arrivalLocation; }
            set { SetPropertyValue("ArrivalLocation", ref m_arrivalLocation, value); }
        }

        [Persistent("part_number")]
        public string PartNumber
        {
            get { return (this.Part != null ? Part.PartNumber : ""); }
            set { SetPropertyValue("PartNumber", ref m_partNumber, value); }
        }

        [Persistent("serial_number")]
        public string SerialNumber
        {
            get { return m_item == null ? "" : m_item.SerialNumber; }
        }

        [Persistent("program")]
        public string Program
        {
            get { return m_program; }
            set { SetPropertyValue("Program", ref m_program, value); }
        }

        [Persistent("consumed_in_lotid")]
        public string ConsumedInLotId
        {
            get { return m_consumedInLotId; }
            set { SetPropertyValue("ConsumedInLotId", ref m_consumedInLotId, value); }
        }


        protected override void OnSaved()
        {
            if(Saved != null)
                Saved(this, null);
        }
    }
}