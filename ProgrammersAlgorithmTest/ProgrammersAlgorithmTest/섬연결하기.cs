using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42861"/>
    /// 카루스칼 알고리즘
    [TestClass]
    public class 섬연결하기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(4, new int[,] { { 0, 1, 1 }, { 0, 2, 2 }, { 1, 2, 5 }, { 1, 3, 1 }, { 2, 3, 8 } }), 4);
        }

        public class Bridge : IComparable<Bridge>
        {
            public int FirstIsland { get; set; }
            public int SecondIsland { get; set; }
            public int Distance { get; set; }

            public Bridge(int firstIsland, int secondIsland, int distance)
            {
                FirstIsland = firstIsland;
                SecondIsland = secondIsland;
                Distance = distance;
            }

            public int CompareTo(Bridge bridge)
            {
                if (Distance > bridge.Distance)
                    return 1;
                else if (Distance < bridge.Distance)
                    return -1;
                else
                    return 0;
            }
        }

        public int solution(int n, int[,] costs)
        {
            var edges = new List<Bridge>();

            for (var i = 0; i < costs.GetLength(0); i++)
            {
                edges.Add(new Bridge(costs[i, 0], costs[i, 1], costs[i, 2]));
            }

            edges.Sort();

            int[] islands = new int[n];

            for (int i = 0; i < n; i++)
            {
                islands[i] = i;
            }

            int minCost = 0;

            for (var i = 0; i < edges.Count; i++)
            {
                if (CompareIsland(islands, edges[i].FirstIsland, edges[i].SecondIsland))
                {
                    minCost += edges[i].Distance;
                    MergeIsland(islands, edges[i].FirstIsland, edges[i].SecondIsland);
                }
            }

            return minCost;
        }

        void MergeIsland(int[] islands, int firstIsland, int secondIsland)
        {
            firstIsland = GetParentIsland(islands, firstIsland);
            secondIsland = GetParentIsland(islands, secondIsland);

            if (firstIsland < secondIsland) 
                islands[secondIsland] = firstIsland;
            else 
                islands[firstIsland] = secondIsland;
        }

        bool CompareIsland(int[] set, int firstIsland, int secondIsland)
        {
            firstIsland = GetParentIsland(set, firstIsland);
            secondIsland = GetParentIsland(set, secondIsland);

            return firstIsland != secondIsland;
        }

        int GetParentIsland(int[] islands, int island)
        {
            if (islands[island] == island)
                return island;

            return islands[island] = GetParentIsland(islands, islands[island]);
        }
    }
}
