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
        DBContext departmentContext = new DBContext();

        public List<Department> DepartmentSelect
        {
            get
            {

                List<Department> departments = new List<Department>();

                var lst = from n in departmentContext.Departments select n;
                departments = lst.ToList();
                return departments;
            }

        }

        public int AddDepartment(Department department)
        {

            departmentContext.Departments.Add(department);
            return departmentContext.SaveChanges();

        }

        public Department GetDeptDepartmentById(int id)
        {
            return departmentContext.Departments.Where(x => x.DepartmentID == id).FirstOrDefault();
        }
        public void DeleteDepartment(int id)
        {

            var department = (from p in departmentContext.Departments where p.DepartmentID == id select p).FirstOrDefault();
            departmentContext.Departments.Remove(department);
            departmentContext.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {

            departmentContext.Entry(department).State = System.Data.Entity.EntityState.Modified; // gets state of entity. modified state means the entity has changed
            departmentContext.SaveChanges();

        }




    }




}

