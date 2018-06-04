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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        ShopServiceClient ssc = new ShopServiceClient();
        public RegisterPage() {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e) {
            PasswordText.Content = ssc.Register(UserText.Text.ToString());
        }
    }
}
