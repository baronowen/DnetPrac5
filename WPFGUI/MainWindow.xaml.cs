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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            //ShopServiceClient shopProxy = new ShopServiceClient();
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
