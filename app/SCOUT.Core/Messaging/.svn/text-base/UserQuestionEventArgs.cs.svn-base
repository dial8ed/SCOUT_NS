using System;

namespace SCOUT.Core.Messaging
{

    public class UserQuestionEventArgs : EventArgs
    {
        private string m_question;
        private QuestionResult m_result;
        private QuestionResult m_cancelOn;

        public UserQuestionEventArgs(string question, QuestionResult cancelOn)
        {
            m_question = question;
            m_cancelOn = cancelOn;
        }

        public string Question
        {
            get { return m_question; }            
        }

        public QuestionResult Result
        {
            get { return m_result; }            
        }

        public QuestionResult CancelOn
        {
            get { return m_cancelOn; }            
        }
    }


}