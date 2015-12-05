using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;

using ToteCommands=SCOUT.WinForms.Core.ToteCommands;

namespace SCOUT.WinForms.Inventory
{
    public partial class ToteManagerForm : XtraForm
    {
        private Tote m_tote;
        private FrontController m_frontController = FrontController.GetInstance();

        public ToteManagerForm(Tote tote)
        {
            InitializeComponent();
            m_tote = tote;
            Bind();
            WireCommandRequests();
            WireEvents();
        }

        private void WireEvents()
        {
            transferToteLink.LinkClicked += linkButton_LinkClicked;
            removeItemsLink.LinkClicked += removeItemsLink_LinkClicked;
            transferItemsLink.LinkClicked += transferItemsLink_LinkClicked;
            printLabelItem.LinkClicked += printLabelItem_LinkClicked;
            addItemsLink.LinkClicked += addItemsLink_LinkClicked;
            putAwayItemsLink.LinkClicked += putAwayItemsLink_LinkClicked;
            exportLink.LinkClicked += exportLink_LinkClicked;
        }

        void exportLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {           
            Export.ExportGridToFile(toteContentsGrid, "xls");            
        }

        void putAwayItemsLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            m_frontController.RunCommand(ToteCommands.TotePutAway, m_tote);
        }

        void addItemsLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            m_frontController.RunCommand(ToteCommands.AddItems, m_tote);
        }

        void printLabelItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            m_frontController.RunCommand(ToteCommands.TotePrintLabel, m_tote);
        }

        void transferItemsLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {                     
            m_frontController.RunCommand(
                e.Link.Item.Tag.ToString(),
                new ToteContentsTransferCommandArguments(
                m_tote));
        }

        private void WireCommandRequests()
        {
            transferToteLink.Tag = ToteCommands.ToteTransfer;
            removeItemsLink.Tag = ToteCommands.RemoveItems;
            transferItemsLink.Tag = ToteCommands.ToteContentsTransfer;
            addItemsLink.Tag = ToteCommands.AddItems;
        }

        void removeItemsLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            object row = contentsView.GetFocusedRow();
            if(row != null)
                m_frontController.RunCommand(
                    e.Link.Item.Tag.ToString(), 
                    m_tote);
            Bind();
        }

        void linkButton_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            m_frontController.RunCommand(
                    e.Link.Item.Tag.ToString(), 
                    m_tote);
            Bind();
        }

        private void Bind()
        {
            try
            {
                toteContentsGrid.DataSource = m_tote.Contents;                
                toteTypeText.Text = m_tote.ToteType.ToString();
                locationText.Text = m_tote.Domain.ToString();
                labelText.Text = m_tote.Label;
                locationLabel.Text = string.Format(locationLabel.Text, m_tote.ToteType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshToteLink_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Bind();
        }
    }
}