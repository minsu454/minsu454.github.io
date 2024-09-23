namespace TextRPG
{
    public class EpicArmor : BaseItem
    {
        protected override void Init()
        {
            name = "철 갑옷";
            defense = 15;
            explanation = "대장장이가 대충 만든 갑옷";
            gold = 3500;
        }
    }
}