using Day06.CustomFilter;
using Day06.Models;
using Day06.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day06.Controllers
{
    //[MyExceptionFilter]
    [Authorize(Roles = "Admin")]

    public class StudentController : Controller
    {
        IStudentRepo studentRepo;//=new StudentRepo();
        IDepartmentRepo departmentRepo ;

        public StudentController(IDepartmentRepo _departmentRepo,IStudentRepo _studentRepo)
        {
            departmentRepo = _departmentRepo;
            studentRepo = _studentRepo;
        }
        [Authorize(Roles = "Instructor")]

        public IActionResult Index()
        {
            var model = studentRepo.GetAll();
            return View(model);
        }
        [LoginFilter]

        public IActionResult Create()
        {
            ViewBag.depts = departmentRepo.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                studentRepo.Add(student);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depts = departmentRepo.GetAll();
                return View(student);
            }
        }

        public IActionResult Details(int id)
        {
            var model = studentRepo.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.depts = departmentRepo.GetAll();
            return View(model);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Student model = studentRepo.GetById(id.Value);

            
            if (model == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.depts = departmentRepo.GetAll();
                return View(model);
            }

        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Update(student);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depts = departmentRepo.GetAll();
                return View(student);
            }
        }
        public IActionResult Delete(int id)
        {
            studentRepo.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}
