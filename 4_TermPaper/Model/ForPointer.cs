using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _4_TermPaper.Model
{
    public class ForPointer
    {
        private int minPointAngel;
        private int maxPointAngel;
        private int angel;
        private Point arrow;

        public int MinPointAngel { get => minPointAngel;}
        public int MaxPointAngel { get => maxPointAngel;}
        public Point Arrow { get => arrow;}
        public int Angel { get => angel; set => angel = value; }

        public ForPointer(int min = -120, int max = 120, int angel = 0, int radiusSmallerBy = 0)
        {
            this.minPointAngel = min;
            this.maxPointAngel = max;
            this.angel = angel;
            this.arrow = new Point(150, radiusSmallerBy);
        }
    }
}
