using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ClockFace.ViewModel
{
    class MaineWindowViewModel : BaseViewModel
    {
        private int degree;
        public int Degree 
        { 
            get => degree;
            set 
            {
                degree = value;
                OnPropertyChanged("Degree");
            }
        }

        public ObservableCollection<Division> Divisions { get; } = new ObservableCollection<Division>();
        public double Radius { get; }
        public Point Centre { get; }

        public MaineWindowViewModel(MainWindow mainWindow)
        {
            Degree = -120;
            mainWindow.transform.BeginAnimation(RotateTransform.AngleProperty,
                   new DoubleAnimation
                   {
                       From = -120,
                       To = 120,
                       Duration = TimeSpan.FromSeconds(2)
                   });

            Radius = 100;
            Centre = new Point(100, 100);
            for (int i = 0; i < 360; i += 6)
            {
                double lenght;
                if (i % 90 == 0)
                    lenght = 15;
                else if (i % 30 == 0)
                    lenght = 10;
                else
                    lenght = 5;
                Divisions.Add(new Division(lenght, i));
            }

            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = new TimeSpan(10000);
            //timer.Tick += Timer_Tick;
            //timer.Start();

            //Thread myThread = new Thread(Change);
            //myThread.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if(Degree == 120)
                Degree = -120;

            Degree += 6;
        }

        public void Change() 
        {
            for(int i = -1200; i < 1200; i++) 
            {
                Degree = i / 10;
            }
        }
    }
}
