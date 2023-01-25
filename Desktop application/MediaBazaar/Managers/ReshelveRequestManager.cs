using MediaBazaar.DataAccess;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using System.Data;

namespace MediaBazaar.Managers
{
    public class ReshelveRequestManager
    {
        private ReshelveRequestStorage reshelveRequestStorage = new ReshelveRequestStorage();

        public ReshelveRequest GetReshelveRequestById(int reshelveRequestId) 
        {
            if (reshelveRequestId < 1) 
            {
                return null;
            }

          return  reshelveRequestStorage.GetReshelveRequestById(reshelveRequestId);
        }

        public DataTable GetDataTableOfAllReshelveRequests() 
        {
            return reshelveRequestStorage.GetReshelveRequests();
        }

        public int GetReshelveRequestIdPerEmployee(int employeeId)
        {
           int? reshelverequestId = reshelveRequestStorage.GetReshelveRequestIdByPersonIdIfStatusCreated(employeeId);
            if (reshelverequestId.Value != 0)
            {
                return reshelverequestId.Value;
            }
            else 
            {
                reshelveRequestStorage.CreateReshelveRequest(employeeId);
                return (int)reshelveRequestStorage.GetReshelveRequestIdByPersonIdIfStatusCreated(employeeId);
            }
        }

        public void UpdateStatusByReshelveRequestId(int reshelveRequestId, TrackingStatus trackingStatus)
        {
            reshelveRequestStorage.UpdateStatusByReshelveRequestId(reshelveRequestId, trackingStatus);
        }

        public DataTable GetRequestItems(int id)
        {
            return reshelveRequestStorage.GetRequestItems(id);
        }

        public DataTable GetDataTableOfAllSentReshelveRequests()
        {
            return reshelveRequestStorage.GetSentReshelveRequests();
        }

        public DataTable GetRequestDetails2(int id)
        {
            return reshelveRequestStorage.GetRequestDetails2(id);
        }

        public void AssignEmployeeToRequest(int requestId, int userId)
        {
            reshelveRequestStorage.AssignEmployeeToRequest(requestId, userId);
        }
        public bool UpdateStatusInRestockRequest(int id, TrackingStatus trackingStatus)
        {
            if (trackingStatus == TrackingStatus.Delivered)
            {
                reshelveRequestStorage.UpdateArrivalDate(id, DateTime.Today);
            }
            return reshelveRequestStorage.UpdateStatusInRestockRequest(id, trackingStatus);
        }
    }
}
