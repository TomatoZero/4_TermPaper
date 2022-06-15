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
    internal class MainWindowViewModel : BaseViewModel
    {
        private int degree;
        private RotateTransform rotateTransform;
        private ClockFace clockFace;
        private Storyboard storyboard;

        #region Icon
        private InformationIcon oil;
        private InformationIcon battery;
        private InformationIcon colingSystem;
        private InformationIcon hoodOpen;
        private InformationIcon trunkOpen;
        private InformationIcon brakeSystemWarning;
        private InformationIcon fogLight;
        private InformationIcon lowBeam;
        private InformationIcon highBeam;
        private InformationIcon myESP;
        private InformationIcon immobilizer;
        private InformationIcon checkEngine;
        private InformationIcon preGlow;
        private InformationIcon openDoors;
        private InformationIcon seatBeltWarning;
        private InformationIcon applyFootBrake;
        private InformationIcon parkingLight;
        private InformationIcon lowTirePressure;

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
        public InformationIcon HoodOpen 
        {
            get => hoodOpen;
            set 
            {
                hoodOpen = value;
                OnPropertyChanged("HoodOpen");
            }
        }
        public InformationIcon TrunkOpen 
        {
            get => trunkOpen;
            set 
            {
                trunkOpen = value;
                OnPropertyChanged("TrunkOpen");
            }
        }
        public InformationIcon BrakeSystemWarning 
        {
            get => brakeSystemWarning;
            set 
            {
                brakeSystemWarning = value;
                OnPropertyChanged("BrakeSystemWarning");
            }
        }
        public InformationIcon FogLight 
        {
            get => fogLight; 
            set
            {
                fogLight = value;
                OnPropertyChanged("FogLight");
            }
        }
        public InformationIcon LowBeam 
        {
            get => lowBeam;
            set
            {
                lowBeam = value;
                OnPropertyChanged("LowBeam");
            }
        }
        public InformationIcon HighBeam 
        {
            get => highBeam;
            set 
            { 
                highBeam = value;
                OnPropertyChanged("HighBeam");
            }
        }
        public InformationIcon ESP 
        {
            get => myESP;
            set 
            {
                myESP = value;
                OnPropertyChanged("ESP");
            }
        }
        public InformationIcon Immobilizer 
        {
            get => immobilizer;
            set 
            {
                immobilizer = value;
                OnPropertyChanged("Immobilizer");
            }
        }
        public InformationIcon CheckEngine 
        {
            get => checkEngine;
            set 
            {
                checkEngine = value;
                OnPropertyChanged("CheckEngine");
            }
        }
        public InformationIcon PreGlow 
        {
            get => preGlow;
            set 
            {
                preGlow = value;
                OnPropertyChanged("PreGlow");
            }
        }
        public InformationIcon OpenDoors 
        {
            get => openDoors;
            set 
            {
                openDoors = value;
                OnPropertyChanged("OpenDoors");
            }
        }
        public InformationIcon SeatBeltWarning 
        {
            get => seatBeltWarning;
            set 
            {
                seatBeltWarning = value;
                OnPropertyChanged("SeatBeltWarning");
            }
        }
        public InformationIcon ApplyFootBrake 
        {
            get => applyFootBrake;
            set 
            {
                applyFootBrake = value;
                OnPropertyChanged("ApplyFootBrake");
            }
        }
        public InformationIcon ParkingLight 
        {
            get => parkingLight;
            set 
            {
                parkingLight = value;
                OnPropertyChanged("ParkingLight");
            }
        }
        public InformationIcon LowTirePressure 
        {
            get => lowTirePressure;
            set 
            {
                lowTirePressure = value;
                OnPropertyChanged("lowTirePressure");
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

            MyOil = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.red);
            Battery = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.red);
            ColingSystem = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.red);
            HoodOpen = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.red);
            TrunkOpen = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.red);
            BrakeSystemWarning = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.red);
            FogLight = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.orange);
            LowBeam = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.green);
            HighBeam = new InformationIcon(TimeSpan.FromSeconds(0.6), new SolidColorBrush(Colors.Gray), IndicatorType.blue);

            ESP = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.orange);
            Immobilizer = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.orange);
            CheckEngine = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.orange);
            PreGlow = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.orange);
            OpenDoors = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.red);
            SeatBeltWarning = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.red);
            ApplyFootBrake = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.green);
            ParkingLight = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.green);
            LowTirePressure = new InformationIcon(TimeSpan.FromSeconds(0.5), new SolidColorBrush(Colors.Gray), IndicatorType.orange);

            icons = new List<InformationIcon>();
            icons.Add(MyOil);
            icons.Add(Battery);
            icons.Add(ColingSystem);
            icons.Add(HoodOpen);
            icons.Add(TrunkOpen);
            icons.Add(BrakeSystemWarning);
            icons.Add(FogLight);
            icons.Add(LowBeam);
            icons.Add(HighBeam);
            icons.Add(ESP);
            icons.Add(Immobilizer);
            icons.Add(CheckEngine);
            icons.Add(PreGlow);
            icons.Add(OpenDoors);
            icons.Add(SeatBeltWarning);
            icons.Add(ApplyFootBrake);
            icons.Add(ParkingLight);
            icons.Add(LowTirePressure);

            ClockFaces = new ClockFace(TimeSpan.FromSeconds(2), "km/h",
                new ForPointer(radiusSmallerBy: -20, angel: -121), 
                new ForMyDial(min: 0, max: 245, radiusSmallerBy: -50, angle: 0, steap: 5, difference: 10), -50);
            mainWindow.PointerDeveceOne.Draw(ClockFaces);

            ClockFace face = new ClockFace(TimeSpan.FromSeconds(1), "rmp",
                new ForPointer(radiusSmallerBy: -20, angel: -121),
                new ForMyDial(min: 0, max: 245, radiusSmallerBy: -50, angle: 0, steap: 5, difference: 10, 20, 100), -50);
            mainWindow.PointerDeveceTwo.Draw(face);

            ClockFace forFuelInficator = new ClockFace(TimeSpan.FromSeconds(1), "Fuel", 
                new ForPointer(-76, 76, -76, 75), 
                new ForMyDial(min: 0, max: 170, radiusSmallerBy: 50, angle: 45, steap: 25, 0.5), radiusSmallerBy: 50,
                new Point(-200, -100), new Point(200, -100));
            mainWindow.FuelIndicator.Draw(forFuelInficator);

            ClockFace forOilePreshure = new ClockFace(TimeSpan.FromSeconds(1), "bar", 
                new ForPointer(-76, 76, -76, 75),
                new ForMyDial(min: 0, max: 170, radiusSmallerBy: 50, angle: 45, steap: 25, difference:1, 20,10), radiusSmallerBy: 50,
                new Point(-200, -100), new Point(200, -100));
            mainWindow.oilPressure.Draw(forOilePreshure);

            ponterDevices = new PonterDevice[4]
            {
                mainWindow.PointerDeveceOne,
                mainWindow.PointerDeveceTwo,
                mainWindow.FuelIndicator,
                mainWindow.oilPressure
            };
            

            DigitallInstrumentModel digitalInstrument = new DigitallInstrumentModel(TimeSpan.FromMilliseconds(2), "", 0, 999);
            mainWindow.totalMileage.Create(digitalInstrument);
            DigitallInstrumentModel secondInstrument = new DigitallInstrumentModel(TimeSpan.FromMilliseconds(2), "", 0, 999);
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
                int min = ponterDevices[i].MyClockFace.Pointer.MinPointAngel;
                int max = ponterDevices[i].MyClockFace.Pointer.MaxPointAngel;

                parametr.Item1 = ponterDevices[i].MyClockFace.Pointer.Angel;
                parametr.Item2 = random1.Next(min, max);

                ponterDevices[i].MyMethod(parametr);
            }

            foreach (InformationIcon icon in icons)
                icon.StopAnimation();

            int n = random1.Next(0, 4);
            List<int> wasBefore = new List<int>();
            for (int i = 0; i < n; i++) 
            {
                int m = random1.Next(0, icons.Count);

                if(wasBefore.Contains(m))
                { i--; continue; }

                icons[m].StartAnimation();
            }

            for(int i = 0; i < digitals.Length; i++) 
            {
                int current = Convert.ToInt32(digitals[i].MyValue.Content);

                parametr.Item1 = current;
                parametr.Item2 = random1.Next(current, digitals[i].digital.Max + 100) / 10;

                digitals[i].MyAnimation(parametr);
            }
        }

    }
}
