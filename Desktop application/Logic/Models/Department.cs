using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public  class Department
    {

      // properties

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string JobDescription { get; set; }
            


        public Department(int id, string name, string job)
        {
            DepartmentId = id;
            Name = name;
            JobDescription = job;
        }



    }
}
