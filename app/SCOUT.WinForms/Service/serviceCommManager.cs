using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using SCOUT.Core.Data;


namespace SCOUT.WinForms.Service
{
    public partial class ServiceCommManager
    {        
        private IUnitOfWork m_unitOfWork;

        public ServiceCommManager()
        {
            InitializeComponent();
            Init();
            WireEvents();
        }

        private void WireEvents()
        {
            serviceCategoryList.ButtonPressed += serviceCategoryList_ButtonPressed;
            codesView.ValidateRow += codesView_ValidateRow;
            codesView.InvalidRowException += codesView_InvalidRowException;
            commodityGrid.EmbeddedNavigator.ButtonClick += EmbeddedNavigator_ButtonClick;
            commodityGrid.DoubleClick += commodityGrid_DoubleClick;
        }

        void commodityGrid_DoubleClick(object sender, EventArgs e)
        {
            PartServiceCommodity commodity = commodityView.GetFocusedRow() as PartServiceCommodity;
            if(commodity != null)
            {
                LoadCommodityEditor(commodity);
            }            
        }
       
        private void LoadCommodityEditor(PartServiceCommodity commodity)
        {
            ServiceCommForm f = new ServiceCommForm(commodity);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                if (commodityGrid.DefaultView.Name == "codeView")
                {
                    m_unitOfWork.PurgeDeletedObjects();
                    m_unitOfWork.Commit();
                }
            }
        }

        private void codesView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void codesView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            ServiceCodeUIValidators.ValidateRow(sender, e, commodityGrid);
        }

        private void serviceCategoryList_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                CodeCategoryForm form = new CodeCategoryForm();
                form.ShowDialog();
                LoadCategories();
                return;
            }
        }

        private void LoadCategories()
        {
            categoryList.Reload();
        }

        private void Init()
        {
            m_unitOfWork = Scout.Core.Data.GetUnitOfWork();
            categoryList.Session = m_unitOfWork as XpoUnitOfWork;

            serviceCodeTypeList.DataSource = Enum.GetValues(typeof(ServiceCodeType));
            LoadCategories();

            commodityList.Session = m_unitOfWork as XpoUnitOfWork;
        }

        private void editButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            commodityGrid_DoubleClick(null,null);
        }
    }
}