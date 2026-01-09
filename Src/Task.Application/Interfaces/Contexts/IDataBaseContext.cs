using Microsoft.EntityFrameworkCore;
using Task.Domain.Entities;

namespace Task.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<Customer> Customers { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}