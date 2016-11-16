using System;

namespace OpenParser.Subscribers
{
    public interface ISubscriber<T>
    {
        void Disable();
        void Enable();

        event EventHandler<T> Matched;
    }
}