using NewVariant.Exceptions;
using NewVariant.Interfaces;
using NewVariant.Models;

namespace WebAppSR3MOD3.Generators
{
    public static class GoodGenerator
    {
        /// <summary>
        /// Filles Good database with random data.
        /// </summary>
        /// <param name="database">Database to fill.</param>
        public static void Generate(IDataBase database)
        {
            try
            {
                database.CreateTable<Good>();
            }
            catch (DataBaseException e)
            {

            }
            Random r = new Random();
            int numberOfShops = r.Next(1, 1001);
            for (int i = 0; i < numberOfShops; ++i)
            {
                database.InsertInto<Good>(() => new Good(
                    RandomValues.GetRandomGoodName(),
                    r.Next(database.GetTable<Shop>().Count()),
                    RandomValues.GetRandomCategory(),
                    r.Next(10000)));
            }

        }
    }
}
