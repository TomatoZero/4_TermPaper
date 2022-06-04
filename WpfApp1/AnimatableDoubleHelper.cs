using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace WpfApp1
{
    public static class AnimatableDoubleHelper
    {
        // Это attached property OriginalProperty. К нему мы будем привязывать свойство из VM,
        // и получать нотификацию об его изменении
        public static double GetOriginalProperty(DependencyObject obj) => (double)obj.GetValue(OriginalPropertyProperty);
        public static void SetOriginalProperty(DependencyObject obj, double value) => obj.SetValue(OriginalPropertyProperty, value);
        public static readonly DependencyProperty OriginalPropertyProperty = DependencyProperty.RegisterAttached("OriginalProperty", typeof(double), typeof(AnimatableDoubleHelper), new PropertyMetadata(OnOriginalUpdated));

        // это "производное" attached property, которое будет
        // анимированно "догонять" OriginalProperty
        public static double GetAnimatedProperty(DependencyObject obj) => (double)obj.GetValue(AnimatedPropertyProperty);
        public static void SetAnimatedProperty(DependencyObject obj, double value) => obj.SetValue(AnimatedPropertyProperty, value);
        public static readonly DependencyProperty AnimatedPropertyProperty = DependencyProperty.RegisterAttached("AnimatedProperty", typeof(double), typeof(AnimatableDoubleHelper));

        // это вызывается когда значение OriginalProperty меняется
        static void OnOriginalUpdated(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            double newValue = (double)e.NewValue;
            // находим элемент, на котором меняется свойство
            FrameworkElement self = (FrameworkElement)o;
            DoubleAnimation animation = new DoubleAnimation(newValue, new Duration(TimeSpan.FromSeconds(0.3))); // создаём анимацию... 
            // и запускаем её на AnimatedProperty
            self.BeginAnimation(AnimatedPropertyProperty, animation);
        }
    }
}
