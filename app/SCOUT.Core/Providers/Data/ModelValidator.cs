using SCOUT.Core.Messaging;

namespace SCOUT.Core.Data
{
    public abstract class ModelValidator<TModel> : ValidatorBase
    {       
        private TModel m_model;
        private IUserMessageOutputHost m_userMessageOutputHost;

        public ModelValidator(TModel model, MessageListener listener) : base(listener)
        {           
            m_model = model;            
        }


        public TModel Model
        {
            get { return m_model; }            
        }


        /// <summary>
        /// Returns true if the validator is valid.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {            
            return this.Validated();            
        }
    }
}