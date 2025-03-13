using Task.Common.Dtos;

namespace Task.Application.Services.Customers.Queries.GetAllCustomer
{
    public interface IGetAllCustomersService
    {
        ResultDto<List<GetAllCustomersDto>> Execute();
    }
}