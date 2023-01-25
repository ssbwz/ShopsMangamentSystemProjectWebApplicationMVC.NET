using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using System.Data;

namespace MediaBazaar.DataAccess
{
    public interface IReshelveRequestStorage
    {
        public ReshelveRequest GetReshelveRequestById(int reshelveRequestId);

        public DataTable GetSentReshelveRequests();

        public void UpdateStatusByReshelveRequestId(int reshelveRequestId, TrackingStatus trackingStatus);

        public void CreateReshelveRequest(int creatorId);

        public int? GetReshelveRequestIdByPersonIdIfStatusCreated(int employeeId);

        public DataTable GetReshelveRequests();

        public DataTable GetRequestItems(int id);

        public DataTable GetRequestDetails2(int id);

        public void AssignEmployeeToRequest(int requestId, int userId);

        private protected int getCreaterIdByReshleveRequestId(int reshelveRequestId);

        private protected int getAssignedToIdByReshleveRequestId(int reshelveRequestId);

        public bool UpdateStatusInRestockRequest(int id, TrackingStatus trackingStatus);

        public void UpdateArrivalDate(int id, DateTime date);

    }
}
