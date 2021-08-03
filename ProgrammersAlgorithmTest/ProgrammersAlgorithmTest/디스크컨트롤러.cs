using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42627"/>
    [TestClass]
    public class 디스크컨트롤러
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[,] { { 0, 3 }, { 1, 9 }, { 2, 6 } }), 9);
        }

        /// <param name="jobs">1~500</param> N^3 까지 OK
        public int solution(int[,] jobs)
        {
            var jobList = new List<Job>();

            // O(N)
            for (var i = 0; i < jobs.GetLength(0); i++)
            {
                var job = new Job()
                {
                    RequestTime = jobs[i, 0],
                    ExecutionTime = jobs[i, 1]
                };

                jobList.Add(job);
            }

            var currentTime = 0;

            // 0(NlogN) ~ O(N^2)
            jobList = jobList.OrderBy(d => d.ExecutionTime).ToList();

            var totalTime = 0;

            // O(C)
            while (jobList.Count > 0)
            {
                // 현재시간기준 들어와있는 요청이 있다면 하나를 가져와서 (이 하나는 수행시간이 가장 짧은 job)
                var tempJob = jobList.FirstOrDefault(d => d.RequestTime <= currentTime);

                if (tempJob != null)
                {
                    currentTime += tempJob.ExecutionTime;
                    totalTime += (currentTime - tempJob.RequestTime);
                }
                else
                {
                    currentTime++;
                }

                // O(logN)
                jobList.Remove(tempJob);
            }

            return totalTime / jobs.GetLength(0);
        }

        public class Job
        {
            public int RequestTime { get; set; }
            public int ExecutionTime { get; set; }
        }
    }
}
