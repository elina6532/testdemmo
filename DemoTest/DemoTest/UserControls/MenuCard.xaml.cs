using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DemoTest.UserControls
{
    public partial class MenuCard : UserControl
    {
        public MenuCard(int ProductID,string Name,string Descriprion,decimal Cost, byte[] imgs, int Quantity,string Status)
        {
            InitializeComponent();
            txtID.Text = ProductID.ToString();
            txtName.Text = Name;
            txtDescription.Text = Descriprion;
            txtCost.Text = Cost.ToString();

            txtquantity.Text = Quantity.ToString();
            txtstatus.Text = Status;

            try
            {
                BitmapImage img = new BitmapImage();
                MemoryStream MS = new MemoryStream();
                img.BeginInit();
                img.StreamSource = MS;
                img.EndInit();
                Images.Source = img;

            }
            catch { }

        }
        private void TotalAmount()
        {
            decimal totalamount = Classes.Basket.GetProducts().Sum(p => p.TotalPrice);
            TotalPrice.Text = "Общая стоимость"+ totalamount.ToString("C");
        }
        private void Basket_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(txtstatus.Text == "В наличии")
            {
                int productID = int.Parse(txtID.Text);
                string Name = txtName.Text;
                string Price = txtCost.Text;
                int quantity = int.Parse(txtquantity.Text);
                ImageSource imageSource = Images.Source;

                Classes.SelectedProduct selectedProduct = new Classes.SelectedProduct()
                {
                    ProductId = productID,
                    Name = Name,
                    Price = Price,
                    Quantity = quantity,
                    Images = imageSource
                };
                Classes.Basket.BasketAdd(selectedProduct);
                MessageBox.Show("Добавлен в корзину");
                TotalAmount();

            }
        }
    }
}
