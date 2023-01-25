using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDepartmentManager
    {

        public List<Department> ViewAllDepartments();
        public List<Department> ViewAllEmployeeDepartments();
        public bool AddDepartment(string name);
        public bool EditDepartment(string name, int id);
        public bool DeleteDepartment(int id);

    }
}
