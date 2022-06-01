using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

namespace BusinessLayer
{
    public class DepartmentBusinessLayer
    {


        public List<Department> DepartmentSelect
        {
            get
            {
                Database.SetInitializer<DBContext>(null);
                List<Department> departments = new List<Department>();
                DBContext departmentContext = new DBContext();

                var lst = from n in departmentContext.Departments select n;
                departments = lst.ToList();
                return departments;
            }

        }

        public void AddDepartment(Department department)
        {

            DBContext departmentContext = new DBContext();

            departmentContext.Departments.Add(department);
            departmentContext.SaveChanges();

        }


        public void DeleteDepartment(int id)
        {

            DBContext departmentContext = new DBContext();
            var delete = (from p in departmentContext.Departments where p.DepartmentID == id select p).SingleOrDefault();
            departmentContext.Departments.Remove(delete);
            departmentContext.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            DBContext departmentContext = new DBContext();
            
            departmentContext.Entry(department).State = System.Data.Entity.EntityState.Modified;
            departmentContext.SaveChanges();


        }



    }




}

