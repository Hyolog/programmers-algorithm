using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/68646"/>
    [TestClass]
    public class 풍선터트리기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 9, -1, -5 }), 3);
            Assert.AreEqual(solution(new int[] { -16, 27, 65, -2, 58, -92, -71, -68, -61, -33 }), 6);
            Assert.AreEqual(solution(new int[] { -10, -6, -7, -3, 10, -1 }), 4);
        }

        /// <param name="a">1~1,000,000 (item : -1,000,000,000~1,000,000,000, 중복x)</param>
        public int solution(int[] a)
        {
            var answer = 2;
            var leftMinHistory = new int[a.Length];
            var rightMinHistory = new int[a.Length];
            var leftMin = int.MaxValue;
            var rightMin = int.MaxValue;

            // O(2n)
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] < leftMin)
                    leftMin = a[i];

                leftMinHistory[i] = leftMin;

                if (a[a.Length - 1 - i] < rightMin)
                    rightMin = a[a.Length - 1 - i];

                rightMinHistory[a.Length - 1 - i] = rightMin;
            }

            // O(n)
            for (var i = 1; i < a.Length - 1; i++)
            {
                if (a[i] > leftMinHistory[i - 1] && a[i] > rightMinHistory[i + 1])
                    continue;

                answer++;
            }

            return answer;
        }
    }
}
