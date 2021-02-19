//https://programmers.co.kr/learn/courses/30/lessons/12935

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 제일작은수제거하기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 4, 3, 2, 1 }), new int[] { 4, 3, 2 });
            CollectionAssert.AreEqual(solution(new int[] { 3 }), new int[] { -1 });
            CollectionAssert.AreEqual(solution(new int[] { 3 }), new int[] { -1 });
        }

        public int[] solution(int[] arr)
        {
            var min = arr.Min();

            return arr.Length == 1 ? new int[] { -1 } : arr.Where(d => d != min).ToArray();
        }
    }
}
