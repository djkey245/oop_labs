using System;

namespace LAB12;

public class MathHelper
{
    // Формула: S = (∛(2 + cos(x)^2)) / 84 + (5.87 * x) / (∜(3 + cos(y)^2)) + (∛(2 + cos(xy)^2)) / 9;
    public static double CalculateFormulaNoFuncs(double x, double y)
    {
        return Math.Pow(2 + Math.Pow(Math.Cos(x), 2), 1.0 / 3) / 84
            + (5.87 * x) / Math.Pow(3 + Math.Pow(Math.Cos(y), 2), 1.0 / 4)
            + Math.Pow(2 + Math.Pow(Math.Cos(x * y), 2), 1.0 / 3) / 9;
    }

    public static double CalculateFormulaWithFuncs(double x, double y)
    {
        return CubeRoot(2 + Cos2(x)) / 84
            + (5.87 * x) / FourthRoot(3 + Cos2(y))
            + CubeRoot(2 + Cos2(x * y)) / 9;
    }

    private static double Cos2(double val)
    {
        return Math.Pow(Math.Cos(val), 2);
    }

    private static double CubeRoot(double val)
    {
        return Math.Pow(val, 1.0 / 3);
    }

    private static double FourthRoot(double val)
    {
        return Math.Pow(val, 1.0 / 4);
    }
} 