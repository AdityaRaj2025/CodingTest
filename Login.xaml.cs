using RouteLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RailwayTask
{
    public static class UserContext
    {
        public static string UserRole { get; set; }
    }

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            txtUser.Text = Environment.UserName;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string role = ((ComboBoxItem)roleComboBox.SelectedItem).Content.ToString();
            string password = passwordBox.Password;
            string username = txtUser.Text;

            if ((role == "Admin" && password == "Admin2024") || (role == "Operator" && password == "Operator2024"))
            {
                UserContext.UserRole = role;
       
                IRecordRepository recordRepository = new RecordRepository(); 
                MainWindow mainWindow = new MainWindow(recordRepository);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid role or password. Please try again.");
            }
        }

    }
}
