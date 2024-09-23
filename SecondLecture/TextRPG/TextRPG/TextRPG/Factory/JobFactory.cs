namespace TextRPG
{
    public static class JobFactory
    {
        /// <summary>
        /// 직업 생성자 리턴해주는 함수
        /// </summary>
        public static BaseInfo CreateInfo(JobType type)
        {
            BaseInfo job;

            switch (type)
            {
                case JobType.Warrior:
                    job = new Warrior();
                    break;
                case JobType.Assassin:
                    job = new Assassin();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"job is {type}");
            }

            return job;
        }

        /// <summary>
        /// 직업 이름 한국어로 리턴해주는 함수
        /// </summary>
        public static string JobName(JobType type)
        {
            string name;

            switch (type)
            {
                case JobType.Warrior:
                    name = "전사";
                    break;
                case JobType.Assassin:
                    name = "암살자";
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"job is {type}");
            }

            return name;
        }
    }

}
