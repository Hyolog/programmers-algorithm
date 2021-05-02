using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://programmers.co.kr/learn/courses/30/lessons/42583"/>
    /// 구현 문제
    [TestClass]
    public class 다리를지나는트럭
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(solution(2, 10, new int[] { 7, 4, 5, 6 }), 8);
            Assert.AreEqual(solution(100, 100, new int[] { 10 }), 101);
            Assert.AreEqual(solution(100, 100, new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }), 110);
        }

        public int solution(int bridge_length, int weight, int[] truck_weights)
        {
            var truckWeights = new Queue<int>();
            
            foreach (var truckWeight in truck_weights)
                truckWeights.Enqueue(truckWeight);

            var bridgeWeightSum = new int[(bridge_length + 1) * truck_weights.Length];

            var time = 0;

            // 트럭 다 보낼때까지
            while (truckWeights.Count != 0)
            {
                // 트럭을 가져와서
                var nextTruckWeight = truckWeights.Peek();

                // 다리 위 무게 + 다음 트럭 무게 <= 하중 이면
                if (bridgeWeightSum[time] + nextTruckWeight <= weight)
                {
                    // 해당시점에 트럭을 출발시키고
                    nextTruckWeight = truckWeights.Dequeue();
                    
                    // 누적 무게 갱신
                    for (int i = 0; i < bridge_length; i++)
                        bridgeWeightSum[time + i] += nextTruckWeight;
                }

                time++;
            }

            return time + bridge_length;
        }
    }
}
