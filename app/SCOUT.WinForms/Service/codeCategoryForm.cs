using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class CodeCategoryForm : XtraForm
    {
        public CodeCategoryForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            categoriesList = new XPCollection(Scout.Core.Data.GetUnitOfWork(),typeof(ServiceCodeCategory));
            categoriesGrid.DataSource = categoriesList;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}