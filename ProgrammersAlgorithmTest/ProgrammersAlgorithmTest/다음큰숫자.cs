//https://programmers.co.kr/learn/courses/30/lessons/12911

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 다음큰숫자
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(78), 83);
            Assert.AreEqual(solution(15), 23);
        }

        private int CountOf1(int num)
        {
            var countOf1 = 0;
            var binary = Convert.ToString(num, 2);

            foreach (var item in binary)
            {
                if (item == '1')
                    countOf1++;
            }

            return countOf1;

            //why time out?
            //return Convert.ToString(num, 2).Where(d => d == '1').Count();
        }

        public int solution(int n)
        {
            var countOf1 = CountOf1(n);
            var nextNum = n + 1;

            while (true)
            {
                var nextCountOf1 = CountOf1(nextNum);

                if (nextCountOf1 == countOf1)
                    return nextNum;

                nextNum++;
            }
        }
    }
}
