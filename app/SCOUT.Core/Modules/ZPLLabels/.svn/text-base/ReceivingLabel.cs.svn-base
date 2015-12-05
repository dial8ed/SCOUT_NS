using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    [Persistent("receiving_labels")]
    [MapInheritance(MapInheritanceType.ParentTable)]
    public class ReceivingLabel : ZPLLabel
    {
        public ReceivingLabel(Session session) : base(session)
        {


        }

        public void SetLabelValues(string lotId, string serialNumber, string partNumber, 
                string partDesc, string returnType, string rma, string receivedBy, 
                string receiveDate, string comments, string orderNotes, string process, string program)
        {

            base.SetLabelValues(new object[]
                                {
                                    lotId,
                                    lotId,
                                    serialNumber,
                                    serialNumber,
                                    partNumber,
                                    partNumber,
                                    partDesc,
                                    returnType,
                                    rma,
                                    receivedBy,
                                    receiveDate,
                                    comments,
                                    orderNotes,
                                    process,
                                    program
                                });
        }

        public static ReceivingLabel GetReceivingLabel()
        {
            return new ReceivingLabel(Scout.Core.Data.GetUnitOfWork());
        }

        public override bool Print()
        {
            ZPLLabel zplLabel = GetLabelByName("CHARTER_REC");
            zplLabel.LabelValues = LabelValues;
            return zplLabel.Print();	                           
        }       
    }
}