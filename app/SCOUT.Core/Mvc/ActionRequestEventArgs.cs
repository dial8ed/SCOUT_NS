using System;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{

    // SingleChoiceAction
    // MultiChoiceAction
    // SimpleAction
    public class ActionRequestEventArgs: EventArgs
    {
        private UserMessage m_message;
        private bool m_cancel;

        public ActionRequestEventArgs()
        {
        }

        public ActionRequestEventArgs(UserMessage message)
        {
            m_message = message;
        }

        public UserMessage UserMessage
        {
            get { return m_message; }
            set { m_message = value; }
        }

        public bool Cancel
        {
            get { return m_cancel; }
            set { m_cancel = value; }
        }
    }

    public class SingleChoiceActionRequestEventArgs<T> : ActionRequestEventArgs
    {
        private T m_actionItem;
        public SingleChoiceActionRequestEventArgs(T actionItem)
        {
            m_actionItem = actionItem;
        }

        public T ActionItem
        {
            get { return m_actionItem; }            
        }
    }
}