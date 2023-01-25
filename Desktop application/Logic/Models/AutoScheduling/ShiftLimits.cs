
namespace Logic.Models.AutoScheduling
{
    public class ShiftLimits
    {
        public ShiftLimits(int maxEmployees, int minEmployees) 
        {
            this.MaxEmployees = maxEmployees;
            this.MinEmployees = minEmployees;
        }
        
        public int MaxEmployees { get; private set; }

        public int MinEmployees { get; private set; }
    }
}
