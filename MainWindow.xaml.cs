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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
        }

        public void NavigateToMainPage()
        {
            NavBar.SelectedIndex = 0;
            MainFrame.Navigate(new MainPage());
        }

        public void NavigateToDetailedPage(string id)
        {
            NavBar.SelectedIndex = 1;
            MainFrame.Navigate(new DetailedPage(id));
        }

        public void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the added items (selected tab items)
            var addedItems = e.AddedItems;

            // Check if any items were added
            if (addedItems.Count > 0)
            {
                // Get the first added item (selected tab item)
                TabItem selectedTab = (TabItem) addedItems[0];

                // Determine which tab was selected
                if (selectedTab.Header.ToString() == "Main Page")
                {
                    NavigateToMainPage();
                }
                else if (selectedTab.Header.ToString() == "Detailed Page")
                {
                    NavigateToDetailedPage(null);
                }
                // Add more conditions for additional tabs as needed
            }
        }
    }
}
