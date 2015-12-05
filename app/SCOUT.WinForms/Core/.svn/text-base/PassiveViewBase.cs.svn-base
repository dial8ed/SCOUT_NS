using System.Windows.Forms;
using SCOUT.Core.Messaging;
using SCOUT.Core.Mvc;

namespace SCOUT.WinForms.Core
{
    /// <summary>
    /// Base class for a view
    /// </summary>
    public class PassiveViewBase : Form, IPassiveView                                            
    {
        private MvcEventsController m_eventsController;
   
        private IUserMessageOutputHost m_messageHost =
            new MessageBoxOutputHost();

    
        /// <summary>
        /// Constructor
        /// Default user message output host
        /// </summary>
        protected PassiveViewBase()
        {
            m_eventsController = new MvcEventsController(this);
        }


        /// <summary>
        /// Constructor
        /// Custom user message output host
        /// </summary>
        /// <param name="outputHost"></param>
        protected PassiveViewBase(IUserMessageOutputHost outputHost)
        {
            m_messageHost = outputHost;
            m_eventsController = new MvcEventsController(this);
        }

        /// <summary>
        /// Gets the EventsController used to synchonrize model and view.
        /// </summary>
        public MvcEventsController EventsController
        {
            get { return m_eventsController; }
        }

        /// <summary>
        /// Gets the <cref>UserMessageOutputHost</cref> used to display user messages
        /// </summary>
        public IUserMessageOutputHost UserMessageOutputHost
        {
            get { return m_messageHost; }
            protected set { m_messageHost = value; }
        }


        /// <summary>
        /// Shows a message box and returns a <cref>QuestionResult</cref>
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public QuestionResult AskQuestion(string question)
        {
            DialogResult result;
            result = MessageBox.Show(question, "Question",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question,
                                     MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
                return QuestionResult.Yes;

            return QuestionResult.No;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PassiveViewBase
            // 
            this.ClientSize = new System.Drawing.Size(458, 218);
            this.Name = "PassiveViewBase";
            this.ResumeLayout(false);

        }
    }
}