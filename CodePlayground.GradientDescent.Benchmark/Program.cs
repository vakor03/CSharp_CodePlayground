// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using CodePlayground.GradientDescent.Benchmark;

BenchmarkRunner.Run<GradientDescentBenchmarkTests>();