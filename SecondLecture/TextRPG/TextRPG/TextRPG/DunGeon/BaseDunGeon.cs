namespace TextRPG
{
    public class BaseDunGeon
    {
        public string? name;
        public int recommendDefense;
        public int clearGold;

        public BaseDunGeon() { Init(); }

        public virtual void Init() { }
    }
}
