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
using WPFGUI.ShopGuiReference;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        ShopServiceClient ssc = new ShopServiceClient();
        public ProductsPage()
        {
            InitializeComponent();

            User x = (User)Application.Current.Properties["user"];

            productBox.ItemsSource = ssc.GetAllProducts();
            boughtBox.ItemsSource = ssc.GetBoughtProducts();
            moneyLeft.Content = "Money left: €" + x.Balance;
            //TODO add balance
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ssc.GetAllProducts();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //TODO paramaters for user and product need to be filled in
            Product p = (Product)productBox.SelectedItem;
            User u = (User)Application.Current.Properties["user"];

            MessageBoxResult result = MessageBox.Show(ssc.BuyProduct(u, p, 1));
        }
    }
}
