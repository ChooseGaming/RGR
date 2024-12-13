using System;

class thr
{
    static void Main()
    {
        int N = 3;
        int M = 1;
        int arrow = 1;
        int cd1 = 1, cd2 = 1, start = 1;
        Console.WriteLine("начальные координаты: (" + cd1 + ", " + cd2 + ")");
        while (M > 0)
        {
            if (arrow == 1)
            {
                Calc(ref cd1, ref cd2, start, N);
            } else
            {
                for (int i = 0; i < 3; i++)
                    Calc(ref cd1, ref cd2, start, N);
            }
            M -= 1;
        }
        Console.WriteLine("конечные координаты: (" + cd1 + ", " + cd2 + ")");
    }
    static void Calc(ref int cd1, ref int cd2, int start, int N)
    {
        if (cd1 > cd2)
        {
            cd2 = cd1;
            cd1 = cd2 == 1 ? N : (N - start + 1);
        }
        else if (cd1 == cd2)
        {
            cd2 = cd1;
            cd1 = cd1 == 1 ? N : 1;
        }
        else
        {
            cd1 = cd1 - 1 <= 0 ? start : 1;
        }
    }
}