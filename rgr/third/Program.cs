using System;

class thr
{
    static void Main()
    {
        string[] files = System.IO.Directory.GetFiles("../../rubik");
        for (int i = 0; i < files.Length / 2; i++)
        {
            string[] file = System.IO.File.ReadAllLines(files[i]);
            string[] content = file[1].Split(' ');
            int N = int.Parse(file[0].Split(' ')[0]), M = int.Parse(file[0].Split(' ')[1]);
            int x = int.Parse(content[0]), y = int.Parse(content[1]), z = int.Parse(content[2]);
            for (int j = 2; j <= M+1; j++)
            {
                string[] action = file[j].Split(' ');
                if (action[0] == "Z")
                {
                    int[] a = Calc(x, y, z , N, int.Parse(action[2]), int.Parse(action[1]));
                    x = a[0];
                    y = a[1];
                }
                else if (action[0] == "X")
                {
                    int[] a = Calc(y, z, x, N, int.Parse(action[2]), int.Parse(action[1]));
                    y = a[0];
                    z = a[1];
                }
                else if (action[0] == "Y")
                {
                    int[] a = Calc(z, x, y, N, int.Parse(action[2]), int.Parse(action[1]));
                    z = a[0];
                    x = a[1];
                }
            }
            Console.WriteLine($"Мой ответ: {x} {y} {z} | Входящий файл: {files[i]}");
            Console.WriteLine("Ответы: " + System.IO.File.ReadAllText(files[i + 20]) + $" | Файл с ответами {files[i + 20]}\n");
        }
    }
    static int[] Calc(int cord1, int cord2, int cord3, int N, int dir, int K)
    {
        int num1 = cord1, num2 = cord2;
        if (cord3 == K)
        {
            num1 = (dir == 1) ? cord2 : (N - cord2 + 1);
            num2 = (dir == 1) ? (N - cord1 + 1) : cord1;
        }
        return new int[] { num1, num2 };
    }
}