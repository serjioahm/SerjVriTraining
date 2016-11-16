using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points3D
{
    class Path
    {
        private List<Points3d> pointList = new List<Points3d>();

        public List<Points3d> PointList
        {
            get { return pointList; }
        }
        public void AddPoints(Points3d point)
        {
            pointList.Add(point);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < pointList.Count; i++)
            {
                result.Append(pointList[i].ToString());
            }
            return result.ToString();
        }

    }
}
