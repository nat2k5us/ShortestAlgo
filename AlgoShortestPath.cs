using System;
using System.Collections.Generic;
using System.Text;

namespace stoneeagle
{
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public static class Dijkstra
    {

        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        public static void DijkstraAlgo(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            Print(distance, verticesCount);
        }

        public static void Print2DArray(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    //put a single value
                    Console.Write($"{matrix[i, k]} ");
                }
                //next row
                Console.WriteLine();
            }
        }

        private static int MinofThree(int x, int y, int z)
        {

            var items = new List<int>();
            if (x != 0) items.Add(x);
            if (y != 0) items.Add(y);
            if (z != 0) items.Add(z);
            return items.Min();

        }

        public static Dictionary<int,int> TravelPathsDictionary { get; set; }

        public static int[,] minCost(int[,] costPaths, int m, int n, rootPlayer player)
        {
            TravelPathsDictionary = new Dictionary<int, int>();
            int i, j;
            int[,] totalCost = new int[m , n ];
            totalCost[0, 0] = costPaths[0, 0];

            for (i = 1; i < m; i++)
            {
                totalCost[i, 0] = totalCost[i - 1, 0] + costPaths[i, 0];
            }

            for (j = 1; j < n; j++)
            {
                totalCost[0, j] = totalCost[0, j - 1] + costPaths[0, j];
            }

            for (i = 1; i < m; i++)
            {
                for (j = 1; j < n; j++)
                {
                    Console.WriteLine($"Evaluating 3 Positions 1:{totalCost[i - 1, j - 1]} , 2:{totalCost[i - 1, j]} , 3:{totalCost[i, j - 1]}");
                    var i1 = Math.Min(totalCost[i - 1, j], totalCost[i, j - 1]);
                    //MinofThree(
                    //    totalCost[i - 1, j - 1],
                    //    totalCost[i - 1, j],
                    //    totalCost[i, j - 1]);
                    var curPos = costPaths[i, j];
                    var finalCost = i1 + curPos;
                    Console.WriteLine($"Going to {i1}, totalCost {finalCost}");
                    totalCost[i, j] = finalCost;

                    // Console.Write($"{i},{j} => {totalCost[i, j]}");
                }
            }

            var ret = totalCost[m - 1, n - 1];
            return totalCost;
        }
        //static void Main(string[] args)
        //{
        //    int[,] graph =  {
        //                 { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
        //                 { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
        //                 { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
        //                 { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
        //                 { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
        //                 { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
        //                 { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
        //                 { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
        //                 { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
        //                    };

        //    DijkstraAlgo(graph, 0, 9);
        //}
    }
}
