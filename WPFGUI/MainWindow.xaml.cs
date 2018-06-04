using System.Windows;
using WPFGUI.ShopGuiReference;

namespace WPFGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            ShopServiceClient shopProxy = new ShopServiceClient();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MainFrame.Content = new RegisterPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            MainFrame.Content = new LoginPage();
        }
    }
}