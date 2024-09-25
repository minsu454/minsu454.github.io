namespace TextRPG
{
    public static class DunGeonFactory
    {
        /// <summary>
        /// 던전 만들어주는 함수
        /// </summary>
        public static BaseDunGeon? CreateDunGeon(DunGeonType type)
        {
            BaseDunGeon? baseDunGeon = null;
            switch (type)
            {
                case DunGeonType.Easy:
                    baseDunGeon = new EasyDunGeon();
                    break;
                case DunGeonType.Normal:
                    baseDunGeon = new NormalDunGeon();
                    break;
                case DunGeonType.Hard:
                    baseDunGeon = new HardDunGeon();
                    break;
            }

            return baseDunGeon;
        }

        /// <summary>
        /// 던전 이름 반환해주는 함수
        /// </summary>
        public static string? DungeonName(DunGeonType type)
        {
            string? name = null;

            switch (type)
            {
                case DunGeonType.Easy:
                    name = "쉬운 던전";
                    break;
                case DunGeonType.Normal:
                    name = "노말 던전";
                    break;
                case DunGeonType.Hard:
                    name = "하드 던전";
                    break;
            }

            return name;
        }
    }
}
