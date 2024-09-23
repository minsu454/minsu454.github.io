namespace TextRPG
{
    public class CommonArmor : BaseItem
    {
        protected override void Init()
        {
            name = "가죽 갑옷";
            defense = 5;
            explanation = "어설픈 손놀림으로 만들었지만 애착이 가는 갑옷";
            gold = 1000;
        }
    }
}