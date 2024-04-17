using DemoTest.Models;
using System.Windows;

namespace DemoTest.Windows
{
    public partial class Authorization : Window
    {
        private NewCafeContext _context;
        public Authorization()
        {
            InitializeComponent();
            _context = new NewCafeContext();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Length == 0)
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Введите пароль");
                return;
            }
            if(txtLogin.Text.Length != 0 && txtPassword.Text.Length != 0)
            {
                Models.Employee employee = _context.Employees.FirstOrDefault(u=> u.Login == txtLogin.Text && u.Password == txtPassword.Text);
                if (employee != null)
                {
                    MessageBox.Show($"Здравствуйте, {employee.SNP} - {employee.PostName}");
                    Classes.AllData.Id = employee.IdEmployee;
                    if(employee.IdPosition == 1)
                    {
                        Waiter.Menu employee1 = new Waiter.Menu();
                        employee1.Show();
                        this.Close();
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Выйти?", "Сообщение", MessageBoxButton.YesNo);
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
