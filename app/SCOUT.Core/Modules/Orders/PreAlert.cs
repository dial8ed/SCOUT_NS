using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using SCOUT.Core.Messaging;


namespace SCOUT.Core.Data
{
    public abstract class PreAlert : IPreAlert
    {
        protected PurchaseOrder m_purchaseOrder;
        protected List<PartToImport> m_importList;
        protected LineItemImporter m_importer;
        protected LineItemImportValidator m_validator;

        protected bool LoadFromFile<T>(FileInfo fileInfo, ref T dataset, string tableName) where T : DataSet
        {
            PopulateDataSet<T>(fileInfo,ref dataset,tableName);
            BuildImportList();
            BuildValidator();
            return true;
        }

        public abstract DataTable DataTable { get; }
       
        public abstract bool LoadFromFile(FileInfo fileInfo);

        private void PopulateDataSet<T>(FileInfo fileInfo,ref T dataSet, string tableName) where T : DataSet
        {
            try
            {
                ExternalDataReader.FillDataSet(fileInfo, ref dataSet, tableName);
            }
            catch (NotSupportedException ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message,UserMessageType.Error);                
            }
        }

        public List<PartToImport> ImportList
        {
            get { return m_importList; }
        }


        private void BuildImportList()
        {
            m_importList =
                new LineItemImporter(DataTable, PartColumnName).ImportList;
        }


        private void BuildValidator()
        {
            m_validator = new LineItemImportValidator(ref m_importList,
                                                      m_purchaseOrder);
        }


        public bool AssociateLinesToPurchaseOrder()
        {
            if (m_importList.Count == 0)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(
                    "There are no line items to import", UserMessageType.Error);
                return false;
            }

            foreach (PartToImport part in m_importList)
            {
                if (part.IsValid)
                    m_purchaseOrder.AddLineItem(part.Part, part.Qty);
            }

            MapDataSetToPersistedObjects();

            return true;
        }


        public LineItemImportValidator Validator
        {
            get { return m_validator; }
        }


        public bool Import()
        {
            return AssociateLinesToPurchaseOrder();
        }


        public PurchaseOrder PurchaseOrder
        {
            get { return m_purchaseOrder; }
            set { m_purchaseOrder = value; }
        }

        public abstract void MapDataSetToPersistedObjects();

        public abstract string PartColumnName { get; }


        public abstract bool SerialIsExpected(PurchaseOrder purchaseOrder,
                                              string serialNumber);


        public abstract string DisplayType { get; }


        public abstract IPreAlertItem GetItemBySerialNumber(PurchaseOrder order,
                                                            string number);


        public override string ToString()
        {
            return GetType().Name;
        }
    }
}