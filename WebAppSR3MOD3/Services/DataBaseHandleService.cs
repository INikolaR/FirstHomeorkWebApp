using DatabaseLib;
using NewVariant.Interfaces;
using WebAppSR3MOD3.Generators;
using WebAppSR3MOD3.Services.Interfaces;

namespace WebAppSR3MOD3.Services
{
    /// <summary>
    /// Class to initialize the database once at the start of the program.
    /// </summary>
    public class DataBaseHandleService : IDataBaseHandlerService
    {
        private readonly IDataBase _database;
        /// <summary>
        /// Constructor to generate random data for database.
        /// </summary>
        /// <param name="database">Database to fill.</param>
        public DataBaseHandleService(
            IDataBase database)
        {
            _database = database;
            generateDatabase(_database);

        }
        /// <summary>
        /// Method to get database.
        /// </summary>
        /// <returns>Database.</returns>
        public IDataBase GetDataBase()
        {
            return _database;
        }
        /// <summary>
        /// Generates random data for database.
        /// </summary>
        /// <param name="dataBase">Database to fill.</param>
        private void generateDatabase(IDataBase dataBase)
        {
            ShopGenerator.Generate(dataBase);
            BuyerGenerator.Generate(dataBase);
            GoodGenerator.Generate(dataBase);
            SaleGenerator.Generate(dataBase);

        }
    }
}
