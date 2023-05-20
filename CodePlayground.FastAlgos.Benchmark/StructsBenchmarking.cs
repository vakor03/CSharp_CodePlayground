using BenchmarkDotNet.Attributes;

namespace CodePlayground.FastAlgos.Benchmark;

[MemoryDiagnoser(), ShortRunJob]
public class StructsBenchmarking
{
    private const int RUNS = 1_000_000;
    private TestStruct _testStructA;
    private TestStruct _testStructB;
    private TestStruct _testStructC;

    [GlobalSetup]
    public void Setup()
    {
        _testStructA = new TestStruct(10);
        _testStructB = new TestStruct(10);
        _testStructC = new TestStruct(11);
    }

    //[Benchmark()]
    public void StructIEquatableTest()
    {
        for (int i = 0; i < RUNS; i++)
        {
            bool equals = _testStructA.Equals(_testStructB);
            bool notEquals = _testStructB.Equals(_testStructC);
        }
    }
    
    [Benchmark()]
    public void StructIComparableTest()
    {
        for (int i = 0; i < RUNS; i++)
        {
            bool equals = _testStructA.CompareTo(_testStructB) == 0;
            bool notEquals = _testStructB.CompareTo(_testStructC) == 0;
        }
    }


    //[Benchmark()]
    public void StructEqualityComparerTest()
    {
        var equalityComparer = EqualityComparer<TestStruct>.Default;
        for (int i = 0; i < RUNS; i++)
        {
            var equals = equalityComparer.Equals(_testStructA, _testStructB);
            var notEquals = equalityComparer.Equals(_testStructB, _testStructC);
        }
    }

    // [Benchmark()]
    public void TightlyPackedObjectEqualsTest()
    {
        for (int i = 0; i < RUNS; i++)
        {
            var p1 = new TightlyPacked();
            var p2 = new TightlyPacked();
            p1.Equals(p2);
        }
    }
    
    // [Benchmark()]
    public void NotTightlyPackedObjectEqualsTest()
    {
        for (int i = 0; i < RUNS; i++)
        {
            var p1 = new NotTightlyPacked();
            var p2 = new NotTightlyPacked();
            p1.Equals(p2);
        }
    }
}

internal struct TightlyPacked
{
    public int Age { get; set; }
    public int Salary { get; set; }
}

internal struct NotTightlyPacked
{
    public int Age { get; set; }
    public double Salary { get; set; }
}

internal struct TestStruct : IEquatable<TestStruct>, IComparable<TestStruct>
{
    public int Value { get; }

    public TestStruct(int value)
    {
        Value = value;
    }

    public bool Equals(TestStruct other)
    {
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is TestStruct other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value;
    }

    public int CompareTo(TestStruct other)
    {
        return Value.CompareTo(other.Value);
    }
}