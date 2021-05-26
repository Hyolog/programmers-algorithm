using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12921"/>
    [TestClass]
    public class 소수찾기2
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(1), 0);
            Assert.AreEqual(solution(2), 1);
            Assert.AreEqual(solution(10), 4);
            Assert.AreEqual(solution(5), 3);
        }

        public int solution(int n)
        {
            if(n == 1)
                return 0;
            else if (n == 2)
                return 1;

            var answer = 1;

            for (int num = 3; num <= n; num += 2)
            {
                if (IsPrime(num))
                {
                    answer++;
                }
            }

            return answer;
        }

        private bool IsPrime(int number)
        {
            var sqrt = Math.Sqrt(number);

            for (int i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
