using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/77884"/>
    [TestClass]
    public class 약수의개수와덧셈
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(13, 13), 13);
            Assert.AreEqual(solution(1, 1), -1);
        }

        public int solution(int left, int right)
        {
            var result = 0;

            for (int i = left; i <= right; i++)
            {
                if (GetNumberOfDivisors(i) % 2 == 0)
                {
                    result += i;
                }
                else
                {
                    result -= i;
                }
            }

            return result;
        }

        private int GetNumberOfDivisors(int number)
        {
            var result = 1;

            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
