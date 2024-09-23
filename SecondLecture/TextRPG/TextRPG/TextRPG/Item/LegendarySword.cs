namespace TextRPG
{
    public class LegendarySword : BaseItem
    {
        protected override void Init()
        {
            name = "마 검";
            attack = 50;
            explanation = "출처를 모르지만 세계에 몇 개 없는 마검";
            gold = 10000;
        }
    }
}