using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Calc2 : Main
    {
        double Tg, Tst, N_CO2, N_H20, l, b, e, h;
        public Calc2(double Tg, double Tst, double N_CO2, double N_H2O, double l, double r, double e, double h)
        {
            this.Tg = Convert.ToDouble(Tg);
            this.Tst = Convert.ToDouble(Tst);
            this.N_CO2 = Convert.ToDouble(N_CO2);
            this.N_H20 = Convert.ToDouble(N_H2O);
            this.l = Convert.ToDouble(l);
            this.b = Convert.ToDouble(b);
            this.e = Convert.ToDouble(e);
            this.h = Convert.ToDouble(h);
        }

        public double F()
        {
            return 2 * (h+b) * l;
        }

        public double V()
        {
            return h*b*l;
        }
        public double S()
        {
            return 0.9 * 4 * V() / F();
        }
        public double k_Tr()
        {
            //(0,8+1,6*B5*100000)*(1-0,00038*B2)/((100000*B5+100000*B4)*G8)^0,5
            return (0.8 + 1.6 * N_CO2 * 100000) * (1 - 0.00038 * Tg) / Math.Pow((100000 * N_H20 + 100000 * N_CO2) * S(), 0.5);
        }
        public double e_g()
        {
            //(0,8+1,6*B5*100000)*(1-0,00038*B2)/((100000*B5+100000*B4)*G8)^0,5
            return 1 - Math.Exp(-k_Tr() * (N_CO2 + N_H20) * 100000 * S());
        }
        public double k_Tst()
        {
            return (0.8 + 1.6 * N_H20 * 100000) * (1 - 0.00038 * Tst) / Math.Pow((100000 * N_H20 + 100000 * N_CO2) * S(), 0.5);
        }
        public double ar()
        {
            //=1-EXP(-G11*(100000*B5+100000*B4)*G8)
            return 1 - Math.Exp(-k_Tst() * 100000 * (N_CO2 + N_H20) * S());
        }

        //=5,67*(G10/G12*(B2/100)^4-(B3/100)^4)/(1/G12+1/B8-1)

        public double q()
        {
            return 5.67 * (e_g() / ar() * Math.Pow(Tg / 100, 4) - Math.Pow(Tst / 100, 4)) / (1 / ar() + 1 / e - 1);
        }

        public double Q()
        {
            return q() * F();
        }
    }
}
