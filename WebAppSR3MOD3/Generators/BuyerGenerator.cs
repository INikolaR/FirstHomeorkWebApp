using NewVariant.Exceptions;
using NewVariant.Interfaces;
using NewVariant.Models;

namespace WebAppSR3MOD3.Generators
{
    public static class BuyerGenerator
    {
        /// <summary>
        /// Filles Buyer database with random data.
        /// </summary>
        /// <param name="database">Database to fill.</param>
        public static void Generate(IDataBase database)
        {
            try
            {
                database.CreateTable<Buyer>();
            }
            catch (DataBaseException e)
            {

            }
            Random r = new Random();
            int numberOfShops = r.Next(1, 10);
            for (int i = 0; i < numberOfShops; ++i)
            {
                database.InsertInto<Buyer>(() => new Buyer(
                    RandomValues.GetRandomName(),
                    RandomValues.GetRandomSurname(),
                    RandomValues.GetRandomCity(),
                    RandomValues.GetRandomCountry()));
            }

        }
    }
}
