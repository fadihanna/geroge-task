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
    public class EmployeeBusinessLayer
    {
        
       
        public List<Employee> EmployeeSelect
        {
            get
            {
                 
                    List<Employee> employees = new List<Employee>();
                    DBContext employeeContext = new DBContext();
                     
                    var lst = from n in employeeContext.Employees select n;
                    employees = lst.ToList();
                    return employees;
                }
                     
         }

        public void AddEmployee(Employee employee)
        {

            DBContext employeeContext = new DBContext();
           
            employeeContext.Employees.Add(employee);
            employeeContext.SaveChanges();

        }

     
        public void DeleteEmployee(int id)
        {
            
            DBContext employeeContext = new DBContext();
            var delete =  (from p in employeeContext.Employees where p.EmployeeID == id select p).SingleOrDefault();
            employeeContext.Employees.Remove(delete);
            employeeContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            DBContext employeeContext = new DBContext();

            employeeContext.Entry(employee).State = System.Data.Entity.EntityState.Modified;

            employeeContext.SaveChanges();

            
        }

        public List<Employee> OrderByEmployeeName()
        {
            List<Employee> employees = new List<Employee>();
            DBContext employeeContext = new DBContext();

            var lst = from n in employeeContext.Employees orderby n.Name ascending select n;
            employees = lst.ToList();

            return employees;

         }


        }




    }

