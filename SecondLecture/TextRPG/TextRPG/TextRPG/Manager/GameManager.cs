namespace TextRPG
{
    public static class GameManager
    {
        public static bool isRun = true;

        public static SceneManager Scene = new SceneManager();
        public static ItemManager Item = new ItemManager();
        public static DunGeonManager DunGeon = new DunGeonManager();

        public static Player? player;

        public static void Init()
        {
            isRun = true;
            Scene.Init();
            Item.Init();
            DunGeon.Init();
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
