using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12912"/>
    [TestClass]
    public class 두정수사이의합
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(5, 3), 12);
            Assert.AreEqual(solution(3, 5), 12);
            Assert.AreEqual(solution(-3, -1), -6);
            Assert.AreEqual(solution(-1, -3), -6);
            Assert.AreEqual(solution(-1, -1), -1);
        }

        public long solution(int a, int b)
        {
            long result = 0;

            var start = a < b ? a : b;
            var end = a < b ? b : a;

            for (var i = start; i <= end; i++)
            {
                result += i;
            }

            return result;
        }
    }
}
