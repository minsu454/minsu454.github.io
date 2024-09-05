namespace LearningAgain
{
    internal class Program
    {
        #region 홀수 출력
        //static void Main(string[] args)
        //{
        //    //for문
        //    //for (int i = 1; i <= 100; i++)
        //    //{
        //    //    if (i % 2 == 1)
        //    //    {
        //    //        Console.WriteLine($"{i}");
        //    //    }
        //    //}

        //    //while문
        //    //int i = 1;

        //    //while (i <= 100)
        //    //{
        //    //    if (i % 2 == 1)
        //    //    {
        //    //        Console.WriteLine($"{i}");
        //    //    }
        //    //    i++;
        //    //}

        //    //do-while문
        //    //int i = 1;

        //    //do
        //    //{
        //    //    if (i % 2 == 1)
        //    //    {
        //    //        Console.WriteLine($"{i}");
        //    //    }
        //    //    i++;
        //    //}
        //    //while (i <= 100);

        //}
        #endregion

        #region 배열을 사용한 합계 및 평균 계산
        //static void Main(string[] args)
        //{
        //    int[] arr = [10, 20, 30, 40, 50];
        //    int sum = 0, average = 0;

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        sum += arr[i];
        //    }

        //    Console.WriteLine($"Sum : {sum}");

        //    average = sum / arr.Length;

        //    Console.WriteLine($"Average : {average}");
        //}
        #endregion

        #region 팩토리얼 계산
        //static void Main(string[] args)
        //{
        //    int num = 0;
        //    int factorial = 0;

        //    Console.Write("Enter a number: ");
        //    num = int.Parse(Console.ReadLine());


        //    for (int i = num; i > 0; i--)
        //    {
        //        if (i == num)
        //        {
        //            factorial += i;
        //        }
        //        else
        //        {
        //            factorial *= i;
        //        }
        //    }

        //    Console.WriteLine($"Factorial of {num} is {factorial}");
        //}
        #endregion

        #region 숫자 맞추기 게임
        //static void Main(string[] args)
        //{
        //    Random random = new Random();
        //    int randNum = random.Next(1, 101);
        //    bool clear = false;

        //    while (!clear)
        //    {
        //        Console.Write("Enter your guess (1-100) : ");
        //        int tempNum = int.Parse(Console.ReadLine());
        //        if (tempNum < randNum)
        //        {
        //            Console.WriteLine("Too low! Try again.");
        //        }
        //        else if (tempNum > randNum)
        //        {
        //            Console.WriteLine("Too high! Try again.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Congratulations! You guessed the number.");
        //            clear = true;
        //        }
        //    }
        //}
        #endregion

        #region 이중 반복문을 사용한 구구단 출력
        //static void Main(string[] args)
        //{
        //    string[,] arr = new string[8, 9];

        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 9; j++)
        //        {
        //            arr[i, j] = $"{i + 2} * {j + 1} = {((i + 2) * (j + 1)).ToString("D2")}";
        //        }
        //    }

        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 9; j++)
        //        {
        //            Console.Write($"{arr[i, j]} ");
        //        }
        //        Console.WriteLine();
        //    }

        //    Console.WriteLine();

        //    for (int i = 0; i < 9; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            Console.Write($"{arr[j, i]} ");
        //        }
        //        Console.WriteLine();
        //    }
        //}
        #endregion

        #region 배열 요소의 최대값과 최소값 찾기
        //static void Main(string[] args)
        //{
        //    int[] numbers = { 20, 30, 40, 50, 10 };
        //    int min = 0, max = 0;

        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        if (i == 0)
        //        {
        //            min = max = numbers[i];
        //        }
        //        else
        //        {
        //            if (min > numbers[i])
        //            {
        //                min = numbers[i];
        //            }
        //            else if (max < numbers[i])
        //            {
        //                max = numbers[i];
        //            }
        //        }
        //    }

        //    Console.WriteLine($"min : {min}, max : {max}");
        //}
        #endregion

        #region 행맨 게임
        static void Main(string[] args)
        {
            
        }
        #endregion
    }
}
