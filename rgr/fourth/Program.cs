using System;

class f
{
    static void Main()
    {
        long MaxN = long.Parse(Console.ReadLine());
        long count = 0;

        // Максимальное значение Z, при котором 2^Z - 1 <= MaxN
        int maxZ = (int)Math.Log(MaxN + 1, 2);

        for (int Z = 1; Z <= maxZ; Z++)
        {
            long powerOf2Z = 1L << Z; // 2^Z
            long sum = powerOf2Z - 1; // 2^Z - 1

            // Если сумма превышает MaxN, выходим из цикла
            if (sum > MaxN) break;

            // Вычисляем KMax
            long KMax = MaxN / sum;

            // Увеличиваем счетчик на количество допустимых K
            count += KMax; // Все K от 1 до KMax допустимы
        }

        Console.WriteLine(count);
    }
}