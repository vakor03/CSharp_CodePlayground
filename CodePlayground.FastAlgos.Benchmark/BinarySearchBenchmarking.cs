using BenchmarkDotNet.Attributes;

namespace CodePlayground.FastAlgos.Benchmark;

[MemoryDiagnoser, ShortRunJob]
public class BinarySearchBenchmarking
{
    private const int RUNS = 1_000_000;
    private BinarySearch<int, long> _binarySearch;
    private Element<int, long>[] _array;
    [GlobalSetup]
    public void Setup()
    {
        _binarySearch = new BinarySearch<int, long>();
        _array = GenerateRandomArray(100);
        _binarySearch.InitArray(_array);
    }
    
    [Benchmark()]
    public void BinarySearchTest()
    {
        for (int i = 0; i < RUNS; i++)
        {
            var elementIndex = _binarySearch.FindElementIndex(i % 100);
        }
    }
    
    public static Element<int, long>[] GenerateRandomArray(int size)
     {
         return Enumerable.Range(0, size).Select(n => new Element<int, long>(size - n - 1, n)
         ).ToArray();
     }
}

