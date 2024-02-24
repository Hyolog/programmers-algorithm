using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/87946"/>
    [TestClass]
    public class 피로도
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(80, new int[,] { { 80, 20 }, { 50, 40 }, { 30, 10 } }), 3);
        }

        public int answer;
        public bool[] visited;

        public int solution(int k, int[,] dungeons)
        {
            // 던전 길이만큼 방문 여부 체크할 변수 설정, dfs호출 이후 방문 초기화 해준다.
            // 전역변수로 설정되어 있으므로 방문초기화 필수 <-
            visited = new bool[dungeons.GetLength(0)];

            dfs(0, k, dungeons);

            return answer;
        }

        /// <param name="depth">현재 던전의 depth (몇번째 던전인지)</param>
        /// <param name="k">피로도</param>
        /// <param name="dungeons">던전 정보</param>
        public void dfs(int depth, int k, int[,] dungeons)
        {
            for (int i = 0; i < dungeons.GetLength(0); i++)
            {
                // 방문하지 않은 상태면서 k가 최소 필요 피로도보다 크거나 같은 경우
                if (!visited[i] && dungeons[i, 0] <= k)
                {
                    visited[i] = true; // 방문 처리
                    dfs(depth + 1, k - dungeons[i, 1], dungeons); // 재귀 호출
                    visited[i] = false; // 방문 초기화
                }
            }

            answer = Math.Max(answer, depth);
        }
    }
}
