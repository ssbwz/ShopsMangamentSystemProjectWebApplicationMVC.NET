using Logic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDepartmentStorage
    {

        public List<Department> ViewAllEployeeDepartments();
        public List<Department>  GetDepartments();
        public bool AddDepartment(string name);

        public bool EditDepartment(string name, int id);

        public bool DeleteDepartment(int departmentId);

    }
}
