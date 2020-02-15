using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EmployeeApplication.Helper
{

    public class EmployeeAPI
    {
        private string _apiBaseURI = "http://localhost:50645";
        public HttpClient InitializeClient()
        {
            var client = new HttpClient();
            //Passing service base url  
            client.BaseAddress = new Uri(_apiBaseURI);

            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }
    }

    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? BirthDate { get; set; }

        public decimal Sullary { get; set; }

        public bool TemrsAccepted { get; set; }

    }

}
