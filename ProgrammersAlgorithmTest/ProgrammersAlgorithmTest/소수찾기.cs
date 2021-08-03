using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42839"/>
    /// TODO : dfs 공부 좀 더해야할듯
    [TestClass]
    public class 소수찾기
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution("17"), 3);
            Assert.AreEqual(solution("011"), 2);
        }

        HashSet<int> primeNumbers = new HashSet<int>();
        int[] visited;

        /// <param name="numbers">1~7</param>
        public int solution(string numbers)
        {
            visited = new int[numbers.Length];
            
            for (int i = 0; i < numbers.Length; i++)
                dfs(i, numbers, "");

            return primeNumbers.Count;
        }

        public void dfs(int index, string numbers, string num)
        {
            // 1.방문처리
            visited[index] = 1;

            #region 추가작업
            // 숫자만들기
            num += numbers[index];

            var number = int.Parse(num);

            // 소수 기록
            if (!primeNumbers.Contains(number) && IsPrimeNumber(number))
                primeNumbers.Add(number);
            #endregion

            // 2.연결된 애들 방문
            for (int i = 0; i < numbers.Length; i++)
            {
                if (visited[i] == 0) 
                    dfs(i, numbers, num);
            }

            // 방문기록 초기화
            visited[index] = 0;
        }

        private bool IsPrimeNumber(int number)
        {
            if (number <= 1)
                return false;
            else if (number == 2)
                return true;
            else if (number % 2 == 0)
                return false;

            var squareRoot = Math.Sqrt(number);

            for (var i = 2; i <= (int)squareRoot; i++)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
