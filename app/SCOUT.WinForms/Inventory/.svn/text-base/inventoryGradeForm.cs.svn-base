using System;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Inventory
{
    public partial class InventoryGradeForm : XtraForm
    {
        private InventoryItem m_item;

        public InventoryGradeForm(InventoryItem item)
        {
            InitializeComponent();
            m_item = item;
            Bind();
        }

        private void Bind()
        {
            lotIdText.DataBindings.Add("Text", m_item, "LotId");
            pnText.DataBindings.Add("Text", m_item, "PartNumber");
            gradeLookUp.DataBindings.Add("EditValue", m_item, "Grade");
            gradeLookUp.Properties.DataSource = Enum.GetValues(typeof (ProductGrade));
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            m_item.Save();
            Close();
        }
    }
}