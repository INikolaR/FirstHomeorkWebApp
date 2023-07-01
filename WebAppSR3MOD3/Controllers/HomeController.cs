using DatabaseLib;
using Microsoft.AspNetCore.Mvc;
using NewVariant.Interfaces;
using NewVariant.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Encodings.Web;
using WebAppSR3MOD3.Generators;
using WebAppSR3MOD3.Models;
using WebAppSR3MOD3.Services.Interfaces;

namespace WebAppSR3MOD3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;
        private readonly IDataBase _dataBase;
        /// <summary>
        /// Constructor to arrange DataBase and DataAccessLayer.
        /// </summary>
        /// <param name="dataAccessLayer"></param>
        /// <param name="service"></param>
        public HomeController(
            IDataAccessLayer dataAccessLayer,
            IDataBaseHandlerService service)
        {
            _dataAccessLayer = dataAccessLayer;
            _dataBase = service.GetDataBase();
        }
        /// <summary>
        /// "Welcome" page.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Main application page.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult Application(string name, int numTimes)
        {
            return View();
        }
        /// <summary>
        /// Page with result of GetAllGoodsOfLongestNameBuyer.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetAllGoodsOfLongestNameBuyer()
        {
            ViewData["output"] = _dataAccessLayer.GetAllGoodsOfLongestNameBuyer(_dataBase).ToList().ConvertAll(x => x.ToString());
            return View();
        }
        /// <summary>
        /// Page with result of GetMinimumNumberOfShopsInCountry.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetMinimumNumberOfShopsInCountry()
        {
            ViewData["output"] = _dataAccessLayer.GetMinimumNumberOfShopsInCountry(_dataBase);
            return View();
        }
        /// <summary>
        /// Page with result of GetMinimumSalesCity.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetMinimumSalesCity()
        {
            ViewData["output"] = _dataAccessLayer.GetMinimumSalesCity(_dataBase);
            return View();
        }
        /// <summary>
        /// Page with result of GetMostExpensiveGoodCategory.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetMostExpensiveGoodCategory()
        {
            ViewData["output"] = _dataAccessLayer.GetMostExpensiveGoodCategory(_dataBase);
            return View();
        }
        /// <summary>
        /// Page with result of GetMostPopularGoodBuyers.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetMostPopularGoodBuyers()
        {
            ViewData["output"] = _dataAccessLayer.GetMostPopularGoodBuyers(_dataBase).ToList().ConvertAll(x => x.ToString());
            return View();
        }
        /// <summary>
        /// Page with result of GetOtherCitySales.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetOtherCitySales()
        {
            ViewData["output"] = _dataAccessLayer.GetOtherCitySales(_dataBase).ToList().ConvertAll(x => x.ToString());
            return View();
        }
        /// <summary>
        /// Page with result of GetTotalSalesValue.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetTotalSalesValue()
        {
            ViewData["output"] = _dataAccessLayer.GetTotalSalesValue(_dataBase);
            return View();
        }
        /// <summary>
        /// Page with database of Shops.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetTableShops()
        {
            ViewData["output"] = _dataBase.GetTable<Shop>().ToList().ConvertAll(x => x.ToString());
            return View();
        }
        /// <summary>
        /// Page with database of Buyers.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetTableBuyers()
        {
            ViewData["output"] = _dataBase.GetTable<Buyer>().ToList().ConvertAll(x => x.ToString());
            return View();
        }
        /// <summary>
        /// Page with database of Goods.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetTableGoods()
        {
            ViewData["output"] = _dataBase.GetTable<Good>().ToList().ConvertAll(x => x.ToString());
            return View();
        }
        /// <summary>
        /// Page with database of Sales.
        /// </summary>
        /// <returns>The view of page.</returns>
        public IActionResult GetTableSales()
        {
            ViewData["output"] = _dataBase.GetTable<Sale>().ToList().ConvertAll(x => x.ToString());
            return View();
        }
        /// <summary>
        /// Error page.
        /// </summary>
        /// <returns>The view of page.</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}