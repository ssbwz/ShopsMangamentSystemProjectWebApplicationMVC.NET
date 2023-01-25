using System.Data;
using System.Diagnostics;
using DataAccess;
using Logic.Enums;
using Logic.Interfaces;
using Logic.Models;
using Logic.Models.AutoScheduling;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace MediaBazaar.Managers
{
    public class ScheduleManager
    {
        private readonly MySqlConnection conn;

        private EmployeeManager employeeManager;

        public ScheduleManager(MySqlConnection conn)
        {
            this.conn = conn;

            employeeManager = new EmployeeManager(conn);
        }

        public int GetNumEmployeesPerShift(DateOnly date, ShiftTime shift)
        {
            var cmd = new MySqlCommand(
                "select count(*) from schedule s join schedule_shifts ss on s.id = ss.schedule_id where s.work_date = @WORK_DATE and ss.shift_time = @SHIFT",
                conn);

            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("SHIFT", shift.ToString());

            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public DataTable GetEmployeesPerShift(DateOnly date, ShiftTime shift)
        {
            var adapter = new MySqlDataAdapter(
                "select e.id, e.first_name, e.last_name from schedule s join schedule_shifts ss on s.id = ss.schedule_id join employees e on e.id = s.user_id where s.work_date = @WORK_DATE and ss.shift_time = @SHIFT",
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            adapter.SelectCommand.Parameters.AddWithValue("SHIFT", shift.ToString());

            var dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }

        public int GetNumEmployeesPerShiftPerDepartment(DateOnly date, ShiftTime shift, string department)
        {
            var cmd = new MySqlCommand(
                "select count(*) from schedule s join schedule_shifts ss on s.id = ss.schedule_id INNER JOIN employees_departments as ed ON s.user_id = ed.user_id " +
                "INNER JOIN departments as d on ed.job_id = d.id where s.work_date = @WORK_DATE and ss.shift_time = @SHIFT AND d.department = @DEPARTMENT;",
                conn);

            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("SHIFT", shift.ToString());
            cmd.Parameters.AddWithValue("DEPARTMENT", department);

            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public int GetNumEmployeesPerDay(DateOnly date)
        {
            var cmd = new MySqlCommand(
                "select count(*) from schedule where work_date = @WORK_DATE",
                conn);

            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public DataTable GetEmployeesPerDay(DateOnly date)
        {
            var adapter = new MySqlDataAdapter(
                "select e.id as ID, e.first_name as 'First name', e.last_name as 'Last name' from schedule s join employees e on e.id = s.user_id where s.work_date = @WORK_DATE",
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

            var dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }

        public int GetPresentEmployeesPerDay(DateOnly date)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT s.user_id) from schedule as s INNER JOIN schedule_shifts as ss ON s.id = ss.schedule_id" +
                " WHERE ss.is_present = true AND work_date = @DATE;", conn);

            cmd.Parameters.AddWithValue("DATE", date.ToString("yyyy-MM-dd"));

            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public int GetAllAbsentEmployeesPerDay(DateOnly date)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT s.user_id) from schedule as s INNER JOIN schedule_shifts as ss ON s.id = ss.schedule_id" +
                " WHERE ss.is_present = false AND work_date = @DATE;", conn);

            cmd.Parameters.AddWithValue("DATE", date.ToString("yyyy-MM-dd"));

            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public int GetSickEmployeesPerDay(DateOnly date)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(DISTINCT s.user_id) from schedule as s INNER JOIN schedule_shifts as ss ON s.id = ss.schedule_id" +
                " WHERE ss.is_present = false AND ss.absence_reason LIKE '%sick%' AND work_date = @DATE;", conn);

            cmd.Parameters.AddWithValue("DATE", date.ToString("yyyy-MM-dd"));

            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public DataTable GetNumEmployeesPerWeek(int year, int weekNum)
        {
            var adapter = new MySqlDataAdapter(
                String.Join(
                    Environment.NewLine,
                        "select",
                        "concat(Date, ' - ', dayname(Date)) as Shift,",
                        "count(case when ss.shift_time = 'Morning' then s.id end) as Morning,",
                        "count(case when ss.shift_time = 'Afternoon' then s.id end) as Afternoon,",
                        "count(case when ss.shift_time = 'Evening' then s.id end) as Evening",
                        "from (select str_to_date(concat(@YEAR, '-', @WEEK_NUM, ' Monday'), '%Y-%u %W') + interval a.a day as Date from(select 0 as a union all select 1 union all select 2 union all select 3 union all select 4 union all select 5 union all select 6) a) b",
                        "left join schedule s on Date = s.work_date",
                        "left join schedule_shifts ss on s.id = ss.schedule_id",
                        "group by Shift"),
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("WEEK_NUM", weekNum);
            adapter.SelectCommand.Parameters.AddWithValue("YEAR", year);

            var dt = new DataTable();

            adapter.Fill(dt);

            var finalTable = GetTransposedTable(dt);

            return finalTable;


            //throw new NotImplementedException();
        }

        public DataTable GetEmployeeWeeklySchedule(int userId, int year, int weekNum)
        {
            var adapter = new MySqlDataAdapter(
                String.Join(
                    Environment.NewLine,
                        "select",
                        "concat(Date, ' - ', dayname(Date)) as Date,",
                        "group_concat(case when ss.shift_time = 'Morning' and s.user_id = @USER_ID then 'Assigned' end) as Morning,",
                        "group_concat(case when ss.shift_time = 'Afternoon' and s.user_id = @USER_ID then 'Assigned' end) as Afternoon,",
                        "group_concat(case when ss.shift_time = 'Evening' and s.user_id = @USER_ID then 'Assigned' end) as Evening ",
                        "from (select str_to_date(concat(@YEAR, '-', @WEEK_NUM, 'Monday'), '%Y-%u %W') + interval a.a day as Date from(select 0 as a union all select 1 union all select 2 union all select 3 union all select 4 union all select 5 union all select 6) a) b ",
                        "left join schedule s on Date = s.work_date",
                        "left join schedule_shifts ss on s.id = ss.schedule_id",
                        "group by Date",
                        "order by Date asc"),
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("USER_ID", userId);
            adapter.SelectCommand.Parameters.AddWithValue("WEEK_NUM", weekNum);
            adapter.SelectCommand.Parameters.AddWithValue("YEAR", year);

            var dt = new DataTable();

            adapter.Fill(dt);

            var finalTable = GetTransposedTable(dt);

            return finalTable;
        }

        public DataTable FillEmployeeWeeklyScheduleWithUnavailabilities(DataTable baseDataTable, int userId)
        {
            var adapter = new MySqlDataAdapter(
                    "select * from unavailability " +
                    "where user_id = @USER_ID",
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("USER_ID", userId);

            var dt = new DataTable();

            adapter.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 1; i < baseDataTable.Columns.Count; i++)
                {
                    var dayDate = DateTime.ParseExact(baseDataTable.Columns[i].ToString().Split(" - ")[0], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    var unavailabilityStart = DateTime.ParseExact(row["start_date"].ToString().Trim(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    var unavailabilityEnd = DateTime.ParseExact(row["end_date"].ToString().Trim(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                    if (dayDate >= unavailabilityStart && dayDate <= unavailabilityEnd)
                    {
                        baseDataTable.Rows[0][i] = row["reason"];
                        baseDataTable.Rows[1][i] = row["reason"];
                        baseDataTable.Rows[2][i] = row["reason"];
                    }
                }
            }
            return baseDataTable;
        }

        public DataTable GetEmployeeShiftsPerDay(int user_id, DateOnly date)
        {
            var adapter = new MySqlDataAdapter(
                "select s. work_date, ss.shift_time from schedule_shifts ss " +
                "left join schedule s " +
                "on s.id = ss.schedule_id " +
                "where s.user_id = @USER_ID and s.work_date = @WORK_DATE",
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("USER_ID", user_id);
            adapter.SelectCommand.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

            var dt = new DataTable();

            adapter.Fill(dt);

            return dt;
        }

        public void InsertCheckIn(int user_id, DateTime datetime, string tokenType)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO check_ins (user_id, scanned_on, token_type, direction) VALUES(@USER_ID, @DATE, @TOKEN, @DIRECTION);",
                conn);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("DATE", datetime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("TOKEN", tokenType);
            cmd.Parameters.AddWithValue("DIRECTION", "IN");

            cmd.ExecuteNonQuery();
        }

        public void InsertCheckOut(int user_id, DateTime datetime, string tokenType)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO check_ins (user_id, scanned_on, token_type, direction) VALUES(@USER_ID, @DATE, @TOKEN, @DIRECTION);",
                conn);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("DATE", datetime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("TOKEN", tokenType);
            cmd.Parameters.AddWithValue("DIRECTION", "OUT");

            cmd.ExecuteNonQuery();
        }

        public void InsertCheckInOut(int user_id, DateTime datetime, string tokenType, string direction)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO check_ins (user_id, scanned_on, token_type, direction) VALUES(@USER_ID, @DATE, @TOKEN, @DIRECTION);",
                conn);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("DATE", datetime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("TOKEN", tokenType);
            cmd.Parameters.AddWithValue("DIRECTION", direction.ToUpper());

            cmd.ExecuteNonQuery();
        }

        public bool CheckMaxShiftsPerDay(int user_id, DateOnly date)
        {
            var cmd = new MySqlCommand(
                "select count(ss.id) as shiftsPerDay from schedule s " +
                "join schedule_shifts ss on ss.schedule_id = s.id " +
                "where s.user_id = @USER_ID and s.work_date = @WORK_DATE",
                conn);

            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

            int result = Convert.ToInt32(cmd.ExecuteScalar());

            // return true when user has been assigned maximum amount of shifts a day (2), otherwise false

            return result > 1;
        }

        public bool CheckMaxShiftsPerWeek(int user_id, DateOnly date)
        {
            var cmd = new MySqlCommand(
                "select count(*) from schedule s " +
                "join schedule_shifts ss " +
                "on s.id = ss.schedule_id " +
                "where s.user_id =  @USER_ID and week(s.work_date, 1) = week(@WORK_DATE, 1)",
                conn);

            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

            int result = Convert.ToInt32(cmd.ExecuteScalar());

            // return true when user has been assigned maximum amount of days a week (5), otherwise false

            return result > 4;
        }

        public void AssignUserShift(int user_id, DateOnly date, ShiftTime shift)
        {
            var cmd1 = new MySqlCommand(
                "insert ignore into schedule (user_id, work_date) values (@USER_ID, @WORK_DATE);" +
                "select id from schedule where user_id=@USER_ID and work_date=@WORK_DATE;",
                conn);

            cmd1.Parameters.AddWithValue("USER_ID", user_id);
            cmd1.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

            var result1 = cmd1.ExecuteScalar();

            var cmd2 = new MySqlCommand(
                "insert ignore into schedule_shifts (schedule_id, shift_time) values (@SCHEDULE_ID, @SHIFT)",
                conn);

            cmd2.Parameters.AddWithValue("SCHEDULE_ID", Convert.ToInt32(result1));
            cmd2.Parameters.AddWithValue("SHIFT", shift.ToString());

            cmd2.ExecuteNonQuery();
        }

        public void UpdateEmployeePresence(int user_id, DateOnly date, bool isPresent, string? absenceReason)
        {
            var cmd = new MySqlCommand(
                "update schedule set is_present=@IS_PRESENT, absence_reason=@ABSENCE_REASON where user_id=@USER_ID and work_date=@WORK_DATE",
                conn);
            cmd.Parameters.AddWithValue("IS_PRESENT", isPresent);
            cmd.Parameters.AddWithValue("ABSENCE_REASON", absenceReason);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

            cmd.ExecuteNonQuery();
        }

        public void DeleteUserShift(int user_id, DateOnly date, ShiftTime shift)
        {
            var cmd1 = new MySqlCommand(
                "delete ss from schedule_shifts ss " +
                "join schedule s " +
                "on s.id = ss.schedule_id " +
                "where s.work_date = @WORK_DATE and ss.shift_time = @SHIFT and s.user_id = @USER_ID;",
                conn);

            cmd1.Parameters.AddWithValue("USER_ID", user_id);
            cmd1.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            cmd1.Parameters.AddWithValue("SHIFT", shift.ToString());

            cmd1.ExecuteNonQuery();

            // 2nd command

            var cmd2 = new MySqlCommand(
                "delete schedule from schedule " +
                "where not exists " +
                "(select 1 from schedule_shifts where schedule.id = schedule_shifts.schedule_id) and schedule.work_date = @WORK_DATE and schedule.user_id = @USER_ID",
                conn);

            cmd2.Parameters.AddWithValue("USER_ID", user_id);
            cmd2.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            cmd2.ExecuteNonQuery();
        }

        public Shift GetShift(DateOnly date, ShiftTime shiftTime)
        {
            try
            {
                List<Attendance> attendances = new List<Attendance>();

                var cmd = new MySqlCommand(
        "select e.id, e.first_name, e.last_name,e.address,e.birthday,e.phone_num,e.spouse_phone_num,e.BSN,e.is_active,e.username,e.email,e.password," +
        "ss.is_present, ss.absence_reason, ss.attendance_status " +
        "from schedule s join schedule_shifts ss on s.id = ss.schedule_id join employees e on e.id = s.user_id " +
        "where s.work_date = @WORK_DATE and ss.shift_time = @SHIFT",
        conn);

                cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("SHIFT", shiftTime.ToString());

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string firstName = reader.GetString("first_name");
                        string lastName = reader.GetString("last_name");
                        string address = reader.GetString("address");
                        DateOnly birthday = DateOnly.FromDateTime(reader.GetDateTime("birthday"));
                        int phoneNumber = reader.GetInt32("phone_num");
                        int? spousePhoneNum = reader["spouse_phone_num"] != DBNull.Value ? reader.GetInt32("spouse_phone_num") : null;
                        int BSN = reader.GetInt32("BSN");
                        bool isActive = reader.GetBoolean("is_active");
                        string username = reader.GetString("username");
                        string email = reader.GetString("email");
                        string password = reader.GetString("password");

                        ISettingsRepository settingRepostiry = new SettingsStorage(id);

                        Employee employee = new Employee(id, firstName, lastName, address
                            , birthday, phoneNumber, spousePhoneNum, BSN, isActive, username,
                            email, password, settingRepostiry);


                        bool? isPresent = reader["is_present"] != DBNull.Value ? reader.GetBoolean("is_present") : null;
                        string absenceReason = reader.GetString("absence_reason");
                        AttendanceStatus? attendanceStatus = reader["attendance_status"] != DBNull.Value ? (AttendanceStatus)Enum.Parse(typeof(AttendanceStatus), reader.GetString("attendance_status")) : null;


                        attendances.Add(new Attendance(employee, isPresent, absenceReason, attendanceStatus));
                    }
                }

                return new Shift(date, shiftTime, attendances);
            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateShift(Shift shift)
        {
            try
            {
                string sql = string.Empty;

                var cmd = new MySqlCommand(
                sql,
                conn);

                sql = "UPDATE schedule_shifts ss INNER JOIN schedule s ON ss.schedule_id = s.id SET";

                string isPresentForEmployeesPerShift = "(CASE ";
                string absenceReasonForEmployeesPerShift = "(CASE ";

                //Adding the attendance per each employee
                for (int i = 0; i < shift.Attendances.Count; i++)
                {
                    isPresentForEmployeesPerShift += $"when s.user_id = @USERID{i} then @ISPRESENT{i} ";
                    absenceReasonForEmployeesPerShift += $"when s.user_id = @USERID{i} then @ABSENCEREASON{i} ";


                    cmd.Parameters.AddWithValue($"USERID{i}", shift.Attendances[i].Employee.Id);
                    cmd.Parameters.AddWithValue($"ISPRESENT{i}", shift.Attendances[i].IsPresent);
                    cmd.Parameters.AddWithValue($"ABSENCEREASON{i}", shift.Attendances[i].AbsenceReason);
                }

                isPresentForEmployeesPerShift += " END)";
                absenceReasonForEmployeesPerShift += " END)";

                //Adding the employees ides to the where clause
                string ids = string.Empty;
                foreach (var attendance in shift.Attendances)
                {
                    ids += $"'{attendance.Employee.Id}',";
                }
                ids = ids.Remove(ids.Length - 1);

                sql += $" ss.is_present = {isPresentForEmployeesPerShift}, ss.absence_reason= {absenceReasonForEmployeesPerShift}" +
                    $" WHERE s.user_id in ({ids}) and s.work_date = @WORK_DATE and ss.shift_time = @SHIFT";

                cmd.Parameters.AddWithValue("WORK_DATE", shift.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("SHIFT", shift.ShiftTime.ToString());

                cmd.CommandText = sql;

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        private List<Shift> getDayShifts(DateOnly date)
        {
            try
            {
                List<Attendance> attendancesMorning = new List<Attendance>();
                List<Attendance> attendancesAfternoon = new List<Attendance>();
                List<Attendance> attendancesEvening = new List<Attendance>();

                var cmd = new MySqlCommand(
        " select ss.shift_time, e.id, e.first_name, e.last_name,e.address,e.birthday,e.phone_num,e.spouse_phone_num,e.BSN,e.is_active,e.username,e.email,e.password," +
        " ss.is_present, ss.absence_reason, ss.attendance_status, c.id contract_id, c.start_date, c.end_date,c.FTE, c.leave_reason " +
        " from schedule s join schedule_shifts ss on s.id = ss.schedule_id join employees e on e.id = s.user_id " +
        " inner join contracts c" +
        " On e.id = c.employee_id" +
        " where s.work_date = @WORK_DATE ",
        conn);

                cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int employeeId = reader.GetInt32("id");

                        Employee? existedEmployeeInOneOfTheLists = getEmployee(employeeId);
                        Employee employee = null;

                        //Using the same employee object if the employee existed in other shift
                        if (existedEmployeeInOneOfTheLists != null)
                        {
                            employee = existedEmployeeInOneOfTheLists;
                        }
                        else
                        {
                            string firstName = reader.GetString("first_name");
                            string lastName = reader.GetString("last_name");
                            string address = reader.GetString("address");
                            DateOnly birthday = DateOnly.FromDateTime(reader.GetDateTime("birthday"));
                            int phoneNumber = reader.GetInt32("phone_num");
                            int? spousePhoneNum = reader["spouse_phone_num"] != DBNull.Value ? reader.GetInt32("spouse_phone_num") : null;
                            int BSN = reader.GetInt32("BSN");
                            bool isActive = reader.GetBoolean("is_active");
                            string username = reader.GetString("username");
                            string email = reader.GetString("email");
                            string password = reader.GetString("password");


                            ISettingsRepository settingRepostiry = new SettingsStorage(employeeId);

                            employee = new Employee(employeeId, firstName, lastName, address
                                , birthday, phoneNumber, spousePhoneNum, BSN, isActive, username,
                                email, password, settingRepostiry);

                            //Getting contract 
                            int contractId = reader.GetInt32("contract_id");
                            DateOnly startDate = DateOnly.FromDateTime(reader.GetDateTime("start_date"));
                            DateOnly? endDate = reader["end_date"] != DBNull.Value ? DateOnly.FromDateTime(reader.GetDateTime("end_date")) : null;
                            decimal fte = reader.GetDecimal("FTE");
                            string? leaveReason = reader["leave_reason"] != DBNull.Value ? reader.GetString("leave_reason") : null;

                            employee.Contract = new Contract(contractId, startDate, endDate, fte, leaveReason, employeeId);
                        }

                        bool? isPresent = reader["is_present"] != DBNull.Value ? reader.GetBoolean("is_present") : null;
                        string absenceReason = reader.GetString("absence_reason");
                        AttendanceStatus? attendanceStatus = reader["attendance_status"] != DBNull.Value ? (AttendanceStatus)Enum.Parse(typeof(AttendanceStatus), reader.GetString("attendance_status")) : null;


                        Attendance attendance = new Attendance(employee, isPresent, absenceReason, attendanceStatus);

                        switch ((ShiftTime)Enum.Parse(typeof(ShiftTime), reader.GetString("shift_time")))
                        {
                            case ShiftTime.Morning: attendancesMorning.Add(attendance); break;
                            case ShiftTime.Afternoon: attendancesAfternoon.Add(attendance); break;
                            case ShiftTime.Evening: attendancesEvening.Add(attendance); break;
                        }
                    }
                }

                List<Shift> dayShifts = new List<Shift>();

                dayShifts.Add(new Shift(date, ShiftTime.Morning, attendancesMorning));
                dayShifts.Add(new Shift(date, ShiftTime.Afternoon, attendancesAfternoon));
                dayShifts.Add(new Shift(date, ShiftTime.Evening, attendancesEvening));

                return dayShifts;

                //Geting the employee object instead of making new one to use the referencing to change the FTE for all of the employee objects in the system
                Employee getEmployee(int employeeId)
                {
                    foreach (Attendance employeeMorning in attendancesMorning)
                    {
                        if (employeeMorning.Employee.Id == employeeId)
                        {
                            return employeeMorning.Employee;
                        }
                    }
                    foreach (Attendance employeeAfternoon in attendancesAfternoon)
                    {
                        if (employeeAfternoon.Employee.Id == employeeId)
                        {
                            return employeeAfternoon.Employee;
                        }
                    }
                    foreach (Attendance employeeEvening in attendancesEvening)
                    {
                        if (employeeEvening.Employee.Id == employeeId)
                        {
                            return employeeEvening.Employee;
                        }
                    }

                    return null;

                }
            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        private List<List<Shift>> getWeekSchedule(int year, int weekNumber)
        {
            DateOnly firstDayDate = DateOnly.FromDateTime(firstDateOfWeekISO8601(year, weekNumber));

            List<List<Shift>> weekShifts = new List<List<Shift>>();

            for (int i = 0; i < 7; i++)
            {
                weekShifts.Add(getDayShifts(firstDayDate.AddDays(i)));
            }

            return weekShifts;
        }

        private List<List<Employee>> getAvailableEmployeesPerWeek(int year, int weekNumber)
        {
            DateOnly firstDayDate = DateOnly.FromDateTime(firstDateOfWeekISO8601(year, weekNumber));

            List<List<Employee>> availableEmployeesForWeek = new List<List<Employee>>();

            List<Employee> gottenAvailableEmployeesForday = null;
            for (int i = 0; i < 7; i++)
            {
                gottenAvailableEmployeesForday = getAvailableEmployeesPerDate(firstDayDate.AddDays(i));

                availableEmployeesForWeek.Add(gottenAvailableEmployeesForday);
            }
            return availableEmployeesForWeek;
        }

        private List<Employee> getAvailableEmployeesPerDate(DateOnly date)
        {
            try
            {
                List<Employee> availableEmployees = new List<Employee>();
                var cmd = new MySqlCommand(
        "SELECT e.id, e.first_name, e.last_name,e.address,e.birthday,e.phone_num,e.spouse_phone_num,e.BSN,e.is_active,e.username,e.email,e.password, " +
        "c.id contract_id, c.start_date contract_start_date, c.end_date contract_end_date, c.FTE, c.leave_reason " +
        "from employees e inner join contracts c On e.id = c.employee_id " +
        "Where e.id NOT IN( SELECT e.id " +
        "from employees e LEFT JOIN unavailability u ON e.id = u.user_id inner join contracts c On e.id = c.employee_id " +
        "WHERE e.is_active = '1' and u.start_date NOT BETWEEN CAST(@WORK_DATE AS DATE) and CAST(@WORK_DATE AS DATE)" +
        " AND u.end_date NOT BETWEEN CAST(@WORK_DATE AS DATE) and CAST(@WORK_DATE AS DATE)" +
        " or u.end_date = null " +
        "GROUP By e.id)",
        conn);

                cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int employeeId = reader.GetInt32("id");
                        string firstName = reader.GetString("first_name");
                        string lastName = reader.GetString("last_name");
                        string address = reader.GetString("address");
                        DateOnly birthday = DateOnly.FromDateTime(reader.GetDateTime("birthday"));
                        int phoneNumber = reader.GetInt32("phone_num");
                        int? spousePhoneNum = reader["spouse_phone_num"] != DBNull.Value ? reader.GetInt32("spouse_phone_num") : null;
                        int BSN = reader.GetInt32("BSN");
                        bool isActive = reader.GetBoolean("is_active");
                        string username = reader.GetString("username");
                        string email = reader.GetString("email");
                        string password = reader.GetString("password");

                        ISettingsRepository settingRepostiry = new SettingsStorage(employeeId);

                        Employee employee = new Employee(employeeId, firstName, lastName, address
                            , birthday, phoneNumber, spousePhoneNum, BSN, isActive, username,
                            email, password, settingRepostiry);

                        //Getting contract 
                        int contractId = reader.GetInt32("contract_id");
                        DateOnly startDate = DateOnly.FromDateTime(reader.GetDateTime("contract_start_date"));
                        DateOnly? endDate = reader["contract_end_date"] != DBNull.Value ? DateOnly.FromDateTime(reader.GetDateTime("contract_end_date")) : null;
                        decimal fte = reader.GetDecimal("FTE");
                        string? leaveReason = reader["leave_reason"] != DBNull.Value ? reader.GetString("leave_reason") : null;

                        employee.Contract = new Contract(contractId, startDate, endDate, fte, leaveReason, employeeId);

                        const int ONE_FTE_HOURS = 40;
                        const int SHIFT_DURATION = 4;

                        //Calculating how many shift can the employee takes by using FTE
                        employee.Contract.NumberOfShiftLeftForTheEmployee = (Convert.ToInt32(Math.Floor(employee.Contract.FTE * ONE_FTE_HOURS / SHIFT_DURATION)));


                        availableEmployees.Add(employee);
                    }
                }

                return availableEmployees;
            }
            catch (MySqlException ex)
            {
                Connection.CloseConnection();
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public void GenerateWeekSchedule(int year, int weekNumber, WeekLimits weekLimits)
        {
            const int MONDAY_INDEX = 0;
            const int TUESDAY_INDEX = 1;
            const int WEDNESDAY_INDEX = 2;
            const int THURSDAY_INDEX = 3;
            const int FRIDAY_INDEX = 4;
            const int SATURDAY_INDEX = 5;
            const int SUNDAY_INDEX = 6;

            ///<para>This schedule holds the last version of the the schedule which combined between addedShiftsPerWeek and the schedule in the database</para>
            List<List<Shift>> lastUpdatedSchedulePerWeek = getWeekSchedule(year, weekNumber);
            List<List<Employee>> availableEmployeesPerWeek = getAvailableEmployeesPerWeek(year, weekNumber);


            List<List<Shift>> addedShiftsPerWeek = new List<List<Shift>>();

            //Clone the old schedule to create the index for each day and for each shift
            clonelastUpdatedSchedulePerWeek();

            replaceTheNewEmployeeObejctWithOldEmployeeObject();

            calculateNumberOfShiftLeftForTheEmployeePerEmployeeForAWeek(lastUpdatedSchedulePerWeek, availableEmployeesPerWeek);

            scheduleForWeek();

            foreach (List<Employee> availableEmployeesPerDay in availableEmployeesPerWeek)
            {
                if (isWeekNeedsMore())
                {
                    scheduleForWeek();
                }
            }

            InsertSchedule(addedShiftsPerWeek);

            //Clone the old schedule to create the index for each day and for each shift
            void clonelastUpdatedSchedulePerWeek()
            {
                for (int dayIndex = 0; dayIndex < lastUpdatedSchedulePerWeek.Count; dayIndex++)
                {
                    addedShiftsPerWeek.Add(new List<Shift>());

                    for (int shiftIndex = 0; shiftIndex < 3; shiftIndex++)
                    {
                        DateOnly dateOnly = lastUpdatedSchedulePerWeek[dayIndex][shiftIndex].Date;
                        ShiftTime shiftTime = lastUpdatedSchedulePerWeek[dayIndex][shiftIndex].ShiftTime;

                        addedShiftsPerWeek[dayIndex].Add(new Shift(dateOnly, shiftTime, new List<Attendance>()));
                    }
                }
            }

            //ToDo: make it go throw the day not the week to save time
            void scheduleForWeek()
            {
                //Seperating the scheduling method per day to prevent looping through each day to check if it possible to schedule per shift

                //Scheduling for monday
                if (isShiftNeedsMore(MONDAY_INDEX, ShiftTime.Morning))
                {
                    scheduleForShift(MONDAY_INDEX, ShiftTime.Morning);
                }
                if (isShiftNeedsMore(MONDAY_INDEX, ShiftTime.Afternoon))
                {
                    scheduleForShift(MONDAY_INDEX, ShiftTime.Afternoon);
                }
                if (isShiftNeedsMore(MONDAY_INDEX, ShiftTime.Evening))
                {
                    scheduleForShift(MONDAY_INDEX, ShiftTime.Evening);
                }
                //Scheduling for tuesday
                if (isShiftNeedsMore(TUESDAY_INDEX, ShiftTime.Morning))
                {
                    scheduleForShift(TUESDAY_INDEX, ShiftTime.Morning);
                }
                if (isShiftNeedsMore(TUESDAY_INDEX, ShiftTime.Afternoon))
                {
                    scheduleForShift(TUESDAY_INDEX, ShiftTime.Afternoon);
                }
                if (isShiftNeedsMore(TUESDAY_INDEX, ShiftTime.Evening))
                {
                    scheduleForShift(TUESDAY_INDEX, ShiftTime.Evening);
                }
                //Scheduling for wedensday
                if (isShiftNeedsMore(WEDNESDAY_INDEX, ShiftTime.Morning))
                {
                    scheduleForShift(WEDNESDAY_INDEX, ShiftTime.Morning);
                }
                if (isShiftNeedsMore(WEDNESDAY_INDEX, ShiftTime.Afternoon))
                {
                    scheduleForShift(WEDNESDAY_INDEX, ShiftTime.Afternoon);
                }
                if (isShiftNeedsMore(WEDNESDAY_INDEX, ShiftTime.Evening))
                {
                    scheduleForShift(WEDNESDAY_INDEX, ShiftTime.Evening);
                }
                //Scheduling for thursday
                if (isShiftNeedsMore(THURSDAY_INDEX, ShiftTime.Morning))
                {
                    scheduleForShift(THURSDAY_INDEX, ShiftTime.Morning);
                }
                if (isShiftNeedsMore(THURSDAY_INDEX, ShiftTime.Afternoon))
                {
                    scheduleForShift(THURSDAY_INDEX, ShiftTime.Afternoon);
                }
                if (isShiftNeedsMore(THURSDAY_INDEX, ShiftTime.Evening))
                {
                    scheduleForShift(THURSDAY_INDEX, ShiftTime.Evening);
                }
                //Scheduling for friday
                if (isShiftNeedsMore(FRIDAY_INDEX, ShiftTime.Morning))
                {
                    scheduleForShift(FRIDAY_INDEX, ShiftTime.Morning);
                }
                if (isShiftNeedsMore(FRIDAY_INDEX, ShiftTime.Afternoon))
                {
                    scheduleForShift(FRIDAY_INDEX, ShiftTime.Afternoon);
                }
                if (isShiftNeedsMore(FRIDAY_INDEX, ShiftTime.Evening))
                {
                    scheduleForShift(FRIDAY_INDEX, ShiftTime.Evening);
                }
                //Scheduling for saturday
                if (isShiftNeedsMore(SATURDAY_INDEX, ShiftTime.Morning))
                {
                    scheduleForShift(SATURDAY_INDEX, ShiftTime.Morning);
                }
                if (isShiftNeedsMore(SATURDAY_INDEX, ShiftTime.Afternoon))
                {
                    scheduleForShift(SATURDAY_INDEX, ShiftTime.Afternoon);
                }
                if (isShiftNeedsMore(SATURDAY_INDEX, ShiftTime.Evening))
                {
                    scheduleForShift(SATURDAY_INDEX, ShiftTime.Evening);
                }
                //Scheduling for sunday
                if (isShiftNeedsMore(SUNDAY_INDEX, ShiftTime.Morning))
                {
                    scheduleForShift(SUNDAY_INDEX, ShiftTime.Morning);
                }
                if (isShiftNeedsMore(SUNDAY_INDEX, ShiftTime.Afternoon))
                {
                    scheduleForShift(SUNDAY_INDEX, ShiftTime.Afternoon);
                }
                if (isShiftNeedsMore(SUNDAY_INDEX, ShiftTime.Evening))
                {
                    scheduleForShift(SUNDAY_INDEX, ShiftTime.Evening);
                }

                void scheduleForShift(int dayindex, ShiftTime shiftTime)
                {
                    //Getting list of available employees of the day

                    List<Employee> availableEmployeesPerDay = Shuffle(availableEmployeesPerWeek[dayindex]);

                    //Check if the available employees are empty and return
                    if (availableEmployeesPerDay.Count == 0)
                        return;

                    //Getting assgined employees of the selected shift
                    List<Employee> shiftEmployees = lastUpdatedSchedulePerWeek[dayindex][getShiftIndex(shiftTime)].Attendances.Select(Employee => Employee.Employee).ToList();

                    for (int avialableEmployee = 0; avialableEmployee < availableEmployeesPerDay.Count; avialableEmployee++)
                    {

                        if (availableEmployeesPerDay[avialableEmployee].Contract.NumberOfShiftLeftForTheEmployee <= 0)
                        {
                            availableEmployeesPerDay.Remove(availableEmployeesPerDay[avialableEmployee]);
                            avialableEmployee = 0;

                            //Check if the available employees are empty and return
                            if (availableEmployeesPerDay.Count == 0)
                                return;
                        }

                        for (int employeInShift = 0; employeInShift <= shiftEmployees.Count; employeInShift++)
                        {

                            //It will jumb the employee index from the list of avilable employee of the day  if the employee already in that shift
                            if (shiftEmployees.Count == 0 ? false : isAvaialableEmployeeInShift(availableEmployeesPerDay[avialableEmployee]))
                            {
                                break;
                            }

                            if (!hasTwoShiftInDay(dayindex) && hasAShiftLeft())
                            {
                                Attendance attendance = new Attendance(availableEmployeesPerDay[avialableEmployee], null, " ", null);
                                //Adding the employee in the shift in two lists in lastUpdatedSchedulePerWeek to check later for it and addedShiftsPerWeek which will be for inserting the new shifts in the database
                                addedShiftsPerWeek[dayindex][getShiftIndex(shiftTime)].Attendances.Add(attendance);
                                lastUpdatedSchedulePerWeek[dayindex][getShiftIndex(shiftTime)].Attendances.Add(attendance);

                                //Decreasing the FTE by one shift
                                availableEmployeesPerDay[avialableEmployee].Contract.NumberOfShiftLeftForTheEmployee -= 1;
                                return;
                            }

                            //Check if the available employees are empty and return
                            if (availableEmployeesPerDay.Count == 0)
                                return;

                            //Return true if employee has two shift else false
                            bool hasTwoShiftInDay(int dayindex)
                            {
                                int numberofShiftsPerDay = 0;
                                foreach (Shift shift in lastUpdatedSchedulePerWeek[dayindex])
                                {
                                    foreach (Attendance attendance in shift.Attendances)
                                    {
                                        if (availableEmployeesPerDay[avialableEmployee].Id == attendance.Employee.Id)
                                        {
                                            numberofShiftsPerDay++;
                                        }
                                    }
                                }

                                if (numberofShiftsPerDay < 2)
                                {
                                    return false;
                                }
                                else if (numberofShiftsPerDay == 2)
                                {
                                    //Removing employee from the day if they have two shifts
                                    availableEmployeesPerDay.Remove(availableEmployeesPerDay[avialableEmployee]);
                                    return true;
                                }
                                else
                                {
                                    throw new Exception("Something went wrong counting the number of shifts per day for employee");
                                }
                            }

                            //Return true if employee in the shift else false
                            bool isAvaialableEmployeeInShift(Employee availableEmployee)
                            {
                                foreach (Attendance attendance in lastUpdatedSchedulePerWeek[dayindex][getShiftIndex(shiftTime)].Attendances)
                                {
                                    if (attendance.Employee.Id == availableEmployee.Id)
                                    {
                                        return true;
                                    }

                                }
                                return false;
                            }

                            //Return true if employee in has a shift left else false
                            bool hasAShiftLeft()
                            {
                                return availableEmployeesPerDay[avialableEmployee].Contract.NumberOfShiftLeftForTheEmployee > 0;
                            }
                        }
                    }


                }
            }

            //isDayNeedsMore checks all of the days in that week return true if it can take more and there is enough employees otherwise false
            bool isWeekNeedsMore()
            {
                for (int dayIndex = 0; dayIndex < lastUpdatedSchedulePerWeek.Count; dayIndex++)
                {

                    //isDayNeedsMore checks all of the shifts in that day return true if it can take more and there is enough employees otherwise false
                    if (canAddEmployeesInDay())
                    {
                        return true;
                    }

                    //isDayNeedsMore checks all of the shifts in that day return true if it can take more and there is enough employees otherwise false
                    bool canAddEmployeesInDay()
                    {
                        for (int shiftIndex = 0; shiftIndex < lastUpdatedSchedulePerWeek[dayIndex].Count; shiftIndex++)
                        {

                            if (canAddEmployeesInShift())
                            {
                                return true;
                            }

                            bool canAddEmployeesInShift()
                            {
                                int numberOfEmployeesForAShift = lastUpdatedSchedulePerWeek[dayIndex][shiftIndex].Attendances.Count;
                                int numberOfAvailableEmployeeForTheDay = availableEmployeesPerWeek[dayIndex].Count;

                                if (numberOfEmployeesForAShift < getShiftLimits(dayIndex, getShiftTime(shiftIndex)).MaxEmployees && numberOfAvailableEmployeeForTheDay != 0)
                                {
                                    return true;
                                }

                                return false;
                            }
                        }
                        return true;


                    }
                }

                return true;
            }

            ///<para>This method checks if the shift can add more  employees and it will return ture or not it will return false</para>
            bool isShiftNeedsMore(int dayindex, ShiftTime shiftTime)
            {
                switch (shiftTime)
                {
                    case ShiftTime.Afternoon: return isShiftNeedsMore(shiftTime);
                    case ShiftTime.Evening: return isShiftNeedsMore(shiftTime);
                    default: return isShiftNeedsMore(shiftTime);
                }

                ///<para>This method checks if the shift can add more employees and it will return ture or not it will return false</para>
                bool isShiftNeedsMore(ShiftTime shiftTime)
                {
                    int employeesInShiftCount = lastUpdatedSchedulePerWeek[dayindex][getShiftIndex(shiftTime)].Attendances.Count;

                    //When number of employees in that shift are less than requested
                    if (employeesInShiftCount < getShiftLimits(dayindex, shiftTime).MinEmployees)
                    {
                        return true;
                    }
                    //When number of employees in that shift are equal the maximum number of employees in that shift 
                    if (employeesInShiftCount == getShiftLimits(dayindex, shiftTime).MaxEmployees)
                    {
                        return false;
                    }
                    //When there are no employees available in that day
                    if (employeesInShiftCount != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }

            ///<para>This method gets the index by the shiftTime from the day</para>
            int getShiftIndex(ShiftTime shiftTime)
            {
                switch (shiftTime)
                {
                    case ShiftTime.Afternoon: return 1;
                    case ShiftTime.Evening: return 2;
                    default: return 0;

                }
            }

            ///<para>This method gets the shiftTime by the index of the day</para>
            ShiftTime getShiftTime(int shiftIndex)
            {
                switch (shiftIndex)
                {
                    case 1: return ShiftTime.Afternoon;
                    case 2: return ShiftTime.Evening;
                    default: return ShiftTime.Morning;

                }
            }

            ///<para>This method gets the Daylimits by the index in the List<List<Shifts>></para>
            ShiftLimits getShiftLimits(int dayIndex, ShiftTime shiftTime)
            {
                switch (dayIndex)
                {
                    case 1:
                        switch (shiftTime)
                        {
                            case ShiftTime.Afternoon: return weekLimits.TuesdayLimits.AfternoonShift;
                            case ShiftTime.Evening: return weekLimits.TuesdayLimits.EveningShift;
                            default:
                                return weekLimits.TuesdayLimits.MorningShift;
                        };
                    case 2:
                        switch (shiftTime)
                        {
                            case ShiftTime.Afternoon: return weekLimits.WednesdayLimits.AfternoonShift;
                            case ShiftTime.Evening: return weekLimits.WednesdayLimits.EveningShift;
                            default:
                                return weekLimits.WednesdayLimits.MorningShift;
                        };
                    case 3:
                        switch (shiftTime)
                        {
                            case ShiftTime.Afternoon: return weekLimits.ThursdayLimits.AfternoonShift;
                            case ShiftTime.Evening: return weekLimits.ThursdayLimits.EveningShift;
                            default:
                                return weekLimits.ThursdayLimits.MorningShift;
                        };
                    case 4:
                        switch (shiftTime)
                        {
                            case ShiftTime.Afternoon: return weekLimits.FridayLimits.AfternoonShift;
                            case ShiftTime.Evening: return weekLimits.FridayLimits.EveningShift;
                            default:
                                return weekLimits.FridayLimits.MorningShift;
                        };
                    case 5:
                        switch (shiftTime)
                        {
                            case ShiftTime.Afternoon: return weekLimits.SaturdayLimits.AfternoonShift;
                            case ShiftTime.Evening: return weekLimits.SaturdayLimits.EveningShift;
                            default:
                                return weekLimits.SaturdayLimits.MorningShift;
                        };
                    case 6:
                        switch (shiftTime)
                        {
                            case ShiftTime.Afternoon: return weekLimits.SundayLimits.AfternoonShift;
                            case ShiftTime.Evening: return weekLimits.SundayLimits.EveningShift;
                            default:
                                return weekLimits.SundayLimits.MorningShift;
                        };
                    default:
                        switch (shiftTime)
                        {
                            case ShiftTime.Afternoon: return weekLimits.MondayLimits.AfternoonShift;
                            case ShiftTime.Evening: return weekLimits.MondayLimits.EveningShift;
                            default:
                                return weekLimits.MondayLimits.MorningShift;
                        }
                }
            }

            ///<para>Calculate FTE baside on how many shift they have on the shifts they have in the week </para>
            void calculateNumberOfShiftLeftForTheEmployeePerEmployeeForAWeek(List<List<Shift>> weekShifts, List<List<Employee>> availableEmployeesPerWeek)
            {
                //looping through all of employeesAssignedForTheWeek to calculate FTE for each employee

                List<Employee> allEmployeeForWeek = new List<Employee>();
                foreach (List<Employee> availableEmployeesPerDay in availableEmployeesPerWeek)
                {
                    allEmployeeForWeek.AddRange(availableEmployeesPerDay);
                }
                allEmployeeForWeek = allEmployeeForWeek.Select(employee => employee).Distinct().ToList();

                foreach (Employee employee in allEmployeeForWeek)
                {
                    foreach (List<Shift> day in weekShifts)
                    {
                        foreach (Shift shift in day)
                        {
                            foreach (Attendance attendance in shift.Attendances)
                            {
                                if (employee.Id == attendance.Employee.Id)
                                {
                                    employee.Contract.NumberOfShiftLeftForTheEmployee -= 1;
                                }
                            }
                        }
                    }
                }
            }

            //Deleting the new object of employee if the employee does excist in other day of availableEmployeesPerWeek or in  and replace it with the old one to use only one object reference for same employee
            void replaceTheNewEmployeeObejctWithOldEmployeeObject()
            {
                //Looping through available employees
                for (int availableEmployeesFordayIndexLayer1 = 0; availableEmployeesFordayIndexLayer1 < availableEmployeesPerWeek.Count; availableEmployeesFordayIndexLayer1++)
                {
                    for (int avialableEmployeeIndex = 0; avialableEmployeeIndex < availableEmployeesPerWeek[availableEmployeesFordayIndexLayer1].Count; avialableEmployeeIndex++)
                    {
                        for (int availableEmployeesFordayIndexLayer2 = 0; availableEmployeesFordayIndexLayer2 < availableEmployeesPerWeek.Count; availableEmployeesFordayIndexLayer2++)
                        {
                            if (availableEmployeesFordayIndexLayer1 != availableEmployeesFordayIndexLayer2)
                            {
                                for (int checkingEmployeeIndex = 0; checkingEmployeeIndex < availableEmployeesPerWeek[availableEmployeesFordayIndexLayer2].Count; checkingEmployeeIndex++)
                                {
                                    if (availableEmployeesPerWeek[availableEmployeesFordayIndexLayer1][avialableEmployeeIndex].Id == availableEmployeesPerWeek[availableEmployeesFordayIndexLayer2][checkingEmployeeIndex].Id)
                                    {
                                        Employee employeeFirstLayer = availableEmployeesPerWeek[availableEmployeesFordayIndexLayer1][avialableEmployeeIndex];

                                        //Replace the second layer employee with first layer employeee
                                        availableEmployeesPerWeek[availableEmployeesFordayIndexLayer2].RemoveAt(checkingEmployeeIndex);
                                        availableEmployeesPerWeek[availableEmployeesFordayIndexLayer2].Insert(checkingEmployeeIndex, employeeFirstLayer);
                                    }
                                }
                            }
                        }
                    }
                }


                //Looping through week shifts
                foreach (List<Shift> day in lastUpdatedSchedulePerWeek)
                {
                    foreach (Shift shift in day)
                    {
                        for (int employeeInShiftIndex = 0; employeeInShiftIndex < shift.Attendances.Count; employeeInShiftIndex++)
                        {
                            foreach (List<Employee> availableEmployeesPerDay in availableEmployeesPerWeek)
                            {
                                for (int avaialableEmployeeIndex = 0; avaialableEmployeeIndex < availableEmployeesPerDay.Count; avaialableEmployeeIndex++)
                                {
                                    if (shift.Attendances[employeeInShiftIndex].Employee.Id == availableEmployeesPerDay[avaialableEmployeeIndex].Id)
                                    {
                                        //Replacing employee object in list of employees in a shift with availableEmployee in availableEmployeesPerWeek
                                        shift.Attendances[employeeInShiftIndex].Employee = availableEmployeesPerDay[avaialableEmployeeIndex];
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void InsertSchedule(List<List<Shift>> schedule)
        {
            //Creating the Query for inserting the in employees in the schedule
            for (int dayIndex = 0; dayIndex < schedule.Count; dayIndex++)
            {
                List<Shift> day = schedule[dayIndex];
                for (int shiftIndex = 0; shiftIndex < day.Count; shiftIndex++)
                {
                    Shift shift = day[shiftIndex];
                    for (int employeeInShiftIndex = 0; employeeInShiftIndex < shift.Attendances.Count; employeeInShiftIndex++)
                    {
                        Employee employee = shift.Attendances[employeeInShiftIndex].Employee;
                        AssignUserShift(employee.Id, shift.Date, shift.ShiftTime);
                    }
                }
            }
        }

        // HELPER FUNCTIONS

        // https://www.codeproject.com/Articles/44274/Transpose-a-DataTable-using-C
        private DataTable GetTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }

        //https://stackoverflow.com/questions/662379/calculate-date-from-week-number
        private DateTime firstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }

        //https://stackoverflow.com/questions/273313/randomize-a-listt
        private Random rng = new Random();

        public List<Employee> Shuffle(List<Employee> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Employee employeeN = list[n];
                list[n] = list[k];
                list[k] = employeeN;
            }

            return list;
        }
        public void MarkEmployeePresent(int user_id, DateOnly date, ShiftTime shift)
        {
            var cmd = new MySqlCommand(
                "update schedule_shifts ss " +
                "join schedule s " +
                "on (s.id = ss.schedule_id) " +
                "set is_late = @IS_LATE, is_present = @IS_PRESENT " +
                "where s.user_id = @USER_ID and s.work_date = @WORK_DATE and shift_time = @SHIFT",
                conn);
            cmd.Parameters.AddWithValue("IS_PRESENT", true);
            cmd.Parameters.AddWithValue("IS_LATE", false);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("SHIFT", shift.ToString());

            cmd.ExecuteNonQuery();
        }

        public string GetLastEmployeeCheckInOutDirection(int user_id, DateOnly date)
        {
            var cmd = new MySqlCommand(
                "select direction from check_ins " +
                "where user_id = @USER_ID and date(scanned_on) = @DATE " +
                "order by scanned_on desc " +
                "limit 1",
                conn);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("DATE", date.ToString("yyyy-MM-dd"));

            return cmd.ExecuteScalar() is not null ? (string)cmd.ExecuteScalar() : "";
        }

        public DateTime GetLastEmployeeCheckInDate(int user_id, DateOnly date)
        {
            var cmd = new MySqlCommand(
                "select scanned_on from check_ins " +
                "where user_id = @USER_ID and date(scanned_on) = @DATE and direction = 'IN'" +
                "order by scanned_on desc " +
                "limit 1",
                conn);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("DATE", date.ToString("yyyy-MM-dd"));

            return (DateTime)cmd.ExecuteScalar();
        }

        public void MarkEmployeeAbsent(int user_id, DateOnly date, ShiftTime shift)
        {
            var cmd = new MySqlCommand(
                "update schedule_shifts ss " +
                "join schedule s " +
                "on (s.id = ss.schedule_id) " +
                "set is_late = @IS_LATE, is_present = @IS_PRESENT " +
                "where s.user_id = @USER_ID and s.work_date = @WORK_DATE and shift_time = @SHIFT",
                conn);
            cmd.Parameters.AddWithValue("IS_PRESENT", false);
            cmd.Parameters.AddWithValue("IS_LATE", false);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("SHIFT", shift.ToString());

            cmd.ExecuteNonQuery();
        }

        public void MarkEmployeeAbsent(int user_id, DateOnly date, ShiftTime shift, string absence_reason)
        {
            var cmd = new MySqlCommand(
                "update schedule_shifts ss " +
                "join schedule s " +
                "on (s.id = ss.schedule_id) " +
                "set is_late = @IS_LATE, is_present = @IS_PRESENT, absence_reason = @ABSENCE_REASON " +
                "where s.user_id = @USER_ID and s.work_date = @WORK_DATE and shift_time = @SHIFT",
                conn);
            cmd.Parameters.AddWithValue("IS_PRESENT", false);
            cmd.Parameters.AddWithValue("ABSENCE_REASON", absence_reason.Trim());
            cmd.Parameters.AddWithValue("IS_LATE", false);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("SHIFT", shift.ToString());

            cmd.ExecuteNonQuery();
        }

        public void MarkEmployeeLate(int user_id, DateOnly date, ShiftTime shift)
        {
            var cmd = new MySqlCommand(
                "update schedule_shifts ss " +
                "join schedule s " +
                "on (s.id = ss.schedule_id) " +
                "set is_late = @IS_LATE, is_present = @IS_PRESENT " +
                "where s.user_id = @USER_ID and s.work_date = @WORK_DATE and shift_time = @SHIFT",
                conn);
            cmd.Parameters.AddWithValue("IS_PRESENT", true);
            cmd.Parameters.AddWithValue("IS_LATE", true);
            cmd.Parameters.AddWithValue("USER_ID", user_id);
            cmd.Parameters.AddWithValue("WORK_DATE", date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("SHIFT", shift.ToString());

            cmd.ExecuteNonQuery();
        }

    }
}
