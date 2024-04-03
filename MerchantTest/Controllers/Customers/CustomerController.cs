using AutoMapper;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Api.Models.Response;
using MerchantTest.Applicatiıon.Managers.Caches;
using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Applicatiıon.Services;
using MerchantTest.Applicatiıon.Strategies.Customer;
using MerchantTest.Domain.Entities;
using MerchantTest.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MerchantTest.Api.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly ILogger<CustomerController> _logger;
        private readonly ConfigurationStrategyFactory _factory;
        private readonly IDistributedCacheManager _cacheManager;
        private readonly IDistributedCache _distributedCache;

        public CustomerController(ICustomerService customerService, IMapper mapper, ICustomerRepository customerRepository, IPaymentRequestRepository paymentRequestRepository, ILogger<CustomerController> logger, ConfigurationStrategyFactory factory, IDistributedCacheManager cacheManager, IDistributedCache distributedCache)
        {
            _customerService = customerService;
            _mapper = mapper;
            _customerRepository = customerRepository;
            _paymentRequestRepository = paymentRequestRepository;
            _logger = logger;
            _factory = factory;
            _cacheManager = cacheManager;
            _distributedCache = distributedCache;
        }


        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerRepository.GetCustomerDetailsByIdAsync(id);

            var model = _mapper.Map<GetCustomerResponse>(customer);

            var factory = new ConfigurationStrategyFactory();
            var strategy = factory.GetStrategy(customer.Configuration);
            var result = strategy.Execute();

            _cacheManager.Set("Customer", model);
            var cachedCustomer = _cacheManager.Get<GetCustomerResponse>("Customer");
            _logger.LogInformation("Customer Cached: {@customer}", cachedCustomer);

            return Ok(cachedCustomer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerRequest Request)
        {
            var customer = _mapper.Map<Customer>(Request);

            if (Request != null)
            {
                var paymentMethods = await _paymentRequestRepository.GetPaymentRequestsByIds(Request.PaymentRequestIds);
                if (paymentMethods != null)
                {
                    customer.AddPaymentRequestsRange(paymentMethods);
                }
            }
            Thread.Sleep(10000);
            await _customerRepository.AddAsync(customer);

            _logger.LogInformation("Customer Created: {@customer}", customer);

            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int CustomerId, List<int> PaymentRequestIds)
        {
            var operationResult = await _customerService.AssignPaymentRequestToCustomer(CustomerId, PaymentRequestIds);

            if (operationResult.Success)
            {
                return Ok(operationResult.Message);
            }
            else
            {
                return BadRequest(operationResult.Message);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerRepository.SoftDeleteAsync(id);

            return Ok();
        }
    }
}
