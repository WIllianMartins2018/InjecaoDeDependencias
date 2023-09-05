using Dapper;
using DemoInjecaoDependencias.Models;
using DemoInjecaoDependencias.Repositories.Contracts;
using System.Data.SqlClient;

namespace DemoInjecaoDependencias.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlConnection _connection;

        public ProductRepository(SqlConnection connection)
            => _connection = connection;

        public async Task<decimal> GetSubTotal(int qtdProducts)
        {
            decimal subTotal = 0;
            const string getProductQuery = "SELECT [Id], [Name], [Price] FROM PRODUCT WHERE ID=@id";
            for (var p = 0; p < qtdProducts; p++)
            {
                Product product;
                product = await _connection.QueryFirstOrDefaultAsync<Product>(getProductQuery, new { Id = p });

                subTotal += product.Price;
            }

            return subTotal;

        }
    }
}
