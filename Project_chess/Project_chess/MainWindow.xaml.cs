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
using Project_chess.ViewModels;

namespace Project_chess
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

        private Point _last_Point;

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var tempPoint = e.GetPosition(this);
                this.Top += tempPoint.Y - _last_Point.Y;
                this.Left += tempPoint.X - _last_Point.X;
            }

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this._last_Point = e.GetPosition(this);
                }        
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
