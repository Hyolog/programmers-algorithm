using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/76503"/>
    /// 13,14,18 시간초과
    [TestClass]
    public class 모두0으로만들기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { -5, 0, 2, 1, 2 }, new int[,] { { 0, 1 }, { 3, 4 }, { 2, 3 }, { 0, 3 } }), 9);
            Assert.AreEqual(solution(new int[] { 0, 1, 0 }, new int[,] { { 0, 1 }, { 1, 2 } }), -1);
        }

        Dictionary<int, List<int>> edgeConnectionInfo = new Dictionary<int, List<int>>();
        //int[] visitedEdges;
        int[] valueSet;
        long answer = 0;

        public long solution(int[] a, int[,] edges)
        {
            if (a.Sum() != 0)
                return -1;

            valueSet = a;

            //visitedEdges = new int[a.Length];

            // edge 연결정보 양방향으로 기록
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                var from = edges[i, 0];
                var to = edges[i, 1];

                SetConnectionInfo(from, to);
                SetConnectionInfo(to, from);
            }

            dfs(0, 0);

            return answer;
        }

        private void SetConnectionInfo(int from, int to)
        {
            if (edgeConnectionInfo.TryGetValue(from, out var neighbor))
            {
                if (!neighbor.Contains(to))
                {
                    neighbor.Add(to);
                }
            }
            else
            {
                edgeConnectionInfo.Add(from, new List<int>() { to });
            }
        }

        private long dfs(int edge, int parent)
        {
            //visitedEdges[edge] = 1;

            long weight = valueSet[edge];

            if (edgeConnectionInfo.TryGetValue(edge, out var neighbor))
            {
                for (int i = 0; i < neighbor.Count; i++)
                {
                    if (neighbor[i] != parent)
                        weight += dfs(neighbor[i], edge);
                }
            }

            answer += Math.Abs(weight);
            return weight;
        }
    }
}
