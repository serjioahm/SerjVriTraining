using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points3D
{
    class DistanceCalculator
    {
        public static double TwoPoints(Points3d pointOne, Points3d pointTwo)
        {
            double xDistance = Math.Pow(pointTwo.X - pointOne.X, 2);
            double yDistance = Math.Pow(pointTwo.Y - pointOne.Y, 2);
            double zDistance = Math.Pow(pointTwo.Z - pointOne.Z, 2);

            return Math.Sqrt(xDistance + yDistance + zDistance);
        }

    }
}
