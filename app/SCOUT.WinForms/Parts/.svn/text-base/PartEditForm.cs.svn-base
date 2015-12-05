using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using SCOUT.Core.Services;
using SCOUT.WinForms.Core;
using SCOUT.WinForms.Parts;
using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public partial class PartEditForm : DevExpress.XtraEditors.XtraForm
    {
        #region Member Variables

        private Part m_part;        
        private ICollection<PartServiceCommodity> m_serviceCommodities;
        private IUnitOfWork m_session;
        private PartService m_service = new PartService();
        private MaterialsPart m_materialsPart;

        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="part"></param>
        public PartEditForm(Part part)
        {
            InitializeComponent();
            mainLayout.Dock = DockStyle.Fill;
            m_part = part;
            m_session = part.Session;
            InitLists();
            LoadPart(part);
            WireEvents();
            InitBindings();
            InitSecurity();
        }
         
        /// <summary>
        /// 
        /// </summary>
        public MaterialsPart MaterialsPart
        {
            get
            {
                return m_materialsPart;
            }
            set
            {
                m_materialsPart = value;
                if (m_materialsPart == null)
                {
                    DisableMaterialsConfiguration();
                } 
                else
                {
                    EnableMaterialsConfiguration(m_materialsPart);
                }                
            }
        }

        /// <summary>
        /// Enables the MaterialsPart editors
        /// </summary>
        /// <param name="materialsPart"></param>
        private void EnableMaterialsConfiguration(MaterialsPart materialsPart)
        {
            materialsConfigGroup.Visibility = LayoutVisibility.Always;
            createMaterialsConfigLayout.Visibility = LayoutVisibility.Never;
            deleteMaterialsConfigLayout.Visibility = LayoutVisibility.Always;
            BindMaterialsConfiguration(materialsPart);
        }


        /// <summary>
        /// Binds the MaterialsPart configuration to the UI for editing.
        /// </summary>
        /// <param name="materialsPart"></param>
        private void BindMaterialsConfiguration(MaterialsPart materialsPart)
        {
            materialsOrderablePnText.DataBindings.Clear();
            materialsWhereUsedText.DataBindings.Clear();
            materialsXrefGrid.DataBindings.Clear();
            materialsLeadTimeGrid.DataBindings.Clear();

            materialsOrderablePnText.DataBindings.Add("Text", materialsPart,
                                                      "OrderablePn");

            materialsWhereUsedText.DataBindings.Add("Text", materialsPart,
                                                    "WhereUsed");

            materialsXrefGrid.DataBindings.Add("DataSource", materialsPart,
                                               "XrefPartNumbers");

            materialsLeadTimeGrid.DataBindings.Add("DataSource", materialsPart,
                                                   "Suppliers");

        }

        /// <summary>
        /// Disables the MaterialsPart configuration editors
        /// </summary>
        private void DisableMaterialsConfiguration()
        {
            materialsConfigGroup.Visibility = LayoutVisibility.Never;
            createMaterialsConfigLayout.Visibility = LayoutVisibility.Always;
            deleteMaterialsConfigLayout.Visibility  = LayoutVisibility.Never;
        }

        /// <summary>
        /// Hides the attribute controls that have no values defined.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void attrLayout_TextChanged(object sender, EventArgs e)
        {
            LayoutControlItem layoutItem = sender as LayoutControlItem;
            if (layoutItem != null)
            {
                if (layoutItem.Text == layoutItem.Name)
                    layoutItem.Visibility = LayoutVisibility.Never;
                else
                    layoutItem.Visibility = LayoutVisibility.Always;
            }
        }

        /// <summary>
        /// Subscribe to various form events.
        /// </summary>
        private void WireEvents()
        {
            serviceCommoditySelList.EditValueChanged += serviceCommoditySelList_EditValueChanged;
            filePathHyperLink.Click += filePathHyperLink_Click;
            filePathHyperLink.ButtonClick += filePathHyperLink_ButtonClick;
            snFormatsCheckList.ItemCheck += snFormatsCheckList_ItemCheck;
            familyText.ButtonClick += familyText_ButtonClick;

            attr10Layout.TextChanged += attrLayout_TextChanged;
            attr2Layout.TextChanged += attrLayout_TextChanged;
            attr3Layout.TextChanged += attrLayout_TextChanged;
            attr4Layout.TextChanged += attrLayout_TextChanged;
            attr5Layout.TextChanged += attrLayout_TextChanged;
            attr6Layout.TextChanged += attrLayout_TextChanged;
            attr7Layout.TextChanged += attrLayout_TextChanged;
            attr8Layout.TextChanged += attrLayout_TextChanged;
            attr9Layout.TextChanged += attrLayout_TextChanged;
            attr10Layout.TextChanged += attrLayout_TextChanged;
        }


        /// <summary>
        /// Loads the part family view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void familyText_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(m_part.PartFamily != null)
            {
                ViewLoader.Instance()
                    .CreateFormWithArgs<PartFamilyForm>(false, new object[] {m_part.PartFamily});         
            }
        }

        void snFormatsCheckList_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CheckedListBoxItem item in snFormatsCheckList.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    sb.AppendFormat("{0},", item.Value);
            }

            if (sb.Length > 0)
                m_part.ValidSerialFormats = sb.ToString(0, sb.Length - 1);
            else
                m_part.ValidSerialFormats = "";

        }


        /// <summary>
        /// Requests a file path via the OpenFileDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void filePathHyperLink_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            documentsView.ActiveEditor.EditValue = ofd.FileName;
        }


        /// <summary>
        /// Opens the selected part document for viewing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void filePathHyperLink_Click(object sender, EventArgs e)
        {
            PartDocument document = documentsView.GetFocusedRow() as PartDocument;
            if (document != null)
            {
                document.Document.Open();
            }
        }


        /// <summary>
        /// Loads the additional configuration options available 
        /// under the selected <see cref="PartServiceCommodity"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serviceCommoditySelList_EditValueChanged(object sender, EventArgs e)
        {
            PartServiceCommodity serviceCommodity = serviceCommoditySelList.EditValue as PartServiceCommodity;
            if (serviceCommodity != null)
            {
                LoadAttributeLabels(serviceCommodity);
                LoadAttributeValues(serviceCommodity);
                LoadModels(serviceCommodity);                              
            }
        }


        /// <summary>
        /// Load the part model options from the <see cref="PartServiceCommodity"/>
        /// </summary>
        /// <param name="commodity"></param>
        private void LoadModels(PartServiceCommodity commodity)
        {
            modeLookup.Properties.DataSource = commodity.PartModels;
            modeLookup.Properties.DisplayMember = "Model";
            modeLookup.Properties.ValueMember = "This";
        }


        /// <summary>
        /// Load the values of any defined service attributes
        /// </summary>
        /// <param name="commodity"></param>
        private void LoadAttributeValues(PartServiceCommodity commodity)
        {
            ClearAttrBindings();

            if(m_part.Attributes == null)
            {
                m_part.Attributes = Scout.Core.Data.CreateEntity<PartAttributeValues>(m_session);
            }

            m_part.Attributes.Part = m_part;
            m_part.Attributes.Header = commodity.AttributesHeader;
            
            attr1Text.DataBindings.Add("Text", m_part.Attributes, "Attr1");
            attr2Text.DataBindings.Add("Text", m_part.Attributes, "Attr2");
            attr3Text.DataBindings.Add("Text", m_part.Attributes, "Attr3");
            attr4Text.DataBindings.Add("Text", m_part.Attributes, "Attr4");
            attr5Text.DataBindings.Add("Text", m_part.Attributes, "Attr5");
            attr6Text.DataBindings.Add("Text", m_part.Attributes, "Attr6");
            attr7Text.DataBindings.Add("Text", m_part.Attributes, "Attr7");
            attr8Text.DataBindings.Add("Text", m_part.Attributes, "Attr8");
            attr9Text.DataBindings.Add("Text", m_part.Attributes, "Attr9");
            attr10Text.DataBindings.Add("Text", m_part.Attributes, "Attr10");
        }

        /// <summary>
        /// Clears the data bindings of the attribute text boxes
        /// </summary>
        private void ClearAttrBindings()
        {
            attr1Text.DataBindings.Clear();
            attr2Text.DataBindings.Clear();
            attr3Text.DataBindings.Clear();
            attr4Text.DataBindings.Clear();
            attr5Text.DataBindings.Clear();
            attr6Text.DataBindings.Clear();
            attr7Text.DataBindings.Clear();
            attr8Text.DataBindings.Clear();
            attr9Text.DataBindings.Clear();
            attr10Text.DataBindings.Clear();
        }

        /// <summary>
        /// Loads the attribute label values
        /// </summary>
        /// <param name="commodity"></param>
        private void LoadAttributeLabels(PartServiceCommodity commodity)
        {
            PartAttributesHeader header = commodity.AttributesHeader;
            if(header != null)
            {
                // Show the attributes layout
                attributesLayout.Visibility = LayoutVisibility.Always;

                // set the labels text to the attribute display value
                attr1Layout.Text = header.Attr1;
                attr2Layout.Text = header.Attr2;
                attr3Layout.Text = header.Attr3;
                attr4Layout.Text = header.Attr4;
                attr5Layout.Text = header.Attr5;
                attr6Layout.Text = header.Attr6;
                attr7Layout.Text = header.Attr7;
                attr8Layout.Text = header.Attr8;
                attr9Layout.Text = header.Attr9;
                attr10Layout.Text = header.Attr10;
            } 
            else
            {
                // Hide the attributes layout
                attributesLayout.Visibility = LayoutVisibility.Never;
            }
        }

        /// <summary>
        /// Enables or disables the editing of the part based on the current users permissions
        /// </summary>
        private void InitSecurity()
        {
            if (!SCOUT.Core.Security.UserSecurity.CurrentUser.CanPerform(SCOUT.Core.Security.UserSecurity.Action.EditParts))
            {
                // Enter into a view only mode.
                saveBtn.Enabled = false;

                foreach (Control c in Controls)
                    c.Enabled = false;
            }
        } 


        /// <summary>
        /// Load all the part property selection lists
        /// </summary>
        private void InitLists()
        {
            try
            {                                
                typeEdit.Properties.DataSource = PartService.GetPartTypes(m_session);
                typeEdit.Properties.DisplayMember = "Name";
                typeEdit.Properties.ValueMember = "This";

                identEdit.Properties.DataSource = PartService.GetPartIdentTypes(m_session);
                identEdit.Properties.DisplayMember = "Name";
                identEdit.Properties.ValueMember = "This";

                manfLookUp.Properties.DataSource = PartService.GetPartManufacturers(m_session);
                manfLookUp.Properties.DisplayMember = "Manufacturer";
                manfLookUp.Properties.ValueMember = "This";

                sflLookUp.DataSource = Scout.Core.Service<IAreaService>().GetAllShopfloorlines(m_session);
                sflLookUp.DisplayMember = "Label";
                sflLookUp.ValueMember = "This";

                routeLookUp.DataSource = Scout.Core.Service<IShopfloorService>().GetAllServiceRoutes(m_session);
                routeLookUp.DisplayMember = "Name";
                routeLookUp.ValueMember = "This";

                m_serviceCommodities = PartService.GetPartServiceCommodities(m_session);    
                

                serviceCommoditySelList.Properties.DataSource = m_serviceCommodities;                
                orgSource.DataSource = Organization.GetOrganizations();

                if (m_part.ServiceCommodity != null)
                {
                    modeLookup.Properties.DataSource = m_part.ServiceCommodity.PartModels;
                    modeLookup.Properties.DisplayMember = "Model";
                    modeLookup.Properties.ValueMember = "This";
                }
                                   
                LoadSerialFormats();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Load the valid serial number formats for the part being edited.
        /// </summary>
        private void LoadSerialFormats()
        {
            // Guard
            if(m_part.ValidSerialFormatList == null)
                return;

            foreach (string format in m_part.ValidSerialFormatList )
            {
                foreach (CheckedListBoxItem item in snFormatsCheckList.Items)
                {
                    if(item.Value.ToString() == format)
                        item.CheckState = CheckState.Checked;
                }
            }            
        }


        /// <summary>
        /// Bind the editors the part entity
        /// </summary>
        private void InitBindings()
        {
            try
            {
                partNoEdit.DataBindings.Add("Text", partSource, "PartNumber");
                descEdit.DataBindings.Add("Text", partSource, "Description");                
                typeEdit.DataBindings.Add("EditValue", m_part, "Type!");
                identEdit.DataBindings.Add("EditValue", m_part, "IdentType!");
                isShipEdit.DataBindings.Add("Checked", m_part, "IsShippable");
                isReceivableCheck.DataBindings.Add("Checked", m_part, "IsReceivable");
                serviceCommoditySelList.DataBindings.Add("EditValue", m_part, "ServiceCommodity!");
                manfLookUp.DataBindings.Add("EditValue", m_part, "Manufacturer!");
                documentsGrid.DataBindings.Add("DataSource", m_part, "Documents");
                defaultRoutesGrid.DataBindings.Add("DataSource", m_part, "DefaultRoutes");
                topLevelCheck.DataBindings.Add("Checked", m_part, "IsTopLevel");
                modeLookup.DataBindings.Add("EditValue", m_part, "Model!");
                disableRealTimeConsumptionCheck.DataBindings.Add("Checked", m_part, "DisableMaterialsTracking");

                if(m_part.PartFamily != null)
                {
                    familyText.Text = m_part.PartFamily.Label;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Load the part for editing
        /// </summary>
        /// <param name="part"></param>
        public void LoadPart(Part part)
        {
            m_part = part;
            partSource.DataSource = m_part;

            if (m_part.Id == -1)
                Text = "New Part";
            else
                Text = "Part " + m_part.PartNumber;

            partNoEdit.Enabled = m_part.IsNew;

            LoadConfigurations();

        }


        /// <summary>
        /// Load any defined part configurations for editing
        /// </summary>
        private void LoadConfigurations()
        {
            MaterialsPart = PartService.GetMaterialsPart(m_part);
        }


        /// <summary>
        /// Save the changes to the database.
        /// </summary>
        private void Save()
        {            
            Helpers.ForeceDataBindUpdate(this);
            if (m_service.SavePart(m_part))
                Close();
        }


        /// <summary>
        /// Save button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {            
            focusLabel.Focus();                        
            Save();
        }


        /// <summary>
        /// Removes the selected document from the parts document list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeDocumentLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            PartDocument document = documentsView.GetFocusedRow() as PartDocument;
            if(document != null)
            {
                m_part.RemoveDocument(document);    
            }           
        }


        /// <summary>
        /// Creates a new MaterialsPart Configuration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createMatlConfigurationLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
           MaterialsPart = PartService.CreateMaterialsPart(m_part);
        }


        /// <summary>
        /// Gets the current PartModel and opens the bom master for editing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openBomMasterLink_OpenLink(object sender, OpenLinkEventArgs e)
        {
            PartModel partModel = modeLookup.EditValue as PartModel;
            if(partModel != null)
            {
                FrontController.GetInstance().RunCommand(
                     PartCommands.ManagePartModelBomMaster, partModel.Id); 
            }                
        }
    }
}