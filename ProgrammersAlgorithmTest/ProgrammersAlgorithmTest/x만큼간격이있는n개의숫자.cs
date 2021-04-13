using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12954"/>
    [TestClass]
    public class x만큼간격이있는n개의숫자
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(2, 5), new long[] { 2, 4, 6, 8, 10 });
            CollectionAssert.AreEqual(solution(-2, 5), new long[] { -2, -4, -6, -8, -10 });
            CollectionAssert.AreEqual(solution(10000000, 3), new long[] { 10000000, 20000000, 30000000 });
            CollectionAssert.AreEqual(solution(-5, 1), new long[] { -5 });
            CollectionAssert.AreEqual(solution(-5, 1), new long[] { -5 });
        }

        /// <param name="x">-10,000,000 ~ 10,000,000</param>
        public long[] solution(int x, int n)
        {
            var answer = new long[n];

            for (long i = 0; i < n; i++)
                answer[i] = x * (i + 1);

            return answer;
        }
    }
}
