using System;
using Challenge_One_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_One_Tests
{
    [TestClass]
    public class ChallengeOneTests
    {
        [TestMethod]
        public void SetMealName_SetCorrectString()
        {
            CafeMenu item = new CafeMenu();
            item.MealName = "Sloppy Joe's Sliders";

            string expected = "Sloppy Joe's Sliders";
            string actual = item.MealName;

            Assert.AreEqual(expected, actual);

        }
    }
}
