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

namespace goApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Currentplayer { get; set; } = X;
        public const string X = "X";
        public const string O = "O";
        private void setLable_click(object sender, RoutedEventArgs e)
        {
            var space = (Button)sender;
            if (space != null)
            {
                if (Currentplayer == X)
                {
                    Ellipse blackCircule = new Ellipse();
                    blackCircule.Fill = Brushes.Black;
                    blackCircule.Width = space.ActualWidth / 2;
                    blackCircule.Height = space.ActualHeight / 2;
                    blackCircule.Margin = new Thickness(0, 0, 0, 0);
                    space.Content = blackCircule;
                    Currentplayer = O;
                }

                else
                {
                    Ellipse whiteCircle = new Ellipse();
                    whiteCircle.Fill = Brushes.Silver;
                    whiteCircle.Width = space.ActualWidth / 2;
                    whiteCircle.Height = space.ActualHeight / 2;
                    whiteCircle.Margin = new Thickness(0, 0, 0, 0);
                    space.Content = whiteCircle;
                    Currentplayer = X;

                }
            }
        }
    }
}
