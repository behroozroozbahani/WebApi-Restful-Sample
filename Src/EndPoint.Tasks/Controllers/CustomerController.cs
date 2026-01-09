using Microsoft.AspNetCore.Mvc;
using Task.Application.Interfaces.FacadePatterns;
using Task.Application.Services.Customers.Commands.AddCustomer;
using Task.Application.Services.Customers.Commands.EditCustomer;
using Task.Common.Hateoas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Endpoint.Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerFacade _customerFacade;

        public CustomerController(ICustomerFacade customerFacade)
        {
            _customerFacade = customerFacade;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _customerFacade.GetAllCustomersService.Execute();

            if (result.Data == null)
            {
                return NotFound(result.Message);
            }

            foreach (var item in result.Data)
            {
                item.Links = new List<Link>()
                {
                  new Link()
                {
                     Href = Url.Action(nameof(Get), "Customer", new { result.Data.FirstOrDefault().Id }, Request.Scheme),
                     Rel = "Self",
                     Method = "Get"
                },

                  new Link()
                {
                    Href = Url.Action(nameof(Delete), "Customer", new { result.Data.FirstOrDefault().Id }, Request.Scheme),
                    Rel = "Delete",
                    Method = "Delete"
                },

                  new Link()
                {
                    Href = Url.Action(nameof(Put), "Customer", Request.Scheme),
                    Rel = "Update",
                    Method = "Put"
                },
                };
            }

            return Ok(result);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var result = _customerFacade.GetCustomerService.Execute(id);

            if (result.Data == null)
            {
                return NotFound(result.Message);
            }

            result.Data.Links = new List<Link>()
            {
                new Link()
                {
                    Href = Url.Action(nameof(Get), "Customer", new {result.Data.Id}, Request.Scheme),
                    Rel = "Self",
                    Method = "Get"
                },

                new Link()
                {
                    Href = Url.Action(nameof(Delete), "Customer", new {result.Data.Id}, Request.Scheme),
                    Rel = "Delete",
                    Method = "Delete"
                },

                new Link()
                {
                    Href = Url.Action(nameof(Put), "Customer", Request.Scheme),
                    Rel = "Update",
                    Method = "Put"
                },
            };

            return Ok(result);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] RequestAddCustomerDto request)
        {
            var result = _customerFacade.AddCustomerService.Execute(request);

            string url = Url.Action(nameof(Get), "Customer", new { Id = result }, Request.Scheme);

            return Created(url, result);
        }

        // PUT api/<CustomerController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] RequestEditCustomerDto request)
        {
            var result = _customerFacade.EditCustomerService.Execute(request);

            if (result.IsSuccess == false)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _customerFacade.DeleteCustomerService.Execute(id);

            if (result.IsSuccess == false)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }
    }
}
