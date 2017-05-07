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

namespace ShapeCanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle r;
        Ellipse el;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            r = null;
            el = null;
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = System.Windows.Input.Mouse.GetPosition(DrawCanvas);
            Random rand = new Random();
            int randNum = rand.Next(2) + 1;
            int randNumTemp = 1;

            switch (randNumTemp)
            {
                case 1:
                    r = new Rectangle();
                    r.Width = rand.Next(200) + 10;
                    r.Height = rand.Next(200) + 10;
                    r.Fill = Brushes.Black;
                    Canvas.SetTop(r, 0);
                    Canvas.SetLeft(r, 0);
                    DrawCanvas.Children.Add(r);
                    break;
                case 2:
                    el = new Ellipse();
                    el.Width = rand.Next(60) + 10;
                    el.Height = rand.Next(60) + 10;
                    DrawCanvas.Children.Add(el);
                    break;
            }
        }
    }
}
