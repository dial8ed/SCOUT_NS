using System;
using System.Collections.Generic;

namespace SCOUT.Core.Messaging
{
    // Base class for a message listener
    public class MessageListener : IDisposable
    {
        private List<IUserMessageGenerator> m_generators;
        private IUserMessageOutputHost m_outputHost;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outputHost">The output host the will process the message.</param>
        public MessageListener(IUserMessageOutputHost outputHost)
        {
            m_outputHost = outputHost;
            m_generators = new List<IUserMessageGenerator>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outputHost">The output host the will process the message.</param>
        /// <param name="provider">The provider of the message to be processed</param>
        public MessageListener(IUserMessageOutputHost outputHost, IUserMessageGenerator generator) 
            : this(outputHost)
        {
            AddProvider(generator);
        }

        /// <summary>
        /// Adds a message provider to the listener and hooks up the MessageRaised event.
        /// </summary>
        /// <param name="provider"></param>
        public void AddProvider(IUserMessageGenerator provider)
        {
            if (m_generators.Contains(provider))
                return;

            m_generators.Add(provider);
            provider.MessageRaised += provider_MessageRaised;
        }

        /// <summary>
        /// Tells the output host to process the message 
        /// when a provider raises a message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void provider_MessageRaised(object sender, UserMessageEventArgs e)
        {
            m_outputHost.ProcessMessage(e);            
        }

        /// <summary>
        /// Clears the message providers.
        /// </summary>
        public void ClearProviders()
        {
            foreach (IUserMessageGenerator generator in m_generators)
            {
                generator.MessageRaised -= provider_MessageRaised;
            }

            m_generators.Clear();
        }


        public void Dispose()
        {
            ClearProviders();
        }
    }
}