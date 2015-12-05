using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SCOUT.Core;
using SCOUT.Core.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms
{
    public partial class areaManagementForm : Form
    {
        private ICollection<Site> m_areaData;        
        private IUnitOfWork m_uow;
        private PersistenceController m_persistenceController;

        public areaManagementForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            m_uow = Scout.Core.Data.GetUnitOfWork();

            m_persistenceController  = new PersistenceController(m_uow);

            m_areaData = Scout.Core.Data.GetList<Site>(m_uow).All();            

            areaGrid.DataSource = m_areaData;

            WireEvents();
            colStatus.ColumnEdit = new AreaStatusComboObserver(m_uow);
            colDomainStatus.ColumnEdit = new AreaStatusComboObserver(m_uow);
            colSflStatus.ColumnEdit = new AreaStatusComboObserver(m_uow);
            
            saveButton.Click += (s,e) => 
                                    {
                                        if(m_persistenceController.Save())
                                            Close();
                                    };

            cancelButton.Click += (s,e) =>
                                      {
                                          if(m_persistenceController.Cancel())
                                            Close();
                                      };
        }

        private void WireEvents()
        {
            areaView.ValidateRow += view_ValidateRow;
            sflView.ValidateRow += view_ValidateRow;
            domainView.ValidateRow +=view_ValidateRow;

            areaView.InvalidRowException += view_InvalidRowException;
            sflView.InvalidRowException += view_InvalidRowException;
            domainView.InvalidRowException += view_InvalidRowException;            
        }

        void view_ValidateRow(object sender, ValidateRowEventArgs e)
        {
          AreaUIValidators.ValidateRow(sender, e, areaGrid);  
        }

        void view_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }


        private void locationEditButton_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ColumnView gridView = areaGrid.GetViewAt(areaGrid.PointToClient(MousePosition)) as ColumnView;

            if (gridView != null)
            {
                int[] rowHandle = gridView.GetSelectedRows();

                Domain currentDomain = areaGrid.DefaultView.GetRow(rowHandle[0]) as Domain;

                if (currentDomain != null)
                {
                    domainLocationManager f = new domainLocationManager(currentDomain);
                    f.ShowDialog(this);
                }
            }
        }

        private void printItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            areaGrid.Print();
        }

        private void printPreviewItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            areaGrid.ShowPrintPreview();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog(this);
            areaGrid.ExportToXls(saveFileDialog.FileName);                        
        }

        private void domainLabelEditor_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Delete)
            {                
                Domain domain = domainView.GetFocusedRow() as Domain;
                if(domain != null)
                {
                    domain.Delete();
                }
            }
        }
    }
}