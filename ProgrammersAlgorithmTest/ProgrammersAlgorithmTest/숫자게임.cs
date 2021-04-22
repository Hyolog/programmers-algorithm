using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12987"/>
    [TestClass]
    public class 숫자게임
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 1, 3, 5 }, new int[] { 4, 4, 4 }), 2);
            Assert.AreEqual(solution(new int[] { 5, 1, 3, 7 }, new int[] { 2, 2, 6, 8 }), 3);
            Assert.AreEqual(solution(new int[] { 2, 2, 2, 2 }, new int[] { 1, 1, 1, 1 }), 0);
        }

        /// <param name="A">1~100,000(item:1~1,000,000,000)</param>
        /// <param name="B">1~100,000</param>
        /// <returns></returns>
        public int solution(int[] A, int[] B)
        {
            var answer = 0;
            Array.Sort(A);
            Array.Sort(B);

            var minA = A.Min();
            var maxA = A.Max();
            var minB = B.Min();
            var maxB = B.Max();

            if (minB > maxA)
                return B.Length;
            else if (minA > maxB)
                return 0;
            else
            {
                var indexOfA = A.Length - 1;

                for (int indexOfB = B.Length - 1; indexOfB >= 0; indexOfB--)
                {
                    while (indexOfA >= 0)
                    {
                        if (B[indexOfB] > A[indexOfA])
                        {
                            indexOfA--;
                            answer++;
                            break;
                        }

                        indexOfA--;
                    }
                }
            }

            return answer;
        }
    }
}