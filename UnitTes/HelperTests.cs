using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxAlive;
using MaxAlive.Model;
using MaxAlive.Helper;

namespace UnitTes
{
    [TestClass]
    public class HelperTests
    {
       [TestMethod]
        public void TestPeopleConstructor()
        {
            People p = new People("test",1976,1998);
            Assert.IsInstanceOfType(p.BornYear,typeof(int));
            Assert.IsInstanceOfType(p.DieYear,typeof(int));
            Assert.IsInstanceOfType(p.Name,typeof(string));
            Assert.IsNotNull(p.BornYear);
            Assert.IsNotNull(p.DieYear);
            Assert.IsNotNull(p.Name);
        }

        [TestMethod]
        public void TestPeopleGenerator()
        {
            List<People> peoples = Samples.GeneratePeopleslList(3);
            Assert.AreEqual(3, peoples.Count);
        }

        [TestMethod]
        public void TestPeopleGeneratorInput0()
        {
            List<People> peoples = Samples.GeneratePeopleslList(0);
            Assert.AreEqual(0, peoples.Count);
        }

        [TestMethod]//insure random year is generated
        public void TestRandomforGeneratePeoplesList()
        {
            List<People> peoples = Samples.GeneratePeopleslList(3);
            Assert.AreNotEqual(peoples[1].BornYear,peoples[2].BornYear);
            Assert.AreNotEqual(peoples[1].DieYear, peoples[2].DieYear);
            Assert.IsTrue(peoples[1].BornYear <= peoples[1].DieYear);
            Assert.IsTrue(peoples[2].BornYear <= peoples[2].DieYear);
        }

        [TestMethod]
        public void TestRandomDatasetBornDieYearinRange1900_2000()
        {
            List<People> peoples = Samples.GeneratePeopleslList(1000);
            foreach (var p in peoples)
            {
                Assert.IsTrue(p.BornYear <= 2000 || p.BornYear >= 1800);
                Assert.IsTrue(p.DieYear >= 1900 || p.DieYear <= 2100);
                Assert.IsTrue((p.DieYear - p.BornYear)<=100);
            }
        }

    }
}
