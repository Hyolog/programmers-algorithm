using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42587"/>
    [TestClass]
    public class 프린터
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 2, 1, 3, 2 }, 2), 1);
            Assert.AreEqual(solution(new int[] { 1, 1, 9, 1, 1, 1 }, 0), 5);
        }

        public int solution(int[] priorities, int location)
        {
            int answer = 0;
            var maxPriority = priorities.Max();
            int index = 0;

            var prioritiesQueue = new Queue<KeyValuePair<int, int>>();

            foreach (var priority in priorities)
            {
                prioritiesQueue.Enqueue(new KeyValuePair<int, int>(index, priority));
                index++;
            }


            while (prioritiesQueue.TryPeek(out var peek))
            {
                if (peek.Value < maxPriority)
                { 
                    prioritiesQueue.Dequeue();
                    prioritiesQueue.Enqueue(peek);
                }
                else
                {
                    if (peek.Key == location)
                    {
                        return ++answer;
                    }
                    else
                    {
                        prioritiesQueue.Dequeue();
                        answer++;
                        maxPriority = prioritiesQueue.Select(d => d.Value).Max();
                    }
                }
            }

            throw new Exception("Input Error");
        }
    }
}
