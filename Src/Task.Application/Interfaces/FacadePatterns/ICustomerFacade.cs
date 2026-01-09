using Task.Application.Services.Customers.Commands.AddCustomer;
using Task.Application.Services.Customers.Commands.DeleteCustomer;
using Task.Application.Services.Customers.Commands.EditCustomer;
using Task.Application.Services.Customers.Queries.GetAllCustomer;
using Task.Application.Services.Customers.Queries.GetCustomer;

namespace Task.Application.Interfaces.FacadePatterns
{
    public interface ICustomerFacade
    {
        AddCustomerService AddCustomerService { get; }
        DeleteCustomerService DeleteCustomerService { get; }
        EditCustomerService EditCustomerService { get; }
        GetAllCustomersService GetAllCustomersService { get; }
        GetCustomerService GetCustomerService { get; }
    }
}