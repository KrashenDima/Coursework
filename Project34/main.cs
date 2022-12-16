using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project34
{
    class TestClass
    {
        /*static public double TestFunction(List<double> point)
        {
            return 8 * point[0] * point[0] - 4 * point[0] * point[1] 
                + 5 * point[1] * point[1] + 8 * Math.Sqrt(5) * (point[0] + 2 * point[1]) + 64;
        }*/

        static void Main(string[] args)
        {
            /*var GD = new GradientDescent();
            var minimumPoint = GD.Calculate(new List<double> { 0, 0 }, TestFunction);


            foreach (double val in minimumPoint)
            {
                Console.WriteLine(val);
            }
            foreach(List<double> l in GD.LofP)
            {
                foreach(double value in l)
                {
                    Console.Write(value);
                }
                Console.Write("\n");
            }

            List<double> fi = new List<double> { 30 * (Math.PI / 180), 30 * (Math.PI / 180) };
            List<double> link_len = new List<double> { 1, 2 };
            var Kin = new Kinematics1(fi, link_len).GetPosition();

           foreach(var val in Kin)
            {
                Console.WriteLine(val);
            }*/

            List<double> start_point = new List<double> { 0, 0 };
            List<double> link_len = new List<double> { 1, 2 };
            List<double> limitations = new List<double> {40*(Math.PI / 180), 40* (Math.PI / 180)};
            double[] need_point = new double[] { 1.866025, 2.232050 };

            List<double> fi = new Kinematics2(start_point, link_len, limitations, need_point).Get_fi();

            foreach (var val in fi)
            {
                Console.WriteLine(val);
            }

        }
    }
}
