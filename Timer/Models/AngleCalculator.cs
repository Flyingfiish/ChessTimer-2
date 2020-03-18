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

        public static (double, double, double) GetAngles(int hours, int minutes, int seconds)
        {
            return (
                CalculateAngle((double)hours + CalculateAngle(minutes)/360), 
                CalculateAngle((double)minutes + CalculateAngle(seconds) / 360), 
                CalculateAngle(seconds));
        }

    }
}
