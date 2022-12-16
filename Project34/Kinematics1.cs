using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project34
{
    //Прямая задача кинематики
    class Kinematics1
    {
        private ArrayList List_of_matrix = new ArrayList();
        public List<double> fi = new List<double>();
        public List<double> link_lenghts = new List<double>();
        

        public Kinematics1(List<double> fi, List<double> link_lenghts)
        {
            this.fi = fi;
            this.link_lenghts = link_lenghts;
        }

        //вычисление матриц преобразования
        private void Calculate_Matrix()
        {
            List_of_matrix.Add(new double[,] { { Math.Cos(fi[0]), -Math.Sin(fi[0]), 0},
                                   { Math.Sin(fi[0]), Math.Cos(fi[0]), 0},
                                        { 0, 0, 1 } });
            for (var i = 1; i < fi.Count; i++)
            {
                List_of_matrix.Add(new double[,] { { Math.Cos(fi[i]), -Math.Sin(fi[i]), link_lenghts[i-1]},
                                   { Math.Sin(fi[i]), Math.Cos(fi[i]), 0},
                                        { 0, 0, 1 } });
            }
        }

        public double[] GetPosition()
        {
            Calculate_Matrix();
            double[,] r = new double[3, 3];
            double[,] M1 = (double[,])List_of_matrix[0];

            //Произведение матриц преобразования
            for (var g = 1; g < List_of_matrix.Count; g++) { 
                for(int i = 0; i < 3; i++)
                {
                    for(int j =0; j < 3; j++)
                    {
                        for(int k = 0; k < 3; k++)
                        {
                            r[i, j] += M1[i, k] * ((double[,])List_of_matrix[g])[k, j];
                        }
                    }
                }
                M1 = r;
             }

            double[] position = new double[3];
            //радиус-вектор точки в системе координат последнего звена
            double[] rn = {link_lenghts.Last(), 0, 1};

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    position[i] += r[i, j] * rn[j];
                }
            }

            return position;
        }

    }
}
