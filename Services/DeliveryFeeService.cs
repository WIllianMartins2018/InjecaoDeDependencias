using DemoInjecaoDependencias.Services.Contracts;
using RestSharp;

namespace DemoInjecaoDependencias.Services
{
    public class DeliveryFeeService : IDeliveryFeeServices
    {
        public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
        {
            decimal deliveryFee = 0;
            var client = new RestClient(baseUrl: "https://consultafrete.io/cep/");
            var request = new RestRequest()
                .AddJsonBody(new
                {
                    zipCode
                });
            deliveryFee = await client.PostAsync<decimal>(request);
            // Nunca é menos que R$ 5,00
            if (deliveryFee < 5)
                deliveryFee = 5;

            return deliveryFee; 
        }
    }
}
