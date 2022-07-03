using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
    [Table("Department")]
    public class Department
    {

        public int DepartmentID { get; set; }

        public String DepartmentName { get; set; }

       


    }
}
