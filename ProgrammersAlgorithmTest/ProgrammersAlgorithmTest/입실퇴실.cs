using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var answerDic = new Dictionary<int, HashSet<int>>(); 
            var answer = new int[enter.Length];
            var intersect = new List<int>();

            for (int i = 0; i < leave.Length; i++)
            { 
                var index = Array.IndexOf(enter, leave[i]); 
                var count = index; 
                var lastCount = leave.Length - i - 1; 
                
                if (count <= 0 || lastCount <= 0) 
                    continue; 
                
                intersect = enter.Take(count).Intersect(leave.TakeLast(lastCount)).ToList(); 
                intersect.Add(leave[i]); 
                
                foreach (var item in intersect) 
                { 
                    if (!answerDic.ContainsKey(item - 1)) 
                        answerDic.Add(item - 1, new HashSet<int>()); 
                    
                    foreach (var node in intersect) 
                    { 
                        if (item == node) 
                            continue; 
                        
                        answerDic[item - 1].Add(node); 
                    } 
                } 
                
                enter[index] = 0; 
            }

            foreach (var e in answerDic) 
                answer[e.Key] += e.Value.Count; 
            
            return answer;
        }
    }
}
