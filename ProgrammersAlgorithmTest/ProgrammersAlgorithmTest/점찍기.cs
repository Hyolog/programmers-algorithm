using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/140107"/>
    [TestClass]
    public class 점찍기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(2, 4), 6);
            Assert.AreEqual(solution(1, 5), 26);
        }

        public long solution(int k, int d)
        {
            long answer = 0;
            long dd = (long)d * d;
            long kk = (long)k * k;

            for (var x = 0; x <= d; x += k)
            {
                long xx = (long)x * x;
                long y = (long)Math.Sqrt((dd - xx) / kk);
                answer += (y + 1);
            }

            return answer;
        }
    }
}
