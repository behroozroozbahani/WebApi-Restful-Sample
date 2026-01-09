using Task.Common.Dtos;

namespace Task.Application.Services.Customers.Commands.EditCustomer
{
    public interface IEditCustomerService
    {
        ResultDto Execute(RequestEditCustomerDto request);
    }
}
