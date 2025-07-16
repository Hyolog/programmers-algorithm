using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/340213"/>
    [TestClass]
    public class 동영상재생기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("34:33", "13:00", "00:55", "02:55", new string[] { "next", "prev" }), "13:00");
            Assert.AreEqual(solution("10:55", "00:05", "00:15", "06:55", new string[] { "prev", "next", "next" }), "06:55");
            Assert.AreEqual(solution("07:22", "04:05", "00:15", "04:07", new string[] { "next" }), "04:17");
        }

        public string solution(string video_len, string pos, string op_start, string op_end, string[] commands)
        {
            foreach (var command in commands)
            {
                pos = SkipOp(pos, op_start, op_end);

                switch (command)
                {
                    case "prev": pos = Prev(pos); break;
                    case "next": pos = Next(pos, video_len); break;
                }

                pos = SkipOp(pos, op_start, op_end);
            }

            return pos;
        }

        public int StringTimeToTotalSeconds(string time)
        {
            string[] mmss = time.Split(":");
            int minutes = int.Parse(mmss[0]);
            int seconds = int.Parse(mmss[1]);
            return minutes * 60 + seconds;
        }

        public string TotalSecondsToStringTime(int totalSeconds)
        {
            return $"{totalSeconds / 60:D2}:{totalSeconds % 60:D2}";
        }

        public string Prev(string pos)
        {
            var totalSeconds = StringTimeToTotalSeconds(pos);

            totalSeconds -= 10;

            if (totalSeconds < 0)
            {
                totalSeconds = 0;
            }

            return TotalSecondsToStringTime(totalSeconds);
        }

        public string Next(string pos, string video_len)
        {
            var totalSeconds = StringTimeToTotalSeconds(pos);
            totalSeconds += 10;

            var totalSecondsForVideoLen = StringTimeToTotalSeconds(video_len);

            if (totalSeconds > totalSecondsForVideoLen)
            {
                totalSeconds = totalSecondsForVideoLen;
            }

            return TotalSecondsToStringTime(totalSeconds);
        }

        public string SkipOp(string pos, string op_start, string op_end)
        {
            var current = StringTimeToTotalSeconds(pos);
            var start = StringTimeToTotalSeconds(op_start);
            var end = StringTimeToTotalSeconds(op_end);

            if (start <= current && current <= end)
            {
                current = end;
            }

            return TotalSecondsToStringTime(current);
        }
    }
}
