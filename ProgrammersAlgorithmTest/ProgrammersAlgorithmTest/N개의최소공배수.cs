using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12953"/>
    [TestClass]
    public class N개의최소공배수
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 2, 6, 8, 14 }), 168);
            Assert.AreEqual(solution(new int[] { 1, 2, 3 }), 6);
        }

        public int solution(int[] arr)
        {
            var answer = arr[0];

            for (var i = 1; i < arr.Length; i++)
                answer = GetLCM(answer, arr[i]);

            return answer;
        }

        private int GetLCM(int number1, int number2)
        {
            var tempNumber1 = number1;
            var tempNumber2 = number2;

            while (tempNumber1 != tempNumber2)
            {
                if (tempNumber1 < tempNumber2)
                    tempNumber1 += number1;
                else if (tempNumber1 > tempNumber2)
                    tempNumber2 += number2;
            }

            return tempNumber1;
        }
    }
}
