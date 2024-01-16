
using login.Data;
using login.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace anjalweb.Controllers
{
	public class HomeController : Controller
	{
		private readonly AppDbContext _db;

		public object Session { get; private set; }

		public HomeController(ILogger<HomeController> logger, AppDbContext db)
		{
			
			_db = db;
			
		}

		public IActionResult Index()
		{
			 if(HttpContext.Session.GetString("UserSession") != null)
			{
				ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
				return View();
			}
			else
			{
				return RedirectToAction("Login");
			}
				
		}

		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(User obj)
		{
			var MyUser = _db.Users.Where(x=>x.Email== obj.Email && x.Password==obj.Password).FirstOrDefault();
			if (MyUser != null)
			{
				HttpContext.Session.SetString("UserSession",MyUser.Name);
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.LoginFail = "Email/Password is Incorrect";
				
			}
			return View();
		}
		public IActionResult Logout()
		{
			if (HttpContext.Session.GetString("UserSession") != null)
			{
				HttpContext.Session.Remove("UserSession");
				return RedirectToAction("Login");
			}
			return View();
		}
		public IActionResult Register() {
		return View();
		}
		[HttpPost]
		public IActionResult Register(User obj)
		{
			if (ModelState.IsValid){

                var MyUser = _db.Users.Where(x => x.Email == obj.Email).FirstOrDefault();
                if (MyUser != null)
                {
                    ViewBag.RegisterFail = "This Email is Already Registered";
                }
                else
                {
                    _db.Users.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
		
			return View();

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
