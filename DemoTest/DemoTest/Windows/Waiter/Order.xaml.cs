using DemoTest.Classes;
using DemoTest.Models;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace DemoTest.Windows.Waiter
{
    public partial class Order : Window
    {
        public ObservableCollection<SelectedProduct> BasketItems { get; set; }
        private NewCafeContext context;
        public decimal totalamountt;
        public Order()
        {
            InitializeComponent();
            context = new NewCafeContext();
            BasketItems = new ObservableCollection<SelectedProduct>(Classes.Basket.GetProducts());
            totalamountt = BasketItems.Sum(u => u.TotalPrice);
            totalamount.Text = $"Общая стоимость {totalamountt}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Models.Order order = new Models.Order()
            {
                IdEmployee = 1,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                OrderStatus = "В обработке",
                OrderTotalAmount = totalamountt
            };
            context.Orders.Add(order);
            context.SaveChanges();
            foreach (var productinfo in Classes.Basket.GetProducts())
            {
                Orderitem item = new Orderitem()
                {
                    IdOrder = order.IdOrder,
                    IdMenu = productinfo.ProductId,
                    Price = totalamountt,
                    Quantity = productinfo.Quantity
                };
                context.Orderitems.Add(item);
            }
            context.SaveChanges();

            BasketItems.Clear();
            totalamount.Text = "0";
            MessageBox.Show("Успешно");

        }
    }
}
