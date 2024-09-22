namespace TextRPG
{
    public class Archer : BaseInfo
    {
        public Archer()
        {
            job = JobType.Archer;

            attack = 15;
            defense = 3;
            hp = 100;

            attackLevelPoint = 4;
            defenseLevelPoint = 2;
        }
    }
}
