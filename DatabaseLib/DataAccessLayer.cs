using NewVariant.Interfaces;
using NewVariant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLib
{
    /// <summary>
    /// Class to get access to the data.
    /// </summary>
    public class DataAccessLayer : IDataAccessLayer
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DataAccessLayer()
        {

        }
        /// <summary>
        /// Gets sequence of goods which were bought by a person with the longest name.
        /// </summary>
        /// <param name="dataBase">Database.</param>
        /// <returns>Sequence of Good objects.</returns>
        public IEnumerable<Good> GetAllGoodsOfLongestNameBuyer(IDataBase dataBase)
        {
            var buyersWithLongestName = from buyer in dataBase.GetTable<Buyer>()
                       where buyer.Name.Length == dataBase.GetTable<Buyer>().Max(x => x.Name.Length)
                       orderby buyer.Name descending
                       select buyer;
            var buyerId = buyersWithLongestName.First().Id;

            var query = from sale in dataBase.GetTable<Sale>()
                        join good in dataBase.GetTable<Good>() on sale.GoodId equals good.Id
                        join buyer in dataBase.GetTable<Buyer>() on sale.BuyerId equals buyer.Id
                        where buyer.Id == buyerId
                        select good;
            return query.Distinct();
        }
        /// <summary>
        /// Gets the least number of shops in a country.
        /// </summary>
        /// <param name="dataBase">Database.</param>
        /// <returns>The number of shops.</returns>
        public int GetMinimumNumberOfShopsInCountry(IDataBase dataBase)
        {
            var gropusByCountry = from shop in dataBase.GetTable<Shop>()
                        group shop by shop.Country;
            var number = gropusByCountry.Min(x => x.Count());
            return number;
        }
        /// <summary>
        /// Gets city with the least amount of money spent.
        /// </summary>
        /// <param name="dataBase">Database.</param>
        /// <returns>The name of the city.</returns>
        public string? GetMinimumSalesCity(IDataBase dataBase)
        {
            var groupsByCities = from shop in dataBase.GetTable<Shop>()
                        from sale in dataBase.GetTable<Sale>().Where(x => x.ShopId == shop.Id).DefaultIfEmpty(new Sale(0, 0, 0, 0))
                        from good in dataBase.GetTable<Good>().Where(x => sale.GoodId == x.Id).DefaultIfEmpty(new Good("", 0, "", 0))
                        group (good, sale) by shop.City;
            var orderedGroupsByCities = from q in groupsByCities
                    orderby q.Sum(x => x.Item1.Price * x.Item2.GoodCount) ascending
                    select q;
            var name = orderedGroupsByCities.First().Key;
            return name;

        }
        /// <summary>
        /// Gets the category which consists the most expencive good.
        /// </summary>
        /// <param name="dataBase">Database.</param>
        /// <returns>The name of the category.</returns>
        public string? GetMostExpensiveGoodCategory(IDataBase dataBase)
        {
            var orderedGroupsByPrice = from good in dataBase.GetTable<Good>()
                        orderby good.Price descending
                        select good;
            var category = orderedGroupsByPrice.First().Category;
            return category;
        }
        /// <summary>
        /// Gets the sequence of buyers who bought the most popular good.
        /// </summary>
        /// <param name="dataBase">Database.</param>
        /// <returns>The sequence of buyers.</returns>
        public IEnumerable<Buyer> GetMostPopularGoodBuyers(IDataBase dataBase)
        {
            var query = from sale in dataBase.GetTable<Sale>()
                        group sale by sale.GoodId;
            var maxCount = query.Max(x => x.Sum(y => y.GoodCount));
            var mostPopularIdOfGood = query.Where(x => x.Sum(y => y.GoodCount) == maxCount).First().Key;
            var buyers = from sale in dataBase.GetTable<Sale>()
                         join buyer in dataBase.GetTable<Buyer>() on sale.BuyerId equals buyer.Id
                         where sale.GoodId == mostPopularIdOfGood
                         select buyer;
            return buyers.Distinct();
            
        }
        /// <summary>
        /// Gets the sequence of sales which were made by persons from anouther country.
        /// </summary>
        /// <param name="dataBase">Database.</param>
        /// <returns>The sequence of sales.</returns>
        public IEnumerable<Sale> GetOtherCitySales(IDataBase dataBase)
        {
            var query = from sale in dataBase.GetTable<Sale>()
                        join shop in dataBase.GetTable<Shop>() on sale.ShopId equals shop.Id
                        join buyer in dataBase.GetTable<Buyer>() on sale.BuyerId equals buyer.Id
                        where shop.City != buyer.City
                        select sale;
            return query;
        }
        /// <summary>
        /// Gets the sum of all money spent.
        /// </summary>
        /// <param name="dataBase">Database.</param>
        /// <returns>Total sum of money.</returns>
        public long GetTotalSalesValue(IDataBase dataBase)
        {
            var allGoods = from sale in dataBase.GetTable<Sale>()
                           join good in dataBase.GetTable<Good>() on sale.GoodId equals good.Id
                           select (good, sale);
            var sum = allGoods.Sum(x => x.Item1.Price * x.Item2.GoodCount);
            return sum;
        }
    }
}
