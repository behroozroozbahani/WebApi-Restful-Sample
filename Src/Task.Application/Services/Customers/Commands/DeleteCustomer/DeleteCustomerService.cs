using Task.Application.Interfaces.Contexts;
using Task.Common.Dtos;

namespace Task.Application.Services.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerService : IDeleteCustomerService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public DeleteCustomerService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public ResultDto Execute(long id)
        {
            var customer = _dataBaseContext.Customers.Find(id);

            if (customer == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "مشتری یافت نشد"
                };
            }

            _dataBaseContext.Customers.Remove(customer);
            _dataBaseContext.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "مشتری با موفقیت حذف شد"
            };

        }
    }
}