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
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = NickTextBox.Text;
            string password = PasswordBox.Password;

            // Sprawdzenie, czy użytkownik o podanym loginie już istnieje w pliku tekstowym
            string filePath = "C:\\Users\\patry\\Desktop\\users.txt";
            bool userExists = File.ReadLines(filePath).Any(line => line.Split(',')[0] == login);
            if (userExists)
            {
                MessageBox.Show("Użytkownik o podanym loginie już istnieje!");
                return;
            }

            // Zapisanie danych do pliku tekstowego
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{login},{password},użytkownik");
            }

            MessageBox.Show("Zarejestrowano użytkownika!");

            // Zamknięcie okna rejestracji
            Close();
        }
    }
}
