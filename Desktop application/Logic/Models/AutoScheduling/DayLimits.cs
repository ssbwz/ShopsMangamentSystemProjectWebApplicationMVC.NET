
namespace Logic.Models.AutoScheduling
{
    public class DayLimits
    {
        public DayLimits(ShiftLimits moringShift, ShiftLimits afternoonShift, ShiftLimits eveningShift)
        {
            this.MorningShift = moringShift;
            this.AfternoonShift = afternoonShift;
            this.EveningShift = eveningShift;
        }

        public ShiftLimits MorningShift { get; private set; }

        public ShiftLimits AfternoonShift { get; private set; }

        public ShiftLimits EveningShift { get; private set; }
    }
}
