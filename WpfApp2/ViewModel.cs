using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public class ViewModel
    {
        public ObservableCollection<Division> Divisions { get; }
            = new ObservableCollection<Division>();

        public double Radius { get; }
        public Point Centre { get; }

        public ViewModel()
        {
            Radius = 100;
            Centre = new Point(100, 100);
            for (int i = 0; i < 270; i += 10)
            {
                //if (i > -120 && i < 120)
                //    continue;

                int myI = i / 2;

                string str = "";
                double lenght;
                if (myI % 20 == 0)
                {
                    lenght = 15;
                    str = (myI).ToString();
                }
                else if (myI % 10 == 0)
                {
                    lenght = 10;
                    str = (myI).ToString();
                }
                else
                    lenght = 0;
                Divisions.Add(new Division(lenght, i - 30, str));
            }
        }
    }
}
