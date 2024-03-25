using AutoMapper;
using MerchantTest.Api.Models.Requests;
using MerchantTest.Api.Models.Response;
using MerchantTest.Applicatiıon.Hubs;
using MerchantTest.Applicatiıon.Repositories;
using MerchantTest.Domain.Entities;
using MerchantTest.Domain.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MerchantTest.Api.Controllers.Merchants
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly IPaymentMethodRepository _paymentReposiyory;
        private readonly IMerchantRepository _merchantRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<MerchantHub> _hubContext;

        public MerchantController(
            IMerchantRepository merchantRepository,
            IMapper mapper,
            IPaymentMethodRepository paymentReposiyory,
            IHubContext<MerchantHub> hubContext)
        {
            _merchantRepository = merchantRepository;
            _mapper = mapper;
            _paymentReposiyory = paymentReposiyory;
            _hubContext = hubContext;
        }

        // GET: api/<MerchantController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MerchantController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var merchant = await _merchantRepository.GetMerchantDetailsByIdAsync(id);

            var model = _mapper.Map<GetMerchantResponse>(merchant);

            return Ok(model);
        }

        // POST api/<MerchantController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMerchantRequest Request)
        {
            var merchant = _mapper.Map<Merchant>(Request);

            if (Request.PaymentMethodIds != null)
            {
                var paymentMethods = await _paymentReposiyory.GetPaymentMethodsByIds(Request.PaymentMethodIds);
                if (paymentMethods != null)
                {
                    merchant.AddPaymentMethodsRange(paymentMethods);
                }
            }

            Thread.Sleep(30000); //AASDSADA

            await _merchantRepository.AddAsync(merchant);

            return Ok();
        }

        // PUT api/<MerchantController>/5
        [HttpPut]
        public async Task<IActionResult> AssingPaymentMethodToMerchant(int MerchantId, List<int> PaymentMethodIds)
        {
            //Console.WriteLine("sadsad");
            //await _hubContext.Clients.All.SendAsync("newOrder");

            var merchant = await _merchantRepository.AssignPaymentMethodsToMerchantAsync(MerchantId, PaymentMethodIds);
            
            merchant.UpdateMercantPaymentMethodEvent();

            return Ok();
        }   

        // DELETE api/<MerchantController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
        }
    }
}
