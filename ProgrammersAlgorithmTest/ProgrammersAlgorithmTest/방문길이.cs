using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/49994"/>
    /// 좌표 + 구현문제에 어려움을 느끼는듯
    [TestClass]
    public class 방문길이
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("ULURRDLLU"), 7);
            Assert.AreEqual(solution("LULLLLLLU"), 7);
        }

        public class Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point Copy()
            {
                return new Point(X, Y);
            }

            public static bool operator ==(Point p1, Point p2)
            {
                return p1.X == p2.X && p1.Y == p2.Y ? true : false;
            }

            public static bool operator !=(Point p1, Point p2)
            {
                return p1.X == p2.X && p1.Y == p2.Y ? false : true;
            }
        }

        public class Line
        {
            public Point Start { get; set; }
            public Point End { get; set; }
        }

        public int solution(string dirs)
        {
            var visitedLines = new List<Line>();
            var currentPoint = new Point(0, 0);

            foreach (var dir in dirs)
            {
                var nextPoint = Move(currentPoint, dir);

                if (currentPoint == nextPoint)
                    continue;

                bool isFirstVisit = true;

                foreach (var visitedLine in visitedLines)
                {
                    if (visitedLine.Start == nextPoint && visitedLine.End == currentPoint)
                    {
                        isFirstVisit = false;
                        break;
                    }
                    else if (visitedLine.Start == currentPoint && visitedLine.End == nextPoint)
                    {
                        isFirstVisit = false;
                        break;
                    }
                }

                if (isFirstVisit)
                    visitedLines.Add(new Line() { Start = currentPoint.Copy(), End = nextPoint });

                currentPoint = nextPoint;
            }

            return visitedLines.Count;
        }

        public Point Move(Point point, char dir)
        {
            var newPoint = new Point(point.X, point.Y);

            switch (dir)
            {
                case 'U': if (newPoint.Y < 5) { newPoint.Y++; } break;
                case 'D': if (newPoint.Y > -5) { newPoint.Y--; } break;
                case 'L': if (newPoint.X > -5) { newPoint.X--; } break;
                case 'R': if (newPoint.X < 5) { newPoint.X++; } break;
                default: break;
            }

            return newPoint;
        }
    }
}
