using System.Text.RegularExpressions;

namespace TextRPG
{
    public static class StringExtentions
    {
        /// <summary>
        /// 한국어 줄 정렬하는 함수
        /// </summary>
        public static string KoreanStringInterpolation(string name, int count)
        {
            int length = name.Replace(" ", "").Length;
            length += Regex.Matches(name, "").Count;

            if (count < length)
                throw new OverflowException($"string nameLength * 2 : {length}, count");

            while (length != count)
            {
                name += " ";
                length++;
            }

            return name;
        }
    }
}
