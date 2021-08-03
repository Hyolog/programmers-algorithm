using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42883"/>
    /// TODO : 일부 테케 시간초과. 생각보다 어려웠음
    [TestClass]
    public class 큰수만들기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("1924", 2), "94");
            Assert.AreEqual(solution("1231234", 3), "3234");
            Assert.AreEqual(solution("4177252841", 4), "775841");
            Assert.AreEqual(solution("12", 1), "2");
            Assert.AreEqual(solution("789123", 3), "923");
            Assert.AreEqual(solution("123789", 3), "789");
            Assert.AreEqual(solution("12313524", 3), "33524");
            Assert.AreEqual(solution("987654321", 8), "9");
            Assert.AreEqual(solution("0592508", 4), "958");
            Assert.AreEqual(solution("0004", 2), "4");
        }

        /// <param name="number">1~100만</param>
        /// <param name="k">자연수(< number.length)</param>
        /// 어차피 string으로 리턴할꺼라 불필요 컨버팅 제거했음 Int.Parse(string)
        /// string += 보다 StringBuilder.Append가 빠르다.
        public string solution(string number, int k)
        {
            var result = new StringBuilder();
            var startIndex = 0;
            var endIndex = k;
            var selectedNumberIndex = 0;

            while (result.Length < number.Length - k)
            {
                char maxValue = '0';

                for (var i = startIndex; i <= endIndex; i++)
                {
                    var tempValue = number[i];

                    if (tempValue > maxValue)
                    {
                        maxValue = tempValue;
                        selectedNumberIndex = i;

                        if (maxValue == 9)
                            break;
                    }
                }

                result.Append(maxValue);
                startIndex = selectedNumberIndex + 1;
                endIndex++;
            }

            result.Append(number.Substring(endIndex));

            return result.ToString().TrimStart('0');
        }
    }
}
