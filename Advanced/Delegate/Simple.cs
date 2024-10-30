using System;

namespace Advanced;

public class Simple
{
    delegate int Transformer(int x);
    int square(int x) => x * x;

    int[] value = { 1, 2, 3 };
    public void Consumer()
    {
        Transform(value, square);
        for (int i = 0; i < value.Length; i++)
        {
            Console.WriteLine(value[i]);
        }
    }

    private void Transform(int[] values, Transformer t)
    {
        for (int i = 0; i < values.Length; i++)
        {
            value[i] = t(values[i]);
        }
    }

    Transformer t = new Test().Square;

    class Test { public int Square (int x) => x * x; }

    public void Consumer2()
    {
        Console.WriteLine (t(10)); // 100
    }
}