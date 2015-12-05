using System;
using System.Collections;
using DevExpress.Xpo.DB.Exceptions;
using SCOUT.Core.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public class PersistentModelController
    {        
        private IPersistentModel m_registeredModel;

        public event EventHandler<ActionRequestEventArgs> OnSaved;
        public event EventHandler<ActionRequestEventArgs> OnCancelled;
        private IUserQuestionEnabledView m_userQuestionView;
        public event EventHandler<LockingExceptionEventArgs> OnLockingException;

        public PersistentModelController(IUserQuestionEnabledView userQuestionView, IPersistentModel model)
        {
            m_userQuestionView = userQuestionView;
            m_registeredModel = model;
        }
       
        /// <summary>
        /// Save the changes made in the models unit of work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Save(object sender, ActionRequestEventArgs args)
        {                           
            IUnitOfWork unitOfWork = m_registeredModel.UnitOfWork;
            if(unitOfWork == null)
                throw new InvalidOperationException("The persistent model is not associated with a UnitOfWork");

            try
            {                
                   Scout.Core.Data.Save(unitOfWork);
                                                 
                    args.UserMessage = new UserMessage("Save Complete",
                                                       UserMessageType.Information);
                    
                    if(OnSaved != null)
                        OnSaved(this, args);
                
            }
            catch(LockingException exception)
            {
                if(OnLockingException != null)
                {
                    OnLockingException(this, new LockingExceptionEventArgs(unitOfWork));
                }
            }
            catch (Exception e)
            {
                throw e;
            }                               
        }              
        
 
        /// <summary>
        /// Cancels the changes made in the models unit of work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Cancel(object sender,ActionRequestEventArgs args)
        {                        
            if(VerifyCancel() == QuestionResult.No)
                return;

            IUnitOfWork unitOfWork = m_registeredModel.UnitOfWork;
          
            if (unitOfWork == null)
                throw new InvalidOperationException("The persistent model is not associated with a UnitOfWork");
                        
            if(unitOfWork.InTransaction)
                unitOfWork.RollbackTransaction();

            args.UserMessage = new UserMessage("Cancel Complete",
                                               UserMessageType.Information);
           
            if(OnCancelled != null)
                OnCancelled(this, args);

        }

        private QuestionResult VerifyCancel()
        {
            if (ModelHasChanges(m_registeredModel))
                return
                    m_userQuestionView.AskQuestion(
                        "You have un-saved changes. Are you sure you want to cancel?");
                    
            
            return QuestionResult.Yes;
        }


        private bool ModelHasChanges(IPersistentModel model)
        {
            ICollection objectsToDelete = model.UnitOfWork.GetObjectsToDelete();
            ICollection objectsToSave = model.UnitOfWork.GetObjectsToSave();
           
            return (objectsToDelete.Count > 0 || objectsToSave.Count > 0);
        }
    }
}