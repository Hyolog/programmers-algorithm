using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12978"/>
    /// LV2 맞나? 어려운데
    /// DFS
    [TestClass]
    public class 배달
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(2, new int[,] { { 1, 2, 3 }, { 1, 2, 4 } }, 3), 2);
            Assert.AreEqual(solution(5, new int[,] { { 1, 2, 1 }, { 2, 3, 3 }, { 5, 2, 2 }, { 1, 4, 2 }, { 5, 3, 1 }, { 5, 4, 2 } }, 3), 4);
            Assert.AreEqual(solution(6, new int[,] { { 1, 2, 1 }, { 1, 3, 2 }, { 2, 3, 2 }, { 3, 4, 3 }, { 3, 5, 2 }, { 3, 5, 3 }, { 5, 6, 1 } }, 4), 4);
        }

        public int solution(int N, int[,] road, int K)
        {
            // <방문마을, 최단거리>
            var visitedVillages = new Dictionary<int, int>();

            dfs(road, 1, visitedVillages, K);

            return visitedVillages.Where(d => !d.Value.Equals(int.MaxValue)).Count();
        }

        private void dfs(int[,] road, int village, Dictionary<int, int> visitedVillage, int capa)
        {
            // 방문처리, 갈수있는 거리 업데이트
            if (visitedVillage.TryGetValue(village, out var maxCapa))
            {
                if (maxCapa < capa)
                    visitedVillage[village] = capa;
                else
                    return;
            }
            else
            {
                visitedVillage.Add(village, capa);
            }
            
            //연결되어있는 마을들에 대해 해당 방문한 적 없고 distance 만족하면 dfs 호출
            //돌아가는거 안하도록
            for (int i = 0; i < road.GetLength(0); i++)
            {
                int nextVillage;

                if (road[i, 0].Equals(village))
                    nextVillage = road[i, 1];
                else if (road[i, 1].Equals(village))
                    nextVillage = road[i, 0];
                else
                    continue;

                capa -= road[i, 2];

                if (capa >= 0)
                    dfs(road, nextVillage, visitedVillage, capa);
                
                capa += road[i, 2];
            }
        }
    }
}
