using Task.Application.Interfaces.Contexts;
using Task.Common.Dtos;

namespace Task.Application.Services.Customers.Commands.EditCustomer
{
    public class EditCustomerService : IEditCustomerService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public EditCustomerService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(RequestEditCustomerDto request)
        {
            var customer = _dataBaseContext.Customers.SingleOrDefault(x => x.Id == request.Id);
            if (customer == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "مشتری یافت نشد"
                };
            }

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.FatherName = request.FatherName;
            customer.BirthCertificateNumber = request.BirthCertificateNumber;
            customer.NationalCode = request.NationalCode;
            customer.DateOfBirth = request.DateOfBirth;
            customer.MobileNumber = request.MobileNumber;
            customer.Address = request.Address;
            _dataBaseContext.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "مشتری با موفقیت ویرایش شد"
            };
        }
    }
}
