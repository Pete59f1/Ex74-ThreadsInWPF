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
using System.Windows.Threading;

namespace ThreadsInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool continueBlend = true;
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
            Thread t = new Thread(Blend1);
            t.Start();
        }

        private void BtnBlend2_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(Blend2);
            t.Start();
        }

        private void BtnClean1_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(Clean1);
            t.Start();
        }

        private void BtnClean2_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(Clean2);
            t.Start();
        }

        private void BtnStop1_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(Stop1);
            t.Start();
        }

        private void BtnStop2_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(Stop2);
            t.Start();
        }


        private void Blend1()
        {
            btnBlend1.Dispatcher.Invoke(() => btnBlend1.IsEnabled = false);
            btnStop1.Dispatcher.Invoke(() => btnStop1.IsEnabled = true);
            int blendTime = 10;
            for (int i = 0; i < blendTime; i++)
            {
                lblStatus1.Dispatcher.Invoke(() => lblStatus1.Content = $"Blending {i}");
                Thread.Sleep(100);
            }
            lblStatus1.Dispatcher.Invoke(() => lblStatus1.Content = "Juice Ready");
            btnBlend1.Dispatcher.Invoke(() => btnBlend1.IsEnabled = true);
            btnClean1.Dispatcher.Invoke(() => btnClean1.IsEnabled = true);
            btnStop1.Dispatcher.Invoke(() => btnStop1.IsEnabled = false);
        }

        private void Blend2()
        {
            btnBlend2.Dispatcher.Invoke(() => btnBlend2.IsEnabled = false);
            btnStop2.Dispatcher.Invoke(() => btnStop2.IsEnabled = true);
            int blendTime = 10;
            for (int i = 0; i < blendTime; i++)
            {
                lblStatus2.Dispatcher.Invoke(() => lblStatus2.Content = $"Blending {i}");
                Thread.Sleep(100);
            }
            lblStatus2.Dispatcher.Invoke(() => lblStatus2.Content = "Juice Ready");
            btnBlend2.Dispatcher.Invoke(() => btnBlend2.IsEnabled = true);
            btnClean2.Dispatcher.Invoke(() => btnClean2.IsEnabled = true);
            btnStop2.Dispatcher.Invoke(() => btnStop2.IsEnabled = false);
        }

        private void Clean1()
        {
            lblStatus1.Dispatcher.Invoke(() => lblStatus1.Content = "Cleaned");
            btnClean1.Dispatcher.Invoke(() => btnClean1.IsEnabled = false);
        }
        private void Clean2()
        {
            lblStatus2.Dispatcher.Invoke(() => lblStatus2.Content = "Cleaned");
            btnClean2.Dispatcher.Invoke(() => btnClean2.IsEnabled = false);
        }
        private void Stop1()
        {
            btnStop1.Dispatcher.Invoke(() => Clean1(), DispatcherPriority.Send);
            btnStop1.Dispatcher.Invoke(() => btnStop1.IsEnabled = false);
        }
        private void Stop2()
        {
            btnStop2.Dispatcher.Invoke(() => Clean1(), DispatcherPriority.Send);
            btnStop2.Dispatcher.Invoke(() => btnStop2.IsEnabled = false);
        }
    }

}
