using System;
using SCOUT.WinForms.Inventory;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class ToteCreateDomainCommand : Command, IOutputCommand<Tote>
    {
        private Tote m_tote;
        private ToteCreateCommandArguments m_arguments;

        public ToteCreateDomainCommand(ToteCreateCommandArguments arguments)
            : base(arguments.Arguments)
        {
            m_arguments = arguments;
        }

        public override void Execute()
        {
            m_tote = Scout.Core.Data.CreateEntity<Tote>(m_arguments.UnitOfWork);
            m_tote.Label = "<new>";
            m_tote.ToteType = m_arguments.ToteType;

            ViewLoader.Instance()
                .CreateFormWithArgs<ToteDetailView>(false, m_tote);
        }

        public Tote Output
        {
            get
            {
                if(m_tote.Fit("Id > 0"))
                    return m_tote;
                
                return null;                
            }
        }
    }
}