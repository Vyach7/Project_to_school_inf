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
using System.Windows.Shapes;

namespace project_to_school_inf
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            N2 N2 = new N2();
            N2.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            N12 N12 = new N12();
            N12.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            N3 N3 = new N3();
            N3.Show();
            this.Close();
        }

        private void task4_Click(object sender, RoutedEventArgs e)
        {
            N4 N4 = new N4();
            N4.Show();
            this.Close();
        }

        private void task5_Click(object sender, RoutedEventArgs e)
        {
            N5 N5 = new N5();
            N5.Show();
            this.Close();
        }

        private void task6_Click(object sender, RoutedEventArgs e)
        {
            N6 N6 = new N6();
            N6.Show();
            this.Close();
        }

        private void task7_Click(object sender, RoutedEventArgs e)
        {
            N7 N7 = new N7();
            N7.Show();
            this.Close();
        }

        private void task8_Click(object sender, RoutedEventArgs e)
        {
            N8 N8 = new N8();
            N8.Show();
            this.Close();
        }

        private void task9_Click(object sender, RoutedEventArgs e)
        {
            N9 N9 = new N9();
            N9.Show();
            this.Close();
        }

        private void task10_Click(object sender, RoutedEventArgs e)
        {
            N10 N10 = new N10();
            N10.Show();
            this.Close();
        }

        private void task11_Click(object sender, RoutedEventArgs e)
        {
            N11 N11 = new N11();
            N11.Show();
            this.Close();
        }
    }
}
