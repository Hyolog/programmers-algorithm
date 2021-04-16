using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/76501"/>
    [TestClass]
    public class 음양더하기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 4, 7, 12 }, new bool[] { true, false, true }), 9);
        }
        public int solution(int[] absolutes, bool[] signs)
        {
            var sum = 0;

            for (int i = 0; i < absolutes.Length; i++)
            {
                var realNumber = absolutes[i];

                if (!signs[i])
                    realNumber = int.Parse($"-{absolutes[i]}");

                sum += realNumber;
            }

            return sum;
        }
    }
}
