using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/87389"/>
    [TestClass]
    public class 나머지가1이되는수찾기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(10), 3);
            Assert.AreEqual(solution(12), 11);
        }

        public int solution(int n)
        {
            for (int i = 2; i < n; i++)
                if (n % i == 1)
                    return i;

            return -1;
        }
    }
}
