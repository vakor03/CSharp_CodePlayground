using MathNet.Numerics;

namespace CodePlayground.GradientDescent.Algorithm;

public class GradientDescentParallel
{
    public double[] FindFuncMinima(Func<double[], double> initialFunc, double learningRate, int maxIterations,
        double[] startPointArray, double tolerance)
    {
        Vector funcMinima = new Vector(startPointArray);

        for (int i = 0; i < maxIterations; i++)
        {
            var gradient = CalculateGradientInPoint(initialFunc, funcMinima);
            var difference = learningRate * gradient;
            if (difference.Norm <= tolerance)
            {
                break;
            }

            funcMinima -= difference;
        }

        return funcMinima.GetInternalArray();
    }
    
    private Vector CalculateGradientInPoint(Func<double[], double> initialFunc, Vector point)
    {
        Vector gradient = new Vector(point.Length);

        Parallel.For(0, point.Length, i =>
        {
            gradient[i] =
                Differentiate.FirstPartialDerivative(initialFunc, point.GetInternalArray(), i);
        });
        return gradient;
    }
}