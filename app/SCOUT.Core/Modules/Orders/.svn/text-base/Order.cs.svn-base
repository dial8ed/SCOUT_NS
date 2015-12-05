using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Data;

namespace SCOUT.Core.Data
{
    [Persistent("orders")]
    public class Order : VPObject
    {
        #region fields

        private int m_id;
        private string m_rma;
        private string m_po;
        private string m_other;
        private OrderType m_orderType;
        private List<Type> m_contractTypes;
        private IUserInfoGetter m_userInfoGetter = new SecurityUserGetter();
        private bool m_isTemplate;
        private bool m_createdFromTemplate;

        #endregion

        #region .ctor

        public Order(Session session)
            : base(session)
        {

        }

        public Order(OrderType orderType, Session session) : base(session)
        {
            m_orderType = orderType;
            UserTracking.SetUserInfoGetter(m_userInfoGetter);
            InitContracts();            
        }

        #endregion

        #region properties

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("rma")]
        public string RMA
        {
            get { return m_rma; }
            set
            {
                if (value == null)
                    value = "";

                SetPropertyValue("RMA", ref m_rma, value.ToUpper());
            }
        }

        [Persistent("po")]
        public string PO
        {
            get { return m_po; }
            set
            {
                if (value == null)
                    value = "";
                SetPropertyValue("PO", ref m_po, value.ToUpper());
            }
        }

        [Persistent("other")]
        public string Other
        {
            get { return m_other; }
            set
            {
                if (value == null)
                    value = "";
                
                SetPropertyValue("Other", ref m_other, value.ToUpper());
            }
        }

        [Persistent("order_type")]    
        public OrderType OrderType
        {
            get { return m_orderType; }
            set
            {
                SetPropertyValue("OrderType", ref m_orderType, value);
            }
        }
       
        [Association("Order-Contracts")]
        public XPCollection<ContractBase> Contracts
        {
            get { return GetCollection<ContractBase>("Contracts");}            
        }

        [Persistent("is_template")]
        public bool IsTemplate
        {
            get { return m_isTemplate; }
            set { SetPropertyValue("IsTemplate", ref m_isTemplate, value); }
        }

        public ContractBase GetContract<T>()
        {
            foreach (ContractBase contract in Contracts)
            {
                if(contract.GetType() == typeof(T))
                {
                    return contract;
                }
            }
            return null;
        }

        [NonPersistent]
        public List<Type> ContractTypes
        {
            get
            {
                if (m_contractTypes == null)
                    m_contractTypes = Contract.GetContractTypesFor(m_orderType);

                return m_contractTypes;
            }
        }


        [NonPersistent]
        public bool CreatedFromTemplate
        {
            get { return m_createdFromTemplate; }
            set { m_createdFromTemplate = value; }
        }

        #endregion

        #region methods

        private void InitContracts()
        {
            if(IsNew)
            foreach (Type type in ContractTypes)
            {
                ContractBase contract = Activator.CreateInstance(type, new object[] {Session}) as ContractBase;
                if(contract != null)
                {               
                    contract.UserTracking.SetUserInfoGetter(m_userInfoGetter);
                    Contracts.Add(contract);
                }
            }
        }

        public bool HasDirtyContracts()
        {
            foreach (ContractBase contract in Contracts)
            {
                if(contract.IsDirty)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        protected override void ValidateRules(BrokenRules Verify)
        {
            if(IsTemplate)
                Verify.IsTrue(!String.IsNullOrEmpty(Other), "TemplateNameReq","Template Name is required", "Other");
        }
    }
}