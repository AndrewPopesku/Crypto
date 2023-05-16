using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crypt
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public ObservableCollection<CryptoCurrency> Currencies { get; } = new ObservableCollection<CryptoCurrency>();

        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Currencies.Clear();
                List<CryptoCurrency> currencies = await ApiService.GetTopCurrencies();
                foreach (CryptoCurrency currency in currencies)
                {
                    Currencies.Add(currency);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var id = button.CommandParameter.ToString();

            ((MainWindow) Application.Current.MainWindow).NavigateToDetailedPage(id);
        }
    }
}
