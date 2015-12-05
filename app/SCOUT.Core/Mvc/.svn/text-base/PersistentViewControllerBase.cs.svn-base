using System;
using SCOUT.Core.Data;

namespace SCOUT.Core.Mvc
{
    public abstract class PersistentViewControllerBase<TModel, TView> :
        ViewControllerBase<TModel, TView> where TView : IPassiveView
                                         where TModel : IPersistentModel
    {
        private PersistentModelController m_persistentController;
        private event EventHandler<ActionRequestEventArgs> m_persistenceSave;

        public event EventHandler<ActionRequestEventArgs> PersistenceSave
        {
            add { m_persistenceSave += value;}
            remove { m_persistenceSave -= value;}
        }


        protected override void Initialize(TModel model, TView view)
        {
            base.Initialize(model,view);
            m_persistentController = new PersistentModelController(view, model);
            WirePersistentControllerEvents();            
        }


        protected PersistentModelController PersistentController
        {
            get { return m_persistentController; }            
        }


        /// <summary>
        /// Hookup the persistence event handlers
        /// </summary>
        private void WirePersistentControllerEvents()
        {
            m_persistentController.OnSaved += PersistentController_OnSaved;
            m_persistentController.OnCancelled +=
                PersistentController_OnAction;
        }


        private void PersistentController_OnSaved(object sender, ActionRequestEventArgs e)
        {
            if (m_persistenceSave != null)
                m_persistenceSave(sender, e);

            PersistentController_OnAction(sender, e);
        }


        /// <summary>
        /// Hook to close the view upon <cref>PersistentController</cref> Save or Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PersistentController_OnAction(object sender,
                                                        EventArgs e)
        {
            View.Close();
        }


        /// <summary>
        /// Executes Cancel on the <cref>PersistentController</cref>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void View_Cancel(object sender, ActionRequestEventArgs e)
        {
            m_actionService.RunAction(this, m_persistentController.Cancel);
        }


        /// <summary>
        /// Executes Save on the <cref>PersistentController</cref>
        /// </summary>
        /// <typeparam name="TValidator"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="validator"></param>
        protected void View_Save<TModel>(object sender,
                                                     ActionRequestEventArgs e,
                                                     ModelValidator
                                                         < TModel>
                                                         validator)            
        {
            m_actionService.RunAction(this, validator,
                                         m_persistentController.Save);
        }


        protected void View_Save(object sender, ActionRequestEventArgs e)
        {            
            if(e.Cancel)
                return;

            m_actionService.RunAction(this, m_persistentController.Save);
        }

        protected void View_Save()
        {
            m_actionService.RunAction(this, m_persistentController.Save);
        }

    }
} 