using Day06.CustomFilter;
using Day06.Models;
using Day06.TestRepo;
using Day06.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day06.Controllers
{
    //[MyExceptionFilter]
    [Authorize]

    public class DepartmentController : Controller
    {
        IDepartmentRepo departmentRepo;//=new DepartmentRepo();
        //DepartmentTestRepo departmentRepo = new DepartmentTestRepo();

        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            departmentRepo=_departmentRepo;

        }
       
        public IActionResult Index()
        {
            var model = departmentRepo.GetAll();
            return View(model);
        }
        //[LoginFilter]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    departmentRepo.Add(department);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View(department);

                }
                return RedirectToAction("Index");
            }
            return View(department);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var model = departmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var model = departmentRepo.GetById(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(Department department, int? id)
        {
            //var oldDept = dBContext.Departments.FirstOrDefault(d => d.DeptId == id);
            //if (department.Name != null)
            //{
            //    oldDept.Name = department.Name;
            //    dBContext.SaveChanges();
            department.DeptId = id.Value;
            departmentRepo.Update(department);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return BadRequest();
            //}
            //var model = dBContext.Departments.FirstOrDefault(d => d.DeptId == id);
            //if (model == null)
            //{
            //    return NotFound();
            //}
            //dBContext.Departments.Remove(model);
            //dBContext.SaveChanges();
            departmentRepo.Delete(id.Value);
            return RedirectToAction("Index");
        }
        public IActionResult CheckDeptID(int DeptId)
        {
            var model = departmentRepo.GetById(DeptId);
            if (model != null)
            {
                //int id = departmentRepo.Max(d => d.DeptId);
                return Json("You Can't Use this id try again");
            }
            else
                return Json(true);
        }
        public IActionResult CheckDeptName(string Name, int DeptId)
        {
            var model = departmentRepo.GetByName(Name);
            if (model == null)
            {
                return Json(true);
            }
            else
                return Json($"Try Use {Name + DeptId.ToString()}");
        }

    }
}

