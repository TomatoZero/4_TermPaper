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
using _4_TermPaper.Model;

namespace _4_TermPaper.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private int degree;
        private RotateTransform rotateTransform;
        private ClockFace clockFace;
        private Storyboard storyboard;

        #region Icon
        private InformationIcon oil;
        private InformationIcon battery;
        private InformationIcon colingSystem;

        public InformationIcon MyOil
        {
            get => oil;
            set
            {
                oil = value;
                OnPropertyChanged("Oil");
            }
        }
        public InformationIcon Battery
        {
            get => battery;
            set
            {
                battery = value;
                OnPropertyChanged("Battery");
            }
        }
        public InformationIcon ColingSystem 
        {
            get => colingSystem;
            set 
            {
                colingSystem = value;
                OnPropertyChanged("ColingSystem");
            }
        }
        #endregion

        private Brush brush;

        public int Degree 
        { 
            get => degree;
            set 
            {
                degree = value;
                OnPropertyChanged("Degree");
            }
        }
        public ClockFace ClockFaces 
        { 
            get => clockFace;
            set 
            {
                clockFace = value;
                OnPropertyChanged("ClockFace");
            }
        }
        public Brush Brush 
        {
            get => brush;
            set 
            {
                brush = value;
                OnPropertyChanged("Brush");
            }
        }
        public Storyboard MyStoryboard { get => storyboard; set => storyboard = value; }

        public ObservableCollection<Division> Divisions { get; } = new ObservableCollection<Division>();
        public ObservableCollection<DivisionLable> DivisionLables { get; } = new ObservableCollection<DivisionLable>();
        public double Radius { get; }
        public Point Centre { get; }
        public RotateTransform RotateTransform 
        { 
            get => rotateTransform;
            set 
            {
                rotateTransform = value;
                OnPropertyChanged("RotateTransform");
            } 
        }

        

        DispatcherTimer timer;
        public MainWindowViewModel(MainWindow mainWindow)
        {
            MyStoryboard = new Storyboard();

            MyOil = new InformationIcon(TimeSpan.FromSeconds(0.5));
            Battery = new InformationIcon(TimeSpan.FromSeconds(0.5));
            ColingSystem = new InformationIcon(TimeSpan.FromSeconds(0.5));

            icons = new List<InformationIcon>();
            icons.Add(MyOil);
            icons.Add(Battery);
            icons.Add(ColingSystem);


            for (int i = 0; i < 3; i++) 
            {
                var p = (new SolidColorBrush(Colors.Black), new SolidColorBrush(Colors.Red));
                icons[i].SetParametr(_ = p);
            }

            ClockFaces = new ClockFace(TimeSpan.FromSeconds(2),"km/h", min: 0, max: 245, radiusSmallerBy: -60, steap: 5, pointAngel: -121);
            mainWindow.PointerDeveceOne.Draw(ClockFaces);

            ClockFace face = new ClockFace(TimeSpan.FromSeconds(1), "rmp", min: 0, max: 245, radiusSmallerBy: -50, steap: 5, pointAngel: 121);
            mainWindow.PointerDeveceTwo.Draw(face);

            ClockFace forFuelInficator = new ClockFace(TimeSpan.FromSeconds(1), "Fuel", new Point(-200,-100), new Point(200, -100), angle: 45, min: 0, max: 170, radiusSmallerBy: 50, steap: 25, minPointerAngel: -76, maxPointerAngel: 76);
            mainWindow.FuelIndicator.Draw(forFuelInficator);

            ClockFace forOilePreshure = new ClockFace(TimeSpan.FromSeconds(1), "bar", new Point(-200, -100), new Point(200, -100), angle: 45, min: 0, max: 170, radiusSmallerBy: 50, steap: 25, minPointerAngel: -76, maxPointerAngel: 76);
            mainWindow.oilPressure.Draw(forOilePreshure);

            ponterDevices = new PonterDevice[4]
            {
                mainWindow.PointerDeveceOne,
                mainWindow.PointerDeveceTwo,
                mainWindow.FuelIndicator,
                mainWindow.oilPressure
            };
            

            DigitallInstrumentModel digitalInstrument = new DigitallInstrumentModel(TimeSpan.FromMilliseconds(2), "lol", 0, 999);
            mainWindow.totalMileage.Create(digitalInstrument);
            DigitallInstrumentModel secondInstrument = new DigitallInstrumentModel(TimeSpan.FromMilliseconds(2), "lol2", 0, 999);
            mainWindow.dailyMileage.Create(secondInstrument);

            digitals = new DigitalInstrument[2] { mainWindow.totalMileage, mainWindow.dailyMileage };
            #region 

            //public ClockFace(string unit, int min, int max, Point p1, Point p2, double angle, int radiusSmallerBy = 0) : this(unit, min, max, radiusSmallerBy)


            //ClockFace clock = (ClockFace)utensil;
            //Divisions = clock.Divisions;
            //DivisionLables = clock.DivisionLables;

            //rotateTransform.BeginAnimation(RotateTransform.AngleProperty,
            //       new DoubleAnimation
            //       {
            //           From = -120,
            //           To = 120,
            //           Duration = TimeSpan.FromSeconds(2)
            //       });

            //DoubleAnimation doubleAnimation = new DoubleAnimation(-120, 120, TimeSpan.FromSeconds(3));
            //doubleAnimation.Completed += DoubleAnimation_Completed;

            //mainWindow.PointerDeveceTwo.transform.BeginAnimation(RotateTransform.AngleProperty,
            //       doubleAnimation);


            //Centre = new Point(100, 100);
            //for (int i = 0; i < 245; i += 5)
            //{
            //    //if (i > -120 && i < 120)
            //    //    continue;

            //    int myI = (int)(i / 1.5) ;

            //    string str = "";
            //    double lenght;
            //    if (myI % 20 == 0)
            //    {
            //        lenght = 15;
            //        str = (myI).ToString();
            //    }
            //    else if (myI % 10 == 0)
            //    {
            //        lenght = 10;
            //        str = (myI).ToString();
            //    }
            //    else
            //        lenght = 5;
            //    Divisions.Add(new Division(lenght, i - 30));
            //    DivisionLables.Add(new DivisionLable(i - 25, str));
            //}

            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = new TimeSpan(10000);
            //timer.Tick += Timer_Tick;
            //timer.Start();

            //Thread myThread = new Thread(Change);
            //myThread.Start();
            #endregion
        }


        private RelayCommand random;
        public RelayCommand RandomCommand => random ?? new RelayCommand(_ => RandomButton());

        private PonterDevice[] ponterDevices;
        private DigitalInstrument[] digitals;
        private List<InformationIcon> icons;
        public void RandomButton() 
        {
            (int, int) parametr;
            Random random1 = new Random();
            for (int i = 0; i < ponterDevices.Length; i++)
            {
                int min = ponterDevices[i].MyClockFace.minPointerAngel;
                int max = ponterDevices[i].MyClockFace.maxPointerAngel;
                double angle = ponterDevices[i].MyClockFace.Angle;

                parametr.Item1 = ponterDevices[i].MyClockFace.PointerAngle;
                parametr.Item2 = random1.Next(min, max);

                ponterDevices[i].MyMethod(parametr);
            }

            foreach (InformationIcon icon in icons)
                icon.StopAnimation();

            int n = random1.Next(0, 3);
            List<int> wasBefore = new List<int>();
            for(int i = 0; i < n; i++) 
            {
                int m = random1.Next(0, 3);

                if(wasBefore.Contains(m))
                { i--; continue; }

                icons[m].StartAnimation();
            }

            for(int i = 0; i < digitals.Length; i++) 
            {
                int current = Convert.ToInt32(digitals[i].MyValue.Content);

                parametr.Item1 = current;

                //if(random1.Next(0,1) == 0) 
                //    parametr.Item2 = random1.Next(current, digitals[i].digital.Max + 100) / 10;
                //else
                //    parametr.Item2 = random1.Next(current, digitals[i].digital.Max + 100) / 10;

                parametr.Item2 = random1.Next(current, digitals[i].digital.Max + 100) / 10;

                digitals[i].MyAnimation(parametr);
            }
        }

    }
}
