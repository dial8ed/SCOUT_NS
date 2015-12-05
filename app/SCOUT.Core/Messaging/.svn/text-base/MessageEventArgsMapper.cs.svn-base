using System;

namespace SCOUT.Core.Messaging
{
    public class MessageEventArgsMapper : IMapper<UserMessageEventArgs, UserMessage>
    {
        public UserMessage MapFrom(UserMessageEventArgs input)
        {
            UserMessage message = new UserMessage(input.Message, input.Type);
            return message;
        }
    }
}