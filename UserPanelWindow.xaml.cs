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
    public partial class UserPanelWindow : Window
    {
        private string loggedInUser;

        public UserPanelWindow(string login)
        {
            InitializeComponent();
            loggedInUser = login;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Tworzenie okna zamówienia
            OrderWindow orderWindow = new OrderWindow();

            // Wyświetlenie okna zamówienia i oczekiwanie na jego zamknięcie
            bool? result = orderWindow.ShowDialog();

            // Sprawdzenie, czy użytkownik złożył zamówienie
            if (result == true)
            {
                // Pobranie danych zamówienia z okna zamówienia
                string product = orderWindow.ProductComboBox.Text;
                string address = orderWindow.AddressTextBox.Text;
                string phoneNumber = orderWindow.PhoneNumberTextBox.Text;
                string firstName = orderWindow.FirstNameTextBox.Text;
                string lastName = orderWindow.LastNameTextBox.Text;

                // Generowanie losowego kodu przesyłki
                Random random = new Random();
                int shipmentCode = random.Next(10000, 100000);

                // Tworzenie linii z zamówieniem
                string orderLine = $"{product},{address},{phoneNumber},{firstName},{lastName},{shipmentCode},zamówienie złożone,{loggedInUser}";

                // Dodanie linii z zamówieniem do pliku z zamówieniami
                string filePath = "C:\\Users\\patry\\Desktop\\orders.txt";
                File.AppendAllText(filePath, orderLine + Environment.NewLine);

            }
        }

        private List<string> GetOrdersForUser(string filePath, string userLogin)
        {
            List<string> userOrders = new List<string>();

            // Otwarcie pliku z zamówieniami i odczytanie wszystkich linii
            string[] orderLines = File.ReadAllLines(filePath);

            // Przeszukanie linii i dodanie tych, które należą do użytkownika
            foreach (string line in orderLines)
            {
                string[] orderData = line.Split(',');
                string orderUser = orderData[7];

                if (orderUser == userLogin)
                {
                    userOrders.Add(line);
                }
            }

            return userOrders;
        }

        private void StatusButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobranie listy zamówień użytkownika
            string filePath = "C:\\Users\\patry\\Desktop\\orders.txt";
            List<string> userOrders = GetOrdersForUser(filePath, loggedInUser);

            // Utworzenie okna statusu przesyłki i przesłanie listy zamówień
            // StatusWindow statusWindow = new StatusWindow(userOrders);
            // statusWindow.Show();
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
