namespace TextRPG
{
    public class CommonSword : BaseItem
    {
        protected override void Init()
        {
            name = "나무 검";
            attack = 2;
            explanation = "길을 걷다 주운 나무로 만든 생각보다 튼튼한 검";
            gold = 600;
        }
    }
}
