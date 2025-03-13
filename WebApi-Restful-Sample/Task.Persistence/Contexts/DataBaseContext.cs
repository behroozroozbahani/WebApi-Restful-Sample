using Microsoft.EntityFrameworkCore;
using Task.Application.Interfaces.Contexts;
using Task.Domain.Entities;

namespace Task.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        //----------------------------------
        public DbSet<Customer> Customers { get; set; }
    }
}