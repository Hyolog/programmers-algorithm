using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/154539"/>
    [TestClass]
    public class 뒤에있는큰수찾기
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 2, 3, 3, 5 }), new int[] { 3, 5, 5, -1 });
            CollectionAssert.AreEqual(solution(new int[] { 9, 1, 5, 3, 6, 2 }), new int[] { -1, 5, 6, 6, -1, -1 });
        }

        public int[] solution(int[] numbers)
        {
            int[] answer = new int[numbers.Length];
            Stack<int> stack = new Stack<int>();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= numbers[i])
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    answer[i] = stack.Peek();
                }
                else
                {
                    answer[i] = -1;
                }

                stack.Push(numbers[i]);
            }

            return answer;
        }
    }
}
