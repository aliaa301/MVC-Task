using Microsoft.AspNetCore.Mvc;

namespace Day06.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            // ViewBag.age = 30;
            //ViewBag.name = "aly";
            TempData["age"] = 30;
            TempData["name"] = "aly";
            return View(); 
        }
        public IActionResult Details()
        {
           // int x=(int)(TempData["age"]);
            //string name= TempData["name"].ToString();
            int x =(int) TempData.Peek("age");
            string name=TempData.Peek("name").ToString();
            return Content($"{name}:{x}");
        }

        public IActionResult Create()
        {
            int x=(int)(TempData["age"]);
            string name= TempData["name"].ToString();
            
            return Content($"{name}:{x}");
        }
        public IActionResult Index3()
        {
            int age = 30;
            string name = "Aly";
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetInt32("age", age);
            return View();
        }

        public IActionResult ReadSession() {
        string n=HttpContext.Session.GetString("name");
        int age = HttpContext.Session.GetInt32("age").Value;
        return Content($"{n}:{age}");
                }
        public IActionResult Index2()
        {
            int age = 30;
            string name = "aly";
            Response.Cookies.Append("stdage",age.ToString());
            Response.Cookies.Append("name", name);
            return View();
        }

        public IActionResult ReadCookie()
        {
            int age =int.Parse( Request.Cookies["stdage"]);
            string name = Request.Cookies["name"];
            return Content($"{name}:{age}");
        }
    }
}
