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
        public (SolidColorBrush color1, SolidColorBrush color2) MyParametr { get; set; }

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
        public DispatcherTimer Timer { get => timer; set => timer = value; }
        public SolidColorBrush CurrentSolidColor { get => currentSolidColor; set => currentSolidColor = value; }

        public InformationIcon(TimeSpan duration) : base(duration)
        {
            DefaultSolidColor = new SolidColorBrush(Colors.Blue);
            CurrentSolidColor = DefaultSolidColor.Clone();
        }

        public override void SetParametr(object parameter)
        {    
            if (parameter.GetType() != MyParametr.GetType())
            {
                throw new NotImplementedException();
            }

            MyParametr = ((SolidColorBrush, SolidColorBrush))parameter;
        }

        public void StartAnimation() 
        {
            if (Duration == null)
                throw new ArgumentNullException();

            Timer = new DispatcherTimer();
            Timer.Interval = Duration;
            Timer.Tick += Animation;
            timer.Start();
        }

        private void Animation(object? sender, EventArgs e)
        {
            if(CurrentSolidColor.Color == MyParametr.color1.Color) 
                CurrentSolidColor.Color = MyParametr.color2.Color;
            else
                CurrentSolidColor.Color= MyParametr.color1.Color;
        }

        public void StopAnimation() 
        {
            if (Timer != null)
                if (Timer.IsEnabled)
                {
                    CurrentSolidColor.Color = DefaultSolidColor.Color;
                    Timer.Stop();
                }
        }
    }
}
