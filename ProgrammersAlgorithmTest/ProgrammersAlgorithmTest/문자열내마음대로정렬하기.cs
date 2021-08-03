using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12915"/>
    /// TODO : 은근 복잡하네
    [TestClass]
    public class 문자열내마음대로정렬하기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new string[] { "sun", "bed", "car" }, 1), new string[] { "car", "bed", "sun" });
            CollectionAssert.AreEqual(solution(new string[] { "abce", "abcd", "cdx" }, 2), new string[] { "abcd", "abce", "cdx" });
            CollectionAssert.AreEqual(solution(new string[] { "abc", "c" }, 0), new string[] { "abc", "c" });
            CollectionAssert.AreEqual(solution(new string[] { "ab", "a", "bcd"}, 0), new string[] { "a", "ab", "bcd" });
        }

        public string[] solution(string[] strings, int n)
        {
            return strings.OrderBy(d => d).OrderBy(d => d[n]).ToArray();
        }
    }
}
