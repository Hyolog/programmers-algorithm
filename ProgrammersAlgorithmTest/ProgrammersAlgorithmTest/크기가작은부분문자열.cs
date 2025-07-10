using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/147355"/>
    [TestClass]
    public class 크기가작은부분문자열
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("3141592", "271"), 2);
            Assert.AreEqual(solution("500220839878", "7"), 8);
            Assert.AreEqual(solution("10203", "15"), 3);
            Assert.AreEqual(solution("1", "1"), 1);
            Assert.AreEqual(solution("22", "1"), 0);
            Assert.AreEqual(solution("2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222", "3"), 100);
        }

        public int solution(string t, string p)
        {
            var answer = 0;
            var length = t.Length - p.Length + 1;

            for (int i = 0; i < length; i++)
            {
                if (long.Parse(t.Substring(i, p.Length)) <= long.Parse(p))
                {
                    answer++;
                }
            }

            return answer;
        }
    }
}
