using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_TermPaper
{
    public struct Division
    {
        public double Lenght { get; }
        public double Angle { get; }
        public double MyTranslateTransform { get; }

        public Division(double lenght, double angle)
        {
            Lenght = lenght;
            Angle = angle;
            MyTranslateTransform = -140;
        }

        public Division(double lenght, double angle, double myTranslateTransform)
        {
            Lenght = lenght;
            Angle = angle;
            MyTranslateTransform = myTranslateTransform;
        }
    }

    public struct DivisionLable
    {
        public double Angle { get; }
        public string Str { get; }
        public double MyTranslateTransform { get; }

        public DivisionLable(double angle , string str)
        {
            Angle = angle;
            Str = str;
            MyTranslateTransform = -120;
        }

        public DivisionLable(double angle, string str, double myTranslateTransform)
        {
            Str = str;
            Angle = angle;
            MyTranslateTransform = myTranslateTransform;
        }
    }
}
