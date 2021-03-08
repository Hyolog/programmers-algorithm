//https://programmers.co.kr/learn/courses/30/lessons/12932

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 자연수뒤집어배열로만들기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(12345), new int[] { 5, 4, 3, 2, 1 });
        }

        public int[] solution(long n)
        {
            return n.ToString().Reverse().Select(d => int.Parse(d.ToString())).ToArray();
        }
    }
}
