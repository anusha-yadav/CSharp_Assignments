using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_WebApplication.Models;

namespace Student_WebApplication.Data
{
    public class Student_WebApplicationContext : DbContext
    {
        public Student_WebApplicationContext (DbContextOptions<Student_WebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Student_WebApplication.Models.Register> Register { get; set; } = default!;
    }
}
