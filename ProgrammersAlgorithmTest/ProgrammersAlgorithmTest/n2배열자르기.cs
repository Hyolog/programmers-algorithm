using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/87390"/>
    [TestClass]
    public class n2배열자르기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(3, 2, 5), new int[] { 3, 2, 2, 3 });
            CollectionAssert.AreEqual(solution(4, 7, 14), new int[] { 4, 3, 3, 3, 4, 4, 4, 4 });
            CollectionAssert.AreEqual(solution(1, 0, 0), new int[] { 1 });
        }

        public int[] solution(int n, long left, long right)
        {
            var answer = new int[right - left + 1];

            for (var i = 0; i < answer.Length; i++)
            {
                var y = (left + i) / n;
                var x = (left + i) % n;
                var max = (int)Math.Max(y, x);
                var value = max + 1;

                answer[i] = value;
            }

            return answer;
        }
    }
}
