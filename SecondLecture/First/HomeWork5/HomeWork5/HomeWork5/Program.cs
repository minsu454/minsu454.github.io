using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Cryptography;

namespace HomeWork5
{
    #region LeetCode 84
    //internal class Program
    //{
    //    public static int LargestRectangleArea(int[] heights)
    //    {
    //        int best = 0;
    //        int cur = 0;

    //        Stack<int> stack = new Stack<int>();

    //        stack.Push(-1);

    //        for (int i = 0; i < heights.Length; i++)
    //        {
    //            while (stack.Peek() != -1 && heights[stack.Peek()] > heights[i])
    //            {
    //                cur = stack.Pop();
    //                best = Math.Max(best, heights[cur] * (i - stack.Peek() - 1));
    //            }

    //            stack.Push(i);

    //        }

    //        while (stack.Peek() != -1)
    //        {
    //            cur = stack.Pop();

    //            best = Math.Max(best, heights[cur] * (heights.Length - stack.Peek() - 1));
    //        }

    //        return best;
    //    }

    //    static void Main(string[] args)
    //    {
    //        int[] arr = new int[] { 2, 3, 4 };

    //        int answer = LargestRectangleArea(arr);

    //        Console.WriteLine(answer);
    //    }
    //}
    #endregion

    #region LeetCode 733
    //internal class Program
    //{
    //    public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
    //    {
    //        if (image[sr][sc] == color) return image;

    //        int oldColor = image[sr][sc];

    //        image[sr][sc] = color;

    //        if ((sr - 1) != -1 && image[sr - 1][sc] == oldColor)
    //        {
    //            FloodFill(image, sr - 1, sc, color);
    //        }

    //        if ((sr + 1) != image.Length && image[sr + 1][sc] == oldColor)
    //        {
    //            FloodFill(image, sr + 1, sc, color);
    //        }

    //        if ((sc - 1) != -1 && image[sr][sc - 1] == oldColor)
    //        {
    //            FloodFill(image, sr, sc - 1, color);
    //        }

    //        if ((sc + 1) != image[0].Length && image[sr][sc + 1] == oldColor)
    //        {
    //            FloodFill(image, sr, sc + 1, color);
    //        }

    //        return image;
    //    }

    //    static void Main(string[] args)
    //    {
    //        int[][] arr = new int[][]
    //        {
    //            new int[] {0, 0, 0},
    //            new int[] {0, 0, 0}
    //        };

    //        int sr = 0;
    //        int sc = 0;
    //        int color = 2;

    //        arr = FloodFill(arr, sr, sc, color);

    //        for (int i = 0; i < arr.Length; i++)
    //        {
    //            for (int j = 0; j < arr[i].Length; j++)
    //            {
    //                Console.Write($"{arr[i][j]} ");
    //            }
    //            Console.WriteLine();
    //        }

    //    }
    //}
    #endregion

    #region LeetCode 300
    //internal class Program
    //{
    //    static public int LengthOfLIS(int[] nums)
    //    {
    //        int[] arr = new int[nums.Length];
    //        arr[0] = nums[0];

    //        int count = 1;

    //        for (int i = 1; i < nums.Length; i++)
    //        {
    //            if (arr[count - 1] < nums[i])
    //            {
    //                arr[count] = nums[i];
    //                count++;
    //            }
    //            else
    //            {
    //                int left = 0, right = count;
    //                int mid = 0;
    //                while (left <= right)
    //                {
    //                    mid = (right + left) / 2;

    //                    if (arr[mid] >= nums[i])
    //                    {
    //                        right = mid - 1;
    //                    }
    //                    else
    //                    {
    //                        left = mid + 1;
    //                        mid++;
    //                    }
    //                }
    //                arr[mid] = nums[i];
    //            }
    //        }
    //        return count;
    //    }
    //    static void Main(string[] args)
    //    {
    //        int[] arr = new int[] { 0, 1, 0, 3, 2, 3 };

    //        Console.WriteLine(LengthOfLIS(arr));
    //    }
    //}
    #endregion
}
