using System;
using System.Collections.Generic;
using System.ComponentModel;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public class BomMasterModel : PersistentModel, INotifyPropertyChanged
    {
        private PartModel m_partModel;
        private BomMaster m_bomMaster;
        private event PropertyChangedEventHandler m_propertyChanged;
        private IUnitOfWork m_configurationUow;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { m_propertyChanged += value; }
            remove { m_propertyChanged -= value; }
        }


        public BomMasterModel()
        {
        }


        public BomMasterModel(int partModelId)
            : base(Scout.Core.Data.GetUnitOfWork())
        {
            PartModel = PartRepository.GetPartModelById(UnitOfWork, partModelId);
        }


        public BomMasterModel(IUnitOfWork uow) : base(uow)
        {
        }


        public BomMaster BomMaster
        {
            get { return m_bomMaster; }
            private set
            {
                m_bomMaster = value;
                RaisePropertyChanged("BomMaster");
            }
        }


        private void RaisePropertyChanged(string propertyName)
        {
            if (null != m_propertyChanged)
                m_propertyChanged(this,
                                  new PropertyChangedEventArgs(propertyName));
        }


        public ICollection<BomComponentCategory> BomComponentCategories
        {
            get
            {
                return m_bomMaster == null
                           ? null
                           : m_bomMaster.ComponentCategories;
            }
        }

        public ICollection<BomMasterComponent> BomMasterComponents
        {
            get { return m_bomMaster == null ? null : m_bomMaster.Components; }
        }


        public ICollection<BomConfiguration> BomConfigurations
        {
            get
            {
                return PartRepository.GetBomConfigurationsByModel(UnitOfWork,
                                                                  PartModel);
            }
                      
        }

        public PartModel PartModel
        {
            set
            {
                m_partModel = value;
                if (m_partModel != null)
                {
                    // Set Bom Master
                    BomMaster = m_partModel.BomMaster;
                }

                RaisePropertyChanged("PartModel");
            }

            get { return m_partModel; }
        }


        public void NewBomMaster(object sender, ActionRequestEventArgs e)
        {
            PartModel.BomMaster = Scout.Core.Data.CreateEntity<BomMaster>(UnitOfWork);
            BomMaster = PartModel.BomMaster;
            e.UserMessage = new UserMessage("Bom Master created.",
                                            UserMessageType.Information);
        }


        /// <summary>
        /// Creates a new BomConfiguration with its own independent UnitOfWork
        /// </summary>
        /// <returns></returns>
        public BomConfiguration NewBomConfiguration()
        {
            m_configurationUow = Scout.Core.Data.GetUnitOfWork();

            BomConfiguration configuration =
                Scout.Core.Data.CreateEntity<BomConfiguration>(m_configurationUow);

            // Get the part model under the new unit of work.
            PartModel model = PartRepository.GetPartModelById(m_configurationUow,PartModel.Id);

            configuration.PartModel = model;

            return configuration;            
        }


        public BomConfiguration GetBomConfiguration(int id)
        {
            m_configurationUow = Scout.Core.Data.GetUnitOfWork();
            return PartRepository.GetBomConfigurationById(m_configurationUow, id);
        }


        public void DeleteBomConfiguration(BomConfiguration configuration)
        {
            Scout.Core.Data.Delete(UnitOfWork, configuration, false);

           configuration.Delete();
        }
    }
}