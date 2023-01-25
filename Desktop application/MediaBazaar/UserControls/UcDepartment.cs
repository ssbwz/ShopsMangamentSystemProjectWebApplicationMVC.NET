using DataAccess;
using Logic.Interfaces;
using Logic.Managers;
using Logic.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaar.UserControls
{
    public partial class UcDepartment1 : UserControl
    {

        private MySqlConnection conn;
        //private List<Control> parentControls;

        private IDepartmentStorage departmentStorage;
        private IDepartmentManager departmentManager;


        public UcDepartment1()
        {
            InitializeComponent();


        }


        public void Setup(MySqlConnection conn)
        {
            this.conn = conn;
            departmentStorage = new DepartmentStorage();
            departmentManager = new DepartmentManager(departmentStorage);
            GetAllDepartments();
        }


        public void GetAllDepartments()
        {
            dataGridViewDepartment.Columns.Clear();
            dataGridViewDepartment.Rows.Clear();

            dataGridViewDepartment.Columns.Add("Department Id", "Department Id");
            dataGridViewDepartment.Columns.Add("Department", "Department");

            dataGridViewDepartment.Columns.Add("Number of Employees", "Number of Employees");

            List<Department> employeeDepartments = new List<Department>();

            employeeDepartments = this.departmentManager.ViewAllEmployeeDepartments();  //10
            List<Department> allDepartments = this.departmentManager.ViewAllDepartments();

            List<Department> depts = new List<Department>();
            List<int> empNbr = new List<int>();
            foreach (Department dept in allDepartments)
            {
                List<Department> temp = new List<Department>();
                for (int j = 0; j < employeeDepartments.Count; j++)
                {

                    if (dept.Name == employeeDepartments[j].Name)
                    {
                        temp.Add(employeeDepartments[j]);
                    }
                }
                depts.Add(dept);
                empNbr.Add(temp.Count);
                temp.Clear();
            }

            if (depts != null)
            {
                foreach (Department depart in depts)
                {
                    dataGridViewDepartment.Rows.Add(depart.DepartmentId, depart.Name, empNbr[depts.IndexOf(depart)]);
                }
            }


        }

        private void BtnAddDepartment_Click(object sender, EventArgs e)
        {
            try
            {


                //int id = Convert.ToInt32(textBoxId.Text);
                string name = textBxDesrName.Text;
                string job = textBoxNbrEmpl.Text;

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show(" Enter name of department!");
                    return;
                }
                else
                {
                    if (departmentManager.AddDepartment(name))
                    {
                        MessageBox.Show(" New department is added!");

                    }
                    else
                    {
                        MessageBox.Show(" Added a new department is failed!");
                        return;
                    }

                    GetAllDepartments();
                }

            }

            catch (FormatException ex)
            {
                MessageBox.Show("Please make sure that you fill the fields in the right form.");
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
                Debug.WriteLine(ex.ToString());
            }

        }

        private void BtnUpdateDepartment_Click(object sender, EventArgs e)
        {
            try
            {


                int id = Convert.ToInt32(txtboxId.Text);
                string name = textBxDesrName.Text;

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show(" Enter name of department!");
                    return;
                }
                else
                {
                    if (departmentManager.EditDepartment(name, id))
                    {
                        MessageBox.Show(" Department is updated!");

                    }
                    else
                    {
                        MessageBox.Show(" Updated department has failed try again!");
                        return;
                    }

                    GetAllDepartments();
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show("Please make sure that you fill the fields in the right form.");
                Debug.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
                Debug.WriteLine(ex.ToString());
            }
        }

        private void BtnRemoveDepartment_Click(object sender, EventArgs e)
        {

            string id = txtboxId.Text;



            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show(" Enter the department id to be removed!");
                return;
            }
            else
            {
                if (departmentManager.DeleteDepartment(Convert.ToInt32(id)))
                {
                    MessageBox.Show(" Department is removed!");
                   
                }
                else
                {
                    MessageBox.Show(" Removed department is failed!");
                    return;
                }
                GetAllDepartments();
            }

        }


        private void dataGridViewDepartment_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridViewDepartment.Rows[e.RowIndex];

                txtboxId.Text = row.Cells["Department Id"].Value.ToString();
                textBxDesrName.Text = row.Cells["Department"].Value.ToString();
                textBoxNbrEmpl.Text = row.Cells["Number of Employees"].Value.ToString();
            }
        }
    }
}
