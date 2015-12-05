using System;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public abstract class TransactionSpecification
    {
        protected XPCollection m_destinationAreas;                    
        protected XPCollection m_sourceAreas;       
        private TransactionType m_type;
        private InventoryItem m_item;
        private string m_comments;
        private string m_transRef;        

        protected TransactionSpecification(TransactionType type)
        {
            m_type = type;
        }

        public virtual bool ReloadDestinationsOnSourceChange
        {
            get { return false; }
        }
        
        public XPCollection SourceAreas
        {
            get { return m_sourceAreas; }
        }

        [NonPersistent]
        public XPCollection DestinationAreas
        {
            get { return m_destinationAreas; }
        }

        public InventoryItem Item
        {
            get { return m_item; }
            set { m_item = value;}
        }

        public string Comments
        {
            get { return m_comments; }
            set { m_comments = value;}
        }

        public virtual bool IsProgramRequired
        {
            get { return false; } 
            set { }
        }

        public abstract IArea DestinationArea { get; set; }
        
        public abstract IArea SourceArea { get; set; }

        public abstract void UpdateItem();

        public virtual string SourceName
        {
            get { return "unknown"; }            
        }
        
        public virtual string DestinationName
        {
            get { return "unknown"; }
        }        

        public TransactionType TransactionType
        {
            get { return m_type; }
        }

        public string TransactionReference
        {
            get { return m_transRef; }
            set { m_transRef = value; }
        }

        public virtual string GetErrors()
        {
            return "";
        }
    }
} 