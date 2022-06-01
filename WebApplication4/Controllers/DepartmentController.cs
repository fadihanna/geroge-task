using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebApplication4.Models;
using BusinessLayer;

namespace WebApplication4.Controllers
{
    public class DepartmentController : Controller
    {
      
       DepartmentBusinessLayer departmentBusinessLayer = new DepartmentBusinessLayer();

        public ActionResult Index()
        {

            List<Department> departments = departmentBusinessLayer.DepartmentSelect.ToList();
            return View(departments);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        { 
            return View();
        }


        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Department department)
        {

            if (ModelState.IsValid)
            {
                departmentBusinessLayer.AddDepartment(department);
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            Department department = departmentBusinessLayer.DepartmentSelect.Single(dep => dep.DepartmentID == id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentBusinessLayer.UpdateDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                departmentBusinessLayer.DeleteDepartment(id);
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}