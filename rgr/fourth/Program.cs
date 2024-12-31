using System;

class f
{
    static void Main()
    {
        long MaxN = long.Parse(Console.ReadLine());
        long count = 0;

        int maxZ = (int)Math.Log(MaxN + 1, 2);

        for (int Z = 1; Z <= maxZ; Z++)
        {
            long powerOf2Z = 1L << Z;
            long sum = powerOf2Z - 1;

            if (sum > MaxN) break;

            long KMax = MaxN / sum;

            count += KMax;
        }

        Console.WriteLine(count);
    }
}