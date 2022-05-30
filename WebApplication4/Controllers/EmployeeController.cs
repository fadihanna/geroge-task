using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebApplication4.Models;
using BusinessLayer;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
     
        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

        [ActionName("Index")]
        public ActionResult Index()
        {
            List<Employee> employees = employeeBusinessLayer.EmployeeList.ToList();
            return View(employees);
   
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            Employee employee = new Employee();
            DepartmentBusinessLayer departmentBusinessLayer = new DepartmentBusinessLayer();

            ViewBag.DepartmentID = new SelectList(departmentBusinessLayer.DepartmentList, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Employee employee)
        {

            if (employeeBusinessLayer.EmployeeList.Any(x => x.Name == employee.Name))
            {
                ModelState.AddModelError("Name", "Name already exists");
            }


            if (ModelState.IsValid)
            {
                employeeBusinessLayer.AddEmployee(employee);
               
                return RedirectToAction("Index");
            }

            DepartmentBusinessLayer departmentBusinessLayer = new DepartmentBusinessLayer();
            ViewBag.DepartmentID = new SelectList(departmentBusinessLayer.DepartmentList, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View();
        
        }


        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            DepartmentBusinessLayer departmentBusinessLayer = new DepartmentBusinessLayer();
            Employee employee = employeeBusinessLayer.EmployeeList.Single(emp => emp.EmployeeID == id);

            ViewBag.DepartmentID = new SelectList(departmentBusinessLayer.DepartmentList, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View(employee);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit(Employee employee)
        {

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.EditEmployee(employee);
                return RedirectToAction("Index");
            }
            DepartmentBusinessLayer departmentBusinessLayer = new DepartmentBusinessLayer();

            ViewBag.DepartmentID = new SelectList(departmentBusinessLayer.DepartmentList, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View();
        }

        public ActionResult Delete(int id)
        {

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.DeleteEmployee(id);

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult OrderByName()
        {

            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee>employees = employeeBusinessLayer.OrderByEmployeeName();
            return View(employees);
        }

        public ActionResult EmployeeDepartment(int departmentID)
        {

            List<Employee> employees = employeeBusinessLayer.EmployeeList.Where(x => x.DepartmentID == departmentID).ToList();
            return View(employees);
        }



    }
}