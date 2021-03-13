//https://programmers.co.kr/learn/courses/30/lessons/12914

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 멀리뛰기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(4), 5);
            Assert.AreEqual(solution(3), 3);
        }

        public long solution(int n)
        {
            var result = new List<long>() { 0, 1, 2 };

            if (n < 3)
                return result[n];
            
            for (var i = 3; i <= n; i++)
            {
                result.Add((result[i - 1] + result[i - 2]) % 1234567);
            }

            return result[n];
        }
    }
}
