using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using System.Collections.Generic;

namespace MyApi.Data
{
    public class DataContacts: DbContext
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
