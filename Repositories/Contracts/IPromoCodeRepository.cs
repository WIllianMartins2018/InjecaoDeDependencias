namespace DemoInjecaoDependencias.Repositories.Contracts
{
    public interface IPromoCodeRepository
    {
        Task<decimal> GetDiscountByPromoCode(string promoCode);
    }
}
