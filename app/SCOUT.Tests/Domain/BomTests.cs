using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using NUnit.Framework;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;
using SCOUT.Core.Mvc;


namespace SCOUT.Tests.Domain
{
    //[TestFixture]
    public class BomMasterMvcTests
    {
           
        public void view_fires_event_which_creates_new_bom_master_in_model()
        {
            IBomMasterView view = new BomMasterViewStub();
          
            BomMasterModel model = new BomMasterModel(Xpo.UnitOfWork());
           
            BomMasterController controller = new BomMasterController(model,view);
          
            PartModel partModel = new PartModel(Xpo.UnitOfWork());
            model.PartModel = partModel;

            Assert.IsTrue(model.BomMaster == null);

            view.EventsController.ActionRequestEvents.Fire(this,
                                                              "new_bom_master");

            Assert.IsTrue(model.BomMaster != null);
        }
     
        public void view_fires_event_which_calls_save_on_persistent_model()
        {
                                    
            IBomMasterView view = new BomMasterViewStub();          
            BomMasterModel model = new BomMasterModel(Xpo.UnitOfWork());           
            BomMasterController controller = new BomMasterController(model,view);
          
            PartModel partModel = new PartModel(Xpo.UnitOfWork());
            model.PartModel = partModel;

            view.EventsController.ActionRequestEvents.Fire(this,"save");

                        
        }

        [TearDown]
        public void TearDown()
        {
            Xpo.Destroy();
        }

        private class BomMasterViewStub : IBomMasterView
        {
            private PartModel m_model;
            private XPCollection<PartModel> m_partModels;
            private MvcEventsController m_eventsController;
            private ICollection<BomComponentCategory> m_bomComponentCategories;
            private ICollection<BomMasterComponent> m_bomMasterComponents;
            private ICollection<BomConfiguration> m_bomConfigurations;
            
            public BomMasterViewStub()
            {
                m_eventsController = new MvcEventsController(this);
            }

            public void Fire(string action)
            {
                m_eventsController.ActionRequestEvents.Fire(this, action);
            }

            public PartModel PartModel
            {
                get { return m_model; }
                set { m_model = value; }
            }

            public XPCollection<PartModel> PartModels
            {
                get { return m_partModels; }
                set { m_partModels = value; }
            }

            public MvcEventsController MvcEventsController
            {
                get { return m_eventsController; }                
            }

            public ICollection<BomComponentCategory> BomComponentCategories
            {
                get { return m_bomComponentCategories; }
                set { m_bomComponentCategories = value; }
            }

            public ICollection<BomMasterComponent> BomMasterComponents
            {
                get { return m_bomMasterComponents; }
                set { m_bomMasterComponents = value; }
            }

            public ICollection<BomConfiguration> BomConfigurations
            {
                get { return m_bomConfigurations; }
                set { m_bomConfigurations = value; }
            }

            public void ManageConfiguration(BomConfiguration configuration)
            {
                throw new NotImplementedException();
            }


            public event EventHandler<SingleChoiceActionRequestEventArgs<BomConfiguration>> EditBomConfiguration;
            public event EventHandler<SingleChoiceActionRequestEventArgs<BomConfiguration>> DeleteBomConfiguration;

            public IUserMessageOutputHost UserMessageOutputHost
            {
                get { return new BlackHoleOutputHost(); }
            }

            public QuestionResult AskQuestion(string question)
            {
                throw new NotImplementedException();
            }


            public MvcEventsController EventsController
            {
                get { throw new NotImplementedException(); }
            }

            public void Close()
            {
                throw new NotImplementedException();
            }
        }
    }
}