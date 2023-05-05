using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/154540"/>
    [TestClass]
    public class 무인도여행
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new string[] { "X591X", "X1X5X", "X231X", "1XXX1" }), new int[] { 1, 1, 27 });
            CollectionAssert.AreEqual(solution(new string[] { "XXX", "XXX", "XXX" }), new int[] { -1 });
        }

        public int[] solution(string[] maps)
        {
            List<int> answer = new List<int>();
            bool[,] visited = new bool[maps.Length, maps[0].Length];
            int tempValue = 0;

            for (var x = 0; x < maps.Length; x++, tempValue = 0)
            {
                for (var y = 0; y < maps[x].Length; y++)
                {
                    tempValue = VisitCheck(new Point(x, y), maps, ref visited);

                    if (tempValue > 0)
                    {
                        answer.Add(tempValue);
                    }
                }
            }

            answer.Sort();

            return answer.Count == 0 ? new int[1] { -1 } : answer.ToArray();
        }

        class Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public bool IsValid(string[] maps)
            {
                return X >= 0 && Y >= 0 && X <= maps.Length - 1 && Y <= maps[0].Length - 1;
            }
        }

        private static int VisitCheck(Point point, string[] maps, ref bool[,] visited)
        {
            if (!point.IsValid(maps))
                return 0;
            else if (visited[point.X, point.Y])
                return 0;
            else if (maps[point.X][point.Y].Equals('X'))
                return 0;
            else
            {
                visited[point.X, point.Y] = true;

                return maps[point.X][point.Y].Equals('X') ? 0 : int.Parse(maps[point.X][point.Y].ToString())
                    + VisitCheck(new Point(point.X - 1, point.Y), maps, ref visited)
                    + VisitCheck(new Point(point.X + 1, point.Y), maps, ref visited)
                    + VisitCheck(new Point(point.X, point.Y - 1), maps, ref visited)
                    + VisitCheck(new Point(point.X, point.Y + 1), maps, ref visited);
            }
        }
    }
}