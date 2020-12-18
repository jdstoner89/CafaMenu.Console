using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Challenge_Three
{
    public enum JobType
    {
        Claims= 1,
        Development,
        Sales,
        Underwriting,
        Managerial,
    }
    public class Badges
    {
        public int BadgeNumber { get; set; }
        public string DoorAccess { get; set; }
        public JobType JobField { get; set; }
        public Badges() { }
        public Badges(int badgeNumber, string doorAccess, JobType job)
        {
            BadgeNumber = badgeNumber;
            DoorAccess = doorAccess;
            JobField = job; 
        }
    }
}
