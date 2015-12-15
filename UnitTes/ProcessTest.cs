using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxAlive;
using MaxAlive.Helper;
using MaxAlive.Model;


namespace UnitTes
{
    [TestClass]
    public class ProcessTest
    {
        /// <summary>
        /// Left bound method compares people born year with rang (1900-2000) and return beginning bound to loop mark alive in yearholder value field
        /// </summary>
        [TestMethod]
        public void TestGetLeftBound()
        {
            int leftBound;
            leftBound = Process.GetLeftBound(1875);
            Assert.AreEqual(1900,leftBound);
            leftBound = Process.GetLeftBound(1900);
            Assert.AreEqual(1900, leftBound);
            leftBound = Process.GetLeftBound(1945);
            Assert.AreEqual(1945, leftBound);
            leftBound = Process.GetLeftBound(2000);
            Assert.AreEqual(2000, leftBound);
            leftBound = Process.GetLeftBound(2001);
            Assert.AreEqual(-1, leftBound);
        }
        /// <summary>
        /// Right bound method compares people die year with range(1900-2000) and return end bound to loop mark alive in yearholder
        /// </summary>
        [TestMethod]
        public void TestGetRightBound()
        {
            int rightBound;
            rightBound = Process.GetRightBound(1875);
            Assert.AreEqual(-1, rightBound);
            rightBound = Process.GetRightBound(1900);
            Assert.AreEqual(1900, rightBound);
            rightBound = Process.GetRightBound(1945);
            Assert.AreEqual(1945, rightBound);
            rightBound = Process.GetRightBound(2000);
            Assert.AreEqual(2000, rightBound);
            rightBound = Process.GetRightBound(2001);
            Assert.AreEqual(2000, rightBound);
        }

        /// <summary>
        /// YearHolder is a key/value dictionary to hold range of evaluations, Key = years within 1900 to 2000
        /// </summary>
        [TestMethod]
        public void TestYearHolderRange_GetYearofMaxAlive()
        {
            var maxAlives = Process.GetYearofMaxAlive(Samples.GeneratePeopleslList(1000));
            Assert.IsTrue(maxAlives.Values.Min()>=0); //check Dictionary value initial
            Assert.IsTrue(maxAlives.Keys.Min()>=1900);
            Assert.IsTrue(maxAlives.Keys.Max()<=2000);
            Assert.IsTrue(maxAlives.Count<=101);
        }

        /// <summary>
        /// When range are overlap, then the overlap years within (1900,2000)are the Max years that most people lived
        /// result should be 6 rows:
        /// Year, # of alive
        /// 1900:2
        /// 1901:2
        /// 1902:2
        /// 1903:2
        /// 1904:2
        /// 1905:2
        /// </summary>
        [TestMethod]
        public void TestGetYearofMaxAliveForOverlapCases()
        {
            List<People> peoples = new List<People>();
            peoples.Add(new People("P1",1890,1905));
            peoples.Add(new People("p2",1900,1950));
            var maxAlives = Process.GetYearofMaxAlive(peoples);
            Assert.AreEqual(6,maxAlives.Count());
            foreach (var year in maxAlives)
            {
                Assert.AreEqual(2,year.Value);
            }
        }

        /// <summary>
        /// Given two range that do not overlap for lives, the max year that people alive should = 1 for # of each individual lived in rang (1900,2000)
        /// When no overlap, this case the max # of people for a year is 1
        /// Year, # of alive
        /// 1910: 1
        /// 1911: 1
        /// 1912: 1
        /// 1913: 1
        /// 1995: 1
        /// 1996: 1
        /// 1997: 1
        /// 1998: 1
        /// 1999: 1
        /// 2000: 1
        /// </summary>
        [TestMethod]
        public void TestGetYearofMaxAliveFor_NO_OverlapCases()
        {  
            List<People> peoples = new List<People>();
            peoples.Add(new People("P1", 1910, 1913));
            peoples.Add(new People("p2", 1995, 2010));
            var maxAlives = Process.GetYearofMaxAlive(peoples);
            Assert.AreEqual(10, maxAlives.Count());
            foreach (var year in maxAlives)
            {
                Assert.AreEqual(1, year.Value);
            }
        }
 #region "TestGetYearofMaxAlive2"
        [TestMethod]
        public void TestYearHolderRange_GetYearofMaxAlive2()
        {
            var maxAlives = Process.GetYearofMaxAlive2(Samples.GeneratePeopleslList(1000));
            Assert.IsTrue(maxAlives.Values.Min() >= 0); //check Dictionary value initial
            Assert.IsTrue(maxAlives.Keys.Min() >= 1900);
            Assert.IsTrue(maxAlives.Keys.Max() <= 2000);
            Assert.IsTrue(maxAlives.Count <= 101);
        }
        [TestMethod]
        public void TestGetYearofMaxAlive2ForOverlapCases()
        {
            List<People> peoples = new List<People>();
            peoples.Add(new People("P1", 1890, 1905));
            peoples.Add(new People("p2", 1900, 1950));
            var maxAlives = Process.GetYearofMaxAlive2(peoples);
            Assert.AreEqual(6, maxAlives.Count());
            foreach (var year in maxAlives)
            {
                Assert.AreEqual(2, year.Value);
            }
        }
        [TestMethod]
        public void TestGetYearofMaxAlive2For_NO_OverlapCases()
        {
            List<People> peoples = new List<People>();
            peoples.Add(new People("P1", 1910, 1913));
            peoples.Add(new People("p2", 1995, 2010));
            var maxAlives = Process.GetYearofMaxAlive2(peoples);
            Assert.AreEqual(10, maxAlives.Count());
            foreach (var year in maxAlives)
            {
                Assert.AreEqual(1, year.Value);
            }
        }

        #endregion

    }
}
