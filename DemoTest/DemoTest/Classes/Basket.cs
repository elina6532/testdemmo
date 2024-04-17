namespace DemoTest.Classes
{
    internal class Basket
    {
        private static List<SelectedProduct> products = new List<SelectedProduct>();
        public static void BasketAdd(SelectedProduct product)
        {
            products.Add(product);
        }
        public static List<SelectedProduct> GetProducts()
        {
            return products;
        }
    }
}
