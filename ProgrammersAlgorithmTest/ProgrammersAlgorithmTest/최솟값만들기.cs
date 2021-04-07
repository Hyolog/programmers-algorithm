using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12941"/>
    [TestClass]
    public class 최솟값만들기
    {
        [TestMethod]
        public void Test()
        {

        }

        public int solution(int[] A, int[] B)
        {
            var firstList = A.OrderByDescending(d => d).ToArray();
            var secondList = B.OrderBy(d => d).ToArray();
            var result = 0;

            for (var i = 0; i < firstList.Count(); i++)
                result += firstList[i] * secondList[i];

            return result;
        }
    }
}
