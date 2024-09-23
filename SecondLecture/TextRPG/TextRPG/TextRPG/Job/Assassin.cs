namespace TextRPG
{
    public class Assassin : BaseInfo
    {
        protected override void Init()
        {
            base.Init();

            job = JobType.Assassin;

            attack = 15;
            defense = 3;
            maxHp = curHp = 100;

            levelAttackPoint = 4;
            levelDefensePoint = 2;
        }
    }
}
