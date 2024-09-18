namespace HomeWork2
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    Random random = new Random();
        //    int randNum = random.Next(1, 101);
        //    bool isPlay = true;
        //    int count = 0;

        //    Console.WriteLine("숫자 맞추기 게임을 시작합니다. 1에서 100까지의 숫자 중 하나를 맞춰보세요.");

        //    while (isPlay)
        //    {
        //        int input = 0;

        //        Console.Write("숫자를 입력하세요: ");
        //        int.TryParse(Console.ReadLine(), out input);

        //        if (input > randNum)
        //        {
        //            Console.WriteLine("너무 큽니다!");
        //        }
        //        else if (input == randNum)
        //        {
        //            isPlay = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("너무 작습니다!");

        //        }

        //        count++;
        //    }

        //    Console.WriteLine($"축하합니다! {count}번 만에 숫자를 맞추었습니다.");
        //}

        //static string[] arr = new string[9];
        //static int count = 0;

        //static void Main(string[] args)
        //{
        //    bool isPlay = true;
        //    bool isPlayer1 = true;
        //    bool isDraw = false;

        //    Setting();

        //    while (isPlay)
        //    {
        //        Console.Clear();

        //        printUI(isPlayer1);
        //        Input(isPlayer1);

        //        isPlay = isPlayTest(out isDraw);

        //        isPlayer1 = !isPlayer1;

        //        if (isDraw)
        //        {
        //            break;
        //        }
        //    }
        //    Ending(isPlayer1, isDraw);
        //}

        //static void Setting()
        //{
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        arr[i] = (i + 1).ToString();
        //    }
        //}

        //static void Ending(bool isPlayer1, bool isDraw)
        //{
        //    Console.Clear();
        //    printUI(!isPlayer1, isDraw, true);
        //    Console.SetCursorPosition(0, 20);
        //}

        //static bool isPlayTest(out bool isDraw)
        //{
        //    bool temp = true;
        //    isDraw = false;


        //    //가로세로 검사
        //    for (int i = 0; i < 3; i++)
        //    {
        //        int t1 = i + 1;
        //        int t2 = i * 3;

        //        if (arr[t1] == arr[t1 + 3] && arr[t1] == arr[t1 + 6] && arr[t1] != "")
        //        {
        //            temp = false;
        //            break;
        //        }

        //        if (arr[t2] == arr[t2 + 1] && arr[t2] == arr[t2 + 2] && arr[t2] != "")
        //        {
        //            temp = false;
        //            break;
        //        }
        //    }

        //    //대각선 검사
        //    if (arr[0] == arr[4] && arr[0] == arr[8] && arr[0] != "")
        //    {
        //        temp = false;
        //    }

        //    if (arr[2] == arr[4] && arr[2] == arr[6] && arr[2] != "")
        //    {
        //        temp = false;
        //    }

        //    if (count == arr.Length - 1)
        //    {
        //        isDraw = true;
        //    }
        //    count++;

        //    return temp;
        //}

        //static void Input(bool isPlayer1)
        //{
        //    int input;
        //    int.TryParse(Console.ReadLine(), out input);

        //    arr[input - 1] = (isPlayer1 ? "X" : "O");
        //}

        //static void printUI(bool isPlayer1, bool isDraw = false, bool end = false)
        //{
        //    Console.WriteLine("플레이어 1: X 와 플레이어 2: O");
        //    Console.WriteLine("\n");

        //    string playerNum = isPlayer1 ? "1" : "2";

        //    if (!end)
        //        Console.WriteLine($"플레이어 {playerNum}의 차례\n\n");
        //    else
        //        Console.WriteLine($"{(isDraw ? "비겼습니다." : "플레이어 {playerNum}의 승리!!")}\n\n");

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (i % 3 == 0 || i == arr.Length - 1)
        //        {
        //            NullUI();
        //        }
        //        else if (i % 3 == 1)
        //        {
        //            NumUI(i - 1);
        //        }
        //        else
        //        {
        //            Null_UI();
        //        }
        //    }

        //    Console.SetCursorPosition(0, 4);
        //}

        //static void NullUI()
        //{
        //    Console.WriteLine("     |     |     ");
        //}

        //static void Null_UI()
        //{
        //    Console.WriteLine("_____|_____|_____");
        //}

        //static void NumUI(int i)
        //{
        //    Console.WriteLine($"  {arr[i]}  |  {arr[i + 1]}  |  {arr[i + 2]}  ");
        //}
    }
}
