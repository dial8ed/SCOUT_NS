using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using SCOUT.WinForms.Controls;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Service
{
    public partial class ServiceCommodityManager : PersistentBaseControl
    {
        private ICollection<ServiceCodeCategory> m_codeCategoryData;
        private ICollection<PartServiceCommodity> m_partServiceCommodityData;

        public ServiceCommodityManager() : base(Scout.Core.Data.GetUnitOfWork())
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
                    Scout.Core.Data.Delete(UnitOfWork, commodityView.GetFocusedRow(), true);                    
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
            m_codeCategoryData = Scout.Core.Data.GetList<ServiceCodeCategory>(UnitOfWork).All();
        }

        private void Init()
        {
            LoadCategories();
            m_partServiceCommodityData = Scout.Core.Data.GetList<PartServiceCommodity>(UnitOfWork).All();
            commodityGrid.DataSource = m_partServiceCommodityData;
            serviceCodeTypeList.DataSource = Enum.GetValues(typeof(ServiceCodeType));
                     
        }
    }
}