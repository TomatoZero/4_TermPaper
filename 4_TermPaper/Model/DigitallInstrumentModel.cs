using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace _4_TermPaper.Model
{
    public class DigitallInstrumentModel : MeasuredInstrument
    {
        private string unit;
        private int min;
        private int max;
        private TimeSpan duration;
        private (int from, int to) myParametr;
        private DispatcherTimer timer;
        private DigitalInstrument digital;

        public override string Unit { get => unit; set => unit = value; }
        public override int Min { get => min; set => min = value; }
        public override int Max { get => max; set => max = value; }
        public override TimeSpan Duration { get => duration; set => duration = value; }

        public DigitallInstrumentModel(TimeSpan duration, string unit, int min, int max) : base(duration, unit, min, max)
        {
            digital = new DigitalInstrument();
        }

        public override void ChangeOfIndicators(object utensil, object parameter)
        {
            SetParametr(parameter);
            ChangeOfIndicators(utensil);
        }

        public override void ChangeOfIndicators(object utensil)
        {
            if (utensil.Equals(null))
                throw new ArgumentNullException();

            if (utensil.GetType() != digital.GetType())
                throw new Exception();


            digital = (DigitalInstrument)utensil;

            myI = myParametr.from;
            timer = new DispatcherTimer();
            timer.Interval = Duration;
            timer.Start();

            if(myParametr.from < myParametr.to)
                timer.Tick += MyAnimationUp;
            else
                timer.Tick += MyAnimationDown;
        }

        private void MyAnimationDown(object? sender, EventArgs e)
        {
            if (myI <= Min)
                timer.Stop();

            digital.MyValue.Content = myI.ToString();
            myI--;
        }

        int myI;
        private void MyAnimationUp(object? sender, EventArgs e)
        {
            if (myI > Max)
            {
                myI = myI - Max;
                myParametr.to = myParametr.to - Max;
            }

            if (myI >= myParametr.to - 1)
                timer.Stop();

            digital.MyValue.Content = myI.ToString();
            myI++;
                
        }

        public override void SetParametr(object parameter)
        {
            if (parameter.Equals(null))
                throw new ArgumentNullException();

            if (parameter.GetType() != myParametr.GetType())
                throw new Exception();

            myParametr = ((int, int))parameter;
        }
    }
}
