using Sydesoft.NfcDevice;
using MediaBazaar.Managers;
using System.Data;
using MediaBazaar.DataAccess;

try
{

    var timeNow = DateTime.Now.TimeOfDay;

    var morningShift_start = new TimeSpan(8, 0, 0);
    var afternoonShift_start = new TimeSpan(12, 30, 0);
    var eveningShift_start = new TimeSpan(17, 0, 0);
    var eveningShift_end = new TimeSpan(21, 30, 0);

    // nfc scanner setup
    var acr122u = new ACR122U();
    acr122u.Init(false, 50, 4, 4, 200);
    acr122u.CardInserted += Acr122u_CardInserted;
    acr122u.CardRemoved += Acr122u_CardRemoved;

    // on card/token scan
    void Acr122u_CardInserted(PCSC.ICardReader reader)
    {
        // db setup
        var em = new EmployeeManager(Connection.Connect);
        var sm = new ScheduleManager(Connection.Connect);

        Console.WriteLine("token scanned");

        var todayDate = DateOnly.FromDateTime(DateTime.Now);
        string cardId;
        try
        {
            cardId = BitConverter.ToString(acr122u.GetUID(reader));
        }
        catch (PCSC.Exceptions.RemovedCardException)
        {
            Connection.CloseConnection();
            Console.WriteLine("Error occurred when scanning card, please try again.");
            return;
        }

        var user = em.GetEmployeeByCardId(cardId);

        if (user is null)
        {
            Console.WriteLine(cardId);
            Console.WriteLine("Unrecognized card, please try again.");
            return;
        }

        var shiftsToday = sm.GetEmployeeShiftsPerDay(user.Id, todayDate);
        if (shiftsToday.Rows.Count == 0)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName}, you have no shifts scheduled for today.");
            return;
        }

        var lastCheckout = sm.GetLastEmployeeCheckInOutDirection(user.Id, todayDate);

        if (lastCheckout == "IN")
        {
            Console.WriteLine($"Goodbye {user.Username}");
            sm.InsertCheckOut(user.Id, DateTime.Now, "TOKEN");
            return;
        }

        Console.WriteLine($"Welcome {user.Username}");

        foreach (DataRow row in shiftsToday.Rows)
        {
            // check shifts for today
            if (row["shift_time"].ToString() == "Morning")
            {
                // employee less than 30 mins early
                if ((morningShift_start - timeNow).TotalMinutes > 0 && (morningShift_start - timeNow).TotalMinutes <= 30)
                {
                    // mark present
                    sm.MarkEmployeePresent(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
                // employee less than 30 mins late
                else if ((timeNow - morningShift_start).TotalMinutes > 0 && (timeNow - morningShift_start).TotalMinutes <= 30)
                {
                    // mark present
                    sm.MarkEmployeePresent(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
                // employee more than 30 mins late
                else if ((timeNow - morningShift_start).TotalMinutes > 30)
                {
                    // mark present
                    sm.MarkEmployeeLate(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
            }
            else if (row["shift_time"] == "Afternoon")
            {
                // employee less than 30 mins early
                if ((afternoonShift_start - timeNow).TotalMinutes > 0 && (afternoonShift_start - timeNow).TotalMinutes <= 30)
                {
                    // mark present
                    sm.MarkEmployeePresent(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
                // employee less than 30 mins late
                else if ((timeNow - afternoonShift_start).TotalMinutes > 0 && (timeNow - afternoonShift_start).TotalMinutes <= 30)
                {
                    // mark present
                    sm.MarkEmployeePresent(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
                // employee more than 30 mins late
                else if ((timeNow - afternoonShift_start).TotalMinutes > 30)
                {
                    // mark present
                    sm.MarkEmployeeLate(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
            }
            else if (row["shift_time"] == "Evening")
            {
                // employee less than 30 mins early
                if ((eveningShift_start - timeNow).TotalMinutes > 0 && (eveningShift_start - timeNow).TotalMinutes <= 30)
                {
                    // mark present
                    sm.MarkEmployeePresent(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
                // employee less than 30 mins late
                else if ((timeNow - eveningShift_start).TotalMinutes > 0 && (timeNow - eveningShift_start).TotalMinutes <= 30)
                {
                    // mark present
                    sm.MarkEmployeePresent(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
                // employee more than 30 mins late
                else if ((timeNow - eveningShift_start).TotalMinutes > 30)
                {
                    // mark present
                    sm.MarkEmployeeLate(user.Id, todayDate, MediaBazaar.Logic.Enums.ShiftTime.Morning);
                    // insert checkin
                    sm.InsertCheckInOut(user.Id, DateTime.Now, "TOKEN", GetOppositeDirection(lastCheckout));
                }
            }
        }

        //Closing the connection when employee status got inserted in the database
        Connection.CloseConnection();
    }

    // on card/token removal
    void Acr122u_CardRemoved()
    {
        Console.WriteLine("token removed");
    }

    //helper method
    string GetOppositeDirection(string direction)
    {
        if (direction == "")
            return "IN";
        return direction == "IN" ? "OUT" : "IN";
    }

    // leave terminal open
}
catch (Exception ex) 
{
    Connection.CloseConnection();
    Console.WriteLine("Error: " + ex.Message);
}
Console.ReadKey();