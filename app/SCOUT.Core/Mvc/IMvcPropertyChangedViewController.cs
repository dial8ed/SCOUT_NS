using System;

namespace SCOUT.Core.Mvc
{
    public interface IMvcPropertyChangedEventController
    {
        void RegisterChangeRequestHandler<T>(string propertyName,
                                              EventHandler
                                                  <
                                                  PropertyChangeRequestEventArgs
                                                  <T>> handler);


        void UnRegisterChangeRequestHandler<T>(string propertyName,
                                                EventHandler
                                                    <
                                                    PropertyChangeRequestEventArgs
                                                    <T>> handler);

    }
}