using NewVariant.Exceptions;
using NewVariant.Interfaces;
using NewVariant.Models;

namespace WebAppSR3MOD3.Generators
{
    public static class SaleGenerator
    {
        /// <summary>
        /// Filles Sale database with random data.
        /// </summary>
        /// <param name="database">Database to fill.</param>
        public static void Generate(IDataBase database)
        {
            try
            {
                database.CreateTable<Sale>();
            }
            catch (DataBaseException e)
            {

            }
            Random r = new Random();
            int numberOfShops = r.Next(1, 101);
            for (int i = 0; i < numberOfShops; ++i)
            {
                database.InsertInto<Sale>(() => new Sale(
                    r.Next(database.GetTable<Buyer>().Count()),
                    r.Next(database.GetTable<Shop>().Count()),
                    r.Next(database.GetTable<Good>().Count()),
                    r.Next(1000)));
            }

        }
    }
}
