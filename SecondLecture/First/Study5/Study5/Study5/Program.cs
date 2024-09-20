namespace Study5
{
    #region QuickSort
    //internal class Program
    //{
    //    static void QuickSort(int[] arr, int left, int right)
    //    {
    //        if (left < right)
    //        {
    //            int pivot = Partition(arr, left, right);

    //            QuickSort(arr, left, pivot - 1);
    //            QuickSort(arr, pivot + 1, right);
    //        }
    //    }

    //    static int Partition(int[] arr, int left, int right)
    //    {
    //        int pivot = arr[right];
    //        int i = left - 1;

    //        for (int j = left; j < right; j++)
    //        {
    //            if (arr[j] < pivot)
    //            {
    //                i++;
    //                Swap(arr, i, j);
    //            }
    //        }

    //        Swap(arr, i + 1, right);

    //        return i + 1;
    //    }

    //    static void Swap(int[] arr, int i, int j)
    //    {
    //        int temp = arr[i];
    //        arr[i] = arr[j];
    //        arr[j] = temp;
    //    }

    //    static void Main(string[] args)
    //    {
    //        int[] arr = new int[] { 16, 5, 2, 4, 6, 1, 3, 8, 10, 21, 7 };

    //        QuickSort(arr, 0, arr.Length - 1);

    //        foreach (int num in arr)
    //        {
    //            Console.WriteLine(num);
    //        }
    //    }
    //}
    #endregion

    #region Graph
    public class Graph
    {
        private int V;
        private List<int>[] adj;

        public Graph(int V)
        {
            this.V = V;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        public void DFS(int v)
        {
            bool[] visited = new bool[V];
            DFSUtil(v, visited);
        }

        public void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write($"{v} ");
            foreach (int n in adj[v])
            {
                if (!visited[n])
                {
                    DFSUtil(n, visited);
                }
            }
        }

        public void BFS(int v)
        {
            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();

            visited[v] = true;
            queue.Enqueue(v);

            while (queue.Count > 0)
            {
                int n = queue.Dequeue();
                Console.Write($"{n} ");

                foreach (int m in adj[n])
                {
                    if (!visited[m])
                    {
                        visited[m] = true;
                        queue.Enqueue(m);
                    }
                }
            }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Graph graph = new Graph(6);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 5);

            Console.WriteLine("DFS travelsal: ");
            graph.DFS(0);
            Console.WriteLine();

            Console.WriteLine("BFS travelsal: ");
            graph.BFS(0);
            Console.WriteLine();
        }
    }
    #endregion
}
