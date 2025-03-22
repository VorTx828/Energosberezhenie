using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Calc2
    {
        double Tg, Tst, N_CO2, N_H20, l, r, e;
        public Calc2(double Tg, double Tst, double N_CO2, double N_H2O, double l, double r, double e)
        {
            this.Tg = Convert.ToDouble(Tg);
            this.Tst = Convert.ToDouble(Tst);
            this.N_CO2 = Convert.ToDouble(N_CO2);
            this.N_H20 = Convert.ToDouble(N_H2O);
            this.l = Convert.ToDouble(l);
            this.r = Convert.ToDouble(r);
            this.e = Convert.ToDouble(e);
        }
    }
}
