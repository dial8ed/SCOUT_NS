using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.XtraTreeList.Nodes;
using SCOUT.Core.Mvc;
using SCOUT.WinForms.Core;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Bom
{
    public partial class BomConfigurationView : PassiveViewBase,
                                                IBomConfigurationView
    {
        public BomConfigurationView()
        {
            InitializeComponent();
            WireEvents();
        }


        private void WireEvents()
        {
            shopfloorlineLookUp.EditValueChanged +=
                shopfloorlineLookUp_EditValueChanged;

 
            treeList1.DoubleClick += treeList1_DoubleClick;

            removeItemLink.Click += removeItemLink_Click;

            nameText.EditValueChanged += nameText_EditValueChanged;

            saveButton.Click += saveButton_Click;
            cancelButton.Click += cancelButton_Click;
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "cancel");
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            EventsController.ActionRequestEvents.Fire(this, "save");
        }


        private void removeItemLink_Click(object sender, EventArgs e)
        {
            BomConfigurationItem item =
                configurationItemsView.GetFocusedRow() as BomConfigurationItem;

            if (item == null)
                return;

            if (OnRemoveBomConfigurationItemRequest != null)
                OnRemoveBomConfigurationItemRequest(this,
                                                    new SingleChoiceActionRequestEventArgs
                                                        <BomConfigurationItem>(
                                                        item));
        }


        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            TreeListNode node = treeList1.FocusedNode;
            if (!node.HasChildren)
            {
                BomMasterComponent component = node.Tag as BomMasterComponent;

                if (OnAddComponentToConfigurationRequest != null)
                    OnAddComponentToConfigurationRequest(this,
                                                         new SingleChoiceActionRequestEventArgs
                                                             <BomMasterComponent
                                                             >(component));
            }
        }


        private void nameText_EditValueChanged(object sender, EventArgs e)
        {
            EventsController.ChangeRequestEvents.Fire("Description",
                                                      nameText.Text);
        }



        private void shopfloorlineLookUp_EditValueChanged(object sender,
                                                          EventArgs e)
        {
            EventsController.ChangeRequestEvents.Fire("Shopfloorline",
                                                      shopfloorlineLookUp.
                                                          EditValue as
                                                      Shopfloorline);
        }


        public ICollection<Shopfloorline> Shopfloorlines
        {
            set { shopfloorlineLookUp.Properties.DataSource = value; }
        }

        public PartModel PartModel
        {
            set
            {
                if (value != null)
                    partModelText.Text = value.Model;
            }
        }

        public BomMaster BomMaster
        {
            set
            {
                if (value != null)
                    BindToTree(value.Components);
                else
                    ClearTree();
            }
        }


        private void ClearTree()
        {
            treeList1.Columns.Clear();
            treeList1.Nodes.Clear();
        }


        private void BindToTree(ICollection<BomMasterComponent> components)
        {
            treeList1.BeginUpdate();
            treeList1.Columns.Add();
            treeList1.Columns[0].Caption = "Category";
            treeList1.Columns[0].VisibleIndex = 0;
            treeList1.EndUpdate();

            treeList1.BeginUnboundLoad();

            foreach (BomMasterComponent component in components)
            {
                // Root Category Node
                object[] category = new object[] {component.Category.ToString()};
                TreeListNode categoryNode =
                    DevExpressUI.TreeListHelper.GetNodeByTag(treeList1, category);

                if (categoryNode == null)
                    categoryNode = treeList1.AppendNode(category, null);

                // Child Part Number Node
                object[] value = new object[] {component.PartNumber};
                TreeListNode componentNode =
                    DevExpressUI.TreeListHelper.GetNodeByTag(treeList1, value);

                if (componentNode == null)
                    componentNode =
                        treeList1.AppendNode(
                            new object[] {component.PartNumber}, categoryNode);

                componentNode.Tag = component;
            }

            treeList1.EndUnboundLoad();
            treeList1.ExpandAll();
        }


        public BomConfiguration BomConfiguration
        {
            set
            {
                nameText.Text = value.Description;
                configurationItemsGrid.DataSource = value;
                shopfloorlineLookUp.EditValue = value.Shopfloorline;
                PartModel = value.PartModel;                
                configurationItemsGrid.DataSource = value.ConfigurationItems;
            }
        }

        public event
            EventHandler<SingleChoiceActionRequestEventArgs<BomMasterComponent>>
            OnAddComponentToConfigurationRequest;

        public event
            EventHandler
                <SingleChoiceActionRequestEventArgs<BomConfigurationItem>>
            OnRemoveBomConfigurationItemRequest;
    }
}