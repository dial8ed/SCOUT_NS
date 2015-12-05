using System;
using System.Collections.Generic;
using SCOUT.Core.Modules.Materials;
using SCOUT.WinForms.Core;

namespace SCOUT.WinForms.Materials
{
    public partial class PartsConsumptionView : PassiveViewBase, IPartsConsumptionView
    {
        public PartsConsumptionView()
        {
            InitializeComponent();
            WireEvents();
        }


        private void WireEvents()
        {
            saveButton.Click += saveButton_Click;
            cancelButton.Click += cancelButton_Click;
        }

        void cancelButton_Click(object sender, EventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this,"cancel");                      
        }

        void saveButton_Click(object sender, EventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "save");
        }

        private void refreshMaterialsLink_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "refresh_materials");
        }

        public void SetState(string consumptionDescription, IList<PartToConsume> partsToConsume)
        {
            descriptionText.Text = consumptionDescription;
            configurationItemsGrid.DataSource = partsToConsume;
        }
    }
}