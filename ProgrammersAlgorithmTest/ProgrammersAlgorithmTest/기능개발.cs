using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42586"/>
    [TestClass]
    public class 기능개발
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 93, 30, 55 }, new int[] { 1, 30, 5 }), new int[] { 2, 1 });
        }

        public int[] solution(int[] progresses, int[] speeds)
        {
            var result = new List<int>();
            var progressList = progresses.ToList();

            var index = 0;

            while (true)
            {
                // Do work
                for (var i = index; i < progressList.Count; i++)
                {
                    progressList[i] += speeds[i];
                }

                var countOfCompleteTask = 0;

                // Check complete tasks
                while (true)
                {
                    if (index == progressList.Count)
                    {
                        break;
                    }

                    if (progressList[index] >= 100)
                    {
                        countOfCompleteTask++;
                        index++;
                    }
                    else
                    {
                        break;
                    }
                }

                // Release
                if (countOfCompleteTask > 0)
                {
                    result.Add(countOfCompleteTask);
                }

                // Done
                if (index == progressList.Count)
                {
                    return result.ToArray();
                }
            }
        }
    }
}
