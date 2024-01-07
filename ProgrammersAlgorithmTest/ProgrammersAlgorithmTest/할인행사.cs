using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/131127?language=csharp"/>
    [TestClass]
    public class 할인행사
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new string[] { "banana", "apple", "rice", "pork", "pot" }, new int[] { 3, 2, 2, 2, 1 }, 
                new string[] { "chicken", "apple", "apple", "banana", "rice", "apple", "pork", "banana", "pork", "rice", "pot", "banana", "apple", "banana" }), 3);
            Assert.AreEqual(solution(new string[] { "apple" }, new int[] { 10 },
                new string[] { "banana", "banana", "banana", "banana", "banana", "banana", "banana", "banana", "banana", "banana" }), 0);
        }

        public int solution(string[] want, int[] number, string[] discount)
        {
            var result = 0;

            for (int i = 0; i < discount.Length - 9; i++)
            {
                var discountList = discount.Skip(i).Take(10).ToList();
                if (IsValid(want, number, discountList))
                    result++;
            }

            return result;
        }

        private bool IsValid(string[] want, int[] number, List<string> discountList)
        {
            for (var i = 0; i < want.Length; i++)
            {
                for (int j = 0; j < number[i]; j++)
                {
                    if (discountList.Contains(want[i]))
                        discountList.Remove(want[i]);
                    else
                        return false;
                }
            }

            return true;
        }
    }
}
