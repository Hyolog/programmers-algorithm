using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/43164"/>
    /// 다시 풀어보기
    [TestClass]
    public class 여행경로
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(new string[,] { { "ICN", "JFK" }, { "HND", "IAD" }, { "JFK", "HND" } }), new string[] { "ICN", "JFK", "HND", "IAD" });
            Assert.AreEqual(solution(new string[,] { { "ICN", "SFO" }, { "ICN", "ATL" }, { "SFO", "ATL" }, { "ATL", "ICN" }, { "ATL", "SFO" } }), new string[] { "ICN", "ATL", "ICN", "SFO", "ATL", "SFO" });
        }

        Queue<string[]> ans = new Queue<string[]>();

        public string[] solution(string[,] tickets)
        {
            var length = tickets.GetLength(0);
            var visit = new bool[length];
            var path = new Stack<string>();

            for (int i = 0; i < length; i++)
            {
                path.Push(tickets[i, 0]);
                path.Push(tickets[i, 1]);
                visit[i] = true;
                
                dfs(ref tickets, visit, i, path);
                
                visit[i] = false;
                path.Clear();
            }

            var tempAnswer = ans.Where(x => x[0] == "ICN").ToArray();
            var answer = tempAnswer[0];

            foreach (var v in tempAnswer)
            {
                for (int i = 0; i < length + 1; i++)
                {
                    if (answer[i] != v[i])
                    {
                        if (String.Compare(answer[i], v[i]) == 1)
                            answer = v;

                        break;
                    }
                }
            }

            return answer;
        }

        public void dfs(ref string[,] tickets, bool[] visit, int pos, Stack<string> p)
        {
            if (visit.Contains(false))
            {
                Stack<string> temp;

                for (var i = 0; i < visit.Length; i++)
                {
                    if ((visit[i] == false) && (tickets[pos, 1] == tickets[i, 0]))
                    {
                        temp = p;
                        temp.Push(tickets[i, 1]);
                        visit[i] = true;

                        dfs(ref tickets, visit, i, temp);
                        
                        visit[i] = false;
                        temp.Pop();
                    }
                }
            }
            else
            {
                if (p.Count != visit.Length + 1)
                    return;

                var temp = p.ToArray();
                Array.Reverse(temp);
                ans.Enqueue(temp);
            }
        }
    }
}
