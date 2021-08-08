using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/49994"/>
    /// DONE : 좌표 + 구현문제에 어려움을 느끼는듯
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
            public int X { get; set; }
            public int Y { get; set; }
            public bool UpSideLine { get; set; }
            public bool DownSideLine { get; set; }
            public bool LeftSideLine { get; set; }
            public bool RightSideLine { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                if (obj is Point)
                {
                    var point = obj as Point;

                    return point.X.Equals(X) && point.Y.Equals(Y);
                }

                return false;
            }

            public override int GetHashCode()
            {
                return System.HashCode.Combine(X, Y);
            }

            public bool IsValid()
            {
                return X >= -5 && X <= 5 && Y >= -5 && Y <= 5;
            }
        }

        public Point MakeNextPoint(Point currentPoint, char direction)
        {
            switch (direction)
            {
                case 'U': return new Point(currentPoint.X, currentPoint.Y + 1);
                case 'D': return new Point(currentPoint.X, currentPoint.Y - 1);
                case 'L': return new Point(currentPoint.X - 1, currentPoint.Y);
                case 'R': return new Point(currentPoint.X + 1, currentPoint.Y);
                default: throw new System.Exception("Invalid Direction.");
            }
        }

        public int solution(string dirs)
        {
            // key Point -> 한 점에 연결할 수 있는 선은 최대 4개
            var distinctStepCount = 0;
            var visitedPoints = new HashSet<Point>();
            var currentPoint = new Point(0, 0);
            visitedPoints.Add(currentPoint);

            foreach (var direction in dirs)
            {
                var nextPoint = MakeNextPoint(currentPoint, direction);

                if (!nextPoint.IsValid())
                    continue;

                // 방문 기록 있으면 업데이트
                if (visitedPoints.Contains(nextPoint))
                    visitedPoints.TryGetValue(nextPoint, out nextPoint);

                switch (direction)
                {
                    case 'U':
                        {
                            if (!currentPoint.UpSideLine)
                            {
                                currentPoint.UpSideLine = true;
                                nextPoint.DownSideLine = true;
                                distinctStepCount++;
                            }
                        } break;
                    case 'D':
                        {
                            if (!currentPoint.DownSideLine)
                            {
                                currentPoint.DownSideLine = true;
                                nextPoint.UpSideLine = true;
                                distinctStepCount++;
                            }
                        } break;
                    case 'L':
                        {
                            if (!currentPoint.LeftSideLine)
                            {
                                currentPoint.LeftSideLine = true;
                                nextPoint.RightSideLine = true;
                                distinctStepCount++;
                            }
                        } break;
                    case 'R':
                        {
                            if (!currentPoint.RightSideLine)
                            {
                                currentPoint.RightSideLine = true;
                                nextPoint.LeftSideLine = true;
                                distinctStepCount++;
                            }
                        } break;
                    default: break;
                }

                currentPoint = nextPoint;
                visitedPoints.Add(currentPoint);
            }

            return distinctStepCount;
        }
    }
}
