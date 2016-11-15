using System;

namespace OpenParser
{
    public interface ISubscriber<T>
    {
        void Disable();
        void Enable();

        event EventHandler<T> Received;
    }
}