using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/85002"/>
    /// TODO : LV1 문제 맞아? 신경쓸 포인트가 좀 있다.
    [TestClass]
    public class 복서정렬하기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 50, 82, 75, 120 }, new string[] { "NLWL", "WNLL", "LWNW", "WWLN" }), new int[] { 3, 4, 1, 2 });
            CollectionAssert.AreEqual(solution(new int[] { 145, 92, 86 }, new string[] { "NLW", "WNL", "LWN" }), new int[] { 2, 3, 1 });
            CollectionAssert.AreEqual(solution(new int[] { 60, 70, 60 }, new string[] { "NNN", "NNN", "NNN" }), new int[] { 2, 1, 3 });
            CollectionAssert.AreEqual(solution(new int[] { 60, 70}, new string[] { "NW", "LN" }), new int[] { 1, 2 });
        }

        public class Boxer
        {
            public Boxer(int number, int weight)
            {
                Number = number;
                Weight = weight;
            }

            public int Number { get; set; }
            public double WinningRatio { get; set; }
            // More Heavier Boxer
            public int WinningCount { get; set; }
            public int Weight { get; set; }
        }

        public int[] solution(int[] weights, string[] head2head)
        {
            var boxerList = new List<Boxer>();

            for (int i = 0; i < weights.Length; i++)
            {
                var boxer = new Boxer(i + 1, weights[i]);

                var matchResult = head2head[i];

                var countOfValidMatch = matchResult.Count() - matchResult.Count(d => d.Equals('N'));

                boxer.WinningRatio = countOfValidMatch == 0 ? 0 : (double)(matchResult.Count(d => d.Equals('W')) * 100) / (double)countOfValidMatch;

                for (int j = 0; j < matchResult.Length; j++)
                {
                    var result = matchResult[j];

                    if (result.Equals('W') && weights[i] < weights[j])
                        boxer.WinningCount++;
                }

                boxerList.Add(boxer);
            }

            return boxerList.OrderByDescending(d => d.WinningRatio).ThenByDescending(d => d.WinningCount).ThenByDescending(d => d.Weight).ThenBy(d => d.Number).Select(d => d.Number).ToArray();
        }
    }
}
