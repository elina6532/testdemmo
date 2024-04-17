using System.Windows;

namespace DemoTest.Windows.Waiter
{
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            Productcard.Children.Clear();
            List<Models.Menu> list = App.context.Menus.ToList();
            foreach (Models.Menu item in list)
            {
                 Productcard.Children.Add (new UserControls.MenuCard(item.IdMenu,item.Name,item.Description,Convert.ToDecimal(item.Cost),item.Photo,Convert.ToInt32(item.Quantity),item.Status));
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            this.Hide();
        }
    }
   
}
