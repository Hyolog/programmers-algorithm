using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12919"/>
    [TestClass]
    public class 서울에서김서방찾기
    {
        public string solution(string[] seoul)
        {
            var person = new List<string>(seoul);

            return $"김서방은 {person.IndexOf("Kim")}에 있다";
        }
    }
}
