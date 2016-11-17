using System;

namespace OpenParser.Subscriptions
{
    public abstract class Subscription<TEventResult> : ISubscription
    {
        protected Subscription(LogFile logFile)
        {
            LogFile = logFile;
        }

        protected Subscriber<TEventResult> Subscriber { get; set; }
        protected LogFile LogFile { get; set; }

        public virtual void Enable()
        {
            Subscriber.Enable();
        }

        public virtual void Disable()
        {
            Subscriber.Disable();
        }

        protected void Subscribe()
        {
            Subscriber.Matched += Subscriber_Matched;
        }

        public event EventHandler<TEventResult> Matched;

        protected virtual void Subscriber_Matched(object sender, TEventResult e)
        {
            Matched?.Invoke(sender, e);
        }
    }
}