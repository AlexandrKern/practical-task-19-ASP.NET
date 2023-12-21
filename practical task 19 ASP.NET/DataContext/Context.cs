using Microsoft.EntityFrameworkCore;
using practical_task_19_ASP.NET.Models;
using System;

namespace practical_task_19_ASP.NET.DataContext
{
    public class Context:DbContext
    {
        public DbSet<Contact> contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; 
              DataBase=Contanct; 
             Trusted_Connection=True;");
        }
    }
   
}
