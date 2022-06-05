using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace _4_TermPaper.Model
{
    public abstract class Instrument
    {
        public abstract TimeSpan Duration { get; set; }

        public Instrument(TimeSpan duration)
        {
            Duration = duration;
        }

        public abstract void SetParametr(object parameter);
    }

    public abstract class MeasuredInstrument : Instrument
    {
        public abstract string Unit { get; set; }

        public MeasuredInstrument(TimeSpan duration, string unit)
            : base(duration)
        {
            Unit = unit;
        }
        public abstract void ChangeOfIndicators(object utensil, object parameter);
        public abstract void ChangeOfIndicators(object utensil);
    }
}
