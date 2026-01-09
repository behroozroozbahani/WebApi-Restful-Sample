using Task.Application.Interfaces.Contexts;
using Task.Application.Interfaces.FacadePatterns;
using Task.Application.Services.Customers.Commands.AddCustomer;
using Task.Application.Services.Customers.Commands.DeleteCustomer;
using Task.Application.Services.Customers.Commands.EditCustomer;
using Task.Application.Services.Customers.Queries.GetAllCustomer;
using Task.Application.Services.Customers.Queries.GetCustomer;

namespace Task.Application.Services.Customers.FacadePattern
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly IDataBaseContext _dataBaseContext;

        public CustomerFacade(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        private AddCustomerService _addCustomerService;
        public AddCustomerService AddCustomerService
        {
            get
            {
                return _addCustomerService = _addCustomerService ?? new AddCustomerService(_dataBaseContext);
            }
        }

        private DeleteCustomerService _deleteCustomerService;
        public DeleteCustomerService DeleteCustomerService
        {
            get
            {
                return _deleteCustomerService = _deleteCustomerService ?? new DeleteCustomerService(_dataBaseContext);
            }
        }

        private EditCustomerService _editCustomerService;
        public EditCustomerService EditCustomerService
        {
            get
            {
                return _editCustomerService = _editCustomerService ?? new EditCustomerService(_dataBaseContext);
            }
        }

        private GetAllCustomersService _getAllCustomersService;
        public GetAllCustomersService GetAllCustomersService
        {
            get
            {
                return _getAllCustomersService = _getAllCustomersService ?? new GetAllCustomersService(_dataBaseContext);
            }
        }

        private GetCustomerService _getCustomerService;
        public GetCustomerService GetCustomerService
        {
            get
            {
                return _getCustomerService = _getCustomerService ?? new GetCustomerService(_dataBaseContext);
            }
        }
    }
}
