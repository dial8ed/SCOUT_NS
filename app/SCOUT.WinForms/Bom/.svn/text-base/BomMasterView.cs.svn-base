using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using SCOUT.Core.Mvc;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Bom
{
    public partial class BomMasterView : PassiveViewBase, IBomMasterView
    {
        public BomMasterView()
        {
            InitializeComponent();
            WireEvents();
        }


        protected void WireEvents()
        {
            WireActionRequestEvents();
        }


        private void WireActionRequestEvents()
        {
            saveButton.Click += saveButton_Click;
            cancelButton.Click += cancelButton_Click;
            createBomMasterLink.LinkClicked += createBomMasterLink_LinkClicked;
            newBomConfigurationLink.Click += newBomConfigurationLink_Click;
            editConfigurationLink.Click += editConfigurationLink_Click;
            removeConfigurationLink.Click += removeConfigurationLink_Click;
        }

        void removeConfigurationLink_Click(object sender, EventArgs e)
        {
            BomConfiguration configuration =
                serviceConfigurationsView.GetFocusedRow() as BomConfiguration;

            if(configuration != null)
                DeleteBomConfiguration(this, new SingleChoiceActionRequestEventArgs<BomConfiguration>(configuration));
        }

        void editConfigurationLink_Click(object sender, EventArgs e)
        {
            BomConfiguration configuration =
                serviceConfigurationsView.GetFocusedRow() as BomConfiguration;
    
            if(configuration != null)
                EditBomConfiguration(this, new SingleChoiceActionRequestEventArgs<BomConfiguration>(configuration));            
        }

        void newBomConfigurationLink_Click(object sender, EventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "new_bom_configuration");
        }


        private void createBomMasterLink_LinkClicked(object sender,
                                                     DevExpress.XtraNavBar.
                                                         NavBarLinkEventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "new_bom_master");
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "cancel");
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "save");
        }


        public PartModel PartModel
        {
            set
            {
                if (value != null)
                    partModelText.Text = value.Model;
                else
                {
                    partModelText.Text = "";
                }
            }
        }

        public ICollection<BomComponentCategory> BomComponentCategories
        {
            get
            {
                return
                    componentCategoriesGrid.DataSource as
                    ICollection<BomComponentCategory>;
            }
            set
            {
                componentCategoriesGrid.DataSource = value;
                categoryLookUp.DataSource = value;
            }
        }

        public ICollection<BomMasterComponent> BomMasterComponents
        {
            get
            {
                return
                    componentGrid.DataSource as XPCollection<BomMasterComponent>;
            }
            set { componentGrid.DataSource = value; }
        }

        public ICollection<BomConfiguration> BomConfigurations
        {
            get
            {
                return
                    serviceConfigurationsGrid.DataSource as
                    XPCollection<BomConfiguration>;
            }

            set { serviceConfigurationsGrid.DataSource = value; }
        }

        public void ManageConfiguration(BomConfiguration configuration)
        {
            FrontController.GetInstance().RunCommand(
                PartCommands.ManageBomConfiguration, configuration);
        }

        public event EventHandler<SingleChoiceActionRequestEventArgs<BomConfiguration>> EditBomConfiguration;
        public event EventHandler<SingleChoiceActionRequestEventArgs<BomConfiguration>> DeleteBomConfiguration;

        private void hyperLinkEdit1_OpenLink(object sender, DevExpress.XtraEditors.Controls.OpenLinkEventArgs e)
        {
            BomConfiguration configuration =
                serviceConfigurationsView.GetFocusedRow() as BomConfiguration;

            if (configuration != null)
                FrontController.GetInstance().RunCommand(
                    MaterialCommands.ConsumeBomConfiguration, configuration);

        }
    }
}