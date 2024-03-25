using AutoMapper;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MerchantTest.Api.Controllers.PaymentRequests
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRequestController : ControllerBase
    {
        private readonly IRepository<PaymentRequest> _repository;
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IMapper _mapper;

        public PaymentRequestController(IPaymentRequestRepository paymentRequestRepository, IMapper mapper, IRepository<PaymentRequest> repository)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _mapper = mapper;
            _repository = repository;
        }

        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _repository.FindAsync(id);

            return Ok(model);
        }

        // POST api/<PaymentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePaymentRequestRequest Request)
        {
            var paymentRequest = _mapper.Map<PaymentRequest>(Request);
            await _repository.AddAsync(paymentRequest);

            return Ok(paymentRequest);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.SoftDeleteAsync(id);
            return Ok();
        }
    }
}
