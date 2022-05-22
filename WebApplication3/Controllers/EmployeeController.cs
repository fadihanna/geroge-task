using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.ToList();
            return View(employees);

        }

       
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            Employee employee = new Employee();
            EmployeeContext employeeContext = new EmployeeContext();
            ViewBag.DepartmentID = new SelectList(employeeContext.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Employee employee)
        {
            EmployeeContext employeeContext = new EmployeeContext();

            if (employeeContext.Employees.Any(x => x.Name == employee.Name))
            {
                ModelState.AddModelError("Name", "Name already exists");
            }

           
            if (ModelState.IsValid)
            {
                employeeContext.Employees.Add(employee);
                employeeContext.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.DepartmentID = new SelectList(employeeContext.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View(employee);

        }
            
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeID == id);
     
            ViewBag.DepartmentID = new SelectList(employeeContext.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            EmployeeContext employeeContext = new EmployeeContext();

            if (ModelState.IsValid)
            {
                employeeContext.Entry(employee).State=System.Data.Entity.EntityState.Modified;
                employeeContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(employeeContext.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View(employee);
        }


       public ActionResult Delete(int id)
        {
            
            if (ModelState.IsValid)
            {
                EmployeeContext employeeContext = new EmployeeContext();
                Employee employee = employeeContext.Employees.Find(id);
                employeeContext.Employees.Remove(employee);
                employeeContext.SaveChanges();
                

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult OrderByName()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            var name = from n in employeeContext.Employees orderby n.Name ascending select n;

            return View(name);
        }

        public ActionResult EmployeeDepartment(int departmentID)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.Where(x => x.DepartmentID == departmentID).ToList();
            return View(employees);
        }







    }
}