using System;

class program
{
    const string path = "./../../milk";
    static void Main()
    {
        System.IO.FileInfo[] a = new System.IO.DirectoryInfo(path).GetFiles();
        for (int i = 0; i < a.Length / 2; i++)
        {
            Console.WriteLine("Обработка файла " + a[i]);
            string[] file = System.IO.File.ReadAllLines(path + "/" + a[i]);
            double Min = 1000;
            int num = 0;
            for (int j = 1; j <= int.Parse(file[0]); j++)
            {
                string[] comp = file[j].Split(' ');
                float z1 = float.Parse(comp[0]), x1 = float.Parse(comp[1]), y1 = float.Parse(comp[2]);
                float z2 = float.Parse(comp[3]), x2 = float.Parse(comp[4]), y2 = float.Parse(comp[5]);
                float c1 = float.Parse(comp[6].Replace('.', ',')), c2 = float.Parse(comp[7].Replace('.', ','));

                //float up = (c2 * (x1 * y1 + z1 * y1 + z1 * x1) - c1 * (x2 * y2 + z2 * y2 + z2 * x2));
                //float down = (z2 * x2 * y2) * (x1 * y1 + z1 * y1 + z1 * x1) - (x2 * y2 + z2 * y2 + z2 * x2) * (z1 * x1 * y1);

                float res = 1000 * ((c2 * (x1 * y1 + z1 * y1 + z1 * x1) - c1 * (x2 * y2 + z2 * y2 + z2 * x2)) / ((z2 * x2 * y2) * (x1 * y1 + z1 * y1 + z1 * x1) - (x2 * y2 + z2 * y2 + z2 * x2) * (z1 * x1 * y1)));
                if (Min > res)
                {
                    Min = Math.Round(res, 2);
                    num = j;
                }
            }
            Console.WriteLine("Ответ: " + num +" " + Min);
            Console.WriteLine("output file: " + System.IO.File.ReadAllLines(path + "/" + a[i + 10])[0] + "\n");
        }
    }
}