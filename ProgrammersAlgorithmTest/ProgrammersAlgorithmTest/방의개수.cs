using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/49190"/>
    /// 기본 idea를 잘 생각했고 케어하지 못하는 부분에 대한 처리를 잘 추가했음
    /// Point, Line class Equals(), GetHashCode()를 재정의해서 Dictionary 키로 사용했음
    /// 이동을 int[] dX, int[] dY로 표현하고 vertex, edge를 HashSet을 사용해 다시한번 풀어보자
    [TestClass]
    public class 방의개수
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 6, 6, 2, 2 }), 0);
            Assert.AreEqual(solution(new int[] { 6, 6, 6, 4, 4, 4, 2, 2, 2, 0, 0, 0, 1, 6, 5, 5, 3, 6, 0 }), 3);
            Assert.AreEqual(solution(new int[] { 6, 4, 2, 0, 5 }), 2);
            // 방 중복
            Assert.AreEqual(solution(new int[] { 6, 4, 2, 0, 6, 4, 2, 0 }), 1);
            // 대각선
            Assert.AreEqual(solution(new int[] { 5, 2, 7 }), 1);
            Assert.AreEqual(solution(new int[] { 5, 2, 7, 5, 2, 7 }), 3);
            Assert.AreEqual(solution(new int[] { 5, 2, 7, 1, 6, 3 }), 3);
            // 대각선 + 방 중복
            Assert.AreEqual(solution(new int[] { 5, 2, 7, 2, 5, 2, 7 }), 2);
        }

        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }

            private bool Equals(Point point)
            {
                return point.X.Equals(X) && point.Y.Equals(Y);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Point);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }

        public class Line
        {
            public Line(Point point1, Point point2)
            {
                Point1 = point1;
                Point2 = point2;
            }

            public Point Point1 { get; set; }
            public Point Point2 { get; set; }

            public Line Copy()
            {
                return new Line(new Point(Point1.X, Point1.Y), new Point(Point2.X, Point2.Y));
            }

            private bool Equals(Line line)
            {
                return (line.Point1.Equals(Point1) && line.Point2.Equals(Point2)) || line.Point1.Equals(Point2) && line.Point2.Equals(Point1);
            }

            public override bool Equals(object obj)
            {
                return this.Equals(obj as Line);
            }

            public override int GetHashCode()
            {
                var orderedPoints = new[] { Point1, Point2 }.OrderBy(p => p != null ? p.X : 0).ThenBy(p => p != null ? p.Y : 0).ToList();
                var point1 = orderedPoints[0];
                var point2 = orderedPoints[1];

                return HashCode.Combine(point1, point2);
            }
        }

        // idea1) 특정 Point 재방문시 해당 Point의 마지막 방향과 재방문 방향을 비교해 서로 반대면 무시, 그 외에는 방 하나를 만든것으로 판단.
        // 반복해서 도는 케이스(6-4-2-0-6-4-2-0)는?
        // 기록한 Point&방향 비교하는 방식 대신 지나온 line인지 판단하는 방식으로 변경하면 커버 가능
        // x자 교점(5-2-7)은?
        // 대각선 고려하는 코드 추가
        public int solution(int[] arrows)
        {
            var countOfRooms = 0;
            // <위치, 마지막 방향>
            var visitPoints = new Dictionary<Point, int>();
            // <선, 미사용>
            var visitLines = new Dictionary<Line, bool>();
            var currentPoint = new Point(0, 0);

            // 시작 위치 추가, 방향은 아직 모르니 -1
            visitPoints.Add(currentPoint, -1);
            
            foreach (var arrow in arrows)
            {
                // 현재 위치 방향 기록
                visitPoints[currentPoint] = arrow;
                // 다음 위치 가져오기
                var nextPoint = GetNextPoint(currentPoint, arrow);
                // 길 생성
                var line = new Line(currentPoint, nextPoint);

                // 다음 위치가 재방문인 경우
                if (visitPoints.ContainsKey(nextPoint))
                {
                    // 새로운 길을 통해 방문한거라면
                    if (!visitLines.ContainsKey(line))
                    {
                        // 이동방향이 대각선일 경우 교점 체크해서 방 수++
                        if (IsMakeDiagonalIntersectionPoint(visitLines, line, arrow))
                            countOfRooms++;

                        // 방문기록
                        visitLines.Add(line, true);
                        // room 하나 완성했으니 count++
                        countOfRooms++;
                    }
                }
                else
                {
                    // 이동방향이 대각선일 경우 교점 체크해서 방 수++
                    if (IsMakeDiagonalIntersectionPoint(visitLines, line, arrow))
                        countOfRooms++;

                    // 방문 기록 추가
                    visitPoints.Add(nextPoint, -1);
                    visitLines.Add(line, true);
                }

                currentPoint = nextPoint;
            }

            return countOfRooms;
        }

        private Point GetNextPoint(Point currentPoint, int arrow)
        {
            var nextPoint = new Point(currentPoint.X, currentPoint.Y);

            switch (arrow)
            {
                case 0: nextPoint.Y++; break;
                case 1: nextPoint.X++; nextPoint.Y++; break;
                case 2: nextPoint.X++; break;
                case 3: nextPoint.X++; nextPoint.Y--; break;
                case 4: nextPoint.Y--; break;
                case 5: nextPoint.X--; nextPoint.Y--; break;
                case 6: nextPoint.X--; break;
                case 7: nextPoint.X--; nextPoint.Y++; break;
            }

            return nextPoint;
        }

        private bool IsOpposite(int firstArrow, int secondArrow)
        {
            switch (firstArrow)
            {
                case 0: return secondArrow == 4;
                case 1: return secondArrow == 5;
                case 2: return secondArrow == 6;
                case 3: return secondArrow == 7;
                case 4: return secondArrow == 0;
                case 5: return secondArrow == 1;
                case 6: return secondArrow == 2;
                case 7: return secondArrow == 3;
            }

            throw new Exception("Invalid case exception");
        }

        private bool IsDiagonal(int arrow)
        {
            return arrow == 1 || arrow == 3 || arrow == 5 || arrow == 7;
        }

        private Line GetOppositeDiagonal(Line line)
        {
            var oppositeDiagonalLine = line.Copy();

            if (oppositeDiagonalLine.Point1.X < oppositeDiagonalLine.Point2.X)
            {
                oppositeDiagonalLine.Point1.X++;
                oppositeDiagonalLine.Point2.X--;
            }
            else
            {
                oppositeDiagonalLine.Point1.X--;
                oppositeDiagonalLine.Point2.X++;
            }

            return oppositeDiagonalLine;
        }

        private bool IsMakeDiagonalIntersectionPoint(Dictionary<Line, bool> visitLines, Line line, int arrow)
        {
            if (IsDiagonal(arrow))
            {
                var oppositeDiagonalLine = GetOppositeDiagonal(line);

                return visitLines.ContainsKey(oppositeDiagonalLine);
            }
            else
                return false;
        }
    }
}
