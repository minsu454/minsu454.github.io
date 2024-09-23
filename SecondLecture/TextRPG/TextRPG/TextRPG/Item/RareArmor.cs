namespace TextRPG
{
    public class RareArmor : BaseItem
    {
        protected override void Init()
        {
            name = "사슬 갑옷";
            defense = 9;
            explanation = "조금 더 나은 손길로 만든 사슬 갑옷";
            gold = 2000;
        }
    }
}