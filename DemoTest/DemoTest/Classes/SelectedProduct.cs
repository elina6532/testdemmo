using System.Globalization;
using System.Windows.Media;

namespace DemoTest.Classes
{
    public class SelectedProduct
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public ImageSource Images { get; set; }

        public decimal TotalPrice
        {
            get
            {
                string Cost = Price.Replace("руб.","").Trim();
                return decimal.Parse(Cost,new CultureInfo("ru-RU"))*Quantity;
            }
        }
        public static decimal Baskets(List<SelectedProduct> basketitems)
        {
            return basketitems.Sum(b => b.TotalPrice);
        }
    }
}
