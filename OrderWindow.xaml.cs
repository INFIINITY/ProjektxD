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

namespace WpfApp1
{
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();

            // Ustawienie elementów ComboBox
            ProductComboBox.Items.Add("Elektronika");
            ProductComboBox.Items.Add("Jedzenie");
            ProductComboBox.Items.Add("Higiena");
            ProductComboBox.SelectedIndex = 0;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdzenie, czy pola zostały uzupełnione
            if (String.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                String.IsNullOrWhiteSpace(PhoneNumberTextBox.Text) ||
                String.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                String.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                MessageBox.Show("Uzupełnij wszystkie pola.");
                return;
            }

            // Zamknięcie okna zamówienia i zwrócenie wartości true
            DialogResult = true;
        }
    }
}
