using System.Collections;
using DevExpress.Xpo;

namespace SCOUT.Core.Data
{
    public class AreaStatusList : XPCollection<AreaStatus>, ISubject
    {
        private ArrayList observers;
        private static AreaStatusList m_areaStatusList;

        public static AreaStatusList Current
        {
            get
            {
                if (m_areaStatusList == null)
                {
                    m_areaStatusList = new AreaStatusList() ;
                }

                return m_areaStatusList;
            }
        }
      
        private AreaStatusList()
        {
            observers = new ArrayList();
            this.ListChanged += AreaStatusList_ListChanged;
        }
      
        void AreaStatusList_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void UnregisterObserver(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }
    }
}