using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ThreadsInWPF
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

        private void BtnPutIn1_Click(object sender, RoutedEventArgs e)
        {
            if (lbFruits.SelectedItem != null)
            {
                var fruit = (lbFruits.SelectedItem as ListBoxItem).Content;
                lbBlender1.Items.Add(new ListBoxItem { Content = fruit });
            }
        }

        private void BtnPutIn2_Click(object sender, RoutedEventArgs e)
        {
            if (lbFruits.SelectedItem != null)
            {
                var fruit = (lbFruits.SelectedItem as ListBoxItem).Content;
                lbBlender2.Items.Add(new ListBoxItem { Content = fruit });
            }
        }

        private void BtnBlend1_Click(object sender, RoutedEventArgs e)
        {
            Blend1();
        }

        private void BtnBlend2_Click(object sender, RoutedEventArgs e)
        {
            Blend2();
        }

        private void Blend1()
        {
            int blendTime = 10;
            for (int i = 0; i < blendTime; i++)
            {
                lblStatus1.Content = $"Blending {i}";
                Thread.Sleep(1000);
            }
            lblStatus1.Content = "Juice Ready";
        }

        private void Blend2()
        {
            int blendTime = 10;
            for (int i = 0; i < blendTime; i++)
            {
                lblStatus2.Content = $"Blending {i}";
                Thread.Sleep(1000);
            }
            lblStatus2.Content = "Juice Ready";
        }

    }

}
