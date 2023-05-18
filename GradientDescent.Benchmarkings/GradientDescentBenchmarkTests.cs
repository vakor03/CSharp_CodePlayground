using BenchmarkDotNet.Attributes;
using GradientDescent.Algorithm;

namespace GradientDescent.Benchmarkings;

[MemoryDiagnoser()]
public class GradientDescentBenchmarkTests
{
    [Params(2,5,10,20)]
    public int ArgumentsCount { get; set; }

    private Func<double[], double> _initialFunc;

    private Algorithm.GradientDescent _gradientDescent;
    private double[] _initialPoint;
    private double _learningRate;
    private int _iterationsCount;

    [Benchmark]
    public void PerformGradientDescent()
    {
        double[] funcMinima = _gradientDescent.FindFuncMinima(_initialFunc, _learningRate, _iterationsCount,
            _initialPoint, 0.0001);
    }

    // [Benchmark]
    // public void PerformParallelGradientDescent()
    // {
    //     
    //     double[] finalModelParameters = _gradientDescentParallel.PerformParallelGradientDescent(_modelParameters,
    //         _trainingData, _targets, _learningRate, _maxIterations);
    // }
    
    [GlobalSetup]
    public void Setup()
    {
        _initialFunc = GradientDescentHelper.GenerateInitialFunc(ArgumentsCount);
        _initialPoint = GradientDescentHelper.GenerateInitialPoint(ArgumentsCount, 1000);
        _gradientDescent = new Algorithm.GradientDescent();
        _learningRate = 0.0001;
        _iterationsCount = 1000;
    }

}