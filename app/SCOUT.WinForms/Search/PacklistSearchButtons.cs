using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Orders;

namespace SCOUT.WinForms.Search
{
    public class PacklistSearchButtons : ISearchButtons
    {
        private SearchForm m_searchForm;

        public void LoadButtons(SearchForm searchForm)
        {
            m_searchForm = searchForm;

            ToolStripButton button;

            button = new ToolStripButton(" - Transfer Shipments - ");
            button.Click += TransferShipments;
            m_searchForm.AddToolButton(button);

            button = new ToolStripButton(" - Change Waybill - ");
            button.Click += ChangeWaybill;
            m_searchForm.AddToolButton(button);

            button = new ToolStripButton(" - View Shipments - ");
            button.Click +=ViewShipments;
            m_searchForm.AddToolButton(button);

            button = new ToolStripButton(" - Print - ");
            button.Click += PrintPacklist;
            m_searchForm.AddToolButton(button);

            button = new ToolStripButton("-Change Scrap Control Number-");
            button.Click += ChangeScrapControlNumber;
            m_searchForm.AddToolButton(button);

        }

        private void ChangeScrapControlNumber(object sender, EventArgs e)
        {

            IUnitOfWork uow = Scout.Core.Data.GetUnitOfWork();
            string scrapControlNumber = "";

            UserInputView inputView =
                new UserInputView((s) => scrapControlNumber = s, "Enter Scrap Control Number", true)
                {
                    ShowCancelButton = true
                };


            DialogResult result = inputView.ShowDialog();

            if (result == DialogResult.OK)
            {
                foreach (Packlist p in GetSelectedPacklists(uow))
                {
                    p.XipControlNumber = scrapControlNumber;
                }

                uow.Commit();

                m_searchForm.RunSearch();

            } 
        }

        private void ViewShipments(object sender, EventArgs e)
        {
            
        }

        private void ChangeWaybill(object sender, EventArgs e)
        {
            IUnitOfWork uow = Scout.Core.Data.GetUnitOfWork();
            string waybill = "";

            UserInputView inputView =
                new UserInputView((s) => waybill = s, "Enter waybill", true)
                    {
                        ShowCancelButton = true                      
                    };


            DialogResult result = inputView.ShowDialog();
            
            if(result == DialogResult.OK)
            {
                foreach (Packlist p in GetSelectedPacklists(uow))
                {
                    p.Waybill = waybill;
                }

                uow.Commit();

                m_searchForm.RunSearch();

            }                           
        }
       
        private void TransferShipments(object sender, EventArgs e)
        {
            if(m_searchForm.SelectedRows.Count != 2)
            {
                return;
            }
           
            List<Packlist> packlists = 
                GetSelectedPacklists(Scout.Core.Data.GetUnitOfWork()).ToList();

            // Packlists programs must match in order to transfer between the two.
            if(packlists[0].ShippingConfiguration.Id != 
                packlists[1].ShippingConfiguration.Id)
            {
                Scout.Core.UserInteraction.Dialog
                    .ShowMessage
                    ("These packlists do not having matching shipping configurations.", UserMessageType.Error);
                return;
            }

            PacklistsContentsTransferView view = new PacklistsContentsTransferView(packlists[0], packlists[1]);

            ViewLoader.Instance().ShowForm(view, false);
           
        }

        private void PrintPacklist(object sender, EventArgs e)
        {
            var p = GetSelectedPacklists(Scout.Core.Data.GetUnitOfWork()).First();

            if (p == null)
                return;
            
            var printer = new PacklistPrinter();
            printer.Print(p);      
            
        }

        private IEnumerable<Packlist> GetSelectedPacklists(IUnitOfWork uow)
        {                        
            var packlists =
                from dr in m_searchForm.SelectedRows
                select Scout.Core.Data.Get<Packlist>(uow).ById(dr["id"]);
  
            return packlists;
        }
    }
}