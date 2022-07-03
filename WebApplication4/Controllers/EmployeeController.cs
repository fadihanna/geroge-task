using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using PagedList;
using PagedList.Mvc;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        DepartmentBusinessLayer departmentBusinessLayer = new DepartmentBusinessLayer();
        Employee employee = new Employee();

        [ActionName("Index")]
        public ActionResult Index(int? page)
        {

            List<Employee> employees = employeeBusinessLayer.EmployeeSelect.ToList();
            ViewBag.countEmployees = employeeBusinessLayer.countEmployees();

             return View(employees.ToPagedList(page ?? 1, 3)); // 1 page has 3 rows.

        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {

            ViewBag.DepartmentID = new SelectList(departmentBusinessLayer.DepartmentSelect, "DepartmentID", "DepartmentName"); // display name text field in drop down, source is id
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Employee employee)
        {
            try
            {

                if (employeeBusinessLayer.GetEmployeeByName(employee)) // checks if employee name exists in context
                {
                    ModelState.AddModelError("Name", "Name already exists");
                }

                ViewBag.DepartmentID = new SelectList(departmentBusinessLayer.DepartmentSelect, "DepartmentID", "DepartmentName"); // from controller to view 


                if (ModelState.IsValid)
                {
                    employeeBusinessLayer.AddEmployee(employee);

                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return View();

        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {

            employee = employeeBusinessLayer.GetEmployeeByID(id);

            ViewBag.DepartmentID = new SelectList(departmentBusinessLayer.DepartmentSelect, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(departmentBusinessLayer.DepartmentSelect, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View();
        }

        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {

                employeeBusinessLayer.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult OrderByName() // orders employees by name alphabatically 
        {

            List<Employee> employees = employeeBusinessLayer.OrderByEmployeeName();
            return View(employees);
        }

        public ActionResult EmployeeDepartment(int departmentID) // gets employees working in department by department ID in route
        {
            List<Employee> employees = employeeBusinessLayer.GetEmployeeInDepartments(departmentID);
            return View(employees);
        }
        public ActionResult GetEmployeeByGender(String gender)
        {
            List<Employee> employees = employeeBusinessLayer.GetEmployeesByGender(gender);
            return View(employees);
        }
        


        


      




    }
}