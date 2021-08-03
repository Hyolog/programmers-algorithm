using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42842"/>
    [TestClass]
    public class 카펫
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(10, 2), new int[] { 4, 3 });
            CollectionAssert.AreEqual(solution(8, 1), new int[] { 3, 3 });
            CollectionAssert.AreEqual(solution(24, 24), new int[] { 8, 6 });
        }

        /// <param name="brown">8 ~ 5,000</param>
        /// <param name="yellow">1 ~ 2,000,000</param>
        /// <returns>카펫 가로(x), 세로(y), x >= y</returns>
        public int[] solution(int brown, int yellow)
        {
            var sum = brown + yellow;

            int x = 3;
            int y = 0;

            while (true)
            {
                if (sum % x == 0)
                {
                    y = sum / x;

                    if (IsValid(yellow, x, y))
                    {
                        return new int[] { Math.Max(x, y), Math.Min(x, y) };
                    }
                }

                x++;
            }
        }

        private bool IsValid(int yellow, int x, int y)
        {
            return (x - 2) * (y - 2) == yellow;
        }
    }
}
