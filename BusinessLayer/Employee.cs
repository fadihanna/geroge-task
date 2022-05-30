using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Enter valid Name")]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Enter valid Job Title")]
        public String Title { get; set; }

        [Required]
        public String Gender { get; set; }

        [Required]

        public String Notes { get; set; }

        [Required]
        public int DepartmentID { get; set; }
    }
}
