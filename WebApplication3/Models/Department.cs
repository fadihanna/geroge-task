using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Department")]
    public class Department
    {
        public int DepartmentID { get; set; }


        public String DepartmentName { get; set; }


    }
}