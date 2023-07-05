﻿using System;

namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double d;
        double eps = 1e-6;
        double[] roots = Array.Empty<double>();
        
        d = b * b - 4 * a * c;

        if (Math.Abs(a) < eps)
        {
            throw new System.ArgumentException();
        }
        if (double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) ||
            double.IsPositiveInfinity(a) || double.IsPositiveInfinity(b) || double.IsPositiveInfinity(c) ||
            double.IsNegativeInfinity(a) || double.IsNegativeInfinity(b) || double.IsNegativeInfinity(c))
        {
            throw new System.ArgumentException();
        }
        if (d > eps)
        {
            double x1 = -(b + Math.Sqrt(d)) / (2 * a);
            double x2 = c / x1;
            roots = new double[2];
            roots[0] = x1; roots[1] = x2;
            return roots;
        }
        else if (Math.Abs(d) < eps)
        {
            double x1 = (-b) / (2 * a);
            roots = new double[1];
            roots[0] = x1;
            return roots;
        }
        else
        {
            return roots;
        }


    }

}