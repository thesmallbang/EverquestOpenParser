namespace OpenParser.HandlerObjects
{
    public class MeleeMissInfo : IMissInfo
    {
        public bool HitSuccess
        {
            get { return false; }
            set { }
        }

        public string AttemptType { get; set; }
        public string MissType { get; set; }
    }
}