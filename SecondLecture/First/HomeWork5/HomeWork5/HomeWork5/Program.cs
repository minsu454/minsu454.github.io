using System.Numerics;

namespace HomeWork5
{
    #region LeetCode 84
    //internal class Program
    //{
    //    public static int LargestRectangleArea(int[] heights)
    //    {
    //        int best = 0;
    //        int cur = 0;
    //        int right = 0;

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

    //        right = stack.Peek() + 1;

    //        while (stack.Peek() != -1)
    //        {
    //            cur = stack.Pop();

    //            best = Math.Max(best, heights[cur] * (heights.Length - stack.Peek() - 1));
    //        }

    //        return best;
    //    }

    //    static void Main(string[] args)
    //    {
    //        int[] arr = new int[] { 5, 4, 3, 2 };

    //        int answer = LargestRectangleArea(arr);

    //        Console.WriteLine(answer);
    //    }
    //}
    #endregion

    #region LeetCode 733
    internal class Program
    {
        public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color) return image;

            int oldColor = image[sr][sc];

            image[sr][sc] = color;

            if ((sr - 1) != -1 && image[sr - 1][sc] == oldColor)
            {
                FloodFill(image, sr - 1, sc, color);
            }

            if ((sr + 1) != image.Length && image[sr + 1][sc] == oldColor)
            {
                FloodFill(image, sr + 1, sc, color);
            }

            if ((sc - 1) != -1 && image[sr][sc - 1] == oldColor)
            {
                FloodFill(image, sr, sc - 1, color);
            }

            if ((sc + 1) != image[0].Length && image[sr][sc + 1] == oldColor)
            {
                FloodFill(image, sr, sc + 1, color);
            }

            return image;
        }

        static void Main(string[] args)
        {
            int[][] arr = new int[][]
            {
                new int[] {0, 0, 0},
                new int[] {0, 0, 0}
            };

            int sr = 0;
            int sc = 0;
            int color = 2;

            arr = FloodFill(arr, sr, sc, color);

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]} ");
                }
                Console.WriteLine();
            }

        }
    }
    #endregion
}
