using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12918"/>
    [TestClass]
    public class 문자열다루기기본
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("12005938"), true);
            Assert.AreEqual(solution("00000000"), true);
            Assert.AreEqual(solution("0"), true);
            Assert.AreEqual(solution("a"), false);
            Assert.AreEqual(solution("abjsiwjd"), false);
        }

        public bool solution(string s)
        {
            return (s.Length == 4 || s.Length == 6) && !s.Any(d => !char.IsDigit(d));
        }
    }
}
