using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockFace
{
    public class Division
    {
        public double Lenght { get; }
        public double Angle { get; }

        public Division(double lenght, double angle)
        {
            Lenght = lenght;
            Angle = angle;
        }
    }
}
