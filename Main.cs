using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public interface Main
    {
        double F();
        double V();
        double S();
        double k_Tr();
        double e_g();
        double k_Tst();

        double ar();

        double q();

        double Q();

        List<ChartData> Result(double step);

    }
}
