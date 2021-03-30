using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12917"/>
    [TestClass]
    public class 문자열내림차순으로배치하기
    {
        [TestMethod]
        public void Test()
        {

        }

        public string solution(string s)
        {
            return new string(s.OrderByDescending(d => d).ToArray());
        }
    }
}
