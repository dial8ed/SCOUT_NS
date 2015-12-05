using System;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Services;


namespace SCOUT.WinForms
{
    public partial class TravelerLabelForm : DevExpress.XtraEditors.XtraForm
    {
        private ReceivingLabelDetail labelDetail;

        public TravelerLabelForm()
        {
            InitializeComponent();
            WireEvents();
        }

        private void WireEvents()
        {
            simpleButton1.Click += simpleButton1_Click;
            lotIdText.Validated += lotIdText_Validated;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PrintLabel();
        }

        private void PrintLabel()
        {
            if (lotIdText.Text.Length <= 0)
                return;
           
            InventoryItem item = Scout.Core.Service<IInventoryService>().GetItemById(Scout.Core.Data.GetUnitOfWork(), lotIdText.Text);

            if(item == null)
                item = Scout.Core.Service<IInventoryService>().GetItemBySN(Scout.Core.Data.GetUnitOfWork(), lotIdText.Text);

            if(item != null)      
                Scout.Core.Service<IInventoryService>().PrintTravelerLabel(item);
            else
                Scout.Core.UserInteraction.Dialog.ShowMessage("Invalid inventory item", UserMessageType.Error);
                        
            Reset();
        }

        private void Reset()
        {
            lotIdText.Text = "";
            lotIdText.Focus();
        }

        private void lotIdText_Validated(object sender, EventArgs e)
        {
            PrintLabel();
        }
    }
}