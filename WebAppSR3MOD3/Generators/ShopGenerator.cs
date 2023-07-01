using NewVariant.Exceptions;
using NewVariant.Interfaces;
using NewVariant.Models;

namespace WebAppSR3MOD3.Generators
{
    public static class ShopGenerator
    {
        /// <summary>
        /// Filles Shop database with random data.
        /// </summary>
        /// <param name="database">Database to fill.</param>
        public static void Generate(IDataBase database)
        {
            try
            {
                database.CreateTable<Shop>();
            }
            catch (DataBaseException e)
            {

            }
            Random r = new Random();
            int numberOfShops = r.Next(1, 20);
            for (int i = 0; i < numberOfShops; ++i)
            {
                database.InsertInto<Shop>(() => new Shop(
                    RandomValues.GetRandomShopName(),
                    RandomValues.GetRandomCity(),
                    RandomValues.GetRandomCountry()));
            }

        }
    }
}
