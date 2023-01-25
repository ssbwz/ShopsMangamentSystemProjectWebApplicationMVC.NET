using MediaBazaar.Logic.Enums;

namespace MediaBazaar.Logic.Models
{
    public class Contract
    {
        public int? Id { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public decimal FTE { get; set; }

        public string? LeaveReason { get; set; }

        public int EmployeeId { get; set; }

        public int NumberOfShiftLeftForTheEmployee { get; set; }

        public Contract(int id, DateOnly startDate, DateOnly? endDate, decimal fte, string? leaveReason, int employeeId)
        {
            this.Id = id;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.FTE = fte;
            this.LeaveReason = leaveReason;
            this.EmployeeId = employeeId;
        }
    }
}
