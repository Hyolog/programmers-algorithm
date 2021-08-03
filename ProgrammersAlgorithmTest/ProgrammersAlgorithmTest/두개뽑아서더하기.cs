using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/68644"/>
    [TestClass]
    public class 두개뽑아서더하기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 2, 1, 3, 4, 1 }), new int[] { 2, 3, 4, 5, 6, 7 });
        }

        public int[] solution(int[] numbers)
        {
            var result = new List<int>();

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    var temp = numbers[i] + numbers[j];

                    if (!result.Contains(temp))
                    {
                        result.Add(temp);
                    }
                }
            }

            return result.OrderBy(d => d).ToArray();
        }
    }
}
