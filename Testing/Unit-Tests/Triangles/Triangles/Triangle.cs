using System;

namespace Triangles
{
    public class Triangle
    {
        public static bool IsTriangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                return false;
            if (sideA + sideB <= sideC || sideB + sideC <= sideA || sideA + sideC <= sideB)
                return false;
            return true;
        }
        public static bool IsIsoscelesTriangle(double sideA, double sideB, double sideC)
        {
            return IsTriangle(sideA, sideB, sideC) && (sideA == sideB || sideB == sideC || sideA == sideC);
        }
        public static bool IsRightTriangle(double sideA, double sideB, double sideC)
        {
            return IsTriangle(sideA, sideB, sideC) &&
                ((Math.Pow(sideA, 2) + Math.Pow(sideB, 2)) == Math.Pow(sideC, 2) ||
                (Math.Pow(sideA, 2) + Math.Pow(sideC, 2)) == Math.Pow(sideB, 2) ||
                (Math.Pow(sideB, 2) + Math.Pow(sideC, 2)) == Math.Pow(sideA, 2));
        }
    }
}
