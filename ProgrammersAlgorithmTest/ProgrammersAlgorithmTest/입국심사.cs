using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/43238"/>
    /// TODO : 다시 풀어보기
    [TestClass]
    public class 입국심사
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(6, new int[] { 7, 10 }), 28);
        }

        public long solution(int n, int[] times)
        {
            long answer = 0;
            long minTime = 0;
            long maxTime = 0;

            foreach (var time in times)
            {
                if (time > maxTime)
                {
                    maxTime = time;
                }
            }

            maxTime *= n;
            answer = maxTime;

            while (minTime <= maxTime)
            {
                var avgTime = (minTime + maxTime) / 2;
                long countOfCheckedPerson = 0;

                foreach (var time in times)
                {
                    countOfCheckedPerson += avgTime / time;
                }

                if (countOfCheckedPerson < n)
                {
                    minTime = avgTime + 1;
                }
                else
                {
                    if (avgTime < answer)
                    {
                        answer = avgTime;
                    }

                    maxTime = avgTime - 1;
                }
            }

            return answer;
        }
    }
}
