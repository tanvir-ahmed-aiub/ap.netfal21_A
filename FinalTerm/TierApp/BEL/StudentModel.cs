using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public double Cgpa { get; set; }
        public int DepartmentId { get; set; }

        public virtual DepartmentModel Department { get; set; }
    }
}
