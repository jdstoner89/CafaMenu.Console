using System;
using Repository_Challenge_Three;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_Challenge_Three
{
    [TestClass]
    public class Badges_Tests
    {
        [TestMethod]
        public void SetBadgeNumber_SetCorrectInt()
        {
            Badges badge = new Badges();
            badge.BadgeNumber = 5000;

            int expected = 1500;
            int actual = badge.BadgeNumber;

            Assert.AreEqual(expected, actual);
        }
    }
}
