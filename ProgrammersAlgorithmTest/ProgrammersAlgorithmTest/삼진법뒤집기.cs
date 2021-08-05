using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/68935"/>
    /// DONE : Lv1 치고 어렵다.
    [TestClass]
    public class 삼진법뒤집기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(45), 7);
        }

        public int solution(int n)
        {
            var ternaryString = new StringBuilder();

            var portion = n;

            while (portion > 0)
            {
                var rest = portion % 3;
                portion = portion / 3;

                ternaryString.Append(rest);
            }

            var ternary = new string(ternaryString.ToString().Reverse().ToArray());

            var result = 0;

            for (int i = 0; i < ternary.Length; i++)
            {
                result += (int)char.GetNumericValue(ternary[i]) * (int)Math.Pow(3, i);
            }

            return result;
        }
    }
}
