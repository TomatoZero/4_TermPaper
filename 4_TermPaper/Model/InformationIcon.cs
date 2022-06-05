using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace _4_TermPaper.Model
{
    internal class InformationIcon : Instrument
    {
        private TimeSpan duration;
        private SolidColorBrush defaultSolidColor;
        private SolidColorBrush currentSolidColor;
        private DispatcherTimer timer;
        private (SolidColorBrush color1, SolidColorBrush color2) myParametr { get; set; }

        public override TimeSpan Duration 
        {
            get => duration;
            set 
            {
                if (value.Minutes > 0)
                    throw new Exception();

                duration = value;
            } 
        }
        public SolidColorBrush DefaultSolidColor 
        { 
            get => defaultSolidColor; 
            set => defaultSolidColor = value; 
        }
        public SolidColorBrush CurrentSolidColor { get => currentSolidColor; private set => currentSolidColor = value; }

        public InformationIcon(TimeSpan duration) : base(duration)
        {
            DefaultSolidColor = new SolidColorBrush(Colors.Blue);
            CurrentSolidColor = DefaultSolidColor.Clone();
        }

        public InformationIcon(TimeSpan duration, SolidColorBrush defaultColor) : base(duration)
        {
            DefaultSolidColor = defaultColor;
            CurrentSolidColor = defaultColor;
        }

        public override void SetParametr(object parameter)
        {    
            if (parameter.GetType() != myParametr.GetType())
            {
                throw new NotImplementedException();
            }

            myParametr = ((SolidColorBrush, SolidColorBrush))parameter;
        }

        public void StartAnimation() 
        {
            if (Duration == null)
                throw new ArgumentNullException();

            timer = new DispatcherTimer();
            timer.Interval = Duration;
            timer.Tick += Animation;
            timer.Start();
        }

        private void Animation(object? sender, EventArgs e)
        {
            if(CurrentSolidColor.Color == myParametr.color1.Color) 
                CurrentSolidColor.Color = myParametr.color2.Color;
            else
                CurrentSolidColor.Color= myParametr.color1.Color;
        }

        public void StopAnimation() 
        {
            if (timer != null)
                if (timer.IsEnabled)
                {
                    CurrentSolidColor.Color = DefaultSolidColor.Color;
                    timer.Stop();
                }
        }
    }
}
