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

namespace SamsN6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListZnach.Items.Clear();
                double b = Convert.ToDouble(B.Text);
                double a = Convert.ToDouble(A.Text);
                double c = Convert.ToDouble(C.Text);
                double Last = Convert.ToDouble(LastY.Text);
                double x0 = Convert.ToDouble(DiapStart.Text);
                double h = Convert.ToDouble(DiapShag.Text);
                //  2.y = a * x ^ 2 + b * x + c
                //  y = 2 cos(x)
                if (Last < x0 & h > 0)
                {
                    h *= -1;
                    MessageBox.Show($"Не правильно введен конечный Х или шаг, для изьежания бесконечного цикла шаг был изменён на{h}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (WhatFunk)
                {
                    double y = 0;
                    while (Math.Abs(Last) != x0)
                    {
                        double x = Math.Pow(x0, 2);
                        y = a * x + b * x0 + c;
                        ListZnach.Items.Add("F: " + y + " x: " + x0);
                        x0 += h;
                    }
                }
                if (!WhatFunk)
                {
                    double y = 0;
                    while (Math.Abs(Last) != x0)
                    {
                        y = 2 * Math.Cos(x0);
                        ListZnach.Items.Add("F: " + y + " x: " + x0);
                        x0 += h;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не правильный ввод","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            
            
        }
        private bool WhatFunk = false;
        private void Check(object sender, RoutedEventArgs e)
        {
            if(Checkerf1.IsChecked == true)
            {
                WhatFunk = true;
                Checkerf2.IsChecked = false;
            }
            if (Checkerf2.IsChecked == true)
            {
                WhatFunk = false;
                Checkerf1.IsChecked = false;
            }
        }
    }
}
