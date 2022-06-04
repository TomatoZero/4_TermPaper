using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace _4_TermPaper.Model
{
    public class ClockFace : MeasuredInstrument
    {
        private TimeSpan duration;
        private string unit;
        private int min;
        private int max;

        private double steap;
        private Point point1;
        private Point point2;
        private int radiusSmallerBy;
        private double angle;
        private Point arrow;

        private int pointerAngle;
        public readonly int minPointerAngel;
        public readonly int maxPointerAngel;

        public override TimeSpan Duration { get => duration; set => duration = value; }
        public override string Unit
        {
            get => unit;
            set => unit = value;
        }
        public override int Min { get => min; set => min = value; }
        public override int Max { get => max; set => max = value; }
        public double Steap { get => steap; set => steap = value; }


        public Point Point1 { get => point1; set => point1 = value; }
        public Point Point2 { get => point2; set => point2 = value; }
        public int RadiusSmallerBy { get => radiusSmallerBy; set => radiusSmallerBy = value; }
        public double Angle { get => angle; set => angle = value; }
        public Point Arrow { get => arrow; set => arrow = value; }

        public ObservableCollection<Division> Divisions { get; } = new ObservableCollection<Division>();
        public ObservableCollection<DivisionLable> DivisionLables { get; } = new ObservableCollection<DivisionLable>();

        public RotateTransform RotateTransform { get; set; } = new RotateTransform();
        public int PointerAngle { get => pointerAngle; set => pointerAngle = value; }

        public (int start, int end) MyParametr;

        public ClockFace(TimeSpan duration, string unit,
            int min = 245, int max = -50, double steap = 5, int pointAngel = 0, int minPointerAngel = -120, int maxPointerAngel = 120)
            : base(duration, unit, min, max)
        {
            Divisions = new ObservableCollection<Division>();
            DivisionLables = new ObservableCollection<DivisionLable>();
            Steap = steap;
            PointerAngle = pointAngel;
            this.minPointerAngel = minPointerAngel;
            this.maxPointerAngel = maxPointerAngel;
        }

        public ClockFace(TimeSpan duration, string unit,
            int min = 245, int max = -50, int radiusSmallerBy = 0, double steap = 5, int pointAngel = 0, int minPointerAngel = -120, int maxPointerAngel = 120)
            : this(duration, unit, min, max, steap, pointAngel, minPointerAngel, maxPointerAngel)
        {
            Point1 = new Point(-150, 80);
            Point2 = new Point(150, 80);
            Arrow = new Point(150, radiusSmallerBy + 10);
            RadiusSmallerBy = radiusSmallerBy;
        }

        public ClockFace(TimeSpan duration, string unit, Point p1, Point p2,
            double angle = 0, int min = 245, int max = -50, int radiusSmallerBy = 0, double steap = 5, int pointAngel = 0, int minPointerAngel = -120, int maxPointerAngel = 120)
            : this(duration, unit, min, max, radiusSmallerBy, steap, pointAngel, minPointerAngel, maxPointerAngel)
        {
            Point1 = p1;
            Point2 = p2;
            Angle = angle;
        }


        public override void SetParametr(object parameter)
        {
            if (parameter.Equals(null)) 
                throw new NullReferenceException();

            if(parameter.GetType() != MyParametr.GetType()) 
                throw new ArgumentException();

            MyParametr = ((int,int)) parameter;

        }

        public override void ChangeOfIndicators(object utensil)
        {
            if (utensil.Equals(null))
                throw new NullReferenceException();

            if (utensil.GetType() != RotateTransform.GetType())
                throw new NullReferenceException();

            RotateTransform = (RotateTransform)utensil;
            RotateTransform.BeginAnimation(RotateTransform.AngleProperty,
                new DoubleAnimation(MyParametr.start, MyParametr.end, Duration));

            PointerAngle = MyParametr.end;

            ForDrawing();
        }

        public override void ChangeOfIndicators(object utensil, object parameter)
        {
            SetParametr(parameter);
            ChangeOfIndicators(utensil);
        }

        public void ForDrawing()
        {
            switch (Unit)
            {
                case "km/h":
                    ToFill(20, 10, 1);
                    break;
                case "Fuel":
                    ToFill(20, 10, 100);
                    break;
                case "rmp":
                    ToFill(20, 100, 2);
                    break;
                case "bar":
                    ToFill(20, 10, 16.66);
                    break;
                default:
                    ToFill(20, 10, 1);
                    break;
            }

        }
        private void ToFill(double i1, double i2, double denominator)
        {
            for (double i = Min; i < Max; i += Steap)
            {
                int myI = (int)(i / 1.5);

                string str = "";
                double lenght;
                if (myI % i1 == 0)
                {
                    lenght = 15;
                    str = Math.Round((myI / denominator), 2).ToString();
                }
                else if (myI % i2 == 0)
                {
                    lenght = 10;
                    str = Math.Round((myI / denominator), 2).ToString();
                }
                else
                    lenght = 5;

                Divisions.Add(new Division(lenght, (i - 30) + Angle, -140 + RadiusSmallerBy));
                DivisionLables.Add(new DivisionLable(i - 25 + Angle, str, -120 + RadiusSmallerBy));
            }
        }

    }
}
