using System;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Inventory
{
    public partial class UnitConfigurationForm : DevExpress.XtraEditors.XtraForm
    {
        private InventoryItem m_item;
        private IUnitOfWork m_session;

        public UnitConfigurationForm(InventoryItem item)
        {
            InitializeComponent();
            m_item = item;
            Init();
            WireEvents();
            Bind();            
        }

        private void WireEvents()
        {
            config1Layout.TextChanged += configLayout_TextChanged;
            config2Layout.TextChanged += configLayout_TextChanged;
            config3Layout.TextChanged += configLayout_TextChanged;
            config4Layout.TextChanged += configLayout_TextChanged;
            config5Layout.TextChanged += configLayout_TextChanged;
            config6Layout.TextChanged += configLayout_TextChanged;
            config7Layout.TextChanged += configLayout_TextChanged;
            config8Layout.TextChanged += configLayout_TextChanged;
            config9Layout.TextChanged += configLayout_TextChanged;
            config10Layout.TextChanged += configLayout_TextChanged;   
        }

        void configLayout_TextChanged(object sender, EventArgs e)
        {
            LayoutControlItem layoutItem = sender as LayoutControlItem;
            if(layoutItem != null)
            {
                if (layoutItem.Text == layoutItem.Name)
                    layoutItem.Visibility = LayoutVisibility.Never;
                else
                    layoutItem.Visibility = LayoutVisibility.Always;                               
            }
        }

        private void Init()
        {
            m_session = m_item.Session;
        }

        private void Bind()
        {
            snText.Text = m_item.SerialNumber;
            pnText.Text = m_item.Part.PartNumber;

            PartServiceCommodity commodity = m_item.Part.ServiceCommodity;
            if (commodity != null)
            {
                LoadConfigLabels(commodity);
                LoadConfigValues(commodity);
            }
        }

        private void LoadConfigValues(PartServiceCommodity commodity)
        {
            ClearAttrBindings();

            if (m_item.ConfigValues == null)
            {
                m_item.ConfigValues = Scout.Core.Data.CreateEntity<UnitConfigValues>(m_session);
                m_item.ConfigValues.Item = m_item;
                m_item.ConfigValues.Header = commodity.UnitConfigHeader;
            }

            config1SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr1");
            config2SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr2");
            config3SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr3");
            config4SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr4");
            config5SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr5");
            config6SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr6");
            config7SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr7");
            config8SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr8");
            config9SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr9");
            config10SelList.DataBindings.Add("EditValue", m_item.ConfigValues, "Attr10");
        }

        private void LoadConfigLabels(PartServiceCommodity commodity)
        {
            UnitConfigHeader header = commodity.UnitConfigHeader;
            if(header != null)
            {
                config1Layout.Text = header.Attr1;
                config2Layout.Text = header.Attr2;
                config3Layout.Text = header.Attr3;
                config4Layout.Text = header.Attr4;
                config5Layout.Text = header.Attr5;
                config6Layout.Text = header.Attr6;
                config7Layout.Text = header.Attr7;
                config8Layout.Text = header.Attr8;
                config9Layout.Text = header.Attr9;
                config10Layout.Text = header.Attr10;
            }            
        }

        private void ClearAttrBindings()
        {
            config1SelList.DataBindings.Clear();
            config2SelList.DataBindings.Clear();
            config3SelList.DataBindings.Clear();
            config4SelList.DataBindings.Clear();
            config5SelList.DataBindings.Clear();
            config6SelList.DataBindings.Clear();
            config7SelList.DataBindings.Clear();
            config8SelList.DataBindings.Clear();
            config9SelList.DataBindings.Clear();
            config10SelList.DataBindings.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Scout.Core.Data.Save(m_session);            
            Close();
        }
        
    }
}