using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/389479"/>
    [TestClass]
    public class 서버증설횟수
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 0, 2, 3, 3, 1, 2, 0, 0, 0, 0, 4, 2, 0, 6, 0, 4, 2, 13, 3, 5, 10, 0, 1, 5 }, 3, 5), 7);
            Assert.AreEqual(solution(new int[] { 0, 0, 0, 10, 0, 12, 0, 15, 0, 1, 0, 1, 0, 0, 0, 5, 0, 0, 11, 0, 8, 0, 0, 0 }, 5, 1), 11);
            Assert.AreEqual(solution(new int[] { 0, 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 5, 0, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 }, 1, 1), 12);
        }

        public int solution(int[] players, int m, int k)
        {
            var result = 0;
            var servers = new List<int>();

            foreach (var player in players)
            {
                for (int i = 0; i < servers.Count; i++)
                {
                    servers[i]--;
                }

                servers.RemoveAll(d => d == 0);

                var need = player / m;
                var addedServer = servers.Count;
                var totalNeed = need - addedServer;

                for (int i = 0; i < totalNeed; i++)
                {
                    servers.Add(k);
                    result++;
                }
            }

            return result;
        }
    }
}
