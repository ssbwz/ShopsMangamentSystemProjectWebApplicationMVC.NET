using Logic.Interfaces;
using Logic.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DepartmentStorage : IDepartmentStorage
    {
        private Department department;
        private List<Department> departments;

        public static string GET_ALL_EMPLOYEE_DEPARTMENTS = "SELECT * FROM `departments`;";
        public static string GET_ALL_DEPARTMENTS = "SELECT * FROM `employee_by_department`;";
        public static string REMOVE_DEPARTMENT = "DELETE FROM `employee_by_department` WHERE departmentId=@departmentId;";
        public static string ADD_DEPARTMENT = @"INSERT INTO `employee_by_department`(department) VALUES (@department);";
        public static string UPDATE_DEPARTMENT = "UPDATE `employee_by_department` SET department=@department WHERE departmentId =@departmentId;";

        public DepartmentStorage()
        {
            departments = new List<Department>();
        }
        private MySqlConnection conn
        {
            get { return Connection.Connect; }
        }

        public List<Department> GetDepartments()
        {
            List<Department> newDeptList = new List<Department>();
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(GET_ALL_DEPARTMENTS, conn);


                MySqlDataReader reader = mySqlCommand.ExecuteReader();


                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader.GetString("departmentId"));
                    string name = reader.GetString("department");


                    department = new Department(id, name,null);
                    newDeptList.Add(department);


                }
            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }
            }
            return newDeptList;
        }

        public List<Department> ViewAllEployeeDepartments()
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(GET_ALL_EMPLOYEE_DEPARTMENTS, conn);
           

                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader[0]);
                    string name = reader.GetString("department");
                    string job = reader.GetString("job_description");


                    department = new Department(id, name, job);
                    departments.Add(department);


                }
            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }
            }
            return departments;

        }
        public bool AddDepartment(string name)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(ADD_DEPARTMENT, conn);

                mySqlCommand.Parameters.AddWithValue("@department", name);
                //conn.Open();

                if (mySqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }

            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }
            }


            return false;

        }
        public bool EditDepartment(string name, int id)
        {
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(UPDATE_DEPARTMENT, conn);

               
                mySqlCommand.Parameters.AddWithValue("@department", name);
                mySqlCommand.Parameters.AddWithValue("@departmentId", id);
                //conn.Open();

                int numCreatedRows = mySqlCommand.ExecuteNonQuery();

                if (numCreatedRows > 0)
                {
                    return true;
                }

            }

            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }

            }
                return false;
        }

        public bool DeleteDepartment(int departmentId)
        {
            try
            {
               

                MySqlCommand cmd = new MySqlCommand(REMOVE_DEPARTMENT, conn);
                cmd.Parameters.AddWithValue("@departmentId", departmentId);


                int numCreatedRows = cmd.ExecuteNonQuery();

                if (numCreatedRows == 1)
                {
                    return true;
                }

            }
            catch (MySqlException msqEx)
            {
                Debug.WriteLine(msqEx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                if (conn != null)
                {
                    Connection.CloseConnection();
                }
            }

            return false;
        }

    }
}
