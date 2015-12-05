using System;
using System.Windows.Forms;
using SCOUT.WinForms.Areas;
using SCOUT.Core.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms
{
    public partial class domainLocationManager : Form
    {
        private Domain m_domain;
        private IUnitOfWork m_uow;

        private AreaStatusComboObserver m_areaStatusComboObserver;

        public domainLocationManager(Domain domain)
        {
            InitializeComponent();
            Init(domain);
            BindData();
            WireEvents();
        }

        private void Init(Domain domain)
        {
            m_domain = domain;
            m_uow = m_domain.Session;            
            m_areaStatusComboObserver = new AreaStatusComboObserver(m_uow);
        }

        private void BindData()
        {
            domainText.DataBindings.Add("Text", m_domain, "Label");
            locatorControllerCheck.DataBindings.Add("Checked", m_domain, "LocatorControlled");
            sectionsGrid.DataBindings.Add("DataSource", m_domain, "Sections");
            locationControllerTabGroup.DataBindings.Add("Enabled", m_domain, "LocatorControlled");

            sectionStatusCol.ColumnEdit = m_areaStatusComboObserver;            
            shelfStatusCol2.ColumnEdit = m_areaStatusComboObserver;
            bayStatusCol2.ColumnEdit = m_areaStatusComboObserver;

        }

        private void WireEvents()
        {
            sectionView.ValidateRow += new ValidateRowEventHandler(view_ValidateRow);
            baysView.ValidateRow += new ValidateRowEventHandler(view_ValidateRow);
            shelvesView.ValidateRow += new ValidateRowEventHandler(view_ValidateRow);

            sectionView.ValidatingEditor +=new BaseContainerValidateEditorEventHandler(sectionView_ValidatingEditor);
            baysView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(baysshelvesView_ValidatingEditor);
            shelvesView.ValidatingEditor += new BaseContainerValidateEditorEventHandler(baysshelvesView_ValidatingEditor);

            sectionView.InvalidRowException += new InvalidRowExceptionEventHandler(sectionView_InvalidRowException);
            baysView.InvalidRowException += new InvalidRowExceptionEventHandler(sectionView_InvalidRowException);
            shelvesView.InvalidRowException += new InvalidRowExceptionEventHandler(sectionView_InvalidRowException);

        }

        private void view_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            AreaUIValidators.ValidateRow(sender, e, sectionsGrid);
        }

        private void sectionView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void printItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sectionsGrid.Print();
        }

        private void printPreviewItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sectionsGrid.ShowPrintPreview();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void sectionView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (sectionView.FocusedColumn.FieldName == "Label!")
            {
                if (((string)sectionView.EditingValue).Length > 5)
                {
                    e.Valid = false;
                    e.ErrorText = "Section label must be less than or equal to 5 characters";
                }
            }

        }

        void baysshelvesView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if(view != null)
            {
                if(view.FocusedColumn.FieldName == "Label!")
                {
                    if(((string)view.EditingValue).Length > 3)
                    {
                        e.Valid = false;
                        e.ErrorText = "Bay and shelf labels must be less than or equal to 3 characters";
                    }
                }
            }
        }

        private void repositoryItemPopupContainerEdit1_Popup(object sender, EventArgs e)
        {
            int rowHandle = sectionView.FocusedRowHandle;
            Section section = sectionView.GetRow(rowHandle) as Section;

            if(section != null)
            {
                baysPopupGrid.DataSource = section.Bays;
            }

        }

        private void bayShelvesPopupContainer_Popup(object sender, EventArgs e)
        {
            int rowHandle = baysView.FocusedRowHandle;

            Bay bay = baysView.GetRow(rowHandle) as Bay;
            if(bay != null)
            {
                shelvesPopupGrid.DataSource = bay.Shelves;
            }
        }

        private void generatorItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(new RacklocationGeneratorForm(m_domain).ShowDialog(this) == DialogResult.OK)
            {
                Refresh();
            }
        }
    }
}