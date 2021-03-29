using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/43236"/>
    [TestClass]
    public class 징검다리
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(25, new int[] { 2, 14, 11, 21, 17 }, 1), 3);
            Assert.AreEqual(solution(25, new int[] { 2, 14, 11, 21, 17 }, 2), 4);
            Assert.AreEqual(solution(25, new int[] { 2, 14, 11, 21, 17 }, 3), 6);
            Assert.AreEqual(solution(25, new int[] { 2, 14, 11, 21, 17 }, 4), 11);
            Assert.AreEqual(solution(25, new int[] { 2, 14, 11, 21, 17 }, 5), 25);

            Assert.AreEqual(solution(100, new int[] { 1 }, 1), 100);
            Assert.AreEqual(solution(100, new int[] { 0, 100 }, 1), 0);
            Assert.AreEqual(solution(100, new int[] { 0, 100 }, 2), 100);
            Assert.AreEqual(solution(100, new int[] { 0, 50, 100 }, 1), 0);
            Assert.AreEqual(solution(100, new int[] { 0, 50, 100 }, 2), 50);
            Assert.AreEqual(solution(100, new int[] { 0, 50, 100 }, 3), 100);

            Assert.AreEqual(solution(1000000000, new int[] { 10, 100, 1000, 10000, 100000 }, 3), 10000);
            Assert.AreEqual(solution(1000000000, new int[] { 5, 10, 15, 20, 25 }, 3), 10);
            Assert.AreEqual(solution(1000000000, new int[] { 5, 10, 15, 20, 25 }, 4), 25);
            Assert.AreEqual(solution(1000000000, new int[] { 5, 10, 15, 20, 25 }, 5), 1000000000);
        }

        /// <param name="distance">1 ~ 10억</param>
        /// <param name="rocks">1~50000</param>
        /// <param name="n">1~rocks.Count</param>
        public int solution(int distance, int[] rocks, int n)
        {
            // case1) 10억, 5만개, 2만개 -> 얘만봐도 다 해볼 순 없다. -> 구현문제 아님
            // 다 제거하면 정답은 distancs
            // n개를 잘 제거해서 거리의 최솟값이 최대가 되도록 하는 n 집합을 찾아보자
            // -> 두 바위 사이가 가장 가까운 애들 중 어떠한 방법(A)으로 둘중 하나를 제거해 최소가 되는 거리를 없애가보자
            // rocks 돌면서 바위사이거리 저장(array1) 0(rocks.Count)
            // array1 돌면서 가장 작은거 찾아 방법A로 제거 O(rocks.Count)
            // n번 반복
            // A = 양쪽 거리중 거리가 더 작은쪽의 돌을 제거하 최솟값을 올려주는 쪽으로 수정

            var rockList = new List<int>(rocks).OrderBy(d => d).ToList();
            var distancesBetweenRocks = new int[rocks.Length + 1];
            var indexHistory = new int[rocks.Length + 1];
            var previousPoint = 0;

            // rocks 돌면서 바위사이거리 저장
            for (var i = 0; i < rocks.Length; i++)
            {
                distancesBetweenRocks[i] = rockList[i] - previousPoint;
                previousPoint = rockList[i];
            }
            distancesBetweenRocks[rocks.Length] = distance - previousPoint;

            // 바위사이거리배열 돌면서 거리 가장 작은거 찾아 방법A로 제거 O(rocks.Count)
            for (var i = 0; i < n; i++)
            {
                var minDistancesIndex = Array.IndexOf(distancesBetweenRocks, distancesBetweenRocks.Min());

                var leftIndex = minDistancesIndex;
                var rightIndex = minDistancesIndex;
                // 오른쪽만 보면 되거나 왼쪽만 보면 되는 케이스 체크용
                bool doLeft = false;
                bool doRight = false;
                
                if (minDistancesIndex == 0)
                    doRight = true;
                else if (minDistancesIndex == rocks.Length)
                    doLeft = true;
                
                // 유효한 가장 가까운 왼쪽 index 탐색
                while (true)
                {
                    leftIndex--;

                    if (leftIndex < 0)
                    {
                        doRight = true;
                        break;
                    }

                    if (distancesBetweenRocks[leftIndex] != int.MaxValue)
                        break;
                }

                // 유효한 가장 가까운 오른쪽 index 탐색
                while (true)
                {
                    rightIndex++;

                    if (rightIndex > rocks.Length)
                    {
                        doLeft = true;
                        break;
                    }

                    if (distancesBetweenRocks[rightIndex] != int.MaxValue)
                        break;
                }

                if (doRight)
                    distancesBetweenRocks[rightIndex] += distancesBetweenRocks[minDistancesIndex];
                else if (doLeft)
                    distancesBetweenRocks[leftIndex] += distancesBetweenRocks[minDistancesIndex];
                else
                {
                    if (distancesBetweenRocks[leftIndex] < distancesBetweenRocks[rightIndex])
                        distancesBetweenRocks[leftIndex] += distancesBetweenRocks[minDistancesIndex];
                    else
                        distancesBetweenRocks[rightIndex] += distancesBetweenRocks[minDistancesIndex];
                }

                distancesBetweenRocks[minDistancesIndex] = int.MaxValue;
            }

            return distancesBetweenRocks.Min();
        }

        // try1) 사이 거리가 Min인 두 바위 중 인접한 다른 바위와의 거리가 더 작은 바위를 제거 (n번 반복) 2/9 통과
        // try2) 제거한 바위를 고려하는 코드 추가 (leftIndex, rightIndex) 5/9 통과
        // try3) 기준바위 왼쪽 혹은 오른쪽에 체크할 바위가 없는 케이스 고려 5/9 통과
    }
}
