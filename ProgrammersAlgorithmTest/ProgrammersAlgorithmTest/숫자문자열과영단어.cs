using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/81301?language=csharp"/>
    [TestClass]
    public class 숫자문자열과영단어
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("one4seveneight"), 1478);
            Assert.AreEqual(solution("23four5six7"), 234567);
        }

        public int solution(string s)
        {
            var numberWorldMappingInfo = new Dictionary<string, int>()
            { 
                ["zero"] = 0,
                ["one"] = 1,
                ["two"] = 2,
                ["three"] = 3,
                ["four"] = 4,
                ["five"] = 5,
                ["six"] = 6,
                ["seven"] = 7,
                ["eight"] = 8,
                ["nine"] = 9
            };

            string result = "";
            string tempWord = "";
            int tempIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                    result += s[i];
                else
                {
                    if (result.Length == 0)
                        tempIndex = i;

                    tempWord += s[i];

                    if (numberWorldMappingInfo.TryGetValue(tempWord, out var number))
                    {
                        result += number;
                        tempWord = "";
                        tempIndex = 0;
                    }
                }
            }

            return int.Parse(result);
        }
    }
}
