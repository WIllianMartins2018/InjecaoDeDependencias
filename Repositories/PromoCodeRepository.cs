using Dapper;
using DemoInjecaoDependencias.Models;
using DemoInjecaoDependencias.Repositories.Contracts;
using System.Data.SqlClient;

namespace DemoInjecaoDependencias.Repositories
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private readonly SqlConnection _connection;

        public PromoCodeRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<decimal> GetDiscountByPromoCode(string promoCode)
        {
            decimal discount = 0;

            const string query = "SELECT * FROM PROMO_CODES WHERE CODE=@code";
            var promo = await _connection.QueryFirstOrDefaultAsync<PromoCode>(query, new { code = promoCode });
            if (promo.ExpireDate > DateTime.Now)
                discount = promo.Value;

            return discount;

        }
    }
}
