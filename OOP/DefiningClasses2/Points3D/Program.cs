using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points3D
{
    class Program
    {
        static void Main(string[] args)
        {
            Path path = new Path();
            path.AddPoints(new Points3d(1, 2, 3));
            path.AddPoints(new Points3d(4, 5, 6));
            path.AddPoints(new Points3d(7, 8, 9));
            PathStorage.Save("../../Paths.txt", path);

            Path loadedPath = PathStorage.Load("../../Paths.txt");

        }
    }
}
