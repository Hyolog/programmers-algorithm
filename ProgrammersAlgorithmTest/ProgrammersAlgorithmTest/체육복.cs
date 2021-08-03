using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42862"/>
    [TestClass]
    public class 체육복
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(5, new int[] { 2, 4 }, new int[] { 1, 3, 5 }), 5);
            Assert.AreEqual(solution(5, new int[] { 2, 4 }, new int[] { 3 }), 4);
            Assert.AreEqual(solution(3, new int[] { 3 }, new int[] { 1 }), 2);
            Assert.AreEqual(solution(8, new int[] { 1, 2, 4, 6 }, new int[] { 1, 2, 4, 6 }), 8);
            Assert.AreEqual(solution(2, new int[] { 1, 2 }, new int[] { 1, 2 }), 2);
            Assert.AreEqual(solution(2, new int[] { 1, 2 }, new int[] { 1 }), 1);
            Assert.AreEqual(solution(2, new int[] { 1, 2 }, new int[] { 2 }), 1);
            Assert.AreEqual(solution(2, new int[] { 1, 2 }, new int[] { }), 0);
            Assert.AreEqual(solution(2, new int[] { 1 }, new int[] { 2 }), 2);
            Assert.AreEqual(solution(2, new int[] { 2 }, new int[] { 2 }), 2);

            Assert.AreEqual(solution(7, new int[] { 2, 3, 4, 6 }, new int[] { 1, 2, 3 }), 5);
        }

        public int solution(int n, int[] lost, int[] reserve)
        {
            var status = new int[n];

            // 분실 = -1 처리
            foreach (var item in lost)
            {
                var index = item - 1;
                status[index] = -1;

                if (reserve.Contains(item))
                {
                    status[index] = 0;
                }
            }

            // 여분 빌려주고 0 처리
            foreach (var item in reserve)
            {
                if (lost.Contains(item))
                    continue;

                var index = item - 1;

                // 내가 분실
                if (status[index] == -1)
                {
                    status[index] = 0;
                }
                else
                {
                    if (index > 0 && status[index - 1] == -1)
                    {
                        status[index - 1] = 0;
                    }
                    else if (index < n - 1 && status[index + 1] == -1)
                    {
                        status[index + 1] = 0;
                    }
                }
            }

            return status.Where(d => d == 0).Count();
        }
    }
}
