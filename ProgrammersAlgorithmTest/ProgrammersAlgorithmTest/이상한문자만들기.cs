//https://programmers.co.kr/learn/courses/30/lessons/12930

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    [TestClass]
    public class 이상한문자만들기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("try hello world"), "TrY HeLlO WoRlD");
            Assert.AreEqual(solution("I Hate You"), "I HaTe You");
        }

        public string solution(string s)
        {
            var index = 0;
            var result = "";

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    result += ' ';
                    index = 0;
                }
                else
                {
                    if (index % 2 == 0)
                    {
                        result += char.ToUpper(s[i]);
                    }
                    else
                    {
                        result += char.ToLower(s[i]);
                    }

                    index++;
                }
            }

            return result;
        }
    }
}
