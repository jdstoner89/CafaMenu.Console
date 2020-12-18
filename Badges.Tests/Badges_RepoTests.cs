using System;
using Repository_Challenge_Three;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_Challenge_Three
{
    [TestClass]
    class Badges_RepoTests
    {
        private Badges_Repository _repo;
        private Badges _badge;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new Badges_Repository();
            _badge = new Badges(1500, "a", JobType.Claims);
            _repo.AddBadgeToList(_badge);
        }
        [TestMethod]
        public void AddBadgeToList_ReturnNotNull()
        {
            Badges badge = new Badges();
            badge.BadgeNumber = 1500;
            Badges_Repository repository = new Badges_Repository();

            repository.AddBadgeToList(badge);
            Badges badgeFromDirectory = repository.GetBadgeByBadgeNumber(1500);

            Assert.IsNotNull(badgeFromDirectory);
        }
    }
}
