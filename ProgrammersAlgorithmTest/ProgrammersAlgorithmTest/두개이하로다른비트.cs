using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/77885"/>
    [TestClass]
    public class 두개이하로다른비트
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new long[] { 2 }), new long[] { 3 });
            CollectionAssert.AreEqual(solution(new long[] { 7 }), new long[] { 11 });
            CollectionAssert.AreEqual(solution(new long[] { 11 }), new long[] { 13 });
        }

        public long[] solution(long[] numbers)
        {
            var result = new long[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = GetMinValue(numbers[i]);
            }

            return result;
        }

        private long GetMinValue(long number)
        {
            // case1 : 짝수
            if (number % 2 == 0)
            {
                return number + 1;
            }

            var binary = Convert.ToString(number, 2);
            var lastIndex = binary.Length - 1;

            // case2 : binary가 0을 포함한 경우
            for (var i = lastIndex; i >= 0; i--)
            {
                if (binary[i].Equals('0'))
                {
                    return number + (long)Math.Pow(2, lastIndex - i - 1);
                }
            }

            // case3 : binray가 0을 포함하지 않은 경우
            var length = binary.Length;

            return number + (long)Math.Pow(2, length - 1);
        }

        // 나중에 참고해볼 다른사람 풀이
        public long[] solution2(long[] numbers)
        {
            long[] answer = new long[numbers.Length];
            
            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = ((numbers[i] ^ (numbers[i] + 1)) >> 2) + numbers[i] + 1;
            
            }
            return answer;
        }
    }
}
