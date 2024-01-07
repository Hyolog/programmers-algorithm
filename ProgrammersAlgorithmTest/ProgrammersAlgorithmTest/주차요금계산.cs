using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammersAlgorithmTest
{
    /// <see cref="https://school.programmers.co.kr/learn/courses/30/lessons/92341"/>
    [TestClass]
    public class 주차요금계산
    {
        [TestMethod]
        public void Test()
        {
            CollectionAssert.AreEqual(solution(new int[] { 180, 5000, 10, 600 }, new string[] { "05:34 5961 IN", "06:00 0000 IN", "06:34 0000 OUT", "07:59 5961 OUT", "07:59 0148 IN", "18:59 0000 IN", "19:09 0148 OUT", "22:59 5961 IN", "23:00 5961 OUT" }), new int[] { 14600, 34400, 5000 });
            CollectionAssert.AreEqual(solution(new int[] { 120, 0, 60, 591 }, new string[] { "16:00 3961 IN", "16:00 0202 IN", "18:00 3961 OUT", "18:00 0202 OUT", "23:58 3961 IN" }), new int[] { 0, 591 });
            CollectionAssert.AreEqual(solution(new int[] { 1, 461, 1, 10 }, new string[] { "00:00 1234 IN" }), new int[] { 14841 });
        }

        public int[] solution(int[] fees, string[] records)
        {
            Dictionary<string, float> carTotalFee = new Dictionary<string, float>();
            Dictionary<string, string> carEntryTime = new Dictionary<string, string>();

            for (int i = 0; i < records.Length; i++)
            {
                string carPlate = records[i].Split(" ")[1];

                if (records[i].Substring(11) == "OUT")
                {
                    int parkedMinutes = CalculateTimeMinutesDifference(carEntryTime[carPlate], records[i].Substring(0, 5));
                    carTotalFee[carPlate] += parkedMinutes;
                    carEntryTime.Remove(carPlate);
                }
                else if (records[i].Substring(11) == "IN")
                {
                    carEntryTime.Add(carPlate, records[i].Substring(0, 5));
                    if (!carTotalFee.ContainsKey(carPlate))
                    {
                        carTotalFee.Add(carPlate, 0);
                    }
                }
            }

            if (carEntryTime.Count > 0)
            {
                foreach (string carPlate in carEntryTime.Keys)
                {
                    int parkedMinutes = CalculateTimeMinutesDifference(carEntryTime[carPlate], "23:59");
                    carTotalFee[carPlate] += parkedMinutes;
                }
            }

            List<string> sortedCarPlates = carTotalFee.Keys.ToList();
            sortedCarPlates.Sort();

            int[] answer = new int[sortedCarPlates.Count];

            for (int i = 0; i < sortedCarPlates.Count; i++)
            {
                answer[i] = CalculateFee(fees[0], fees[1], fees[2], fees[3], carTotalFee[sortedCarPlates[i]]);
            }

            return answer;
        }

        int CalculateFee(int baseMinutes, int baseFee, int unitMinutes, int unitFee, float parkedMinutes)
        {
            return parkedMinutes > baseMinutes ? baseFee + (int)((Math.Ceiling((parkedMinutes - baseMinutes) / unitMinutes)) * unitFee) : baseFee;
        }

        int CalculateTimeMinutesDifference(string pastTime, string currentTime)
        {
            int pastHours = int.Parse(pastTime.Substring(0, 2));
            int currentHours = int.Parse(currentTime.Substring(0, 2));
            int pastMinutes = int.Parse(pastTime.Substring(3, 2));
            int currentMinutes = int.Parse(currentTime.Substring(3, 2));

            return (currentHours - pastHours) * 60 + (currentMinutes - pastMinutes);
        }
    }
}
