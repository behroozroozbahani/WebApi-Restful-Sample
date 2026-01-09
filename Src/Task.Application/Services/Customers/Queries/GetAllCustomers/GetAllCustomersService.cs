using Task.Application.Interfaces.Contexts;
using Task.Common.Dtos;
using Task.Common.Hateoas;

namespace Task.Application.Services.Customers.Queries.GetAllCustomer
{
    public class GetAllCustomersService : IGetAllCustomersService
    {
        private readonly IDataBaseContext _dataBaseContext;
        public GetAllCustomersService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto<List<GetAllCustomersDto>> Execute()
        {
            var customers = _dataBaseContext.Customers
                                            .ToList()
                                            .Select(x => new GetAllCustomersDto()
                                            {
                                                Id = x.Id,
                                                FirstName = x.FirstName,
                                                LastName = x.LastName,
                                                FatherName = x.FatherName,
                                                BirthCertificateNumber = x.BirthCertificateNumber,
                                                NationalCode = x.NationalCode,
                                                DateOfBirth = x.DateOfBirth,
                                                MobileNumber = x.MobileNumber,
                                                Address = x.Address,
                                                Links = new List<Link>()
                                            }).ToList();


            if (customers.Count == 0)
            {
                return new ResultDto<List<GetAllCustomersDto>>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "مشتری و یا مشتریانی یافت نشد"
                };
            }

            return new ResultDto<List<GetAllCustomersDto>>()
            {
                Data = customers,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}