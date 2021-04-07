using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42628"/>
    [TestClass]
    public class 이중순위우선큐
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new string[] { "I 16", "D 1" }), new int[] { 0, 0 });
            CollectionAssert.AreEqual(solution(new string[] { "I 7", "I 5", "I -5", "D -1" }), new int[] { 7, 5 });
            //critical point, 없는데 지우려 하는 케이스
            CollectionAssert.AreEqual(solution(new string[] { "I 16", "I -5643", "D -1", "D 1", "D 1", "I 123", "D -1" }), new int[] { 0, 0 });
            CollectionAssert.AreEqual(solution(new string[] { "I -45", "I 653", "D 1", "I -642", "I 45", "I 97", "D 1", "D -1", "I 333" }), new int[] { 333, -45 });
        }

        /// <param name="operations">1~1,000,000</param>
        /// O(nlogn)으로 끊어야할듯
        public int[] solution(string[] operations)
        {
            var list = new List<int>();

            foreach (var operation in operations)
            {
                var split = operation.Split(' ');
                var command = split[0];
                var number = split[1];

                if (command.Equals("I"))
                {
                    list.Add(int.Parse(number));
                }
                else if (command.Equals("D"))
                {
                    if (list.Count == 0)
                        continue;

                    var index = 0;

                    if (number == "1")
                    {
                        var tempMaxValue = int.MinValue;
                        
                        // get max value index
                        for (var i = 0; i < list.Count; i++)
                        {
                            var tempNumber = list[i];

                            if (tempNumber > tempMaxValue)
                            {
                                tempMaxValue = tempNumber;
                                index = i;
                            }
                        }

                        // and delete it
                        list.RemoveAt(index);
                    }
                    else if (number == "-1")
                    {
                        var tempMinValue = int.MaxValue;

                        // get min value index
                        for (var i = 0; i < list.Count; i++)
                        {
                            var tempNumber = list[i];

                            if (tempNumber < tempMinValue)
                            {
                                tempMinValue = tempNumber;
                                index = i;
                            }
                        }

                        // and delete it
                        list.RemoveAt(index);
                    }
                }
            }

            if (list.Count == 0)
                return new int[] { 0, 0 };
            else
                return new int[] { list.Max(), list.Min() };
        }
    }
}
