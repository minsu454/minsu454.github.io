namespace TextRPG
{
    public static class GameManager
    {
        public static bool isRun = true;

        public static SceneManager scene = new SceneManager();

        public static Player? player;

        public static void Init()
        {
            isRun = true;
            scene.Init();
        }

        public static void Update()
        {
            scene.LoadScene();

            Console.Clear();
            Thread.Sleep(100);
        }

        public static void Destroy()
        {

        }
    }
}
