using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        ShopServiceClient ssc = new ShopServiceClient();

        public LoginPage() {
            InitializeComponent();

        }

        private void Login_Click(object sender, RoutedEventArgs e) {
            //if (ssc.Login(UserText.ToString(), PasswordText.ToString()))
            //{
            //    this.NavigationService.Navigate(new ProductsPage());
            //}
            //else
            //{
            //    MessageBoxResult result = MessageBox.Show("Username of password is wrong!" +
            //        "pl try again.");
            //}

            int id = ssc.Login(UserText.Text.ToString(), PasswordText.Text.ToString());
            if (id > 0) {

                Application.Current.Properties["user"] = ssc.findUser(id);
                this.NavigationService.Navigate(new ProductsPage());
            }
            else {
                MessageBox.Show("Username and password combination is wrong", "Alert");
            }
        }
    }
}
