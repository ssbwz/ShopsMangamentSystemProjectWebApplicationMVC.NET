using MediaBazaar.Logic.Enums;

namespace MediaBazaar.Logic.Models
{
    public class ReshelveRequest
    {
        public ReshelveRequest(int id, DateTime requestDate, DateTime? arrivalDate, TrackingStatus trackingStatus, Employee requestCreater, Employee assignedUser) 
        {
            this.Id = id;
            this.RequestDate = requestDate;
            this.ArrivalDate = arrivalDate;
            this.TrackingStatus = trackingStatus;
            this.RequestCreater = requestCreater;
            this.assignedUser = assignedUser;
        }

        public int Id { get;}

        public DateTime RequestDate { get;}

        public DateTime? ArrivalDate { get; set;}

        public TrackingStatus TrackingStatus { get; set; }

        public Employee RequestCreater { get;}

        public Employee assignedUser { get; set; }
    }
}
