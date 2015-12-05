using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using SCOUT.Core.Data;
using SCOUT.Core.Security;
using SCOUT.WinForms.Reports;
using SCOUT.WinForms.Search;

namespace SCOUT.WinForms
{
    public class UserQueryController
    {
        private UserQuery m_userQuery;
        private SearchForm m_searchForm;

        private string m_xmlPath = ReportDirectory.ReportPath;

        public UserQueryController(SearchForm searchForm)
        {
            m_searchForm = searchForm;
        }

        public void SaveUserQuery()
        {          
            if(m_userQuery == null)            
                m_userQuery = new UserQuery(Scout.Core.Data.GetUnitOfWork());

            PopulateQueryValues();

            if(ShowSaveDialog() == DialogResult.OK)
                SaveGridsLayoutToXML();
        }

        private void SaveGridsLayoutToXML()
        {
            m_searchForm.PivotGrid.SaveLayoutToXml(m_userQuery.PivotGridLayout);

            m_searchForm.DataGridView.OptionsLayout.StoreAllOptions = true;
            m_searchForm.DataGridView.OptionsLayout.Columns.StoreAllOptions = true;
            m_searchForm.DataGridView.OptionsLayout.Columns.AddNewColumns = true;           
            m_searchForm.DataGridView.SaveLayoutToXml(m_userQuery.DataGridLayout);
        }

        private DialogResult ShowSaveDialog()
        {
           UserQueryForm queryForm = new UserQueryForm(m_userQuery);
           return queryForm.ShowDialog();
        }

        public void LoadUserQuery(UserQuery query)
        {
            m_userQuery = query;
        }

        private void PopulateQueryValues()
        {
            if(m_userQuery == null)
                return;

            m_userQuery.Filter = m_searchForm.SearchFilterControl.FilterString;
            m_userQuery.Params = FlattenParams();
            m_userQuery.PivotGridLayout =
                string.Format("{0}{1}.xml", m_xmlPath, Guid.NewGuid());
            m_userQuery.DataGridLayout =
                string.Format("{0}{1}.xml", m_xmlPath, Guid.NewGuid());
            m_userQuery.UserName = UserSecurity.CurrentUser.Login;
            m_userQuery.SearchObjectType = m_searchForm.SearchObjectType.AssemblyQualifiedName;
            m_userQuery.SprocName = m_searchForm.StoredProcedure.Name;
        }

        private string FlattenParams()
        {
            IDictionaryEnumerator i = (IDictionaryEnumerator) m_searchForm.StoredProcedure.Params.GetEnumerator();
            StringBuilder sb = new StringBuilder();
            
            while(i.MoveNext())
            {
                ProcSearchParam param = (ProcSearchParam) i.Value;
                if(param.Value != null)
                    sb.AppendFormat("{0}:{1},", param.Name, param.Value);
            }

            if (sb.Length == 0)
                return "";

            return sb.ToString(0, sb.Length - 1);
        }

        public void LoadQueryLayout()
        {
            if (m_userQuery == null)
                return;

            LoadQueryFilter();
            LoadGridsLayout();
        }

        public void LoadParamValues(UserQuery query)
        {
            m_userQuery = query;

            string[] paramValueArray = m_userQuery.Params.Split(new char[] {','});
            Dictionary<string,string> paramValues = new Dictionary<string, string>();

            foreach (string s in paramValueArray)
            {
                paramValues.Add(s.Substring(0,s.IndexOf(":")),
                    s.Substring(s.IndexOf(":") +1,s.Length - s.IndexOf(":") -1));                
            }

            IDictionaryEnumerator i = paramValues.GetEnumerator();
            while(i.MoveNext())
            {
                m_searchForm.StoredProcedure.Params[i.Key.ToString()].Value = i.Value.ToString();
                m_searchForm.ParamEditors[i.Key.ToString()].EditValue = i.Value.ToString();
            }
        }

        public void LoadGridsLayout()
        {
            if (m_userQuery == null)
                return;

            m_searchForm.PivotGrid.RestoreLayoutFromXml(
                @m_userQuery.PivotGridLayout,OptionsLayoutBase.FullLayout);

            m_searchForm.DataGridView.RestoreLayoutFromXml(
                @m_userQuery.DataGridLayout, OptionsLayoutBase.FullLayout);
        }

        public void LoadQueryFilter()
        {
            if (m_userQuery == null)
                return;

            m_searchForm.SearchFilterControl.FilterString = m_userQuery.Filter;
            m_searchForm.SearchFilterControl.ApplyFilter();
        }
    }
}