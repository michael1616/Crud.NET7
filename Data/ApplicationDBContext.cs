using Crud.NET7.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.NET7.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options) 
        {
        }


        public DbSet<Contact> Contacts { get; set; }


    }
}
