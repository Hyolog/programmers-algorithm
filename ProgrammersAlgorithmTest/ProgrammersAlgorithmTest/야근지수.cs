using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12927"/>
    [TestClass]
    public class 야근지수
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(4, new int[] { 4, 3, 3 }), 12);
            Assert.AreEqual(solution(1, new int[] { 2, 1, 2 }), 6);
            Assert.AreEqual(solution(3, new int[] { 1, 1 }), 0);
            Assert.AreEqual(solution(99, new int[] { 2, 15, 22, 55, 55 }), 580);
            Assert.AreEqual(solution(1, new int[] { 1, 1, 1 }), 2);
            Assert.AreEqual(solution(5, new int[] { 2, 3 }), 0);
            Assert.AreEqual(solution(5, new int[] { 3, 3 }), 1);
        }

        /// <param name="n">1~1,000,000</param>
        /// <param name="works">1~20,000(item:1~50,000)</param>
        /// <returns></returns>
        public long solution(int n, int[] works)
        {
            if (n >= works.Sum())
                return 0;

            long answer = 0;
            var previousIntervalSum = 0;
            var previousCriteria = works.Max();
            var criteria = works.Max();

            while (criteria >= 0)
            {
                var intervalSum = GetIntervalSum(works, criteria);

                if (intervalSum < n)
                {
                    previousCriteria = criteria;
                    previousIntervalSum = intervalSum;
                    criteria--;
                }
                else
                {
                    n -= previousIntervalSum;
                    break;
                }
            }

            foreach (var work in works)
            {
                if (work >= previousCriteria && n > 0)
                {
                    n--;
                    var value = previousCriteria - 1;
                    answer += value * value;
                }
                else
                {
                    if (work >= previousCriteria)
                        answer += previousCriteria * previousCriteria;
                    else
                        answer += work * work;
                }
            }

            return answer;
        }

        private int GetIntervalSum(int[] works, int criteria)
        {
            var intervalSum = 0;

            foreach (var work in works)
            {
                var interval = work - criteria;

                if (interval > 0)
                    intervalSum += interval;
            }

            return intervalSum;
        }
    }
}