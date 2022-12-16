
namespace Project34
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    class GradientDescent
    {
        private const double DoubleComparisonDelta = 0.0000001;
        public List<List<double>> LofP = new List<List<double>>();

        //Копирование точки с заменой значения одной из координат
        private List<double> CopyPointWithReplace(List<double> point, double replace, int replaceIndex)
        {
            var result = new List<double>();
            for (var i = 0; i < point.Count; i++)
                if (i == replaceIndex)
                    result.Add(replace);
                else
                    result.Add(point[i]);

            return result;
        }

        public List<double> Calculate(List<double> startPoint, Func<List<double>, double> function, List<double> limitations)
        {
            double alpha = 1;
            var alphaDecreaseRate = 0.5;
            var currentPoint = startPoint;
            while (true)
            {
                var currentValue = function(currentPoint);
                var newPoint = new List<double>();
                var Grad = new List<double>();

                for (var i = 0; i < currentPoint.Count; i++)
                {
                    Func<double, double> func = x => function(CopyPointWithReplace(currentPoint, x, i));
                    newPoint.Add(currentPoint[i] - alpha * new Derivative().GetDerivative(func, currentPoint[i]));
                } 
                
                var newValue = function(newPoint);
                LofP.Add(newPoint);

               /* for (var i = 0; i < newPoint.Count; i++)
                {
                    Func<double, double> func = x => function(CopyPointWithReplace(newPoint, x, i));
                    Grad.Add(new Derivative().GetDerivative(func, newPoint[i]));
                }*/

               //Условие Армихо
                /*while ((currentValue - newValue) < 0.5 * alpha * (new ScalProv().ScProv(Grad, Grad))) {
                    for (var i = 0; i < newPoint.Count; i++)
                    {   
                        alpha *= 0.5;
                        Func<double, double> func = x => function(CopyPointWithReplace(newPoint, x, i));
                        newPoint.Add(newPoint[i] - alpha * new Derivative().GetDerivative(func, newPoint[i]));
                    }
                    newValue = function(newPoint);
                }*/


                if (newValue > currentValue)
                    alpha *= alphaDecreaseRate;
                else
                if (currentValue - newValue <= DoubleComparisonDelta)
                        return newPoint;
                    else
                        currentPoint = newPoint;
            }
        }
    }
}
