using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12933"/>
    [TestClass]
    public class 정수내림차순으로배치하기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(118372), 873211);
        }

        public long solution(long n)
        {
            var a = n.ToString().OrderBy(d => d);
            var b = a.ToString();
            var c = long.Parse(b);

            return long.Parse(n.ToString().OrderBy(d => d).ToString());
        }
    }
}
