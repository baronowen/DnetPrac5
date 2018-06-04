using System.Windows;
using System.Windows.Controls;
using WPFGUI.ShopGuiReference;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private ShopServiceClient ssc = new ShopServiceClient();

        public RegisterPage() {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e) {
            PasswordText.Content = ssc.Register(UserText.Text.ToString());
        }
    }
}