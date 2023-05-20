namespace CodePlayground.GradientDescent.Algorithm;
internal readonly struct Vector
{
    private readonly double[] _vector;

    public double this[int i]
    {
        get => _vector[i];
        set => _vector[i] = value;
    }

    public int Length => _vector.Length;
    public double Norm => Math.Sqrt(_vector.Sum(x => x * x));
    public double[] GetInternalArray() => _vector;

    public Vector(double[] vector)
    {
        _vector = vector;
    }

    public Vector(int size)
    {
        _vector = new double[size];
    }

    public static Vector operator *(double scalar, Vector vector)
    {
        Vector result = new Vector(vector.Length);
        for (int i = 0; i < vector.Length; i++)
        {
            result[i] = scalar * vector[i];
        }

        return result;
    }

    public static Vector operator -(Vector vector1, Vector vector2)
    {
        Vector result = new Vector(vector1.Length);
        for (int i = 0; i < vector1.Length; i++)
        {
            result[i] = vector1[i] - vector2[i];
        }

        return result;
    }
}