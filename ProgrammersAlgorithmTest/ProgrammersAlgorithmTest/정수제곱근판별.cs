using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12934"/>
    [TestClass]
    public class 정수제곱근판별
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(44444435555556), 44444448888889);
            Assert.AreEqual(solution(1), 4);
        }

        /// <param name="n">1~50,000,000,000,000</param>
        public long solution(long n)
        {
            var sqrt = (long)Math.Sqrt(n);

            if (Math.Pow(sqrt, 2).Equals(n))
                return (long)Math.Pow(sqrt + 1, 2);
            else
                return -1;
        }
    }
}
