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
        public DispatcherTimer Timer { get => timer; set => timer = value; }

        public InformationIcon(TimeSpan duration, IndicatorType type = IndicatorType.nan) : base(duration)
        {
            DefaultSolidColor = new SolidColorBrush(Colors.Blue);
            CurrentSolidColor = DefaultSolidColor.Clone();
            SetColor(type);
        }

        public InformationIcon(TimeSpan duration, SolidColorBrush defaultColor, IndicatorType type = IndicatorType.nan) : base(duration)
        {
            DefaultSolidColor = defaultColor;
            CurrentSolidColor = defaultColor.Clone();
            SetColor(type);
        }

        private void SetColor(IndicatorType type)
        {
            switch (type)
            {
                case IndicatorType.green:
                    myParametr = (new SolidColorBrush(Colors.Black), new SolidColorBrush(Colors.Black));
                    break;
                case IndicatorType.blue:
                    myParametr = (new SolidColorBrush(Colors.Blue), new SolidColorBrush(Colors.Black));
                    break;
                case IndicatorType.orange:
                    myParametr = (new SolidColorBrush(Colors.Orange), new SolidColorBrush(Colors.Black));
                    break;
                case IndicatorType.red:
                    myParametr = (new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Black));
                    break;
                case IndicatorType.nan:
                    break;
            }
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

            Timer = new DispatcherTimer();
            Timer.Interval = Duration;
            Timer.Tick += Animation;
            Timer.Start();
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
            if (Timer != null)
                if (Timer.IsEnabled)
                {
                    CurrentSolidColor.Color = DefaultSolidColor.Color;
                    Timer.Stop();
                }
        }

        public void Glow() 
        {
            currentSolidColor.Color = myParametr.color1.Color;
        }
    }

    enum IndicatorType 
    {
        green, blue, orange, red, nan
    }

}
