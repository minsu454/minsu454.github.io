namespace TextRPG
{
    public class Warrior : BaseInfo
    {
        public Warrior()
        {
            job = JobType.Warrior;

            attack = 10;
            defense = 5;
            hp = 100;

            attackLevelPoint = 2;
            defenseLevelPoint = 4;
        }   
    }
}
