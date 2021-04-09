using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12948"/>
    [TestClass]
    public class 핸드폰번호가리기
    {
        [TestMethod]
        public void Test()
        {

        }

        public string solution(string phone_number)
        {
            var tempPhoneNumber = new StringBuilder(phone_number);

            for (var i = 0; i < phone_number.Length - 4; i++)
                tempPhoneNumber[i] = '*';

            return tempPhoneNumber.ToString();
        }
    }
}
