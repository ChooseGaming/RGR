using System;

class thr
{
    static int[] Calc(int cord1, int cord2, int N, int dir)
    {
        int num1, num2;
        if (dir == 1)
        {
            num1 = cord2;
            num2 = N - cord1 + 1;
        } else
        {
            num1 = N - cord2 + 1;
            num2 = cord1;
        }
        return new int[] { num1, num2 };
    }
    static void Main()
    {
        const string PATH = "../../rubik";
        System.IO.FileInfo[] FileNames = new System.IO.DirectoryInfo(PATH).GetFiles();
        for (int j = 0; j < FileNames.Length / 2; j++)
        {
            string[] file = System.IO.File.ReadAllLines(PATH + "/" + FileNames[j].ToString());
            string[] NM = file[0].Split(' ');
            string[] xyz = file[1].Split(' ');

            int x = int.Parse(xyz[0]), y = int.Parse(xyz[1]), z = int.Parse(xyz[2]);
            int N = int.Parse(NM[0]), M = int.Parse(NM[1]);

            for (int i = 0; i < M; i++)
            {
                string[] actions = file[i + 2].Split(' ');
                if (actions[0] == "Z" && int.Parse(actions[1]) == z)
                {
                    int[] a = Calc(x, y, N, int.Parse(actions[2]));
                    x = a[0];
                    y = a[1];
                }
                else if (actions[0] == "X" && int.Parse(actions[1]) == x)
                {
                    int[] a = Calc(y, z, N, int.Parse(actions[2]));
                    y = a[0];
                    z = a[1];
                }
                else if (actions[0] == "Y" && int.Parse(actions[1]) == y)
                {
                    int[] a = Calc(z, x, N, -1 * int.Parse(actions[2]));
                    z = a[0];
                    x = a[1];
                }
            }
            Console.Write($"Получившийся ответ в {FileNames[j].ToString()}: {x} {y} {z} \n");
            Console.WriteLine($"Ответ из решения({FileNames[j + 20].ToString()}) : " + System.IO.File.ReadAllLines(PATH + "/" + FileNames[j + 20].ToString())[0] + "\n");
        }
    }
}