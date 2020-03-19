using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Models
{
    public class AngleCalculator
    {
        public static double CalculateAngle(double value) => value * 6;

        public static (double, double, double) GetAngles(double hours, double minutes, double seconds)
        {
            return (
                CalculateAngle(5 * hours), //+ 5 * CalculateAngle(minutes) / 360),
                CalculateAngle(minutes),
                CalculateAngle(seconds));
        }

    }
}
