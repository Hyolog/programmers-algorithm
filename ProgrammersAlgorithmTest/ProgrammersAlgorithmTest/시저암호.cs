using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12926"/>
    [TestClass]
    public class 시저암호
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("AB", 1), "BC");
            Assert.AreEqual(solution("z", 1), "a");
            Assert.AreEqual(solution("a B z", 4), "e F d");
            Assert.AreEqual(solution("  ", 25), "  ");
            Assert.AreEqual(solution("abcde", 5), "fghij");
            Assert.AreEqual(solution("vwxyz", 5), "abcde");
            Assert.AreEqual(solution(" A a ", 25), " Z z ");
            Assert.AreEqual(solution("Z", 10), "J");
            Assert.AreEqual(solution("y X Z", 4), "c B D");
        }

        // Pseudocode
        // 입력받은 string 돌면서
        // 공백처리
        // int로 형변환 및 덧샘
        // 오버플로우 처리
        // char로 형변환
        // 병합 후 리턴
        public string solution(string s, int n)
        {
            var result = "";

            foreach (var item in s)
            {
                if (item == ' ')
                {
                    result += " ";
                    continue;
                }

                var num = Convert.ToInt32(item);

                if (num > 96)
                {
                    num += n;

                    if (num > 122)
                        num -= 26;
                }
                else
                {
                    num += n;

                    if (num > 90)
                        num -= 26;
                }

                var alphabet = Convert.ToChar(num);

                result += alphabet;
            }

            return result;
        }
    }
}
