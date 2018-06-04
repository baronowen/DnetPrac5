using System.Windows;
using System.Windows.Controls;
using WPFGUI.ShopGuiReference;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private ShopServiceClient ssc = new ShopServiceClient();

        public ProductsPage() {
            InitializeComponent();

            User x = (User)Application.Current.Properties["user"];

            productBox.ItemsSource = ssc.GetAllProducts();
            boughtBox.ItemsSource = ssc.GetBoughtProducts(x.Id);
            moneyLeft.Content = "Money left: €" + x.Balance;
            //TODO add balance
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            //TODO paramaters for user and product need to be filled in
            Product p = (Product)productBox.SelectedItem;
            User u = (User)Application.Current.Properties["user"];
            if (p != null) {
                string result = ssc.BuyProduct(u.Id, p.Id, 1);
                MessageBox.Show(result);
                refresh();
            }
        }

        private void refresh() {
            productBox.ItemsSource = ssc.GetAllProducts();

            User x = (User)Application.Current.Properties["user"];
            boughtBox.ItemsSource = ssc.GetBoughtProducts(x.Id);
            x = ssc.findUser(x.Id);
            Application.Current.Properties["user"] = x;
            moneyLeft.Content = "Money left: €" + x.Balance;
        }
    }
}