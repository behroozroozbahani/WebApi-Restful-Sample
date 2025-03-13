using Task.Application.Interfaces.Contexts;
using Task.Common.Dtos;
using Task.Common.Hateoas;

namespace Task.Application.Services.Customers.Queries.GetCustomer
{
    public class GetCustomerService : IGetCustomerService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public GetCustomerService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto<GetCustomerDto> Execute(long id)
        {
            var customer = _dataBaseContext.Customers.Find(id);

            if (customer == null)
            {
                return new ResultDto<GetCustomerDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "مشتری یافت نشد"
                };
            }

            return new ResultDto<GetCustomerDto>()
            {
                Data = new GetCustomerDto()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    FatherName = customer.FatherName,
                    BirthCertificateNumber = customer.BirthCertificateNumber,
                    NationalCode = customer.NationalCode,
                    DateOfBirth = customer.DateOfBirth,
                    MobileNumber = customer.MobileNumber,
                    Address = customer.Address,
                    Links = new List<Link>()
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
