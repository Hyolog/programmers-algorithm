using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammersAlgorithmTest.Library;
using System;
using System.Diagnostics;
using System.Linq;

namespace SolutionForAllTest
{
    [TestClass]
    public class Linq
    {
        [TestMethod]
        public void CountingSpecificCharUseCount_MoreSlowThenLoop_UseStringBinary()
        {
            var linqRecord = TimeChecker.GetRunningTime(() =>
            {
                var randomBinary = Convert.ToString(new Random().Next(), 2);
                
                randomBinary.Count(d => d == '1');
            }, 1000000);

            var loopRecord = TimeChecker.GetRunningTime(() =>
            {
                var randomBinary = Convert.ToString(new Random().Next(), 2);

                var count = 0;

                foreach (var item in randomBinary)
                {
                    if (item == '1')
                        count++;
                }
            }, 1000000);

            Assert.IsTrue(linqRecord > loopRecord);
            Debug.WriteLine($"LinqRecord vs LoopRecord");
            Debug.WriteLine($"{linqRecord} vs {loopRecord}");
        }
    }
}
