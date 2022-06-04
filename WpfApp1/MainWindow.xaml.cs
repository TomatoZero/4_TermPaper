using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using System.Timers;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Num;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            tbMessage.Text = "0";
            //lableAnimation.BeginAnimation()
            //Timer timer = new Timer();
            //timer.Enabled = true;
            //timer.Interval = 1000;

            StringAnimationUsingKeyFrames stringAnimation = new StringAnimationUsingKeyFrames();

            lable.BeginAnimation(UidProperty, new StringAnimationUsingKeyFrames());

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Start();
            timer.Tick += Timer_Tick;
        }



        int i = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "152";
            tbMessage.Text = "153";
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (i > 123)
                timer.Stop();

            lable.Content = $"{i}";
            i++;
        }
    }
}
