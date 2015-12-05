using System;

namespace SCOUT.Core.Data
{
    public class ProcessingImportPartEventArgs : EventArgs
    {
        private PartToImport m_itemBeingProcessed;

        public ProcessingImportPartEventArgs(PartToImport itemBeingProcessed)
        {
            m_itemBeingProcessed = itemBeingProcessed;
        }


        public PartToImport ItemBeingProcessed
        {
            get { return m_itemBeingProcessed; }
            set { m_itemBeingProcessed = value; }
        }
    }
}