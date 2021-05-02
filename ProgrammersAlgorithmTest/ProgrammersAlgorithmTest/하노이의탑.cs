using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/12946"/>
    [TestClass]
    public class 하노이의탑
    {
        Hashtable sticks = new Hashtable();
        List<KeyValuePair<int, int>> moveHistory = new List<KeyValuePair<int, int>>();

        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(2), new int[,] { { 1, 2 }, { 1, 3 }, { 2, 3 } });
        }

        public int[,] solution(int n)
        {
            var stick1 = new Stack<int>();
            var stick2 = new Stack<int>();
            var stick3 = new Stack<int>();
            sticks[stick1] = 1;
            sticks[stick2] = 2;
            sticks[stick3] = 3;

            for (int i = n; i > 0; i--)
                stick1.Push(i);

            MoveDisk(stick1, stick3, stick2, stick1.Count);

            var answer = new int[moveHistory.Count, 2];

            for (int i = 0; i < moveHistory.Count; i++)
            {
                answer[i, 0] = moveHistory[i].Key;
                answer[i, 1] = moveHistory[i].Value;
            }

            return answer;
        }

        private void MoveDisk(Stack<int> from, Stack<int> to, Stack<int> temp, int countOfDisk)
        {
            if (countOfDisk <= 0)
                return;
            if (countOfDisk == 1)
            {
                var disk = from.Pop();
                to.Push(disk);
                moveHistory.Add(new KeyValuePair<int, int>((int)sticks[from], (int)sticks[to]));
                return;
            }

            MoveDisk(from, temp, to, countOfDisk - 1);
            MoveDisk(from, to, temp, 1);
            MoveDisk(temp, to, from, countOfDisk - 1);
        }
    }
}
