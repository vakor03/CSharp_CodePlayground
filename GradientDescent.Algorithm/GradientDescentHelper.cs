namespace GradientDescent.Algorithm;

public static class GradientDescentHelper
{
    public static GradientDescentInput GenerateGradientDescentInput(int trainingDataCount, int maxIterations)
    {
        maxIterations = 100;
        double[] modelParameters = new double[1];
        double[][] trainingData = new double[trainingDataCount][];
        double[] targets = new double[trainingDataCount];
        double learningRate = 0.1;
        double Func(double x) => x * 2;
        for (int i = 0; i < trainingDataCount; i++)
        {
            trainingData[i] = new double[1];
            trainingData[i][0] = Random.Shared.NextDouble() * 1000;
            targets[i] = Func(trainingData[i][0]);
        }

        return new GradientDescentInput(modelParameters, trainingData, targets, learningRate, maxIterations);
    }

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