using Task.Common.Dtos;

namespace Task.Application.Services.Customers.Queries.GetCustomer
{
    public interface IGetCustomerService
    {
        ResultDto<GetCustomerDto> Execute(long id);
    }
}
