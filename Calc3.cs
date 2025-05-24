using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Calc3 : Main
    {
        double Tg, Tst, N_CO2, N_H20, l, e, h, r;
        public Calc3(double Tg, double Tst, double N_CO2, double N_H2O, double l, double e, double h, double r)
        {
            this.Tg = Convert.ToDouble(Tg);
            this.Tst = Convert.ToDouble(Tst);
            this.N_CO2 = Convert.ToDouble(N_CO2);
            this.N_H20 = Convert.ToDouble(N_H2O);
            this.l = Convert.ToDouble(l);
            this.e = Convert.ToDouble(e);
            this.h = Convert.ToDouble(h);
            this.r = Convert.ToDouble(r);
        }

        public double F()
        {
            return (Math.PI*r + h*2 + r*2)*l;
        }

        public double V()
        {
            return (Math.PI*r*r/2 + r*2*h)*l;
        }
        public double S()
        {
            return 0.9 * 4 * V() / F();
        }
        public double k_Tr()
        {
            //(0,8+1,6*B5*)*(1-0,00038*B2)/((*B5+*B4)*G8)^0,5
            return (0.8 + 1.6 * N_CO2/100) * (1 - 0.00038 * Tg) / Math.Pow((N_H20 +  N_CO2)/100 * S(), 0.5);
        }
        public double k_Tr(double T)
        {
            //(0,8+1,6*B5*)*(1-0,00038*B2)/((*B5+*B4)*G8)^0,5
            return (0.8 + 1.6 * N_CO2/100) * (1 - 0.00038 * T) / Math.Pow((N_H20 + N_CO2)/100 * S(), 0.5);
        }
        public double e_g()
        {
            //(0,8+1,6*B5*)*(1-0,00038*B2)/((*B5+*B4)*G8)^0,5
            return 1 - Math.Exp(-k_Tr() * (N_CO2 + N_H20)/100 *  S());
        }
        public double e_g(double T)
        {
            //(0,8+1,6*B5*)*(1-0,00038*B2)/((*B5+*B4)*G8)^0,5
            return 1 - Math.Exp(-k_Tr(T) * (N_CO2 + N_H20)/100 * S());
        }
        public double k_Tst()
        {
            return (0.8 + 1.6 * N_H20/100) * (1 - 0.00038 * Tst) / Math.Pow(( N_H20 +  N_CO2)/100 * S(), 0.5);
        }
        public double ar()
        {
            //=1-EXP(-G11*(*B5+*B4)*G8)
            return 1 - Math.Exp(-k_Tst() * (N_CO2 + N_H20)/100 * S());
        }

        //=5,67*(G10/G12*(B2/100)^4-(B3/100)^4)/(1/G12+1/B8-1)

        public double q()
        {
            return 5.67 * (e_g() / ar() * Math.Pow(Tg / 100, 4) - Math.Pow(Tst / 100, 4)) / (1 / ar() + 1 / e - 1);
        }
        public double q(double T)
        {
            return 5.67 * (e_g(T) / ar() * Math.Pow(T / 100, 4) - Math.Pow(Tst / 100, 4)) / (1 / ar() + 1 / e - 1);
        }

        public double Q()
        {
            return q() * F();
        }
        public double Q(double T)
        {
            return q(T) * F();
        }
        public List<ChartData> Result(double step = 4)
        {
            var res = new List<ChartData>();

            var cur = this.Tg - 100 * step;

            while (cur < this.Tg + 100 * step)
            {
                var a = new ChartData(cur, k_Tr(cur), e_g(cur), Q(cur));



                res.Add(a);

                cur += 100;
            }


            return res;
        }
    }
}
