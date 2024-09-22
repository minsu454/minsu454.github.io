namespace TextRPG
{
    internal class JobFactory
    {
        public static BaseInfo CreateInfo(JobType type)
        {
            BaseInfo job;

            switch (type)
            {
                case JobType.Warrior:
                    job = new Warrior();
                    break;
                case JobType.Archer:
                    job = new Archer();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"job is {type}");
            }

            return job;
        }

        public static string JobName(JobType type)
        {
            string name;

            switch (type)
            {
                case JobType.Warrior:
                    name = "전사";
                    break;
                case JobType.Archer:
                    name = "궁수";
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"job is {type}");
            }

            return name;
        }
    }

}
