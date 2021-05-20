using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/43163"/>
    [TestClass]
    public class 단어변환
    {
        [TestMethod]
        public void Test()
        {

        }

        public class Solution
        {
            bool[] visited;
            int result = int.MaxValue;

            public int solution(string begin, string target, string[] words)
            {
                visited = new bool[words.Length];

                if (!words.Contains(target))
                    return 0;

                search(begin, 0, words, target);

                return result;
            }

            public void search(string cur, int step, string[] words, string target)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (visited[i])
                    {
                        continue;
                    }

                    var num = 0;

                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if (cur[j] == words[i][j])
                        {
                            num++;
                        }
                    }

                    if (num == cur.Length - 1)
                    {
                        visited[i] = true;

                        if (words[i] == target)
                        {
                            if (result > step)
                            {
                                result = step + 1;
                            }
                        }

                        search(words[i], step + 1, words, target);
                        
                        visited[i] = false;
                    }
                }
            }
        }
    }
}
