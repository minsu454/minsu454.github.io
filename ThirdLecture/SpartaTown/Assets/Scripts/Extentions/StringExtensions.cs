using System;

namespace Common.StringEx
{
    /// <summary>
    /// string 확장
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// string을 enum으로 변환 함수
        /// </summary>
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