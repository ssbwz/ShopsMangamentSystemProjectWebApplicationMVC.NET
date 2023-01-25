using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class DepartmentManager : IDepartmentManager
    {

        private Department department;
        private List<Department> departments;

        private IDepartmentStorage departmentStorage;


        public DepartmentManager(IDepartmentStorage departmentStorage)
        {
            this.departmentStorage = departmentStorage;
            departments = new List<Department>();
        }

        public List<Department> ViewAllEmployeeDepartments()
        {
            return this.departmentStorage.ViewAllEployeeDepartments();
        }
        public bool AddDepartment(string name)
        {
            if(this.departmentStorage.AddDepartment(name))
            {
                return true;
            }
            return false;
        }

        public List<Department> ViewAllDepartments()
        {
            return this.departmentStorage.GetDepartments();
        }


        public bool EditDepartment(string name, int id)
        {
            if (this.departmentStorage.EditDepartment(name, id))
            {
                return true;
            }
            return false;
        }

        public bool DeleteDepartment(int departmentId)
        {
            if (this.departmentStorage.DeleteDepartment(departmentId))
            {
                return true;
            }
            return false;
        }
        
    }
}
