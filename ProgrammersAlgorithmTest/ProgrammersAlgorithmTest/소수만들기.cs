using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12977?language=csharp"/>
    [TestClass]
    public class 소수만들기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 1, 2, 3, 4 }), 1);
            Assert.AreEqual(solution(new int[] { 1, 2, 7, 6, 4 }), 4);
        }

        /// <param name="nums">length : 1~50</param>
        public int solution(int[] nums)
        {
            var answer = 0;
            
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        var number = nums[i] + nums[j] + nums[k];
                        if (IsPrime(number))
                            answer++;
                    }
                }
            }

            return answer;
        }

        private bool IsPrime(int number)
        {
            if (number == 1)
                return false;
            else if (number == 2)
                return true;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
    }
}
