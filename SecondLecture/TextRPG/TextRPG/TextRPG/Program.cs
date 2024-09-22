namespace TextRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameManager.Init();

            while (GameManager.isRun)
            {
                GameManager.Update();
            }

            GameManager.Destroy();
        }
    }
}
