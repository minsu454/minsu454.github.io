using System.Text;

namespace TextRPG
{
    public static class Print
    {
        public static void PrintScreen(string s)
        {
            Console.Write(s);
        }

        public static void PrintScreen(StringBuilder sb)
        {
            Console.Write(sb.ToString());
        }
    }
}
