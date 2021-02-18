// https://programmers.co.kr/learn/courses/30/lessons/42860
// 문제 논란이 좀 있어보임
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 조이스틱
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("JEROEN"), 56);
            Assert.AreEqual(solution("JAN"), 23);
            Assert.AreEqual(solution("AAAAA"), 0);
            Assert.AreEqual(solution("MMM"), 38);
            Assert.AreEqual(solution("NNN"), 41);
            Assert.AreEqual(solution("BBBAAAB"), 9);
        }

        // min = 가로 이동 min + 세로 이동 min
        // 가로 이동 min = 각 자리는 조작이 필요 하거나 없거나
        // 세로 이동 min = IF ( ? < 'M') ? (? - A), (Z - ? + 1) 
        public int solution(string name)
        {
            var rowCount = name.Length - 1;

            if (name.Contains('A'))
            {
                if (name.Length == name.Where(d => d == 'A').Count())
                    return 0;

                // 연속하는 A의 수를 구해서 돌아갈지 가던길 갈지 판단.
                for (var i = 0; i < name.Length; i++)
                {
                    if (name[i] == 'A')
                    {
                        var nextIndex = i + 1;
                        int countOfA = 0;

                        while (nextIndex < name.Length && name[nextIndex] == 'A')
                        {
                            countOfA++;
                            nextIndex++;
                        }

                        // 되돌아가는데 걸리는 횟수
                        var gap = (i - 1) * 2 + (name.Length - 1 - i - countOfA);

                        if (rowCount > gap)
                            rowCount = gap;
                    }
                }
            }

            var columnCount = 0;

            for (var i = 0; i < name.Length; i++)
            {
                if (name[i] < 'N')
                {
                    columnCount += (name[i] - 'A');
                }
                else
                {
                    columnCount += ('Z' - name[i] + 1);
                }
            }

            return rowCount + columnCount;
        }
    }
}
