using Dapper;
using DemoInjecaoDependencias.Models;
using DemoInjecaoDependencias.Repositories.Contracts;
using DemoInjecaoDependencias.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Data.SqlClient;

namespace DemoInjecaoDependencias.Controllers
{


    [Route("v1/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFeeServices _deliveryFeeServices;
        private readonly IProductRepository _productRepository;
        private readonly IPromoCodeRepository _promoCodeRepository;

        public OrderController(
            ICustomerRepository customerRepository, 
            IDeliveryFeeServices deliveryFeeServices,
            IProductRepository productRepository,
            IPromoCodeRepository promoCodeRepository)
        {
            _customerRepository = customerRepository;
            _deliveryFeeServices = deliveryFeeServices;
            _productRepository = productRepository;
            _promoCodeRepository = promoCodeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, int[] products)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer is null)
                return NotFound();

            var deliveryFee = await _deliveryFeeServices.GetDeliveryFeeAsync(zipCode);
            var subTotal = await _productRepository.GetSubTotal(products.Length);
            var discount = await _promoCodeRepository.GetDiscountByPromoCode(promoCode);
            var order = new Order(deliveryFee, discount, subTotal);
            return Ok(new
            {
                Message = $"Pedido {order.Code} gerado com sucesso!"
            });
        }
    }
}
