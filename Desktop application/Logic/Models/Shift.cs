using MediaBazaar.Logic.Enums;

namespace Logic.Models
{
    public class Shift
    {
        public Shift(DateOnly date,ShiftTime shiftTime,List<Attendance> attendances) 
        {
            this.Date = date; 
            this.ShiftTime = shiftTime;
            this.Attendances = attendances;
        }
         
        public DateOnly Date { get; private set; }

        public ShiftTime ShiftTime { get; private set; }

        public List<Attendance> Attendances { get; private set;}

    }
}
