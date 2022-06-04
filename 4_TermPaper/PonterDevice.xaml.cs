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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _4_TermPaper.ViewModel;
using _4_TermPaper.Model;


namespace _4_TermPaper
{
    /// <summary>
    /// Логика взаимодействия для PonterDevice.xaml
    /// </summary>
    public partial class PonterDevice : UserControl
    {
        public PonterDevice()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public ClockFace MyClockFace { get; set; }
        public Point Point { get; set; }


        public void Draw(ClockFace clockFace) 
        {
            MyClockFace = clockFace;

            Point1.Point = MyClockFace.Point1;
            Point2.Point = MyClockFace.Point2;

            Circule1.RadiusX = 145 - MyClockFace.RadiusSmallerBy;
            Circule1.RadiusY = 145 - MyClockFace.RadiusSmallerBy;
            Circule2.RadiusX = 155 - MyClockFace.RadiusSmallerBy;
            Circule2.RadiusY = 155 - MyClockFace.RadiusSmallerBy;

            Arrow.Point = MyClockFace.Arrow;

            MyClockFace.ForDrawing();
        }

        public void MyMethod((int, int) parametr) 
        {
            MyClockFace.ChangeOfIndicators(_ = transform, _ = parametr);
        }
    }
}
