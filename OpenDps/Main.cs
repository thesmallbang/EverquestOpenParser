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
        private const bool isWatch = false;
        private readonly LogFile _log;

        public Main()
        {
            InitializeComponent();


            _log = new LogFile(@"D:\Daybreak Game Company\Installed Games\EverQuest\Logs\eqlog_Jackaz_phinigel.txt",
                isWatch, !isWatch);

            var deathSub = new DeathSubscription(_log);
            deathSub.DeathReceived += DeathSub_DeathReceived;

            Subscriptions.Add(deathSub);
            if (!isWatch)
                _log.ReadChanges();
        }

        private List<ISubscription> Subscriptions { get; } = new List<ISubscription>();

        private void DeathSub_DeathReceived(object sender, Combat<EmptyInfo> e)
        {
            if (showDebug)
                Debug.Print($"Death [{e.Attacker}] killed [{e.Target}]");
        }

        private void HitSubscription_HitReceived(object sender, Combat<MeleeDamageInfo> e)
        {
            if (showDebug)
                Debug.Print($"Hit [{e.Attacker}] {e.Info.DamageType} [{e.Target}] for ({e.Info.Amount})");
        }

        private void SaySubscription_SayReceived(object sender, Say e)
        {
            if (showDebug)
                Debug.Print($"Say[{e.Origin}] [{e.From}] - {e.Message}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var subscription in Subscriptions)
                subscription.Disable();
        }
    }
}