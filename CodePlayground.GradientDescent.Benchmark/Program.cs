// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using CodePlayground.GradientDescent.Benchmark;

BenchmarkRunner.Run<GradientDescentBenchmarkTests>();


// GradientDescentBenchmarkTests test = new GradientDescentBenchmarkTests
// {
//     ArgumentsCount = 20
// };
// test.Setup();
// for (int i = 0; i < 1_000; i++)
// {
//     test.PerformParallelGradientDescent();
// }