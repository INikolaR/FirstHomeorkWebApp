namespace WebAppSR3MOD3.Generators
{
    public static class RandomValues
    {
        private static readonly string[] Countries = new string[]
                    { "Singapure", "Malasia", "Australia", "Argentine", "Norway", "Russia" };
        private static readonly string[] Cities = new string[]
                    { "City1", "City2", "City3", "City4", "City5", "City6" };
        public static readonly string[] Names = new string[]
                    { "Petya", "Vasya", "Dima", "Vova", "Ekaterina" };
        public static readonly string[] Surnames = new string[]
                    { "Petrov", "Vasiliev", "Dimitriev", "Vladimirskiy", "Ekaterinin" };
        private static readonly string[] ShopNames = new string[]
                    { "Shop1", "Shop2", "Shop3", "Shop4", "Shop5", "Shop6", "Shop7", "Shop8" };
        private static readonly string[] Categories = new string[]
                    { "Food", "Furniture", "Toys", "Books" };
        private static readonly string[] GoodNames = new string[]
                    { "Good1", "Good2", "Good3", "Good4", "Good5", "Good6", "Good7", "Good8", "Good9", "Good10" };
        /// <summary>
        /// Generates random country from array of strings.
        /// </summary>
        /// <returns>String of country.</returns>
        public static string GetRandomCountry()
        {
            return Countries[new Random().Next(Countries.Length)];
        }
        /// <summary>
        /// Generates random city from array of strings.
        /// </summary>
        /// <returns>String of city.</returns>
        public static string GetRandomCity()
        {
            return Cities[new Random().Next(Cities.Length)];
        }
        /// <summary>
        /// Generates random shop name from array of strings.
        /// </summary>
        /// <returns>String of shop name.</returns>
        public static string GetRandomShopName()
        {
            return ShopNames[new Random().Next(ShopNames.Length)];
        }
        /// <summary>
        /// Generates random name from array of strings.
        /// </summary>
        /// <returns>String of name.</returns>
        public static string GetRandomName()
        {
            return Names[new Random().Next(Names.Length)];
        }
        /// <summary>
        /// Generates random surname from array of strings.
        /// </summary>
        /// <returns>String of surname.</returns>
        public static string GetRandomSurname()
        {
            return Surnames[new Random().Next(Surnames.Length)];
        }
        /// <summary>
        /// Generates random category from array of strings.
        /// </summary>
        /// <returns>String of category.</returns>
        public static string GetRandomCategory()
        {
            return Categories[new Random().Next(Categories.Length)];
        }
        /// <summary>
        /// Generates random good name from array of strings.
        /// </summary>
        /// <returns>String of good name.</returns>
        public static string GetRandomGoodName()
        {
            return GoodNames[new Random().Next(GoodNames.Length)];
        }
    }
}
