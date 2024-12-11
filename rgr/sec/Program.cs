using System;
using System.IO;

class Program
{
    static void Main()
    {

        System.IO.FileInfo[] a = new System.IO.DirectoryInfo("./../../sold").GetFiles();
        for (int i = 0; i < a.Length/2; i++) {
            Console.WriteLine("Читаемый файл "+ a[i]);
            string[] file = System.IO.File.ReadAllLines("./../../sold/" + a[i]);
            int N = int.Parse(file[0]);
            Console.WriteLine("Ответ: " + CountGroups(N));
            Console.WriteLine("output file: " + System.IO.File.ReadAllLines("./../../sold" + "/" + a[i + 10])[0] + "\n");
        }
    }

    static long CountGroups(int N)
    {
        if (N < 3) return 0;
        return CountGroupsRecursive(N);
    }

    static long CountGroupsRecursive(int N)
    {
        if (N == 3) return 1;
        if (N < 3) return 0;

        return CountGroupsRecursive(N / 2) + CountGroupsRecursive((N + 1) / 2);
    }
}