using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12911"/>
    // DONE : 타임아웃 부분 다시 풀어보기
    [TestClass]
    public class 다음큰숫자
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(78), 83);
            Assert.AreEqual(solution(15), 23);
        }

        public int solution(int n)
        {
            var binary = Convert.ToString(n, 2);
            var countOfOne = binary.Count(d => d == '1');

            while (true)
            {
                n++;
                var tempBinary = Convert.ToString(n, 2);

                if (tempBinary.Count(d => d == '1').Equals(countOfOne))
                    return Convert.ToInt32(tempBinary, 2);
            }
        }
    }
}
