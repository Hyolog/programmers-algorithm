using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/131701"/>
    [TestClass]
    public class 연속부분수열합의개수
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[5] { 7, 9, 1, 1, 4 }), 18);
        }

        public int solution(int[] elements)
        {
            var result = new Dictionary<int, bool>();
            var copy = new int[elements.Length * 2 - 1];
            Array.Copy(elements, 0, copy, 0, elements.Length);
            Array.Copy(elements, 0, copy, elements.Length, elements.Length - 1);

            for (var d = 0; d < elements.Length; d++)
            {
                for (int i = 0; i < copy.Length - d; i++)
                {
                    var num = 0;

                    for (int j = i; j <= i + d; j++)
                    {
                        num += copy[j];
                    }

                    if (!result.TryGetValue(num, out var value))
                    {
                        result.Add(num, true);
                    }
                }
            }

            return result.Count;
        }
    }
}
