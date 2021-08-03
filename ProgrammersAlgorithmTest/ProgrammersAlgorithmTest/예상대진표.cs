using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12985"/>
    [TestClass]
    public class 예상대진표
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(8, 4, 7), 3);
        }

        /// <param name="n">2^1 ~ 2^20</param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int solution(int n, int a, int b)
        {
            // unit으로 나누어 떨어지게 하기위해 0부터 시작하도록 값을 1씩 빼준다.
            a -= 1;
            b -= 1;
            var result = 0;
            var unit = 1;

            while (true)
            {
                var groupA = a / unit;
                var groupB = b / unit;

                if (groupA == groupB)
                    break;

                result++;
                unit *= 2;
            }

            return result;
        }
    }
}
