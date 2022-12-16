using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project34
{
    //Обратная задача кинематики
    class Kinematics2
    {
        public List<double> start_point = new List<double>();
        public List<double> limitations = new List<double>();
        public List<double> link_lenghts = new List<double>();
        public double[] need_point = new double[2];


        public Kinematics2(List<double> start_point, List<double> link_lenghts,
            List<double> limitations, double[] need_point)
        {
            this.start_point = start_point;
            this.link_lenghts = link_lenghts;
            this.limitations = limitations;
            this.need_point = need_point;
        }


        public double Function_to_Opt(List<double> fi)
        {
            return (((new Kinematics1(fi, link_lenghts).GetPosition())[0] - need_point[0])
                * ((new Kinematics1(fi, link_lenghts).GetPosition())[0] - need_point[0])) + (((new Kinematics1(fi, link_lenghts).GetPosition())[1] - need_point[1])
                * ((new Kinematics1(fi, link_lenghts).GetPosition())[1] - need_point[1]));
        }

        public List<double> Get_fi()
        {
            return new GradientDescent().Calculate(start_point, Function_to_Opt, limitations);
        }

    }
}
