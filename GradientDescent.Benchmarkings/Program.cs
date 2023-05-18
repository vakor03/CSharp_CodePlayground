// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using BenchmarkDotNet.Running;
using GradientDescent.Algorithm;
using GradientDescent.Benchmarkings;

BenchmarkRunner.Run<GradientDescentBenchmarkTests>();


// GradientDescent.Algorithm.GradientDescent gradientDescent = new GradientDescent.Algorithm.GradientDescent();
// Func<double[], double> initialFunc = x =>
//     Math.Pow(x[0], 2) + Math.Pow(x[1], 2) + Math.Pow(x[2], 2) + Math.Pow(x[3], 2) + x[0] * x[1] + x[0] * x[2] +
//     x[0] * x[3] + x[1] * x[2] + x[1] * x[3] + x[2] * x[3];
// double[] startPointArray = { 1000.0, 1000.0, 1000.0, 1000.0 };
// double[] funcMinima = gradientDescent.FindFuncMinima(initialFunc, 0.0001, 10000, startPointArray, 0.0001);
// Console.WriteLine($"Func minima: {string.Join(", ", funcMinima)}");