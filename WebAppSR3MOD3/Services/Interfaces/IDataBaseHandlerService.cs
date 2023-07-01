using NewVariant.Interfaces;

namespace WebAppSR3MOD3.Services.Interfaces
{
    /// <summary>
    /// Interface of handler of database.
    /// </summary>
    public interface IDataBaseHandlerService
    {
        /// <summary>
        /// Method to get database.
        /// </summary>
        /// <returns></returns>
        public IDataBase GetDataBase();
    }
}
