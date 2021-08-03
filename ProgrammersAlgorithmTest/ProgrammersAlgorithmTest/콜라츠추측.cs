using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12943"/>
    /// TODO : 다시 풀어보기
    [TestClass]
    public class 콜라츠추측
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(6), 8);
            Assert.AreEqual(solution(16), 4);
            Assert.AreEqual(solution(626331), -1);
        }

        public int solution(int num)
        {
            var count = 0;
            long number = num;

            while (count < 500)
            {
                if (number == 1)
                    return count;

                number = GetNextNumber(number);
                
                count++;
            }

            return -1;
        }

        private long GetNextNumber(long number)
        {
            if (number % 2 == 0)
                return number / 2;
            else
                return (number * 3) + 1;
        }
    }
}
