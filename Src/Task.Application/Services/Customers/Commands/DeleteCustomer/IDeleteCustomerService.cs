using Task.Common.Dtos;

namespace Task.Application.Services.Customers.Commands.DeleteCustomer
{
    public interface IDeleteCustomerService
    {
        ResultDto Execute(long id);
    }
}