using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Data;
using RegistrationApi.Models;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        RegistrationsDbContext _dbContext;

        public EmployeesController(RegistrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Employees
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_dbContext.Employees.Find(id));
        }

        // POST: api/Employees
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
