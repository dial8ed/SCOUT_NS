using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms.Areas
{
    public partial class ShopfloorlineCustomFieldsForm : XtraForm
    {
        private IUnitOfWork m_session;
        private Shopfloorline m_shopfloorline;
        private bool m_loading = false;

        public ShopfloorlineCustomFieldsForm()
        {
            InitializeComponent();
            m_session = Scout.Core.Data.GetUnitOfWork();
            Bind();
            WireEvents();
        }

        private void WireEvents()
        {
            shopfloorlineLookup.EditValueChanged += shopfloorlineLookup_EditValueChanged;
            customFieldsList.ItemCheck += customFieldsList_ItemCheck;
            okButton.Click += okButton_Click;
        }

        private void customFieldsList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if(m_loading) return;

            CheckedListBoxItem item = customFieldsList.Items[e.Index];
            if (item != null)
            {
                if (e.State == CheckState.Checked)
                    m_shopfloorline.AddCustomField(item.Value.ToString());
                else
                    m_shopfloorline.RemoveCustomField(item.Value.ToString());
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Scout.Core.Data.Save(m_session);            
            Close();
        }

        private void shopfloorlineLookup_EditValueChanged(object sender, EventArgs e)
        {
            m_shopfloorline = shopfloorlineLookup.EditValue as Shopfloorline;
            if (m_shopfloorline != null)
            {
                LoadCustomFields(m_shopfloorline);
            }
        }

        private void LoadCustomFields(Shopfloorline shopfloorline)
        {
            m_loading = true;

            foreach (CheckedListBoxItem item in customFieldsList.Items)
            {
                item.CheckState = CheckState.Unchecked;

                foreach (CustomField field in shopfloorline.CustomFields)
                {
                    if (item.Value.ToString().Equals(field.FieldName))
                        item.CheckState = CheckState.Checked;
                }
            }

            m_loading = false;
        }

        private void Bind()
        {
            shopfloorlineLookup.Properties.DataSource =
                Scout.Core.Service<IAreaService>().GetAllShopfloorlines(m_session);

            customFieldsList.Items.AddRange(ItemCustomFields.GetCustomFieldsList());
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}