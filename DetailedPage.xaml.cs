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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crypt
{
    /// <summary>
    /// Interaction logic for DetailedPage.xaml
    /// </summary>
    public partial class DetailedPage : Page
    {
        public CryptoCurrency SelectedCurrency { get; set; } = new CryptoCurrency();
        public DetailedPage(string id)
        {
            InitializeComponent();
            GetCurrencyAsync(id);
        }

        public async void GetCurrencyAsync(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                SelectedCurrency = await ApiService.GetCurrencyById(id);
            }
            DataContext = SelectedCurrency;
        }


    }
}
