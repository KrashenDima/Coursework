using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project34
{
    class Dinamics
    {
        private const double g = 9.8;

        public double Work_of_weight_forces(List<double> mass, List<double> link_lenghts,
            List<double> new_fi, List<double> old_fi)
        {
            double work = 0;
            for(var i = 0; i< new_fi.Count-1; i++)
                work += mass[i] * g * (link_lenghts[i] / 2) * (new_fi[i] - old_fi[i]);

            //+ работа последнего звена с полезным грузом
            /*work += (mass.Last()+mass[new_fi.Count-1])*g
                *(link_lenghts[new_fi.Count - 1]/2 
                *+ (link_lenghts[new_fi.Count - 1]*mass.Last()*g)/ 2(mass[new_fi.Count - 1]*g+mass.Last()))...*/

            return work;
        }

        public double Work_of_friction_forces(List<double> coefficients, 
            List<double> new_fi, List<double> old_fi)
        {
            double work = 0;
            for (var i = 0; i < new_fi.Count; i++)
                work += coefficients[i] * (new_fi[i] - old_fi[i]);
            return work;
        }
    }
}
