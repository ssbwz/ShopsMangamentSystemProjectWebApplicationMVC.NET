using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Unavailability
    {

        // properties

        public int Id { get; set; }
        public int User_id { get; set; }    
        public string Reason { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public Unavailability(int id, int user_id, string reason, string startdate, string enddate)
        {
            this.Id = id;
            this.User_id = user_id;
            this.Reason = reason;
            this.StartDate = startdate;
            this.EndDate = enddate;
        }
        public Unavailability() { }
    }
}
