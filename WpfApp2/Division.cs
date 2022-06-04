using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Division
    {
        public double Lenght { get; }
        public double Angle { get; }
        public string Str { get; }

        public Division(double lenght, double angle)
        {
            Lenght = lenght;
            Angle = angle;
        }

        public Division(double lenght, double angle, string str)
        {
            Lenght = lenght;
            Angle = angle;
            Str = str;
        }
    }
}
