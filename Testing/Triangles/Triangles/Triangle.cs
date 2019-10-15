using System;

namespace Triangles
{
    public class Triangle
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                return false;
            if (a + b <= c || b + c <= a || a + c <= b)
                return false;
            return true;
        }
    }
}
