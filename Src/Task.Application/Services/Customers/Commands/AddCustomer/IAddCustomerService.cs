using Task.Common.Dtos;

namespace Task.Application.Services.Customers.Commands.AddCustomer
{
    public interface IAddCustomerService
    {
        ResultDto Execute(RequestAddCustomerDto request);
    }
}