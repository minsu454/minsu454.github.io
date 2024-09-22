namespace TextRPG
{
    public class Player
    {
        public int level;
        public string name;
        public int gold;

        public BaseInfo info;

        public Player(string name, BaseInfo info)
        {
            this.name = name;
            this.info = info;
        }
    }
}
