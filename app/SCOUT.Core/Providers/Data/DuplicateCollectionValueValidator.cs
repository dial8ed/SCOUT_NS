using System.Collections;
using System.Collections.Generic;
using DevExpress.Xpo;
using System.Reflection;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    public class DuplicateCollectionValueValidator<T> : ValidatorBase
    {
        private ICollection<T> m_collection;
        private string m_propertyName;

        public DuplicateCollectionValueValidator(MessageListener listener, ICollection<T> collection, string propertyName)
            : base(listener)
        {
            m_propertyName = propertyName;
            m_collection = collection;
        }

        public DuplicateCollectionValueValidator(ICollection<T> collection, string propertyName)
        {
            m_collection = collection;
            m_propertyName = propertyName;
        }


        public override void GetError()
        {
            ArrayList items = new ArrayList();                                    
            foreach (T item in m_collection)
            {
                PropertyInfo propertyInfo =
                    item.GetType().GetProperty(m_propertyName);

                object value = propertyInfo.GetValue(item, null);

                if(value != null)
                {
                    if (items.Contains(value))
                    {
                        m_error = value.ToString() + " is a duplicate.";
                        return;
                    }
                                           
                    items.Add(value);
                   
                }                
            }
        }
    }
}