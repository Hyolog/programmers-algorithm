using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/131704"/>
    [TestClass]
    public class 택배상자
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 4, 3, 1, 2, 5 }), 2);
            Assert.AreEqual(solution(new int[] { 5, 4, 3, 2, 1 }), 5);
            Assert.AreEqual(solution(new int[] { 4, 1, 2, 3 }), 1);
            Assert.AreEqual(solution(new int[] { 1 }), 1);
            Assert.AreEqual(solution(new int[] { 3, 2, 1 }), 3);
            Assert.AreEqual(solution(new int[] { 1, 3, 5, 2, 4 }), 3);
        }

        public int solution(int[] order)
        {
            int result = 0;
            var second = new Stack<int>();

            for (int boxNum = 1; boxNum <= order.Length; ++boxNum)
            {
                if (boxNum == order[result])
                    result++;
                else
                    second.Push(boxNum);

                while (second.Count > 0 && second.Peek() == order[result])
                {
                    second.Pop();
                    ++result;
                }
            }

            return result;
        }
    }
}