using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Challenge_Three
{
    public class Badges_Repository
    {
        private List<Badges> _listOfBadges = new List<Badges>();
        public void AddBadgeToList(Badges badge)
        {
            _listOfBadges.Add(badge);
        }
        public List<Badges> GetBadgesList()
        {
            return _listOfBadges;
        }
        public bool UpdateExistingBadge(int originalBadgeNumber, Badges newBadge)
        {
            Badges oldBadge = GetBadgeByBadgeNumber(originalBadgeNumber);
            if(oldBadge != null)
            {
                oldBadge.BadgeNumber = newBadge.BadgeNumber;
                oldBadge.DoorAccess = newBadge.DoorAccess;
                oldBadge.JobField = newBadge.JobField;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateExistingBadge(string originalDoorAccess, Badges newBadge)
        {
            Badges oldBadge = GetBadgeByDoorAccess(originalDoorAccess);
            if(oldBadge != null)
            {
                oldBadge.BadgeNumber = newBadge.BadgeNumber;
                oldBadge.DoorAccess = newBadge.DoorAccess;
                oldBadge.JobField = newBadge.JobField;
                return true;
            }
            else
            {
                return false;
            }
        }
        public Badges GetBadgeByBadgeNumber(int badgeNumber)
        {
            foreach(Badges badge in _listOfBadges)
            {
                if(badge.BadgeNumber == badgeNumber)
                {
                    return badge;
                }
            }
            return null;
        }
        public Badges GetBadgeByDoorAccess(string doorAccess)
        {
            foreach(Badges badge in _listOfBadges)
            {
                if(badge.DoorAccess == doorAccess)
                {
                    return badge;
                }
            }
            return null;
        }
    }
}
