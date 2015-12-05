using System;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("vw_rec_label_details")]
    public class ReceivingLabelDetail : VPLiteObject
    {
        private Guid m_id;
        private string m_lotId;
        private string m_serialNumber;
        private string m_partNumber;
        private string m_description;        
        private string m_rma;
        private string m_comments;
        private string m_notes;
        private string m_receivedBy;
        private string m_receiveDate;
        private string m_process;
        private string m_returnType;
        private string m_program;

        public ReceivingLabelDetail(Session session) : base(session)
        {

        }

        [Persistent("id")]
        [Key(AutoGenerate = false)]
        public Guid Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("lot_id")]
        public string LotId
        {
            get { return m_lotId; }
            set { SetPropertyValue("LotId", ref m_lotId, value); }
        }

        [Persistent("serial_number")]
        public string SerialNumber
        {
            get { return m_serialNumber; }
            set { SetPropertyValue("SerialNumber", ref m_serialNumber, value); }
        }

        [Persistent("part_number")]
        public string PartNumber
        {
            get { return m_partNumber; }
            set { SetPropertyValue("PartNumber", ref m_partNumber, value); }
        }

        [Persistent("description")]
        public string Description
        {
            get { return m_description; }
            set { SetPropertyValue("Description", ref m_description, value); }
        }

        [Persistent("rma")]
        public string Rma
        {
            get { return m_rma; }
            set { SetPropertyValue("Rma", ref m_rma, value); }
        }

        [Persistent("comments")]
        public string Comments
        {
            get { return m_comments; }
            set { SetPropertyValue("Comments", ref m_comments, value); }
        }

        [Persistent("notes")]
        public string Notes
        {
            get { return m_notes; }
            set { SetPropertyValue("Notes", ref m_notes, value); }
        }

        [Persistent("received_by")]
        public string ReceivedBy
        {
            get { return m_receivedBy; }
            set { SetPropertyValue("ReceivedBy", ref m_receivedBy, value); }
        }

        [Persistent("receive_date")]
        public string ReceiveDate
        {
            get { return m_receiveDate; }
            set { SetPropertyValue("ReceiveDate", ref m_receiveDate, value); }
        }

        [Persistent("unit_process")]
        public string Process
        {
            get { return m_process; }
            set { SetPropertyValue("Process", ref m_process, value); }
        }

        [Persistent("return_type")]
        public string ReturnType
        {
            get { return m_returnType; }
            set { SetPropertyValue("ReturnType", ref m_returnType, value); }
        }

        [Persistent("shopfloor_program")]
        public string Program
        {
            get { return m_program; }
            set { SetPropertyValue("Program", ref m_program, value); }
        }

        public static ReceivingLabelDetail GetLabelDetailByLotId(string lotId)
        {
            return Scout.Core.Data.GetUnitOfWork().FindObject<ReceivingLabelDetail>(
                new BinaryOperator("LotId", lotId));
        }

        public object[] ToLabelArgs()
        {
            object[] args = new object[]
                                {
                                    m_lotId,
                                    m_lotId,
                                    m_serialNumber,
                                    m_serialNumber,
                                    m_partNumber,
                                    m_partNumber,
                                    m_description,
                                    m_returnType,
                                    m_rma,
                                    m_receivedBy,
                                    m_receiveDate,
                                    m_comments,
                                    m_notes,
                                    m_process,
                                    m_program
                                };
            return args;
        }
    }
}