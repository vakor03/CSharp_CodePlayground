namespace BaseConsoleApp;

public class Algo
{
    public static int Sum(int a, int b)
    {
        List<int> randomList = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            randomList.Add(i);
        }
        foreach (var i in randomList)
        {
            foreach (var i1 in randomList)
            {
                var c = i + i1;
            }
        }

        return 2;
    } 
}