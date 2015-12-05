using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Xpo;
using SCOUT.Core.Data;
using SCOUT.Core.Services;


namespace SCOUT.Core.Mvc
{
    public class BomConfigurationModel : PersistentModel, INotifyPropertyChanged
    {
        private BomMaster m_bomMaster;
        private BomConfiguration m_configuration;
        private ICollection<PartModel> m_partModels;
        private ICollection<Shopfloorline> m_shopfloorlines;        
        private Shopfloorline m_shopfloorline;
        private RouteStation m_routeStation;
        private string m_name;
        private ICollection<RouteStation> m_routeStations;

        private event PropertyChangedEventHandler m_propertyChanged;
        
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { m_propertyChanged += value; }
            remove { m_propertyChanged -= value; }
        }

        public BomConfigurationModel(BomConfiguration configuration) : base(configuration.Session)
        { 
            Configuration = configuration;            
            LoadLists();
        }

        private void LoadLists()
        {
            m_partModels = PartRepository.GetAllPartModels(UnitOfWork);
            m_shopfloorlines = AreaRepository.GetAllShopfloorlines(UnitOfWork);

            m_routeStations = Scout.Core.Service<IShopfloorService>()
                .GetAllRouteStations(UnitOfWork);
        }


        public BomMaster BomMaster
        {
            get { return m_bomMaster; }
            set
            {
                m_bomMaster = value;
                RaisePropertyChanged("BomMaster");
            }
        }

        public BomConfiguration Configuration
        {
            get { return m_configuration; }
            set
            {
                m_configuration = value;
                BomMaster = m_configuration.PartModel.BomMaster;
            }
        }


        public ICollection<Shopfloorline> Shopfloorlines
        {
            get { return m_shopfloorlines; }            
        }

        public ICollection<RouteStation> RouteStations
        {
            get { return m_routeStations; }            
        }

        public Shopfloorline Shopfloorline
        {
            get { return m_configuration.Shopfloorline; }
            set { m_configuration.Shopfloorline = value; }
        }

        public string Description
        {
            get { return m_configuration.Description; }
            set { m_configuration.Description = value; }
        }


        public PartModel PartModel
        {
            get { return m_configuration.PartModel; }
            set
            {               
                m_configuration.PartModel = value;
                
                if (m_configuration.PartModel != null)
                    BomMaster = m_configuration.PartModel.BomMaster;

            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (null != m_propertyChanged)
                m_propertyChanged(this,
                                  new PropertyChangedEventArgs(propertyName));
        }


        public void AddConfigurationItem(BomMasterComponent component)
        {
            BomConfigurationItem item = Scout.Core.Data.CreateEntity<BomConfigurationItem>(UnitOfWork);
            item.BomComponent = component;
            item.BomConfiguration = m_configuration;
            item.UsageAction = BomUsageAction.Install;

            m_configuration.ConfigurationItems.Add(item);
           
        }


        public bool ContainsConfigurationForPart(Part part)
        {
            foreach (BomConfigurationItem item in m_configuration.ConfigurationItems)
            {
                if(item.BomComponent.Part.Equals(part))
                    return true;
            }

            return false;
        }


        public void RemoveConfigurationItem(BomConfigurationItem item)
        {
            if (m_configuration.ConfigurationItems.DeleteObjectOnRemove == false)
                m_configuration.ConfigurationItems.DeleteObjectOnRemove = true;

            m_configuration.ConfigurationItems.Remove(item);
        }
    }
}