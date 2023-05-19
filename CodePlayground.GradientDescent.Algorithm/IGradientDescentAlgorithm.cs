namespace CodePlayground.GradientDescent.Algorithm;

public interface IGradientDescentAlgorithm
{
    double[] FindFuncMinima(Func<double[], double> initialFunc, double[] startPointArray, double learningRate,
        int maxIterations, double tolerance);
}