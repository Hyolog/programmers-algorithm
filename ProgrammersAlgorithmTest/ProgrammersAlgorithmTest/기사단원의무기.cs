using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/136798?language=csharp"/>
    [TestClass]
    public class 기사단원의무기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(5, 3, 2), 10);
            Assert.AreEqual(solution(10, 3, 2), 21);
        }

        public int solution(int number, int limit, int power)
        {
            var result = 0;

            for (int i = 1; i <= number; i++)
            {
                var p = GetNumberOfDivisor(i);

                if (p > limit)
                    p = power;

                result += p;
            }

            return result;
        }

        public int GetNumberOfDivisor(int number)
        {
            var result = 0;

            for (int i = 1; i * i <= number; i++)
            {
                if (i * i == number)
                    result++;
                else if (number % i == 0)
                    result += 2;
            }

            return result;
        }
    }
}
