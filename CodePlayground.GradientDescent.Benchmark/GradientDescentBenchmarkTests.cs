using BenchmarkDotNet.Attributes;
using CodePlayground.GradientDescent.Algorithm;

namespace CodePlayground.GradientDescent.Benchmark;

[MemoryDiagnoser()]
public class GradientDescentBenchmarkTests
{
    [Params(10, 50, 100, 200, 500, 700, 1000, 1500, 2000, 2500)]
    public int ArgumentsCount { get; set; }

    private Func<double[], double> _initialFunc;

    private Algorithm.GradientDescent _gradientDescent;
    private GradientDescentParallel _gradientDescentParallel;
    private double[] _initialPoint;
    private double _learningRate;
    private int _iterationsCount;

    [GlobalSetup]
    public void Setup()
    {
        _initialFunc = GradientDescentHelper.GenerateInitialFunc(ArgumentsCount);
        _initialPoint = GradientDescentHelper.GenerateInitialPoint(ArgumentsCount, 10);
        _gradientDescent = new Algorithm.GradientDescent();
        _gradientDescentParallel = new GradientDescentParallel();
        _learningRate = 0.02;
        _iterationsCount = 1000;
    }

    [Benchmark]
    public void PerformGradientDescent()
    {
        double[] funcMinima = _gradientDescent.FindFuncMinima(_initialFunc, _initialPoint, _learningRate,
            _iterationsCount, 0.0001);
    }

    [Benchmark]
    public void PerformParallelGradientDescent()
    {
        double[] funcMinima = _gradientDescentParallel.FindFuncMinima(_initialFunc, _initialPoint, _learningRate,
            _iterationsCount, 0.0001);
    }
}