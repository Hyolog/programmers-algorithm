using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12951"/>
    // TODO : 쉬워보이지만 신경쓸것이 은근히 많은 문제.
    [TestClass]
    public class JadenCase문자열만들기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("3people unFollowed me"), "3people Unfollowed Me");
            Assert.AreEqual(solution("for the last week"), "For The Last Week");
            Assert.AreEqual(solution("for the last week "), "For The Last Week ");
            Assert.AreEqual(solution(" for the last week"), " For The Last Week");
            Assert.AreEqual(solution(" for the last week "), " For The Last Week ");
            Assert.AreEqual(solution("   for the last week   "), "   For The Last Week   ");
        }

        public string solution(string s)
        {
            var result = new StringBuilder();
            var isFirst = true;

            for (var i = 0; i < s.Length; i++)
            {
                if (char.IsWhiteSpace(s[i]))
                {
                    result.Append(" ");
                    isFirst = true;
                }
                else
                {
                    if (isFirst)
                    {
                        result.Append(char.ToUpper(s[i]));
                        isFirst = false;
                    }
                    else
                    {
                        result.Append(char.ToLower(s[i]));
                    }
                }
            }

            return result.ToString();
        }
    }
}
