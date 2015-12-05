using System;
using System.Collections.Generic;
using SCOUT.Core;
using SCOUT.WinForms.Controls;

namespace SCOUT.WinForms.Service
{
    public partial class ShopfloorConditionManager : PersistentBaseControl
    {
        private ICollection<ShopfloorCondition> m_conditionsData;

        public ShopfloorConditionManager() : base(Scout.Core.Data.GetUnitOfWork())
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            m_conditionsData = Scout.Core.Data.GetList<ShopfloorCondition>(UnitOfWork).All();
            conditionsGrid.DataSource = m_conditionsData;
        }
    }
}
