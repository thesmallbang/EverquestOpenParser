using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using OpenParser;
using OpenParser.HandlerObjects;
using OpenParser.HandlerObjects.Converters;
using OpenParser.Subscribers;
using OpenParser.Subscribers.Strategies.Combat;
using OpenParser.Subscribers.Strategies.Say;

namespace OpenDps
{
    public partial class Main : Form
    {
        private const bool showDebug = true;
        private const bool isWatch = true;
        private readonly LogFile _log;

        public Main()
        {
            InitializeComponent();


            _log = new LogFile(@"D:\Daybreak Game Company\Installed Games\EverQuest\Logs\eqlog_Jackaz_phinigel.txt",
                isWatch, !isWatch);

            var tellSubscription = new TellSubscription(_log);
            tellSubscription.Received += TellSubscription_Received;

            var saySubscription = new SaySubscription(_log, new SayAllStrategy());
            saySubscription.Received += SaySubscription_Received;


            var hitSubscription = new CombatSubscription(_log, new MeleeHitStrategy());
            hitSubscription.Received += MeleeCombatHitSubscription_Received;

            var missSubscription = new CombatSubscription(_log, new MeleeMissStrategy());
            missSubscription.Received += MeleeCombatMissSubscription_Received;

            var deathSubscription = new CombatSubscription(_log, new DeathStrategy());
            deathSubscription.Received += DeathSubscription_Received;


            Subscriptions.Add(tellSubscription);
            Subscriptions.Add(saySubscription);
            Subscriptions.Add(deathSubscription);
            Subscriptions.Add(hitSubscription);
            Subscriptions.Add(missSubscription);


            if (!isWatch)
                _log.ReadChanges();
        }

        private List<ISubscription> Subscriptions { get; } = new List<ISubscription>();

        private void DeathSubscription_Received(object sender, Combat e)
        {
            if (!showDebug)
                return;

            var info = e.Info.AsInfo<DeathInfo>();
            Debug.Print(
                $"Combat '{e.Attacker}' killed '{e.Target}'");
        }

        private void MeleeCombatHitSubscription_Received(object sender, Combat e)
        {
            if (!showDebug)
                return;

            var info = e.Info.AsInfo<MeleeDamageInfo>();
            Debug.Print(
                $"Combat '{e.Attacker}' {info.DamageType} '{e.Target}' for {info.Amount}");
        }

        private void MeleeCombatMissSubscription_Received(object sender, Combat e)
        {
            if (!showDebug)
                return;

            var info = e.Info.AsInfo<MeleeMissInfo>();
            Debug.Print(
                $"Combat '{e.Attacker}' missed[{info.MissType}] '{e.Target}'");
        }


        private void SaySubscription_Received(object sender, Say e)
        {
            if (showDebug)
                Debug.Print($"Say [{e.Origin}] from {e.From} : {e.Message}");
        }

        private void TellSubscription_Received(object sender, Tell e)
        {
            if (showDebug)
                Debug.Print($"Tell from {e.From} : {e.Message}");
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}