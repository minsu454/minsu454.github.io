namespace TextRPG
{
    public struct ItemLanguage
    {
        public string name;
        public string explanation;
        public string stats;
        public string gold;

        public ItemLanguage(string name, string explanation, string stats, string gold)
        {
            this.name = name;
            this.explanation = explanation;
            this.stats = stats;
            this.gold = gold;
        }
    }
}
