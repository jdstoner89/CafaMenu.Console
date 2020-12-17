using System;
using Challenge_One_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_One_Tests
{
    [TestClass]
    public class CafeMenuRepoTests
    {
        private CafeMenuRepository _repo;
        private CafeMenu _item;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeMenuRepository();
            _item = new CafeMenu("Sloppy Joe's Sliders", 6, "Classic Sloppy Joe's taste with less mess!", "Ground beef mixed with peppers and our signature 'sloppy sauce' on 6 mini Hawaiin rolls.", 5.75, false, MeatType.Beef);
            _repo.AddItemToList(_item);
        }

        [TestMethod]
        public void AddItemToList_ReturnNotNull()
        {
            CafeMenu item = new CafeMenu();
            item.MealName = "Sloppy Joe's Sliders";
            CafeMenuRepository repository = new CafeMenuRepository();

            repository.AddItemToList(item);
            CafeMenu itemFromDirectory = repository.GetItemByMealName("Sloppy Joe's Sliders");

            Assert.IsNotNull(itemFromDirectory);
        }

        
        [TestMethod]
        public void UpdateExistingItem_ReturnTrue()
        {
            CafeMenu newItem = new CafeMenu("Sloppy Sliders", 6, "Classic Sloppy Joe's taste with less mess!", "Ground beef mixed with peppers and our signature 'sloppy sauce' on 6 mini Hawaiin rolls.", 5.75, false, MeatType.Beef);

            bool updateResult = _repo.UpdateExistingItem("Sloppy Joe's Sliders", newItem);
            Assert.IsTrue(updateResult);
        }
        [DataTestMethod]
        [DataRow("Sloppy Joe's Sliders", true)]
        [DataRow("Sloppy Sliders", false)]
        public void UpdateExistingItem(string originalMealName, bool shouldUpdate)
        {
            CafeMenu newItem = new CafeMenu("Sloppy Sliders", 6, "Classic Sloppy Joe's taste with less mess!", "Ground beef mixed with peppers and our signature 'sloppy sauce' on 6 mini Hawaiin rolls.", 5.75, false, MeatType.Beef);
            bool updateResult = _repo.UpdateExistingItem(originalMealName, newItem);
            Assert.AreEqual(shouldUpdate, updateResult);
        }
        [TestMethod]
        public void DeleteItemByName()
        {
            bool deleteResult = _repo.RemoveItemFromList(_item.MealName);
            Assert.IsTrue(deleteResult);
        }
        }
    }

