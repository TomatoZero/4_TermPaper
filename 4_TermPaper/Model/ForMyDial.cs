using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_TermPaper.Model
{
    public class ForMyDial
    {
        private int min;
        private int max;
        private int radiusSmallerBy;
        private int angle;

        private int steap;

        private double difference;
        private double printMultiplesNumber1;
        private double printMultiplesNumber2;

        public ObservableCollection<Division> Divisions { get; } = new ObservableCollection<Division>();
        public ObservableCollection<DivisionLable> DivisionLables { get; } = new ObservableCollection<DivisionLable>();

        public ForMyDial(int min, int max, int radiusSmallerBy = 0, int angle = 0, int steap = 5, double difference = 10, double printMultiplesNumber1 = 20, double printMultiplesNumber2 = 10)
        {
            this.min = min;
            this.max = max;
            this.radiusSmallerBy = radiusSmallerBy;
            this.angle = angle;
            this.steap = steap;
            this.difference = difference;
            this.printMultiplesNumber1 = printMultiplesNumber1;
            this.printMultiplesNumber2 = printMultiplesNumber2;

            ForDrawing();
        }


        public void ForDrawing() 
        {
            double mySteap = 0;
            for (double i = min; i < max; i += steap)
            {
                int myI = (int)(i / 1.5);

                string str = "";
                double lenght;
                if (myI % printMultiplesNumber1 == 0)
                {
                    lenght = 15;
                    str = mySteap.ToString();
                    mySteap += difference;
                }
                else if (myI % printMultiplesNumber2 == 0)
                {
                    lenght = 10;
                    str = mySteap.ToString();
                    mySteap += difference;
                }
                else
                    lenght = 5;


                Divisions.Add(new Division(lenght, (i - 30) + angle, -140 + radiusSmallerBy));
                DivisionLables.Add(new DivisionLable(i - 25 + angle, str, -120 + radiusSmallerBy));
            }

        }

    }
}
