using System.Text.RegularExpressions;
using Task.Application.Interfaces.Contexts;
using Task.Common.Dtos;
using Task.Domain.Entities;

namespace Task.Application.Services.Customers.Commands.AddCustomer
{
    public class AddCustomerService : IAddCustomerService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public AddCustomerService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(RequestAddCustomerDto request)
        {
            if (string.IsNullOrEmpty(request.FirstName))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام را وارد نمایید"
                };
            }

            if (string.IsNullOrEmpty(request.LastName))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام خانوادگی را وارد نمایید"
                };
            }

            if (string.IsNullOrEmpty(request.FatherName))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام پدر را وارد نمایید"
                };
            }

            if (request.BirthCertificateNumber == 0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "شماره شناسنامه را وارد نمایید"
                };
            }

            if (request.NationalCode == 0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کد ملی را وارد نمایید"
                };
            }

            string mobileRegex = "^09[-.\\s]?\\d{2}[-.\\s]?\\d{3}[-.\\s]?\\d{4}$";
            var match = Regex.Match(request.MobileNumber, mobileRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "شماره موبایل به درستی وارد نمایید"
                };
            }

            if (string.IsNullOrEmpty(request.Address))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "آدرس را وارد نمایید"
                };
            }

            Customer customer = new Customer()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                FatherName = request.FatherName,
                BirthCertificateNumber = request.BirthCertificateNumber,
                NationalCode = request.NationalCode,
                DateOfBirth = request.DateOfBirth,
                MobileNumber = request.MobileNumber,
                Address = request.Address,
            };
            _dataBaseContext.Customers.Add(customer);
            _dataBaseContext.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "مشتری با موفقیت اضافه شد"
            };
        }
    }
}