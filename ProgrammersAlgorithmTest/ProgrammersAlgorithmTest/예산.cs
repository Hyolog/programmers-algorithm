using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12982"/>
    [TestClass]
    public class 예산
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 1, 3, 2, 5, 4 }, 9), 3);
        }

        public int solution(int[] d, int budget)
        {
            var result = 0;
            var departments = new List<int>(d).OrderBy(i => i);

            foreach (var department in departments)
            {
                budget -= department;

                if (budget < 0)
                    break;

                result++;
            }

            return result;
        }
    }
}
