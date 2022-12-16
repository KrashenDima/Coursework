using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project34
{
    //Скалярное произведение
    class ScalProv
    {
        public double ScProv(List<double> v1, List<double> v2)
        {
            double sum = 0;
            for(var i =0; i < v1.Count; i++)
                sum += v1[i] * v2[i];
            return sum;
        }
    }
}
