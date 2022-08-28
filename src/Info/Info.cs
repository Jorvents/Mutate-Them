using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Info
{
    public class Info
    {
        public float Angle(Vector2 first, Vector2 second)
        {
            double angleD;
            angleD = Math.Atan(first.Y - second.Y / first.X - second.X);
            if (first.X - second.X < 0)
            {
                angleD += Math.PI;
            }
            angleD = (180 / Math.PI) * angleD;
            return (float)angleD;
        }
    }
}
