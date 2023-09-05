namespace DemoInjecaoDependencias.Services.Contracts
{
    public interface IDeliveryFeeServices
    {
        Task<decimal> GetDeliveryFeeAsync(string zipCode);
    }
}
