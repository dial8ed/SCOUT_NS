using System.Collections.Generic;
using System.Text;
using SCOUT.Core.Services;

namespace SCOUT.Core.Data
{
    public class LineItemImportValidator : ValidatorBase
    {
        #region Delegates

        public delegate void ItemProcessingEventHandler(object sender, ProcessingImportPartEventArgs e);
        public delegate void ValidationFinishedEventHandler();

        public event ItemProcessingEventHandler ItemProcessing;
        public event ValidationFinishedEventHandler ValidationFinished;

        #endregion

        private List<PartToImport> m_importList;
        private PurchaseOrder m_purchaseOrder;

        public LineItemImportValidator(ref List<PartToImport> importList, PurchaseOrder purchaseOrder)
        {
            m_importList = importList;
            m_purchaseOrder = purchaseOrder;
        }

        public int LineItemCount
        {
            get { return m_importList.Count; }
        }

        public void Validate()
        {
            Validated();
        }

        public override void GetError()
        {
            StringBuilder builder = new StringBuilder();

            foreach (PartToImport partToImport in m_importList)
            {
                OnItemProcessing(new ProcessingImportPartEventArgs(partToImport));
                Part part = PartService.GetPartByPartNumber
                    (m_purchaseOrder.Session,partToImport.PartNumber);

                if (part == null)
                {
                    string msg = string.Format("{0} is not a valid part number",
                                               partToImport.PartNumber);
                    builder.AppendLine(msg);
                    partToImport.Error = msg;
                }
                else
                {
                    partToImport.Part = part;
                }
            }

            if (builder.Length > 0)
                m_error = "The import contains invalid line items please view the roll up for details.";

            OnFinishedValidation();
        }

        private void OnFinishedValidation()
        {
            if (ValidationFinished != null)
                ValidationFinished();
        }

        public int IndexOf(PartToImport partToImport)
        {
            return m_importList.IndexOf(partToImport);
        }

        protected void OnItemProcessing(ProcessingImportPartEventArgs e)
        {
            if (ItemProcessing != null)
                ItemProcessing(this, e);
        }
    }
}