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

        private Point point1;
        private Point point2;
        private int radiusSmallerBy;

        private ForPointer pointer;
        private ForMyDial myDial;


        public ForPointer Pointer { get => pointer; set => pointer = value; }
        public ForMyDial MyDial { get => myDial; set => myDial = value; }


        public override TimeSpan Duration { get => duration; set => duration = value; }
        public override string Unit
        {
            get => unit;
            set => unit = value;
        }

        public Point Point1 { get => point1; set => point1 = value; }
        public Point Point2 { get => point2; set => point2 = value; }

        public int RadiusSmallerBy { get => radiusSmallerBy; set => radiusSmallerBy = value; }

        

        public ObservableCollection<Division> Divisions { get; set; }
        public ObservableCollection<DivisionLable> DivisionLables { get; set; }

        public RotateTransform RotateTransform { get; set; } = new RotateTransform();

        public (int start, int end) MyParametr;

        public ClockFace(TimeSpan duration, string unit, ForPointer pointer, ForMyDial myDial, int radiusSmallerBy = 0)
            : base(duration, unit)
        {
            Divisions = new ObservableCollection<Division>();
            DivisionLables = new ObservableCollection<DivisionLable>();

            Point1 = new Point(-150, 80);
            Point2 = new Point(150, 80);

            Pointer = pointer;
            MyDial = myDial;

            RadiusSmallerBy = radiusSmallerBy;
        }

        public ClockFace(TimeSpan duration, string unit, ForPointer pointer, ForMyDial myDial, int radiusSmallerBy,  Point p1, Point p2)
            : this(duration, unit, pointer, myDial, radiusSmallerBy)
        {
            Point1 = p1;
            Point2 = p2;
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

            Pointer.Angel = MyParametr.end;
        }

        public override void ChangeOfIndicators(object utensil, object parameter)
        {
            SetParametr(parameter);
            ChangeOfIndicators(utensil);
        }

        //public void ForDrawing()
        //{
        //    var result = myDial.ForDrawing();
        //    Divisions = result.Item1;
        //    DivisionLables = result.Item2;
        //}
    }
}
