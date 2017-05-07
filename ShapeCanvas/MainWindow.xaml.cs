using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            DrawCanvas.Children.Clear();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = System.Windows.Input.Mouse.GetPosition(DrawCanvas);
            Random rand = new Random();
            int randNum = rand.Next(2) + 1;
            int randNumTemp = randNum;

            switch (randNumTemp)
            {
                case 1:
                    r = new Rectangle();
                    r.Width = rand.Next(80) + 10;
                    r.Height = rand.Next(80) + 10;
                    r.Fill = PickRandomBrush();
                    Canvas.SetTop(r, p.Y - (r.Height/2.0));
                    Canvas.SetLeft(r, p.X - (r.Width/2.0));
                    DrawCanvas.Children.Add(r);
                    break;
                case 2:
                    el = new Ellipse();
                    el.Width = rand.Next(80) + 10;
                    el.Height = rand.Next(80) + 10;
                    Canvas.SetTop(el, p.Y - (el.Height / 2.0));
                    Canvas.SetLeft(el, p.X - (el.Width / 2.0));
                    el.Fill = PickRandomBrush();
                    DrawCanvas.Children.Add(el);
                    break;
            }
        }

        private Brush PickRandomBrush()
        {
            Brush result = Brushes.Transparent;
            Random rnd = new Random();
            Type brushesType = typeof(Brushes);
            PropertyInfo[] properties = brushesType.GetProperties();
            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);
            return result;
        }

        private void DrawCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var canvas = sender as Canvas;
            RemoveShape(canvas, e.GetPosition(canvas));
        }

        public static void RemoveShape(Canvas canvas, Point position)
        {
            var element = canvas.InputHitTest(position) as UIElement;
            UIElement parent;

            while (element != null && (parent = VisualTreeHelper.GetParent(element) as UIElement) != canvas)
            {
                element = parent;
            }

            if (element != null)
            {
                canvas.Children.Remove(element);
            }
        }
    }
}
