using System;
using System.Windows.Forms;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Search
{    
    public class SearchController<T>
    {
        private Form m_parent;
        private SearchForm m_searchForm;
        private SearchDetail<T> m_searchDetail;
        private T m_output;

        public SearchController(Form parent)
        {
            m_parent = parent;
        }

        public SearchController()
        {
        }

        public void SearchByType()
        {
            SearchDetail<T> details = SearchSettings.GetSearchDetailsFor<T>();
            if(details == null)
                throw new NullReferenceException("Could not find SearchSettings for type " + typeof (T));

            SearchByDetail(details);            
        }

        public void SearchByDetail(SearchDetail<T> detail)
        {
            m_searchDetail = detail;

            m_searchForm = new SearchForm
                               {
                                   WindowState = detail.WindowState,
                                   MdiParent = detail.MdiParent,
                                   SearchObjectType = typeof (T),
                                   StoredProc = detail.StoredProcedure,
                                   Text = detail.SearchText
                               };

            m_searchForm.OpenRow += LoadDetailView;

            if(detail.SearchButtons != null)
                detail.SearchButtons.LoadButtons(m_searchForm);

            if (m_searchDetail.ShowModal)
                m_searchForm.ShowDialog();
            else
                m_searchForm.Show();

            m_searchForm.Focus();
        }

        private void LoadDetailView(object sender, OpenRowEventArgs e)
        {
            // Exit if the id column is not defined.
            if (string.IsNullOrEmpty(m_searchDetail.IdColumn))
                return;

            object id = e.DataRow[m_searchDetail.IdColumn];

            //try
            //{
            Object obj;
            if (typeof (T).BaseType == typeof (VPLiteObject) | 
                typeof(T).BaseType == typeof(VPObject) |
                typeof(T).BaseType == typeof(ContractBase) |
                typeof(T).BaseType == typeof(Area))
            {
                IUnitOfWork unitOfWork;
                if (m_searchDetail.Session != null)
                    unitOfWork = m_searchDetail.Session;
                else
                    unitOfWork = Scout.Core.Data.GetUnitOfWork();

                m_output = unitOfWork.GetObjectByKey<T>(id);

                // Call output delegate if the caller only wants output.
                if (m_searchDetail.OutputOnly)
                {
                    m_searchDetail.OnSelection(m_output);
                    m_searchForm.Close();
                    return;
                }

                obj = Activator.CreateInstance(m_searchDetail.EditFormType, new object[] { m_output });
            }
            else
            {
                obj = Activator.CreateInstance(m_searchDetail.EditFormType,
                                               new object[] {RobotRepository.GetObjectByKey<T>(id)});
            }
                         
            Form form = obj as Form;
            if (form != null)
            {
                form.MdiParent = m_searchDetail.MdiParent;
                form.WindowState = FormWindowState.Normal;
                form.Show();
            }   

        }
    }
}