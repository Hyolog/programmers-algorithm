using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/138476"/>
    [TestClass]
    public class 귤고르기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(1, new int[] { 1, 3, 2, 5, 4, 5, 2, 3 }), 1);
            Assert.AreEqual(solution(3, new int[] { 1, 1, 1 }), 1);
            Assert.AreEqual(solution(3, new int[] { 1, 2, 1 }), 2);
            Assert.AreEqual(solution(6, new int[] { 1, 3, 2, 5, 4, 5, 2, 3 }), 3);
            Assert.AreEqual(solution(4, new int[] { 1, 3, 2, 5, 4, 5, 2, 3 }), 2);
            Assert.AreEqual(solution(2, new int[] { 1, 1, 1, 1, 2, 2, 2, 3 }), 1);
        }

        public int solution(int k, int[] tangerine)
        {
            var tanDic = new Dictionary<int, int>();

            foreach (var item in tangerine)
            {
                if (tanDic.TryGetValue(item, out var count))
                {
                    tanDic[item]++;
                }
                else
                {
                    tanDic.Add(item, 1);
                }
            }

            var result = 0;

            foreach (var item in tanDic.OrderByDescending(d => d.Value))
            {
                if (k > 0)
                {
                    k -= item.Value;
                    result++;
                }
                else
                {
                    return result;
                }
            }

            return result;
        }
    }
}
