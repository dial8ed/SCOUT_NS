using System;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Entities.CS;

namespace SCOUT.CS.UI
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
            toteGrid.DataSource = new XPCollection<Tote>(XpoDefault.Session);
            toteTypeList.Items.AddRange(Enum.GetValues(typeof (ToteType)));
        }
    }
}