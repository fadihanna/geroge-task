using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DepartmentController : Controller
    {
        
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Department> departments = employeeContext.Departments.ToList();
            return View(departments);
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Department department)
        {
           

            if (ModelState.IsValid)
            {
                EmployeeContext employeeContext = new EmployeeContext();
                employeeContext.Departments.Add(department);
                employeeContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Department department = employeeContext.Departments.Single(dep => dep.DepartmentID == id);

           

            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            EmployeeContext employeeContext = new EmployeeContext();

            if (ModelState.IsValid)
            {
                employeeContext.Entry(department).State = System.Data.Entity.EntityState.Modified;
                employeeContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(department);
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                EmployeeContext employeeContext = new EmployeeContext();
                Department department = employeeContext.Departments.Find(id);
                employeeContext.Departments.Remove(department);
                employeeContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult EmployeeDepartment (int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List <Employee> employees = employeeContext.Employees.Where(emp=>emp.DepartmentID == id).ToList();

            return View(employees);
        }

    }
}