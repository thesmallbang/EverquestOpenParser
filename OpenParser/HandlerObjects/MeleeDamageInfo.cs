namespace OpenParser.HandlerObjects
{
    public class MeleeDamageInfo : IDamageInfo
    {
        public string DamageType { get; set; }

        public bool IsCritical { get; set; }
        public long Amount { get; set; }

        public bool HitSuccess
        {
            get { return true; }
            set { }
        }
    }
}