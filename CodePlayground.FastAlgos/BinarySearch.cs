namespace CodePlayground.FastAlgos;

public class BinarySearch<TKey, TValue> where TKey : struct, IEquatable<TKey>, IComparable<TKey>
{
    private readonly SortedList<TKey, TValue> _internalList;

    public BinarySearch(int size = 0)
    {
        _internalList = new SortedList<TKey, TValue>(size);
    }

    public void InitArray(Element<TKey, TValue>[] elements)
    {
        _internalList.Clear();
        foreach (var element in elements)
        {
            _internalList.Add(element.Key, element.Value);
        }
    }

    public int FindElementIndex(TKey key)
    {
        if (_internalList.Count == 0)
        {
            return -1;
        }

        int curIndex = (int)Math.Pow(2, Math.Floor(Math.Log2(_internalList.Count)));
        int stepSize = Math.Max(1, curIndex / 2);
        int iterations = 0;
        int maxIterations = (int)Math.Ceiling(Math.Log2(_internalList.Count));

        TKey curElement = _internalList.Keys[0];
        while (iterations <= maxIterations &&
               (curIndex > _internalList.Count - 1
                || !(curElement = _internalList.Keys[curIndex]).Equals(key)))
        {
            if (curIndex > _internalList.Count - 1 || curElement.CompareTo(key) > 0)
            {
                curIndex -= stepSize;
            }
            else
            {
                curIndex += stepSize;
            }

            stepSize /= 2;
            stepSize = Math.Max(1, stepSize);
            iterations++;
        }

        if (curIndex >= 0 && curIndex < _internalList.Count && _internalList.Keys[curIndex].Equals(key))
        {
            return curIndex;
        }

        return -1;
    }
}

public readonly struct Element<TKey, TValue>
{
    public readonly TKey Key;
    public readonly TValue Value;

    public Element(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}