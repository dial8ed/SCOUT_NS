using System;
using SCOUT.WinForms.Core.WinApi;

namespace System.Threading
{
    /// <summary>
	/// Summary description for Signal.
	/// </summary>
    public sealed class NamedEvent : System.Threading.WaitHandle
    {
        private bool m_autoReset = false;
        private string m_name = "";

        private void CreateEvent(bool initState)
        {
            SafeWaitHandle = Call.CreateEvent(IntPtr.Zero,
                !m_autoReset, initState, m_name);

            if (SafeWaitHandle.IsInvalid)
                throw new Exception("Unable to create handle for event.");
        }

        public NamedEvent(string name)
        {
            m_name = name;
            CreateEvent(false);
        }

        public NamedEvent(string name, bool AutoReset)
        {
            m_name = name;
            m_autoReset = AutoReset;
            CreateEvent(false);
        }

        public NamedEvent(string name, bool AutoReset, bool InitialState)
        {
            m_name = name;
            m_autoReset = AutoReset;
            CreateEvent(InitialState);
        }

        public bool AutoReset { get { return m_autoReset; } }

        public bool Set()
        {
            return Call.SetEvent(SafeWaitHandle);
        }

        public bool Reset()
        {
            return Call.ResetEvent(SafeWaitHandle);
        }
    }
}
