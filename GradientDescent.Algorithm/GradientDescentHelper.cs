namespace GradientDescent.Algorithm;

public static class GradientDescentHelper
{
    public static Func<double[], double> GenerateInitialFunc(int argumentsCount)
    {
        return x =>
        {
            double result = 0;
            for (int i = 0; i < argumentsCount; i++)
            {
                result += Math.Pow(x[i], 2);
                for (int j = i + 1; j < argumentsCount; j++)
                {
                    result += x[i] * x[j];
                }
            }

            return result;
        };
    }

    public static double[] GenerateInitialPoint(int argumentsCount, double value)
    {
        double[] initialPoint = new double[argumentsCount];
        for (int i = 0; i < argumentsCount; i++)
        {
            initialPoint[i] = value;
        }

        return initialPoint;
    }
}