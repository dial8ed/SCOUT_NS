using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace SCOUT.Core.Data
{
    [Persistent("parameter_lists")]
    public class ParameterList : VPLiteObject
    {
        private int m_id;
        private string m_paramName;

        public ParameterList(Session session) : base(session)
        {
        }

        [Persistent("id")]
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return m_id; }
            set { SetPropertyValue("Id", ref m_id, value); }
        }

        [Persistent("param_name")]
        public string ParamName
        {
            get { return m_paramName; }
            set { SetPropertyValue("ParamName", ref m_paramName, value); }
        }

        [Association("ParameterList-Items")]
        public XPCollection<ParameterListItem> ListItems
        {
            get { return GetCollection<ParameterListItem>("ListItems"); }
        }

        public XPCollection<ParameterListItem> ListItemsSortedByLastUsed
        {
            get
            {
                XPCollection<ParameterListItem> sortedList = 
                    new XPCollection<ParameterListItem>(ListItems);

                sortedList.Sorting = new SortingCollection(
                        new SortProperty[]
                            {
                                new SortProperty("LastUsed",SortingDirection.Ascending),
                            });
                return sortedList;
            }
        }

        public XPCollection<ParameterListItem> ListItemsSortedAtoZ
        {
            get
            {
                XPCollection<ParameterListItem> sortedList =
                    new XPCollection<ParameterListItem>(ListItems);

                sortedList.Sorting = new SortingCollection(
                        new SortProperty[]
                            {
                                new SortProperty("Item",SortingDirection.Descending),
                            });
                return sortedList;  
            }
        }

        public ParameterListItem Contains(string item)
        {
            foreach (ParameterListItem listItem in ListItems)
            {
                if (listItem.Item == item)
                {
                    return listItem;
                }
            }

            return null;
        }

        public static ParameterList GetListByParamName(IUnitOfWork session, string paramName)
        {
            return session.FindObject<ParameterList>(new BinaryOperator("ParamName", paramName));            
        }


    }
}