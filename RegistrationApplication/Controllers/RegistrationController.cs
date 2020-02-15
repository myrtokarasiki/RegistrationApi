using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RegistrationApplication.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationAPI _EmployeeAPI = new RegistrationAPI();

        public async Task<IActionResult> Index()
        {
            List<EmployeeDTO> dto = new List<EmployeeDTO>();

            HttpClient client = _EmployeeAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/employee");

            //Checking the response is successful or not which is sent using HttpClient    
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api     
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list    
                dto = JsonConvert.DeserializeObject<List<EmployeeDTO>>(result);

            }
            //returning the employee list to view    
            return View(dto);
        }

        //GET: Employees/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Employees/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Password,BirthDate,Sullary,TemrsAccepted")] EmployeeDTO Employee)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _EmployeeAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Employee), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/Employee", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Create");
                }
            }
            return View(Employee);
        }

        // GET: Employees/Edit/1  
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<EmployeeDTO> dto = new List<EmployeeDTO>();
            HttpClient client = _EmployeeAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/Employee");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<EmployeeDTO>>(result);
            }

            var Employee = dto.SingleOrDefault(m => m.Id == id);
            if (Employee == null)
            {
                return NotFound();
            }

            return View(Employee);
        }

        // POST: Employees/Edit/1  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Name,Email,Password,BirthDate,Sullary,TemrsAccepted")] EmployeeDTO Employee)
        {
            if (id != Employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpClient client = _EmployeeAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(Employee), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PutAsync("api/Employee", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Create");
                }
            }
            return View(Employee);
        }

        // GET: Employees/Delete/1  
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<EmployeeDTO> dto = new List<EmployeeDTO>();
            HttpClient client = _EmployeeAPI.InitializeClient();
            HttpResponseMessage res = await client.GetAsync("api/Employee");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dto = JsonConvert.DeserializeObject<List<EmployeeDTO>>(result);
            }

            var Employee = dto.SingleOrDefault(m => m.Id == id);
            if (Employee == null)
            {
                return NotFound();
            }

            return View(Employee);
        }

        // POST: Employees/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            HttpClient client = _EmployeeAPI.InitializeClient();
            HttpResponseMessage res = client.DeleteAsync($"api/Employee/{id}").Result;
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Create");
            }

            return NotFound();
        }
    }
}