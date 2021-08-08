using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42746"/>
    /// DONE : 참고한 풀이. 다시한번 보면 좋을듯
    [TestClass]
    public class 가장큰수
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 0, 0 }), "0");
            Assert.AreEqual(solution(new int[] { 6, 10, 2 }), "6210");
            Assert.AreEqual(solution(new int[] { 3, 30, 34, 5, 9 }), "9534330");
        }

        /// <param name="numbers">1~100,000</param>
        public string solution(int[] numbers)
        {
            var nums = numbers.Select(d => d.ToString()).ToArray();

            Array.Sort(nums, (x, y) => string.Compare(y + x, x + y));

            return nums[0] == "0" ? "0" : string.Join("", nums);
        }
    }
}
