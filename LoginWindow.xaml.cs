using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBoxLogin.Password;

            // Sprawdzenie, czy użytkownik o podanym loginie i haśle istnieje w pliku tekstowym
            string filePath = "C:\\Users\\patry\\Desktop\\users.txt";
            bool userExists = File.ReadLines(filePath).Any(line => line.Split(',')[0] == login && line.Split(',')[1] == password);
            if (!userExists)
            {
                MessageBox.Show("Nieprawidłowy login lub hasło!");
                return;
            }

            // Pobranie rangi użytkownika
            string userLine = File.ReadLines(filePath).First(line => line.Split(',')[0] == login && line.Split(',')[1] == password);
            string userRank = userLine.Split(',')[2];

            // Przeniesienie użytkownika do odpowiedniego panelu w zależności od rangi
            if (userRank == "użytkownik")
            {
                UserPanelWindow userPanelWindow = new UserPanelWindow(login);
                userPanelWindow.Show();
            }
            else if (userRank == "administrator")
            {
                AdminPanelWindow adminPanelWindow = new AdminPanelWindow();
                adminPanelWindow.Show();
            }

            // Zamknięcie okna logowania
            Close();
        }
    }
}

