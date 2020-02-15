using Microsoft.EntityFrameworkCore;
using RegistrationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationApi.Data
{
    public class RegistrationsDbContext : DbContext
    {
        public RegistrationsDbContext(DbContextOptions<RegistrationsDbContext>options): base(options)
        {
                
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
