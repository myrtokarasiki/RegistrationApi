using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using EmployeeApplication.Helper;

namespace EmployeeApplication.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeAPI _EmployeeAPI = new EmployeeAPI();

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Password,BirthDate,Sullary,TemrsAccepted")] EmployeeDTO Employee)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _EmployeeAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Employee), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/Employees", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Create");
                }
            }
            return View(Employee);
        }
              
    }


}