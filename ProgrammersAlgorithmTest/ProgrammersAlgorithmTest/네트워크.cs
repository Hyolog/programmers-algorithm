using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/43162"/>
    [TestClass]
    public class 네트워크
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(3, new int[,] { { 1, 1, 0 }, { 1, 1, 0 }, { 0, 0, 1 } }), 2);
            Assert.AreEqual(solution(3, new int[,] { { 1, 1, 0 }, { 1, 1, 1 }, { 0, 1, 1 } }), 1);
        }

        bool[] visit;

        public int solution(int n, int[,] computers)
        {
            var answer = 0;
            visit = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visit[i])
                {
                    visit[i] = true;
                    answer++;
                    search(i, n, computers);
                }
            }

            return answer;
        }

        public void search(int i, int n, int[,] edge)
        {
            for (int j = 0; j < n; j++)
            {
                if (j != i && !visit[j] && edge[i, j] == 1)
                {
                    visit[j] = true;
                    search(j, n, edge);
                }
            }
        }
    }
}
