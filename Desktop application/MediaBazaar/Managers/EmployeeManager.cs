using System.Data;
using DataAccess;
using Logic.Interfaces;
using MediaBazaar.Logic.Enums;
using MediaBazaar.Logic.Models;
using MySql.Data.MySqlClient;
using Bcrypt = BCrypt.Net.BCrypt;

namespace MediaBazaar.Managers
{
    public class EmployeeManager
    {
        public MySqlConnection conn;

        public EmployeeManager(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public List<int> GetAllEmployeesId(string notificationFor, string notificationType)
        {
            List<int> employeesIds = new List<int>();

            MySqlCommand cmd = new MySqlCommand(
                $" SELECT user_id" +
                $" FROM employees_departments ed INNER JOIN departments d On d.id = ed.job_id " +
                $" WHERE d.{notificationType}  like @NOTIFICATIONFOR ", conn);


            cmd.Parameters.AddWithValue("NOTIFICATIONFOR", notificationFor);


            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows) 
                {
                    return employeesIds;
                }
                while (reader.Read())
                {
                    employeesIds.Add(reader.GetInt32(0));
                }
            }

            return employeesIds;
        }

        public List<string> GetAllJobDescriptionsByDepartment(string department)
        { 
            MySqlCommand cmd = new MySqlCommand("SELECT job_description FROM departments WHERE department = @DEPARTMENT", conn);

            cmd.Parameters.AddWithValue("DEPARTMENT", department);

            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> jobDescription = new List<string>();
            while (reader.Read())
            {
                jobDescription.Add(reader.GetString(0));
            }
            reader.Close();
            return jobDescription;
        }

        public List<string> GetAllDepartments()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT department FROM departments", conn);

            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> departments = new List<string>();
            while (reader.Read())
            {
                departments.Add(reader.GetString(0));
            }
            reader.Close();
            return departments;
        }

        public int GetNumEmployeesPerDepartment(string department)
        {
            var cmd = new MySqlCommand(
                   "select count(DISTINCT user_id) from employees_departments as ed INNER JOIN departments as d on ed.job_id = d.id" +
                   " INNER JOIN employees e" +
                   " On  e.id = ed.user_id" +
                   " where e.is_active = true and d.department = @DEPARTMENT;",
                   conn);

            cmd.Parameters.AddWithValue("DEPARTMENT", department);

            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        public DataTable GetAllEmployees()
        {
            var adapter = new MySqlDataAdapter(
                "SELECT id as ID, first_name as 'First name', last_name as 'Last name', phone_num as 'Phone number', email as Email FROM employees;",
                conn);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public DataTable GetAllEmployees2()
        {
            var adapter = new MySqlDataAdapter(
                "SELECT * FROM employees;",
                conn);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public DataTable GetAllDepotWorkers()
        {
            var adapter = new MySqlDataAdapter(
                "select e.id, concat(e.id, ' - ', e.first_name, ' ', e.last_name) as full_name from employees e " +
                "join employees_departments ed on e.id = ed.user_id WHERE ed.job_id = 7 order by e.id;",
                conn);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public List<(string Department, string JobDescription)> getUserAccounts(int userId)
        {
            var depsAndJobs = new List<(string Department, string JobDescription)>();

            var cmd = new MySqlCommand(
                "select d.* from departments as d INNER JOIN employees_departments as ed ON d.id = ed.job_id where user_id = @USER_ID " +
                "AND (d.job_description IN ('Administrator', 'Sales representative', 'Depot manager', 'Depot employee', 'Manager', 'HR Manager'))",
                this.conn);

            cmd.Parameters.AddWithValue("USER_ID", userId);

            var reader = cmd.ExecuteReader();

            using (reader)
            {
                if (!reader.HasRows)
                    return depsAndJobs;

                while (reader.Read())
                {
                    depsAndJobs.Add((reader.GetString("department"), reader.GetString("job_description")));
                }
            }
            return depsAndJobs;

        }

        public DataTable FilterEmployeesByActiveStatus(bool isActive)
        {
            var adapter = new MySqlDataAdapter(
                "SELECT id as ID, first_name as 'First name', last_name as 'Last name', phone_num as 'Phone number', email as Email FROM employees WHERE is_active = @ISACTIVE;",
                conn);

            adapter.SelectCommand.Parameters.AddWithValue("ISACTIVE", isActive);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public Employee? GetEmployeeById(int employee_id)
        {
            var cmd = new MySqlCommand(
                "select * from employees where id = @ID",
                this.conn);

            cmd.Parameters.AddWithValue("ID", employee_id);

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                // read once because there is only row present
                reader.Read();

                int id = Convert.ToInt32(reader[0]);
                string firstname = reader.GetString("first_name");
                string lastname = reader.GetString("last_name");
                string address = reader.GetString("address");
                DateOnly birthday = DateOnly.FromDateTime((DateTime)reader["birthday"]);
                int phoneNum = reader.GetInt32("phone_num");
                int? spousePhoneNum = !reader.IsDBNull("spouse_phone_num") ? reader.GetInt32("spouse_phone_num") : null;
                int bsn = reader.GetInt32("BSN");
                bool isActive = reader.GetBoolean("is_active");
                string username = reader.GetString("username");
                string email = reader.GetString("email");
                string password = reader.GetString("password");
                ISettingsRepository settingRepository = new SettingsStorage(id);

                var employee = new Employee(id, firstname, lastname, address, birthday, phoneNum, spousePhoneNum, bsn, isActive, username, email, password,settingRepository);

                return employee;

            }
        }

        public Employee? GetEmployeeByCardId(string cardId)
        {
            var cmd = new MySqlCommand(
                "select * from employees where  card_id = @ID",
                this.conn);

            cmd.Parameters.AddWithValue("ID", cardId);

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                // read once because there is only row present
                reader.Read();

                int id = Convert.ToInt32(reader[0]);
                string firstname = reader.GetString("first_name");
                string lastname = reader.GetString("last_name");
                string address = reader.GetString("address");
                DateOnly birthday = DateOnly.FromDateTime((DateTime)reader["birthday"]);
                int phoneNum = reader.GetInt32("phone_num");
                int? spousePhoneNum = !reader.IsDBNull("spouse_phone_num") ? reader.GetInt32("spouse_phone_num") : null;
                int bsn = reader.GetInt32("BSN");
                bool isActive = reader.GetBoolean("is_active");
                string username = reader.GetString("username");
                string email = reader.GetString("email");
                string password = reader.GetString("password");
                ISettingsRepository settingRepository = new SettingsStorage(id);

                var employee = new Employee(id, firstname, lastname, address, birthday, phoneNum, spousePhoneNum, bsn, isActive, username, email, password, settingRepository);

                return employee;

            }
        }

        public Employee? GetLoginEmployee(string login_username, string login_password)
        {
            var cmd = new MySqlCommand(
                "select * from employees where username = binary @USERNAME limit 1",
                this.conn);

            // add parameters to avoid SQL Injection
            cmd.Parameters.AddWithValue("USERNAME", login_username);
            cmd.Parameters.AddWithValue("PASSWORD", login_password);

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return null;
                }

                // read once because there is only row present
                reader.Read();

                int id = reader.GetInt32("id");
                string firstname = reader.GetString("first_name");
                string lastname = reader.GetString("last_name");
                string address = reader.GetString("address");
                DateOnly birthday = DateOnly.FromDateTime((DateTime)reader["birthday"]);
                int phoneNum = reader.GetInt32("phone_num");
                int? spousePhoneNum = !reader.IsDBNull("spouse_phone_num") ? reader.GetInt32("spouse_phone_num") : null;
                int bsn = reader.GetInt32("BSN");
                bool isActive = reader.GetBoolean("is_active");
                string username = reader.GetString("username");
                string email = reader.GetString("email");
                string password = reader.GetString("password");
                ISettingsRepository settingRepository = new SettingsStorage(id);

                var employee = new Employee(id, firstname, lastname, address, birthday, phoneNum, spousePhoneNum, bsn, isActive, username, email, password,settingRepository);
                bool firstTimeLoginDone = reader.GetBoolean("first_time_login_done");

                bool isPasswordCorrect;

                if (firstTimeLoginDone)
                {
                    isPasswordCorrect = Bcrypt.Verify(login_password, password);
                }
                else
                {
                    isPasswordCorrect = login_password.Trim() == password;
                }


                if (!isPasswordCorrect)
                    return null;

                return employee;
            }
        }

        public bool CheckUniqueEmail(string email)
        {
            var cmd = new MySqlCommand(
                "select count(*) from employees where email = @EMAIL",
                this.conn);

            cmd.Parameters.AddWithValue("EMAIL", email);

            int result = Convert.ToInt32(cmd.ExecuteScalar());

            // return true when email is unique (no employees with that email exist), otherwise false
            return result == 0;
        }

        public bool CheckUniqueUsername(string username)
        {
            var cmd = new MySqlCommand(
                "select count(*) from employees where username = @USERNAME",
                this.conn);

            cmd.Parameters.AddWithValue("USERNAME", username);

            int result = Convert.ToInt32(cmd.ExecuteScalar());

            // return true when username is unique (no employees with that username exist), otherwise false
            return result == 0;
        }

        public List<string> GetEmployeeDepartments(int userId)
        {
            var deps = new List<string>();

            var cmd = new MySqlCommand(
                "select distinct d.department from departments AS d INNER JOIN employees_departments AS ed ON d.id = ed.job_id where user_id = @USER_ID",
                this.conn);

            cmd.Parameters.AddWithValue("USER_ID", userId);

            var reader = cmd.ExecuteReader();

            using (reader)
            {
                if (!reader.HasRows)
                    return deps;

                while (reader.Read())
                {
                    deps.Add(reader.GetString("department"));
                }
            }
            return deps;
        }

        public List<(string Department, string JobDescription)> GetAllEmployeeDepartmentsAndJobs(int userId)
        {
            var depsAndJobs = new List<(string Department, string JobDescription)>();

            var cmd = new MySqlCommand(
                "select d.* from departments as d INNER JOIN employees_departments as ed ON d.id = ed.job_id where user_id = @USER_ID",
                this.conn);

            cmd.Parameters.AddWithValue("USER_ID", userId);

            var reader = cmd.ExecuteReader();

            using (reader)
            {
                if (!reader.HasRows)
                    return depsAndJobs;

                while (reader.Read())
                {
                    depsAndJobs.Add((reader.GetString("department"), reader.GetString("job_description")));
                }
            }
            return depsAndJobs;
        }

        public List<(int id, string department, string jobDescription)> GetAllJobs()
        {
            var depsAndJobs = new List<(int id, string department, string jobDescription)>();

            MySqlCommand cmd = new MySqlCommand(
                "select * from departments;",
                this.conn);

            var reader = cmd.ExecuteReader();

            using (reader)
            {
                if (!reader.HasRows)
                    return depsAndJobs;

                while (reader.Read())
                {
                    depsAndJobs.Add((reader.GetInt32("id"), reader.GetString("department"), reader.GetString("job_description")));
                }
            }
            return depsAndJobs;
        }

        public void AddEmployeeDepartment(int userId, int jobId)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO employees_departments(user_id, job_id) VALUES(@ID, @JOBID);",
                conn);

            cmd.Parameters.AddWithValue("ID", userId);
            cmd.Parameters.AddWithValue("JOBID", jobId);

            cmd.ExecuteNonQuery();
        }

        public void DeleteAllEmployeeDepartments(int userId)
        {
            var cmd = new MySqlCommand(
                "delete from employees_departments where user_id = @id",
                conn);

            cmd.Parameters.AddWithValue("id", userId);

            cmd.ExecuteNonQuery();
        }

        public int AddEmployee(string firstName, string lastName, string address, string birthday, int phoneNum, int? spouse_phone_num, int bsn, bool isActive, string username, string email, string password)
        {
            var cmd = new MySqlCommand(
                "INSERT INTO employees(first_name, last_name, username, password, BSN, is_active, email, phone_num, spouse_phone_num, birthday, address) VALUES(@first_name, @last_name, @username, @password, @BSN, @is_active, @email, @phone_num, @spouse_phone_num, @birthday, @address); " +
                "SELECT LAST_INSERT_ID();",
                conn);

            cmd.Parameters.AddWithValue("first_name", firstName);
            cmd.Parameters.AddWithValue("last_name", lastName);
            cmd.Parameters.AddWithValue("address", address);
            cmd.Parameters.AddWithValue("birthday", birthday);
            cmd.Parameters.AddWithValue("phone_num", phoneNum);
            cmd.Parameters.AddWithValue("spouse_phone_num", spouse_phone_num);
            cmd.Parameters.AddWithValue("BSN", bsn);
            cmd.Parameters.AddWithValue("is_active", isActive);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("email", email);
            cmd.Parameters.AddWithValue("password", password);

             
            int newEmployeeId = Convert.ToInt32(cmd.ExecuteScalar());

            //Setting all of the settings for the new employee to enable as default setting
            SettingsStorage settingsStorage = new SettingsStorage(newEmployeeId);
            settingsStorage.InsertDefaultSettings();

            return newEmployeeId;
        }

        public void UpdateEmployee(int id, string firstName, string lastName, string address, string birthday, int phoneNum, int? spouse_phone_num, string username, int bsn, bool isActive, string email, string password)
        {

            var cmd = new MySqlCommand(
                "UPDATE employees SET  id =@id, first_name = @first_name, last_name = @last_name, address = @address, phone_num = @phone_num, spouse_phone_num = @spouse_phone_num, username = @username, BSN=@BSN, is_active = @is_active, birthday = @birthday, email = @email, password = @password WHERE id=@id;",
                conn);

            cmd.Parameters.AddWithValue("@first_name", firstName);
            cmd.Parameters.AddWithValue("@last_name", lastName);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@phone_num", phoneNum);
            cmd.Parameters.AddWithValue("spouse_phone_num", spouse_phone_num);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@BSN", bsn);
            cmd.Parameters.AddWithValue("@is_active", isActive);
            cmd.Parameters.AddWithValue("birthday", birthday);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }


        public void DeleteEmployee(int id)
        {
            var cmd = new MySqlCommand(
                "DELETE from employees WHERE id = @id;",
                conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        // fake delete
        public void UpdateEmployeeActivity(int userId, bool isActive)
        {
            var cmd = new MySqlCommand(
                "update employees set is_active = @is_active where id = @id",
                conn);

            cmd.Parameters.AddWithValue("is_active", isActive);
            cmd.Parameters.AddWithValue("id", userId);

            cmd.ExecuteNonQuery();
        }

        // CONTRACT METHODS
        public void AddContractToEmployee(Contract contract)
        {
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO contracts (start_date, end_date, FTE, leave_reason, employee_id) VALUES (@STARTDATE, @ENDDATE, @FTE, @LEAVEREASON, @EMPLOYEEID);",
                conn);

            cmd.Parameters.AddWithValue("STARTDATE", contract.StartDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("ENDDATE", contract.EndDate == null ? null : contract.EndDate?.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("FTE", contract.FTE);
            cmd.Parameters.AddWithValue("LEAVEREASON", contract.LeaveReason == "" ? null : contract.LeaveReason);
            cmd.Parameters.AddWithValue("EMPLOYEEID", contract.EmployeeId);

            cmd.ExecuteNonQuery();

        }

        public void DeleteContractFromEmployee(int employee_id)
        {
            MySqlCommand cmd = new MySqlCommand(
                "DELETE from contracts WHERE employee_id = @EMPLOYEEID;",
                conn);

            cmd.Parameters.AddWithValue("EMPLOYEEID", employee_id);

            cmd.ExecuteNonQuery();
        }

        public void UpdateContract(int employeeId, DateOnly startDate, DateOnly? endDate, decimal FTE, string? leaveReason)
        {

            var cmd = new MySqlCommand(
                "UPDATE contracts SET start_date = @STARTDATE, end_date = @ENDDATE, FTE = @FTE, leave_reason = @LEAVEREASON WHERE employee_id = @EMPLOYEEID;",
                conn);

            cmd.Parameters.AddWithValue("STARTDATE", startDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("ENDDATE", endDate == null ? null : endDate?.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("FTE", FTE);
            cmd.Parameters.AddWithValue("LEAVEREASON", leaveReason == "" ? null : leaveReason);
            cmd.Parameters.AddWithValue("EMPLOYEEID", employeeId);

            cmd.ExecuteNonQuery();
        }

        public Contract? GetContractByEmployeeId(int employee_id)
        {

            var cmd = new MySqlCommand(
                "SELECT * FROM contracts WHERE employee_id = @EMPLOYEEID;",
                conn);

            cmd.Parameters.AddWithValue("EMPLOYEEID", employee_id);

            MySqlDataReader reader = cmd.ExecuteReader();

            // employee to contract is 1-1 so no need for while loop
            reader.Read();

            // if no contract is found, return null and exit method
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }

            int id = reader.GetInt32("id");
            DateOnly startDate = DateOnly.FromDateTime((DateTime)reader["start_date"]);
            DateOnly? endDate = reader["end_date"] is DBNull ? null : DateOnly.FromDateTime((DateTime)reader["end_date"]);
            decimal fte = reader.GetDecimal("FTE");
            string? leaveReason = reader["leave_reason"] is DBNull ? null : reader.GetString("leave_reason");
            int employeeId = reader.GetInt32("employee_id");

            var contract = new Contract(id, startDate, endDate, fte, leaveReason, employeeId);

            reader.Close();

            return contract;
        }

        public void EndContract(int userId, DateOnly endDate, string leaveReason)
        {
            var cmd = new MySqlCommand(
                "update contracts set end_date = @end_date, leave_reason = @leave_reason where employee_id = @id",
                conn);

            cmd.Parameters.AddWithValue("end_date", endDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("leave_reason", leaveReason);
            cmd.Parameters.AddWithValue("id", userId);

            cmd.ExecuteNonQuery();
        }

        public bool IsLogInForFirstTime(int id)
        {
            var cmd = new MySqlCommand(
                "select first_time_login_done from employees where id = @ID"
                , conn);

            cmd.Parameters.AddWithValue("@ID", id);

            return (bool)cmd.ExecuteScalar();

        }

        public void ChangeingIsLogInForFirstTime(int id)
        {
            var cmd = new MySqlCommand(
            "UPDATE `employees` SET `first_time_login_done`= 1 WHERE id = @ID"
            , conn);

            cmd.Parameters.AddWithValue("@ID", id);

            cmd.ExecuteNonQuery();
        }

    }
}
