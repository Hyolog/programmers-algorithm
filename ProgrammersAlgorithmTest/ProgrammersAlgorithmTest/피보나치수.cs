using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12945"/>
    [TestClass]
    public class 피보나치수
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(3), 2);
            Assert.AreEqual(solution(5), 5);
        }

        /// <param name="n">1 ~ 100,000</param> -> O(NlogN)
        public int solution(int n)
        {
            var array = new int[n + 1];
            array[0] = 0;
            array[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                array[i] = array[i - 1] % 1234567 + array[i - 2] % 1234567;
            }

            return array[n] % 1234567;
        }
    }
}
