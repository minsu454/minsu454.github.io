namespace TextRPG
{
    public static class GameManager
    {
        public static bool isRun = true;

        public readonly static SceneManager Scene = new SceneManager();
        public readonly static ItemManager Item = new ItemManager();
        public readonly static DunGeonManager DunGeon = new DunGeonManager();
        public readonly static DataManager Data = new DataManager();

        public static Player? player;

        public static void Init()
        {
            isRun = true;
            Scene.Init();
            Item.Init();
            DunGeon.Init();
            Data.Init();
        }

        public static void Update()
        {
            Scene.LoadScene();

            Console.Clear();
            Thread.Sleep(100);
        }

        public static void Destroy()
        {

        }
    }
}
