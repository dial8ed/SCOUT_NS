using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using SCOUT.Core.Data;

namespace SCOUT.WinForms
{
    public class MRUListController
    {
        private Dictionary<string, ParameterList> m_editorLists;
        private IUnitOfWork m_session;

        public MRUListController()
        {
            m_session = Scout.Core.Data.GetUnitOfWork();
            m_editorLists = new Dictionary<string, ParameterList>();
        }

        public IUnitOfWork Session
        {
            get { return m_session; }
        }

        public MRUEdit NewMRUEdit(string paramName)
        {
            MRUEdit mruEdit = new MRUEdit();
            mruEdit.Properties.MaxItemCount = 10;
            mruEdit.Name = paramName + "Edit";
            LoadListItems(mruEdit, paramName);
            mruEdit.AddingMRUItem += searchForm_AddingMRUItem;
            mruEdit.Validated += mruEdit_Validated;
            return mruEdit;
        }

        void mruEdit_Validated(object sender, EventArgs e)
        {
            searchForm_AddingMRUItem(sender, null);
        }

        //void mruEdit_Click(object sender, EventArgs e)
        //{
        //    MRUEdit mruEdit = sender as MRUEdit;
        //    ProcSearchParam param = mruEdit.Tag as ProcSearchParam;

        //    if(mruEdit.Properties.Items.Count == 0 )
        //    {
        //        LoadListItems(mruEdit, param.Name.Substring(1));
        //    }
        //}

        public void searchForm_AddingMRUItem(object sender, DevExpress.XtraEditors.Controls.AddingMRUItemEventArgs e)
        {
            if (e == null)
                return;

            MRUEdit editor = sender as MRUEdit;
            if (editor != null)
            {
                ProcSearchParam param = editor.Tag as ProcSearchParam;
                ParameterList list = m_editorLists[editor.Name];
                ParameterListItem item = list.Contains(param.Value.ToString());

                if (item == null)
                {
                    ParameterListItem newItem =Scout.Core.Data.CreateEntity<ParameterListItem>(m_session);
                    newItem.Item = param.Value.ToString();
                    newItem.LastUsed = DateTime.Now;
                    newItem.DateAdded = DateTime.Now;
                    newItem.UserName = SCOUT.Core.Security.UserSecurity.CurrentUser.Login;
                    newItem.ParameterList = list;
                }
                else
                {
                    item.LastUsed = DateTime.Now;
                }

                Scout.Core.Data.Save(m_session);                
            }
        }

        private void LoadListItems(MRUEdit mruEdit, string name)
        {
            ParameterList list = ParameterList.GetListByParamName(m_session, name);

            if (list == null)
            {
                list = Scout.Core.Data.CreateEntity<ParameterList>(m_session);
                list.ParamName = name;
            }

            m_editorLists.Add(mruEdit.Name, list);

            foreach (ParameterListItem item in list.ListItemsSortedAtoZ)
            {
                mruEdit.Properties.Items.Add(item.Item);
            }
        }
    }
}