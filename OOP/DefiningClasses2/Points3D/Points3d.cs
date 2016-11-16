using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points3D
{
    public struct Points3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //Problem2
        private static readonly Points3d centerPoint;

        public Points3d(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        //initializing the readonly field in this constructor
        static Points3d()
        {
            centerPoint = new Points3d(0, 0, 0);
        }

        //Add a static property to return the point O.
        public static Points3d CenterPoint
        {
            get { return centerPoint; }
        }

        //Implement the  ToString()  to enable printing a 3D point.
        public override string ToString()
        {
            StringBuilder printer = new StringBuilder();

            printer.Append(this.X + " " + this.Y + " " + this.Z);

            return printer.ToString();
        }

    }
}
