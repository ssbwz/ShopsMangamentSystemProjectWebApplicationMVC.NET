
namespace Logic.Models.AutoScheduling
{
    public class WeekLimits
    {

        public WeekLimits(DayLimits mondayLimits, DayLimits tuesdayLimits, DayLimits wednesdayLimits, DayLimits thursdayLimits, DayLimits fridayLimits, DayLimits saturdayLimits, DayLimits sundayLimits) 
        {
            this.MondayLimits = mondayLimits;
            this.TuesdayLimits = tuesdayLimits;
            this.WednesdayLimits = wednesdayLimits;
            this.ThursdayLimits = thursdayLimits;
            this.FridayLimits = fridayLimits;
            this.SaturdayLimits = saturdayLimits;
            this.SundayLimits = sundayLimits;
        }

        public DayLimits MondayLimits { get; private set; }

        public DayLimits TuesdayLimits { get; private set; }

        public DayLimits WednesdayLimits { get; private set; }

        public DayLimits ThursdayLimits { get; private set; }

        public DayLimits FridayLimits { get; private set; }

        public DayLimits SaturdayLimits { get; private set; }

        public DayLimits SundayLimits { get; private set; }
    }
}
