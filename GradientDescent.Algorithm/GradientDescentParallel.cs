namespace GradientDescent.Algorithm;

public class GradientDescentParallel
{
    public double[] PerformParallelGradientDescent(double[] modelParameters, double[][] trainingData, double[] targets, double learningRate, int maxIterations)
    {
        int numFeatures = modelParameters.Length;
        int numExamples = trainingData.Length;

        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
            Parallel.For((long)0, numExamples, i =>
            {
                double[] features = trainingData[i];
                double prediction = ComputePrediction(modelParameters, features);
                double error = prediction - targets[i];

                for (int j = 0; j < numFeatures; j++)
                {
                    Interlocked.Add(ref modelParameters[j]), -learningRate * error * features[j]);
                }
            });
        }

        return modelParameters;
    }

    private double ComputePrediction(double[] modelParameters, double[] features)
    {
        double prediction = 0.0;
        for (int i = 0; i < modelParameters.Length; i++)
        {
            prediction += modelParameters[i] * features[i];
        }
        return prediction;
    }
}