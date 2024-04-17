using DemoTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace DemoTest.Windows.Admin
{
    public partial class Employee : Window
    {
       private NewCafeContext _context;
        public Employee()
        {
            InitializeComponent();
            _context = new NewCafeContext();
            _context.Employees.Load();
            GridEmployee.ItemsSource = _context.Employees.Local.ToBindingList();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.Show();
            this.Hide();
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
