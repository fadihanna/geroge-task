using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Web;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {

        DBContext employeeContext = new DBContext();

        public List<Employee> EmployeeSelect
        {
            get
            {
                List<Employee> employees = new List<Employee>();

                var lst = from n in employeeContext.Employees select n;
                employees = lst.ToList();

                return employees;
            }

        }

        public Boolean GetEmployeeByName(Employee employee) // return true if employee name exists
        {

            return employeeContext.Employees.Any(x => x.Name == employee.Name);
        }

        public Employee GetEmployeeByID(int id)
        {

            return employeeContext.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
        }

        public int AddEmployee(Employee employee)
        {
            int x = 0;
            try
            {
                employeeContext.Employees.Add(employee);
                x = employeeContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

            return x;
        }

        public void DeleteEmployee(int id)
        {

            var delete = (from p in employeeContext.Employees where p.EmployeeID == id select p).FirstOrDefault();
            employeeContext.Employees.Remove(delete);
            employeeContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {

            employeeContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            employeeContext.SaveChanges();

        }

        public List<Employee> OrderByEmployeeName()
        {
            List<Employee> employees = new List<Employee>();

            var lst = employeeContext.Employees.OrderBy(x => x.Name);
            employees = lst.ToList();

            return employees;

        }
        public List<Employee> GetEmployeeInDepartments(int id)
        {
            return employeeContext.Employees.Where(x => x.DepartmentID == id).ToList(); // returns list of employees where departmentID = routed id
        }

        public List<Employee> GetEmployeesByGender(String Gender)
        {
            
           return employeeContext.Employees.Where((x) => x.Gender == Gender).ToList();
          

        }
        public int countEmployees()
        {

            int count = employeeContext.Employees.Count();

            return count;
        }







    }




}

