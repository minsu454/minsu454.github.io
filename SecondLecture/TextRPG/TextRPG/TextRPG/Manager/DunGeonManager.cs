namespace TextRPG
{
    public class DunGeonManager
    {
        private readonly Dictionary<DunGeonType, BaseDunGeon> dunGeonDic = new Dictionary<DunGeonType, BaseDunGeon> ();     //모든 씬들 저장해주는 Dictionary

        public void Init()
        {
            foreach (DunGeonType type in Enum.GetValues(typeof(DunGeonType)))
            {
                BaseDunGeon? dunGeon = DunGeonFactory.CreateDunGeon(type);

                if (dunGeon == null)
                    continue;

                dunGeon.name = DunGeonFactory.DungeonName(type)!;
                dunGeonDic.Add(type, dunGeon);
            }
        }

        public BaseDunGeon GetDunGeon(DunGeonType type)
        {
            return dunGeonDic[type];
        }

        /// <summary>
        /// 던전에서 스텟변화 받아오는 함수
        /// </summary>
        public void InDunGeon(DunGeonType type, out bool isClear, out int minusHp, out int clearGold, out int exp)
        {
            Player player = GameManager.player!;
            BaseDunGeon dungeon = dunGeonDic[type];

            Random rand = new Random();
            isClear = true;

            exp = 0;
            clearGold = 0;

            if (player.info.TotalDefense < dungeon.recommendDefense)
            {
                int n = rand.Next(0, 10);
                if (n < 4)
                {
                    isClear = false;
                    minusHp = player.info.maxHp / 2;
                    clearGold = 0;
                    return;
                }
            }

            int minMinusHp = 20 + dungeon.recommendDefense - player.info.TotalDefense;
            int maxMinusHp = 35 + dungeon.recommendDefense - player.info.TotalDefense + 1;
            minusHp = rand.Next(minMinusHp, maxMinusHp);

            clearGold += dungeon.clearGold;
            clearGold += (dungeon.clearGold * rand.Next(player.info.TotalAttack, player.info.TotalAttack * 2 + 1) / 100);

            exp = dungeon.clearExp;
        }
    }
}
