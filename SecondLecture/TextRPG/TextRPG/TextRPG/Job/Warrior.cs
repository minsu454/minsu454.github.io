namespace TextRPG
{
    public class Warrior : BaseInfo
    {
        protected override void Init()
        {
            base.Init();

            job = JobType.Warrior;

            attack = 10;
            defense = 5;
            maxHp = curHp = 100;

            levelAttackPoint = 2;
            levelDefensePoint = 4;
        }
    }
}
