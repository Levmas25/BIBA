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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in grid.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
            pwBox.PasswordChanged += PasswordChangedGandler;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pwBox.Password.Length < 4)
                pwBox.Password += (string)((Button)sender).Content;

        }
        private async void PasswordChangedGandler(object sender, RoutedEventArgs args)
        {
            if (pwBox.Password.Length >= 4)
            {
                if (pwBox.Password == "1234")
                {
                    pwBox.Password = "";
                    textBox.Background = new SolidColorBrush(Color.FromRgb(62, 229, 47));
                    textBox.Visibility = Visibility;
                    textBox.Text = "Access!";
                    await Task.Delay(1200);
                    grid.Children.Remove(textBox);
                    grid.Children.Remove(pwBox);
                }
                else
                {
                    pwBox.Password = "";
                    textBox.Background = new SolidColorBrush(Color.FromRgb(229, 86, 47));
                    textBox.Visibility = Visibility;
                    textBox.Text = "Wrong!";
                    await Task.Delay(1200);
                    textBox.Visibility = Visibility.Hidden;
                }
            }
        }
    }
}
