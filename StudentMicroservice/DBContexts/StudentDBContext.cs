using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentMicroservice.Model;

namespace StudentMicroservice.DBContexts
{
    public class StudentDBContext: DbContext
    {
       public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {

        }

       public DbSet<Student> Students { get; set; }
    }
}
