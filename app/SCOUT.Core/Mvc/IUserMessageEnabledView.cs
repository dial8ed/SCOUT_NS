using SCOUT.Core.Messaging;

namespace SCOUT.Core.Mvc
{
    public interface IUserMessageEnabledView
    {
        /// <summary>
        /// Gets a message output host for user message to be published to.
        /// </summary>
        IUserMessageOutputHost UserMessageOutputHost { get;}
    }
}