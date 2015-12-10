using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventChallenege2015;

namespace AdventChallenge2015Tests
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public void S1Returns11()
        {
            Assert.AreEqual("11", Day10.LookAndSay("1"));
        }

        [TestMethod]
        public void S11Returns21()
        {
            Assert.AreEqual("21", Day10.LookAndSay("11"));
        }

        [TestMethod]
        public void S21Returns1211()
        {
            Assert.AreEqual("1211", Day10.LookAndSay("21"));
        }

        [TestMethod]
        public void S1211Returns111221()
        {
            Assert.AreEqual("111221", Day10.LookAndSay("1211"));
        }

        [TestMethod]
        public void S111221Returns312211()
        {
            Assert.AreEqual("312211", Day10.LookAndSay("111221"));
        }
    }
}
