using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;
using SCOUT.Core.Services;

namespace SCOUT.WinForms
{
    public partial class toteCreatorForm : XtraForm
    {
        public toteCreatorForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            toteGrid.DataSource = new XPCollection<Tote>(Scout.Core.Data.GetUnitOfWork());
            toteTypeList.Items.AddRange(Enum.GetValues(typeof (ToteType)));
            domainLookup.DataSource = Scout.Core.Service<IAreaService>().GetAllDomains(Scout.Core.Data.GetUnitOfWork());
        }
    }
}