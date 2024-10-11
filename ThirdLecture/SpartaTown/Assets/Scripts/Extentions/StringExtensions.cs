using System;

namespace Common.StringEx
{
    public static class StringExtensions
    {
        //string�� enum���� ��ȯ
        public static T StringToEnum<T>(this string value)
        {
            if (!Enum.IsDefined(typeof(T), value))
            {
                throw new Exception(value);
            }

            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}