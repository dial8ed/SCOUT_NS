using System;
using System.Data;
using SCOUT.Core.Messaging;

namespace SCOUT.Core.Utils
{
    public class ExecutionHelpers
    {
        public static bool TryCatch(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                //Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                //return false;
            }
        }

        public static void ThrowIfNull(Func<object> func, string message)
        {
            var result = func();
            if(result == null)
                throw new NoNullAllowedException(message);            
        }

        public static void TryLoopOn<TException>(Action action, int attempts)
        {

            var looper = new ExecutionLoop();
            looper.TryLoopOn<TException>(action,attempts);
        }


        public static bool TryCatchMessage(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                return false;
            }
        }

        public static bool TryCatchMessage(Func<bool> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                Scout.Core.UserInteraction.Dialog.ShowMessage(ex.Message, UserMessageType.Error);
                return false;
            }
        }

        public static Exception TryCatchException(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                return ex;
            }

            return null;

        }


    }
}