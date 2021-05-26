using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/43165"/>
    [TestClass]
    public class 타겟넘버
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new int[] { 1, 1, 1, 1, 1 }, 3), 5);
        }

        int answer = 0;

        public int solution(int[] numbers, int target)
        {
            Dfs(numbers, numbers[0], 1, target);
            Dfs(numbers, -1 * numbers[0], 1, target);

            return answer;
        }

        public void Dfs(int[] numbers, int num, int depth, int target)
        {
            // target 도달여부 체크 = 방문처리
            if (depth == numbers.Length)
            {
                if (num == target)
                {
                    answer++;
                }

                return;
            }

            // 다음수 더하고 호출
            Dfs(numbers, num + numbers[depth], depth + 1, target);
            Dfs(numbers, num - numbers[depth], depth + 1, target);
        }
    }
}
