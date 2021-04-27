using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/77484"/>
    [TestClass]
    public class 로또의최고순위와최저순위
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 44, 1, 0, 0, 31, 25 }, new int[] { 31, 10, 45, 1, 6, 19 }), new int[] { 3, 5 });
        }

        public int[] solution(int[] lottos, int[] win_nums)
        {
            var min = 0;
            var max = 0;

            foreach (var lotto in lottos)
            {
                if (lotto == 0)
                    max++;
                else if (win_nums.Contains(lotto))
                {
                    min++;  
                    max++;
                }
            }

            return new int[] { Math.Min(7 - (max), 6), Math.Min(7 - min, 6) };
        }
    }
}
