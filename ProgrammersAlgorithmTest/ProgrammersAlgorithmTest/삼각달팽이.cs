using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/68645"/>
    [TestClass]
    public class 삼각달팽이
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(1), new int[] { 1 });
            CollectionAssert.AreEqual(solution(4), new int[] { 1, 2, 9, 3, 10, 8, 4, 5, 6, 7 });
            CollectionAssert.AreEqual(solution(5), new int[] { 1, 2, 12, 3, 13, 11, 4, 14, 15, 10, 5, 6, 7, 8, 9 });
            CollectionAssert.AreEqual(solution(6), new int[] { 1, 2, 15, 3, 16, 14, 4, 17, 21, 13, 5, 18, 19, 20, 12, 6, 7, 8, 9, 10, 11 });
        }

        public int[] solution(int n)
        {
            var result = new List<int>();
            var rows = new int[n][];

            for (int i = 0; i < n; i++)
            {
                rows[i] = new int[i + 1];
            }

            int x = 0;
            int y = 0;
            var number = 1;
            int sum = 0;

            for (var i = 1; i <= n; i++)
            {
                sum += i;
            }

            while (true)
            {
                // 좌측하향 이동
                while (true)
                {
                    if (y >= n || (rows[y][x]) != 0)
                    {
                        y--;

                        x++;
                        break;
                    }

                    rows[y][x] = number++; 
                    
                    y++;
                }

                // 우측 이동
                while (true)
                {
                    if (x >= n || (rows[y][x]) != 0)
                    {
                        x--;

                        x--;
                        y--;
                        break;
                    }

                    rows[y][x] = number++;

                    x++;
                }

                // 좌측상향 이동
                while (true)
                {
                    if (x < 0 || y < 0 || (rows[y][x]) != 0)
                    {
                        x++;
                        y++;

                        y++;
                        break;
                    }

                    rows[y][x] = number++;

                    x--;
                    y--;
                }

                // Done
                if (number > sum)
                {
                    foreach (var row in rows)
                    {
                        foreach (var item in row)
                            result.Add(item);
                    }

                    return result.ToArray();
                }
            }
        }
    }
}
