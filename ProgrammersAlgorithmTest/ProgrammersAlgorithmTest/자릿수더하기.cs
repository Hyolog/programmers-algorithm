using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12931"/>
    [TestClass]
    public class 자릿수더하기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(123), 6);
        }

        public int solution(int n)
        {
            var answer = 0;

            while (n > 0)
            {
                answer += n % 10;
                n = n / 10;
            }

            return answer;
        }
    }
}
