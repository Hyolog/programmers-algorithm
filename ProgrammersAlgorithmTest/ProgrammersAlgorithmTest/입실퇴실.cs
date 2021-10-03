using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/86048"/>
    [TestClass]
    public class 입실퇴실
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 1, 3, 2 }, new int[] { 1, 2, 3 }), new int[] { 0, 1, 1 });
            CollectionAssert.AreEqual(solution(new int[] { 1, 4, 2, 3 }, new int[] { 2, 1, 3, 4 }), new int[] { 2, 2, 1, 3 });
            CollectionAssert.AreEqual(solution(new int[] { 3, 2, 1 }, new int[] { 2, 1, 3 }), new int[] { 1, 1, 2 });
            CollectionAssert.AreEqual(solution(new int[] { 3, 2, 1 }, new int[] { 1, 3, 2 }), new int[] { 2, 2, 2 });
            CollectionAssert.AreEqual(solution(new int[] { 1, 4, 2, 3 }, new int[] { 2, 1, 4, 3 }), new int[] {2, 2, 0, 2 });
        }

        public int[] solution(int[] enter, int[] leave)
        {
            var visitInfo = new Dictionary<int, KeyValuePair<double, double>>();

            // 사람 번호, <입실시간, 퇴실시간>
            for (int i = 0; i < enter.Length; i++)
                visitInfo.Add(enter[i], new KeyValuePair<double, double>(i, 0));

            double lastLeaveTime = 0;

            // leave 정보 참고해 퇴실시간 할당
            for (int i = 0; i < leave.Length; i++)
            {
                visitInfo.TryGetValue(leave[i], out var timeInfo);

                var enterTime = timeInfo.Key;
                double leaveTime = Math.Max(lastLeaveTime, enterTime);
                leaveTime += 0.001;

                visitInfo[leave[i]] = new KeyValuePair<double, double>(enterTime, leaveTime);

                lastLeaveTime = leaveTime;
            }

            var result = new int[enter.Length];

            for (int i = 1; i <= visitInfo.Count; i++)
            {
                visitInfo.TryGetValue(i, out var timeInfo);

                for (int j = i + 1; j <= visitInfo.Count; j++)
                {
                    visitInfo.TryGetValue(j, out var timeInfo2);

                    if (IsMeet(timeInfo.Key, timeInfo.Value, timeInfo2.Key, timeInfo2.Value))
                    {
                        result[i - 1]++;
                        result[j - 1]++;
                    }
                }
            }

            return result;
        }

        private bool IsMeet(double enterTime, double leaveTime, double enterTime2, double leaveTime2)
        {
            return (enterTime < enterTime2 && leaveTime > enterTime2) || (enterTime > enterTime2 && leaveTime2 > enterTime);
        }
    }
}
