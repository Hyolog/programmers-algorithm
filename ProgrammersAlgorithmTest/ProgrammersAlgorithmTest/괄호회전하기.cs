using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/76502"/>
    [TestClass]
    public class 괄호회전하기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("[](){}"), 3);
            Assert.AreEqual(solution("}]()[{"), 2);
            Assert.AreEqual(solution("[)(]"), 0);
            Assert.AreEqual(solution("}}}"), 0);
        }

        /// <param name="s">1~1,000</param>
        /// <returns></returns>
        public int solution(string s)
        {
            // O(n^2) 
            var answer = 0;
            var startIndex = 0;

            do
            {
                if (IsValidParenthesis(s, startIndex))
                    answer++;

                startIndex++;

                if (startIndex == s.Length)
                    startIndex = 0;
            }
            while (startIndex != 0);

            return answer;
        }

        private bool IsValidParenthesis(string parenthesis, int startIndex)
        {
            var itemList = new Stack<char>();

            for (int i = 0; i < parenthesis.Length; i++)
            {
                var index = startIndex + i;

                if (index >= parenthesis.Length)
                    index -= parenthesis.Length;

                if (itemList.TryPeek(out var top))
                {
                    if (IsOppositeParenthesis(top, parenthesis[index]))
                        itemList.Pop();
                    else if (parenthesis[index].Equals('(') || parenthesis[index].Equals('{') || parenthesis[index].Equals('['))
                        itemList.Push(parenthesis[index]);
                    else
                        return false;
                }
                else
                {
                    if (parenthesis[index].Equals('(') || parenthesis[index].Equals('{') || parenthesis[index].Equals('['))
                        itemList.Push(parenthesis[index]);
                    else
                        return false;
                }
            }

            return itemList.Count == 0;
        }

        private bool IsOppositeParenthesis(char item1, char item2)
        {
            switch (item1)
            {
                case '(': return item2.Equals(')') ? true : false;
                case ')': return item2.Equals('(') ? true : false;
                case '{': return item2.Equals('}') ? true : false;
                case '}': return item2.Equals('{') ? true : false;
                case '[': return item2.Equals(']') ? true : false;
                case ']': return item2.Equals('[') ? true : false;
            }

            throw new Exception("Invalid parameters");
        }
    }
}