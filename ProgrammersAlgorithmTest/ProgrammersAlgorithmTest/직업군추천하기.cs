using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/84325?language=csharp"/>
    [TestClass]
    public class 직업군추천하기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new string[] { "SI JAVA JAVASCRIPT SQL PYTHON C#", "CONTENTS JAVASCRIPT JAVA PYTHON SQL C++", "HARDWARE C C++ PYTHON JAVA JAVASCRIPT", "PORTAL JAVA JAVASCRIPT PYTHON KOTLIN PHP", "GAME C++ C# JAVASCRIPT C JAVA" }, new string[] { "PYTHON", "C++", "SQL" }, new int[] { 7, 5, 5 }), "HARDWARE");
            Assert.AreEqual(solution(new string[] { "SI JAVA JAVASCRIPT SQL PYTHON C#", "CONTENTS JAVASCRIPT JAVA PYTHON SQL C++", "HARDWARE C C++ PYTHON JAVA JAVASCRIPT", "PORTAL JAVA JAVASCRIPT PYTHON KOTLIN PHP", "GAME C++ C# JAVASCRIPT C JAVA" }, new string[] { "JAVA", "JAVASCRIPT" }, new int[] { 7, 5 }), "PORTAL");
        }

        public string solution(string[] table, string[] languages, int[] preference)
        {
            var recommendJobName = "";
            var jobScore = 0;

            foreach (var job in table)
            {
                var jobInfo = job.Split(' ');

                var tempScore = 0;

                for (int i = 1; i < jobInfo.Length; i++)
                    for (int j = 0; j < languages.Length; j++)
                        if (jobInfo[i].Equals(languages[j]))
                            tempScore += (6 - i) * preference[j];

                if (tempScore > jobScore)
                {
                    jobScore = tempScore;
                    recommendJobName = jobInfo[0];
                }
                else if (tempScore == jobScore)
                {
                    if(string.Compare(recommendJobName, jobInfo[0]) > 0)
                    {
                        recommendJobName = jobInfo[0];
                    }
                }
            }

            return recommendJobName;
        }
    }
}
