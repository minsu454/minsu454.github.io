namespace TextRPG
{
    public static class Input
    {
        #region Format
        private static string inputFormats =
@"원하는 행동을 입력해주세요.
>> ";

        public static string inputErrorFormats =
@"잘못된 입력입니다.
>> ";
        #endregion

        public static int InputKey(int count, bool useZero = false)
        {
            Print.PrintScreen(inputFormats);

            int input = 0;

            while (true)
            {
                input = int.Parse(Console.ReadLine()!);

                if (input <= count && (useZero ? input >= 0 : input >= 1))
                {
                    break;
                }

                Print.PrintScreen(inputErrorFormats);
            }

            return input;
        }
    }
}
