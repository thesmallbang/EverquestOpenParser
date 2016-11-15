using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using OpenParser;
using OpenParser.EventResults;
using OpenParser.Subscribers;

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

            var allSub = new SubscriptionWrapper(_log);
            allSub.OnSay += AllSub_OnSay;
            allSub.OnTell += AllSub_OnTell;
            allSub.OnPhysicalMiss += AllSub_OnPhysicalMiss;
            allSub.OnPhsyicalHit += AllSub_OnPhsyicalHit;
            allSub.OnDeath += AllSub_OnDeath;

            Subscriptions.Add(allSub);

            if (!isWatch)
                _log.ReadChangesByLine();
        }

        private List<ISubscription> Subscriptions { get; } = new List<ISubscription>();

        private void AllSub_OnTell(object sender, Tell e)
        {
            if (showDebug)
                Debug.Print($"Tell [{e.From}] - {e.Message}");
        }

        private void AllSub_OnSay(object sender, Say e)
        {
            if (showDebug)
                Debug.Print($"Say[{e.Origin}] [{e.From}] - {e.Message}");
        }

        private void AllSub_OnDeath(object sender, Combat<EmptyInfo> e)
        {
            if (showDebug)
                Debug.Print($"Death [{e.Attacker}] killed [{e.Target}]");
        }

        private void AllSub_OnPhsyicalHit(object sender, Combat<MeleeDamageInfo> e)
        {
            if (showDebug)
                Debug.Print($"Hit [{e.Attacker}] {e.Info.DamageType} [{e.Target}] for ({e.Info.Amount})");
        }

        private void AllSub_OnPhysicalMiss(object sender, Combat<MeleeMissInfo> e)
        {
            if (showDebug)
                Debug.Print($"Miss[{e.Info.MissType}] [{e.Attacker}] tried to {e.Info.AttemptType} [{e.Target}]");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var subscription in Subscriptions)
                subscription.Disable();
        }
    }
}