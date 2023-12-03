using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api
{
    public class Context : DbContext
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
