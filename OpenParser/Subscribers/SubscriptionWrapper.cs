using System;
using System.Collections.Generic;
using OpenParser.EventResults;
using OpenParser.EventResults.Chat;
using OpenParser.EventResults.Combat;
using OpenParser.Subscribers.Chat;
using OpenParser.Subscribers.Melee;

namespace OpenParser.Subscribers
{
    public class SubscriptionWrapper : ISubscription
    {
        /// <summary>
        ///     Wrapper for using all the prebuilt subscriptions. Not recommended for performance but makes the library easier to
        ///     use for some quick testing.
        /// </summary>
        /// <param name="logFile"></param>
        public SubscriptionWrapper(LogFile logFile)
        {
            var tellSubscription = new TellSubscription(logFile);
            tellSubscription.Matched += TellSubscription_Matched;
            Subscriptions.Add(tellSubscription);

            var saySubscription = new SaySubscription(logFile);
            saySubscription.Matched += SaySubscription_Matched;
            Subscriptions.Add(saySubscription);

            var shoutSubscription = new ShoutSubscription(logFile);
            shoutSubscription.Matched += ShoutSubscription_Matched;
            Subscriptions.Add(shoutSubscription);

            var oocSubscription = new OocSubscription(logFile);
            oocSubscription.Matched += OocSubscription_Matched;
            Subscriptions.Add(oocSubscription);

            var groupChatSubscription = new GroupChatSubscription(logFile);
            groupChatSubscription.Matched += GroupChatSubscription_Matched;
            Subscriptions.Add(groupChatSubscription);

            var guildChatSubscription = new GuildChatSubscription(logFile);
            guildChatSubscription.Matched += GuildChatSubscription_Matched;
            Subscriptions.Add(guildChatSubscription);

            var channelSubscription = new ChannelSubscription(logFile);
            channelSubscription.Matched += ChannelSubscription_Matched;
            Subscriptions.Add(channelSubscription);

            var factionSubscription = new FactionSubscription(logFile);
            factionSubscription.Matched += FactionSubscription_Matched;
            Subscriptions.Add(factionSubscription);

            var physicalHitSubscription = new PhysicalHitSubscription(logFile);
            physicalHitSubscription.Matched += PhysicalHitSubscription_Matched;
            Subscriptions.Add(physicalHitSubscription);

            var physicalMissSubscription = new PhysicalMissSubscription(logFile);
            physicalMissSubscription.Matched += PhysicalMissSubscription_Matched;


            //add death sub last to make sure it comes after combat subscriptions for most common use cases
            var deathSubscription = new DeathSubscription(logFile);
            deathSubscription.Matched += DeathSubscription_Matched;
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

        private void TellSubscription_Matched(object sender, Tell e)
        {
            OnTell?.Invoke(sender, e);
        }

        public event EventHandler<Say> OnSay;

        private void SaySubscription_Matched(object sender, Say e)
        {
            OnSay?.Invoke(sender, e);
        }

        public event EventHandler<ChatMessage> OnShout;

        private void ShoutSubscription_Matched(object sender, ChatMessage e)
        {
            OnShout?.Invoke(sender, e);
        }

        public event EventHandler<ChatMessage> OnOoc;

        private void OocSubscription_Matched(object sender, ChatMessage e)
        {
            OnOoc?.Invoke(sender, e);
        }

        public event EventHandler<ChatMessage> OnGroupChat;

        private void GroupChatSubscription_Matched(object sender, ChatMessage e)
        {
            OnGroupChat?.Invoke(sender, e);
        }

        public event EventHandler<ChatMessage> OnGuildChat;

        private void GuildChatSubscription_Matched(object sender, ChatMessage e)
        {
            OnGuildChat?.Invoke(sender, e);
        }

        public event EventHandler<ChannelMessage> OnChannelMessage;

        private void ChannelSubscription_Matched(object sender, ChannelMessage e)
        {
            OnChannelMessage?.Invoke(sender, e);
        }

        public event EventHandler<Faction> OnFaction;

        private void FactionSubscription_Matched(object sender, Faction e)
        {
            OnFaction?.Invoke(sender, e);
        }


        public event EventHandler<Combat<MeleeDamageInfo>> OnPhsyicalHit;

        private void PhysicalHitSubscription_Matched(object sender, Combat<MeleeDamageInfo> e)
        {
            OnPhsyicalHit?.Invoke(sender, e);
        }

        public event EventHandler<Combat<MeleeMissInfo>> OnPhysicalMiss;

        private void PhysicalMissSubscription_Matched(object sender, Combat<MeleeMissInfo> e)
        {
            OnPhysicalMiss?.Invoke(sender, e);
        }

        public event EventHandler<Combat<EmptyInfo>> OnDeath;

        private void DeathSubscription_Matched(object sender, Combat<EmptyInfo> e)
        {
            OnDeath?.Invoke(sender, e);
        }
    }
}