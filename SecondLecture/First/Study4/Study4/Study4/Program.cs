namespace Study4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10;
            object obj = num1; // 박싱
            int num2 = (int)obj; // 언박싱
            num1 = 20;
            Console.WriteLine("num1: " + num1); // 출력 결과: 10
            Console.WriteLine("num2: " + num2); // 출력 결과: 10
        }
    }
}
