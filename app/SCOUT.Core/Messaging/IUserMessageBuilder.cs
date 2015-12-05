using System.Collections.Generic;

namespace SCOUT.Core.Messaging
{
    public interface IUserMessageBuilder
    {
        List<UserMessage> Contents { get; }

        /// <summary>
        /// A flattened list of messages
        /// </summary>
        string FlatContents { get; }

        /// <summary>
        /// The number of messages in the list
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Add a message to the list
        /// </summary>
        /// <param name="message">The message to add</param>
        /// <param name="type">The type of user message</param>
        void AddMessage(string message, UserMessageType type);

        string ToString();
    }
}