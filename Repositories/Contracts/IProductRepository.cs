namespace DemoInjecaoDependencias.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<decimal> GetSubTotal(int qtdProducts);
    }
}
