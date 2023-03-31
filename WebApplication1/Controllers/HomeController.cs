using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static int LogginVisitorId { get; set; } = 0;
        public static string LogginVisitorPassword { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public IActionResult SoloVisit()
        {
            return View();
        }

        public IActionResult ChooseVisitType()
        {
            return View();
        }

        public IActionResult GroupVisit()
        {
            return View();
        }

        public IActionResult AddNewRequest(DateOnly startDate, DateOnly endDate, int purposeId, int divisionId, string staffName, string surname, string name, string patronomic, string phoneNumber, string email, string organisation, string discription, DateOnly birthdate, int series, int number, string userImage, string userPass)
        {
            int requestId = 0;
            using (HttpClient maxId = new HttpClient())
            {
                requestId = int.Parse(maxId.GetAsync("http://localhost:8080/maxIdRequest", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result) + 1;
            }
            using (HttpClient client = new HttpClient())
            {
                var respoce = client.PutAsync("http://localhost:8080/putVisitor", new StringContent(JsonConvert.SerializeObject(new Models.Visitor(LogginVisitorId, $"{surname} {name} {patronomic}", phoneNumber, email, $"{series}{number}", birthdate, email.Split("@")[0], LogginVisitorPassword, 0, null, null)), Encoding.UTF8, "application/json"));
                respoce.Result.Content.ReadAsStream();
            }
            using (HttpClient client = new HttpClient())
            {
                var respoce = client.PutAsync("http://localhost:8080/putRequest", new StringContent(JsonConvert.SerializeObject(new Models.Request(requestId, "Личная", divisionId, LogginVisitorId, null, DateTime.Parse(startDate.ToShortDateString()), null, null, null, null, null)), Encoding.UTF8, "application/json"));
                respoce.Result.Content.ReadAsStream();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Registr(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) || !string.IsNullOrWhiteSpace(password))
            {
                List<Models.Visitor> visitors = new List<Models.Visitor>();
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        visitors = JsonConvert.DeserializeObject<List<Models.Visitor>>(client.GetAsync("http://localhost:8080/getVisitor", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch { }
                if (visitors.FirstOrDefault(x => x.Email == email) == null)
                {
                    int id = 0;
                    try
                    {
                        using (HttpClient maxId = new HttpClient())
                        {
                            id = int.Parse(maxId.GetAsync("http://localhost:8080/maxIdVisitor", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync()
                                .Result) + 1;
                        }
                    }
                    catch { }
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {
                            var responce = client.PutAsync("http://localhost:8080/putVisitor", new StringContent(JsonConvert.SerializeObject(new Models.Visitor(id, null, null, email, null, null, email.Split("@")[0], password, 0, null, null)), Encoding.UTF8, "application/json"));
                            responce.Result.Content.ReadAsStringAsync().Wait();
                        }
                    }
                    catch { }
                }
                else
                    throw new NotSupportedException("Такой Email уже есть");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Registration(string login, string password)
        {
            var model = new Visitor() { Login = login, Password = password };
            return View("Register", model);
        }

        public IActionResult Login(string login, string password)
        {
            List<Models.Visitor> visitors = new List<Models.Visitor>();
            using (HttpClient client = new HttpClient())
            {
                visitors = JsonConvert.DeserializeObject<List<Models.Visitor>>(client.GetAsync("http://localhost:8080/getVisitor", HttpCompletionOption.ResponseContentRead).Result.Content.ReadAsStringAsync().Result);
            }
            foreach (Models.Visitor visitor in visitors)
            {
                if (visitor.Login == login && visitor.Password == Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetBytes(password).Length)))
                {
                    LogginVisitorId = visitor.Id;
                    LogginVisitorPassword = visitor.Password;
                    return RedirectToAction("ChooseVisitType");
                }
            }
            return Registration(login, password);
        }

        public IActionResult RequestsList()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}