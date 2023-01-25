using Logic.Models;
using MediaBazaar.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaar.Managers
{
    public class UnavailabilityManager
    {
        private UnavailabilityStorage unavailabilityStorage;


        public UnavailabilityManager()
        {
            unavailabilityStorage = new UnavailabilityStorage();
        }

        public DataTable GetUnavailability(int userId)
        {
            return unavailabilityStorage.ReadUnAvailability(userId);
        }

        public bool EnterUnavailability(Unavailability unavailability)
        {
            if (unavailability.Reason == "Vacation" && unavailability.EndDate is null)
            {
                return false;
            }
            if(unavailability.Reason == "Sick" && Convert.ToDateTime(unavailability.StartDate) > DateTime.Today.AddDays(1))
            {
                return false;
            }
            return unavailabilityStorage.EnterUnAvailability(unavailability);
        }

        public bool SetEndDate(int userId, string endDate)
        {
            return unavailabilityStorage.SetEndDate(userId, endDate);
        }

        public bool CheckForSick(int userId)
        {
            return unavailabilityStorage.CheckForSick(userId);
        }

        public DateTime? GetEarliestSickDate(int userId)
        {
            return unavailabilityStorage.GetEarliestSickDate(userId);
        }
    }
}