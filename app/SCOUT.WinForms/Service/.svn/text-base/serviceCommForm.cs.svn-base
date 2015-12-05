using System;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class ServiceCommForm : XtraForm
    {
        private PartServiceCommodity m_commodity;
        private IUnitOfWork m_session;

        public ServiceCommForm(PartServiceCommodity commodity)
        {
            InitializeComponent();
            m_commodity = commodity;                      
            Bind();
            WireEvents();
            LoadAttributes();
            LoadConfigAttributes();
            LoadModelList();
        }

        private void LoadModelList()
        {
            modelLookup.DataSource = m_commodity.PartModels;
            modelLookup.DisplayMember = "Model";
            modelLookup.ValueMember = "This";
        }

        private void WireEvents()
        {
            enableAttrChk.CheckedChanged += enableAttrChk_CheckedChanged;
            enableConfigCheck.CheckedChanged += enableConfigCheck_CheckedChanged;
        }

        void enableConfigCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(enableConfigCheck.Checked)
            {
                EnableConfigEditors(true);
            } else
            {
                EnableConfigEditors(false);
            }
        }

        void enableAttrChk_CheckedChanged(object sender, EventArgs e)
        {
            if (enableAttrChk.Checked)
            {
                EnableAttrEditors(true);               
            }
            else
            {
                EnableAttrEditors(false);    
            }                           
        }

        private void EnableAttrEditors(bool enable)
        {
            attrEditorGroup.Enabled = enable;    

            if(!enable)
                return;
            
            if(m_commodity.AttributesHeader == null)
            {
                m_commodity.CreateAttrHeader();
                LoadAttributes();
            }                    
        }

        private void EnableConfigEditors(bool enable)
        {
            configAttrGroup.Enabled = enable;

            if (!enable)
                return;

            if (m_commodity.UnitConfigHeader == null)
            {
                m_commodity.CreateConfigHeader();
                LoadConfigAttributes();
            }
        }

        private void LoadConfigAttributes()
        {
            if (m_commodity.UnitConfigHeader == null)
            {
                enableConfigCheck.Checked = false;
                EnableConfigEditors(false);
            }
            else
            {
                enableConfigCheck.Checked = true;
                BindConfigAttributes();
            }  
        }

        private void BindConfigAttributes()
        {
            config1Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr1");
            config2Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr2");
            config3Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr3");
            config4Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr4");
            config5Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr5");
            config6Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr6");
            config7Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr7");
            config8Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr8");
            config9Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr9");
            config10Text.DataBindings.Add("Text", m_commodity.UnitConfigHeader, "Attr10");  
        }

        private void LoadAttributes()
        {
            if(m_commodity.AttributesHeader == null)
            {
                enableAttrChk.Checked = false;     
                EnableAttrEditors(false);
            } 
            else
            {
                enableAttrChk.Checked = true;
                BindAttributes();   
            }                   
        }

        private void BindAttributes()
        {
            attr1Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr1");
            attr2Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr2");
            attr3Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr3");
            attr4Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr4");
            attr5Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr5");
            attr6Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr6");
            attr7Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr7");
            attr8Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr8");
            attr9Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr9");
            attr10Text.DataBindings.Add("Text", m_commodity.AttributesHeader, "Attr10");
        }

        private void Bind()
        {
            m_session = m_commodity.Session;
            categoryList.Session = m_session as XpoUnitOfWork;
            categoryLookup.DataSource = categoryList;
            commText.DataBindings.Add("Text", m_commodity, "Name");
            failCodeGrid.DataSource = m_commodity.ServiceCodes;
            componentGrid.DataSource = m_commodity.Components;
            modelGrid.DataSource = m_commodity.PartModels;
        }
       
        private void closeButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void saveButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Scout.Core.Data.Save(m_session);            
            Close();
        }
    }
}