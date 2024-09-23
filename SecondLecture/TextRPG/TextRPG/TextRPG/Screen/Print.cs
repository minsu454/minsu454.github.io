using System.Text;

namespace TextRPG
{
    public static class Print
    {
        /// <summary>
        /// 스크린에 띄워주는 함수
        /// </summary>
        public static void PrintScreen(string s)
        {
            Console.Write(s);
        }

        /// <summary>
        /// 스크린에 띄워주는 함수
        /// </summary>
        public static void PrintScreen(StringBuilder sb)
        {
            Console.Write(sb.ToString());
        }

        /// <summary>
        /// 스크린에 띄워주고 잠시 멈춰주는 함수
        /// </summary>
        public static void PrintScreenAndSleep(string s)
        {
            Console.Write(s);
            Thread.Sleep(500);
        }

        /// <summary>
        /// 스크린에 띄워주고 잠시 멈춰주는 함수
        /// </summary>
        public static void PrintScreenAndSleep(StringBuilder sb)
        {
            Console.Write(sb.ToString());
            Thread.Sleep(500);
        }
    }
}
