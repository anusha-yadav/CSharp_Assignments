using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Application.Models;

namespace Student_Application.Data
{
    public class Student_ApplicationContext : DbContext
    {
        public Student_ApplicationContext (DbContextOptions<Student_ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Student_Application.Models.Register> Register { get; set; } = default!;
    }
}
