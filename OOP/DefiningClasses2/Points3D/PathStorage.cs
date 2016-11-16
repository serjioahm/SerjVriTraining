using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points3D
{
    static class PathStorage
    {
        public static void Save(string filePath, Path path)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < path.PointList.Count; i++)
                {
                    writer.WriteLine(path.PointList[i]);
                }
            }
        }

        public static Path Load(string filePath)
        {
            Path path = new Path();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    int[] coords = reader.ReadLine()
                                         .Split(' ')
                                         .Select(int.Parse)
                                         .ToArray();

                    path.AddPoints(new Points3d(coords[0], coords[1], coords[2]));

                    reader.ReadLine();
                }
            }
            return path;
        }


    }
}
