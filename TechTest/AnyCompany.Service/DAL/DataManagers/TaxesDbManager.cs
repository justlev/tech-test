using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnyCompany.Service.Facades;

namespace AnyCompany.Service.DAL.DataManagers
{
    public class TaxesDbManager : ITaxesFacade
    {
        private readonly IDatabaseWrapper database;

        public TaxesDbManager(IDatabaseWrapper database)
        {
            this.database = database;
        }

        public async Task<decimal> GetTaxByType(string taxType)
        {
            var results = await this.database.ExecuteSqlFile("get-tax-by-type", new Dictionary<string, object> {{"@type", taxType}});
            
            return (decimal) results.First()["tax"];
        }
    }
}