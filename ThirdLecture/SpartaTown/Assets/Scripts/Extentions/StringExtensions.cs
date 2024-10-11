using System;

namespace Common.StringEx
{
    public static class StringExtensions
    {
        //string을 enum으로 변환
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