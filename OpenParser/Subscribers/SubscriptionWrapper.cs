using System;
using System.Collections.Generic;
using OpenParser.EventResults;

namespace OpenParser.Subscribers
{
    public class SubscriptionWrapper : ISubscription
    {
        /// <summary>
        ///     Wrapper for using all the prebuilt subscriptions. Not recommended for performance but makes the library easier to
        ///     use for some.
        /// </summary>
        /// <param name="logFile"></param>
        public SubscriptionWrapper(LogFile logFile)
        {
            var tellSubscription = new TellSubscription(logFile);
            tellSubscription.TellReceived += TellSubscription_TellReceived;
            Subscriptions.Add(tellSubscription);

            var saySubscription = new SaySubscription(logFile);
            saySubscription.SayReceived += SaySubscription_SayReceived;
            Subscriptions.Add(saySubscription);

            var physicalHitSubscription = new PhysicalHitSubscription(logFile);
            physicalHitSubscription.HitReceived += PhysicalHitSubscription_HitReceived;
            Subscriptions.Add(physicalHitSubscription);

            var physicalMissSubscription = new PhysicalMissSubscription(logFile);
            physicalMissSubscription.MissReceived += PhysicalMissSubscription_MissReceived;

            //add death sub last to make sure it comes after combat subscriptions for most common use cases
            var deathSubscription = new DeathSubscription(logFile);
            deathSubscription.DeathReceived += DeathSubscription_DeathReceived;
            Subscriptions.Add(deathSubscription);
        }


        private List<ISubscription> Subscriptions { get; } = new List<ISubscription>();

        public void Enable()
        {
            foreach (var subscription in Subscriptions)
                subscription.Enable();
        }

        public void Disable()
        {
            foreach (var subscription in Subscriptions)
                subscription.Disable();
        }

        public event EventHandler<Tell> OnTell;

        private void TellSubscription_TellReceived(object sender, Tell e)
        {
            OnTell?.Invoke(sender, e);
        }

        public event EventHandler<Say> OnSay;

        private void SaySubscription_SayReceived(object sender, Say e)
        {
            OnSay?.Invoke(sender, e);
        }

        public event EventHandler<Combat<MeleeDamageInfo>> OnPhsyicalHit;

        private void PhysicalHitSubscription_HitReceived(object sender, Combat<MeleeDamageInfo> e)
        {
            OnPhsyicalHit?.Invoke(sender, e);
        }

        public event EventHandler<Combat<MeleeMissInfo>> OnPhysicalMiss;

        private void PhysicalMissSubscription_MissReceived(object sender, Combat<MeleeMissInfo> e)
        {
            OnPhysicalMiss?.Invoke(sender, e);
        }

        public event EventHandler<Combat<EmptyInfo>> OnDeath;

        private void DeathSubscription_DeathReceived(object sender, Combat<EmptyInfo> e)
        {
            OnDeath?.Invoke(sender, e);
        }
    }
}