namespace TextRPG
{
    public static class GameManager
    {
        public static bool isRun = true;

        public readonly static SceneManager Scene = new SceneManager();         //씬 매니저
        public readonly static ItemManager Item = new ItemManager();            //아이템 매니저
        public readonly static DunGeonManager DunGeon = new DunGeonManager();   //던전 매니저
        public readonly static DataManager Data = new DataManager();            //데이터 매니저

        public static Player? player;

        /// <summary>
        /// 생성 함수
        /// </summary>
        public static void Init()
        {
            isRun = true;
            Scene.Init();
            Item.Init();
            DunGeon.Init();
            Data.Init();
        }

        /// <summary>
        /// 업데이트 함수
        /// </summary>
        public static void Update()
        {
            Scene.LoadScene();

            Console.Clear();
            Thread.Sleep(100);
        }

        /// <summary>
        /// 삭제 함수
        /// </summary>
        public static void Destroy()
        {

        }
    }
}
