using DemoTest.Models;
using System.Windows;

namespace DemoTest.Windows.Admin
{
    public partial class AddEmployee : Window
    {
        private NewCafeContext _context;
        public AddEmployee()
        {
            InitializeComponent();
            _context = new NewCafeContext();

            var position = _context.Positions.ToList();

            txtPosition.ItemsSource = position;
            txtPosition.DisplayMemberPath = "Name";
            txtPosition.SelectedValuePath = "IdPosition";

            var status = _context.Statuses.ToList();
            txtStatus.ItemsSource = status;
            txtStatus.DisplayMemberPath = "Name";
            txtStatus.SelectedValuePath = "IdStatus";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstname.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPatronymic.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) ||
                 string.IsNullOrWhiteSpace(txtAdress.Text) || string.IsNullOrWhiteSpace(txtPosition.Text) ||
                 string.IsNullOrWhiteSpace(txtStatus.Text) || string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите все обязательные поля!");
                return;
            }
            using (var context = new NewCafeContext())
            {
                Models.Employee employee = new Models.Employee();
                employee.FirstName = txtFirstname.Text;
                employee.Name = txtName.Text;
                employee.Patronymic = txtPatronymic.Text;
                employee.Phone = txtPhone.Text;
                employee.Adress = txtAdress.Text;
                employee.Passport = txtPassport.Text;
                if (txtPosition.SelectedValue != null)
                {
                    employee.IdPosition = (int)txtPosition.SelectedValue;
                }
                if (txtStatus.SelectedValue != null)
                {
                    employee.IdStatus = (int)txtStatus.SelectedValue;
                }
                employee.Login = txtLogin.Text;
                employee.Password = txtPassword.Text;
                context.Employees.Add(employee);
                context.SaveChanges();
                MessageBox.Show("Успешно");

            }
        }
    }
}
