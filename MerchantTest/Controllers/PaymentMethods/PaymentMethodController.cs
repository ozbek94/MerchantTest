using AutoMapper;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MerchantTest.Api.Controllers.PaymentMethods
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IRepository<PaymentRequest> _repository;
        private readonly IMapper _mapper;

        public PaymentMethodController(IRepository<PaymentRequest> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        // GET: api/<PaymentMethodController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaymentMethodController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaymentMethodController>
        [HttpPost]
        public async Task Post([FromBody] CreatePaymentMethodRequest Request)
        {
            var paymentMethod = _mapper.Map<PaymentRequest>(Request);

            await _repository.AddAsync(paymentMethod);
        }

        // PUT api/<PaymentMethodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentMethodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
