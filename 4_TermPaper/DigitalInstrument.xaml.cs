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
using _4_TermPaper.Model;

namespace _4_TermPaper
{
    /// <summary>
    /// Логика взаимодействия для DigitalInstrument.xaml
    /// </summary>
    public partial class DigitalInstrument : UserControl
    {
        public DigitallInstrumentModel digital { get; set; }
        public DigitalInstrument()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Create(DigitallInstrumentModel digital) 
        {
            MyValue.Content = "0";
            this.digital = digital;
        }

        public void MyAnimation(object parameter) 
        {
            digital.ChangeOfIndicators(_ = this, parameter);
        }
    }
}
