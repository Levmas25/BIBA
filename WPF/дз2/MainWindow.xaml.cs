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
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        DispatcherTimer t = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            t.Interval = new TimeSpan(0, 0, 5);
            t.Tick += Ontime;
            t.Start();
            foreach(UIElement el in some.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
            textBox.TextChanged += Text_Changed;
        }

        private void Ontime(object sender, EventArgs e)
        {
            for(int i = 0; i < some.Children.Count - 1; i++)
            {
                if ((some.Children[i] is Button) & (some.Children[i + 1] is Button))
                {
                    var margin = ((Button)some.Children[i]).Margin;
                    ((Button)some.Children[i]).Margin = ((Button)some.Children[i + 1]).Margin;
                    ((Button)some.Children[i + 1]).Margin = margin;
                    SolidColorBrush background = new SolidColorBrush();
                    background.Color = Color.FromRgb(Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)));
                    ((Button)some.Children[i]).Background = background;
                    SolidColorBrush brush = new SolidColorBrush();
                    brush.Color = Color.FromRgb(Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)), Convert.ToByte(random.Next(0, 255)));
                    zero.Background = brush;
                    nine.Background = brush;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs args)
        {
            if ((string)((Button)sender).Content == "⛌")
            {
                foreach (UIElement el in some.Children)
                {
                    if (el is Button)
                        ((Button)el).Content = "";
                }
            }
            else
            {
                for (int i = 0; i < some.Children.Count - 1; i++)
                {
                    if ((some.Children[i] == (Button)sender) & (some.Children[i + 1] is Button))
                    {
                        var margin = ((Button)some.Children[i]).Margin;
                        ((Button)some.Children[i]).Margin = ((Button)some.Children[i + 1]).Margin;
                        ((Button)some.Children[i + 1]).Margin = margin;
                        if (textBox.Text.Length < 5)
                        {
                            textBox.Text += ((Button)some.Children[i + 1]).Content;
                            textBox.Margin = new Thickness(random.Next(250), random.Next(200), 0, 0);
                        }
                        break;
                    }
                }
            }

        }
        private void Text_Changed(object sender, RoutedEventArgs args)
        {
            if(textBox.Text.Length == 5)
            {
                textBox.Background = new SolidColorBrush(Color.FromRgb(62, 229, 47));
                textBox.Text = "Access";
            }
        }
    }
}
