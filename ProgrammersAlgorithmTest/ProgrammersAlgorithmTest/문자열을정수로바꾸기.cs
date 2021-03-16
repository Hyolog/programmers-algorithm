using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12925"/>
    [TestClass]
    public class 문자열을정수로바꾸기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("1234"), 1234);
            Assert.AreEqual(solution("+1234"), 1234);
            Assert.AreEqual(solution("-1234"), -1234);
        }

        public int solution(string s)
        {
            if (char.IsDigit(s[0]))
                return int.Parse(s);
            else
            {
                var number = int.Parse(s.Substring(1));
                return s[0] == '+' ? number : -number;
            }
        }
    }
}
