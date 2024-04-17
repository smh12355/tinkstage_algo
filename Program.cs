namespace tinkoff_stage_algs;

class Program
{
    static void Main(string[] args)
    {
        fourth();
    }

    static void first()
    {
        var input_amount = int.Parse(Console.ReadLine());
        var input_list = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        var data = new List<int>();
        var counter_cicle = 0;
        var counter_marks = 0;
        for (int i = 0; i < input_list.Length; i++)
        {
            if (input_list[i] < 4)
            {
                if (counter_cicle < 7)
                {
                    counter_cicle = 0;
                    counter_marks = 0;
                    continue;
                }
                else if (counter_cicle is 7)
                {
                    data.Add(counter_marks);
                    counter_marks = 0;
                    counter_cicle = 0;
                    continue;
                }
                else
                {
                    for (int j = 0; j <= counter_cicle - 7; j++)
                    {
                        data.Add(input_list.Skip((i + 1) - counter_cicle + j).Take(7).Count(x => x is 5));
                    }
                    counter_marks = 0;
                    counter_cicle = 0;
                    continue;
                }
            }
            counter_cicle++;
            if (input_list[i] is 5)
            {
                counter_marks++;
            }
            if (i == input_list.Length - 1)
            {
                if (counter_cicle is 7)
                {
                    data.Add(counter_marks);
                    counter_marks = 0;
                    counter_cicle = 0;
                    continue;
                }
                else if (counter_cicle > 7)
                {
                    for (int j = 0; j <= counter_cicle - 7; j++)
                    {
                        data.Add(input_list.Skip((i + 1) - counter_cicle + j).Take(7).Count(x => x is 5));
                    }
                    counter_marks = 0;
                    counter_cicle = 0;
                    continue;
                }
            }
        }
        if (data.Any())
        {
            Console.WriteLine(data.Max());
        }
        else
        {
            Console.WriteLine(-1);
        }
    }

    static void second()
    {
        var dimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        var matrix = new long[dimensions[0], dimensions[1]];
        //var new_matrix = new int[dimensions[1], dimensions[0]];
        for (int i = 0; i < dimensions[0]; i++)
        {
            var array_data = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
            for (int j = 0; j < dimensions[1]; j++)
            {
                matrix[i, j] = array_data[j];
            }
        }
        for (int i = 0; i < dimensions[1]; i++)
        {
            for (int j = 0; j < dimensions[0]; j++)
            {
                //new_matrix[i, j] = matrix[dimensions[0] - 1 - j, i];
                Console.Write(matrix[dimensions[0] - 1 - j, i]);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
    static void third()
    {
        var amount = int.Parse(Console.ReadLine());
        List<string[]> roots = new List<string[]>();
        for (int i = 0; i < amount; i++)
        {
            roots.Add(Console.ReadLine().Split('/').ToArray());
        }
        roots.Sort((x, y) => y.Length.CompareTo(x.Length));
        Console.WriteLine(roots[^1][0]);
        roots.Remove(roots[^1]);
        for (int i = 0; i < roots.Count; i++)
        {
            for (int j = 1; j < roots[i].Length; j++)
            {
                Console.Write(string.Join("", Enumerable.Repeat("  ", j)));
                Console.WriteLine(roots[i][j]);
            }
            for (int j = 1; j < roots[i].Length - 1; j++)
            {
                roots.RemoveAll(x => x.Length == roots[i].Length - j && x[^1] == roots[i][^(j + 1)]);
            }
        }
    }
    static void fourth()
    {
        var input = Console.ReadLine().Split().ToArray();
        //var dim = int.Parse(input[0]);
        //var turn_side = input[1];
        var matrix = new long[int.Parse(input[0]), int.Parse(input[0])];
        for (int i = 0; i < int.Parse(input[0]); i++)
        {
            var array_data = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
            for (int j = 0; j < int.Parse(input[0]); j++)
            {
                matrix[i, j] = array_data[j];
            }
        }
        Console.Write($"{int.Parse(input[0]) * int.Parse(input[0])}\n");
        if (input[1] is "R")
        {
            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                for (int j = 0; j < int.Parse(input[0]); j++)
                {
                    //new_matrix[i, j] = matrix[dimensions[0] - 1 - j, i];
                    Console.Write(matrix[int.Parse(input[0]) - 1 - j, i]);
                    //Console.Write($"{i} {j} {int.Parse(input[0]) - 1 - j} {i}\n");
                }
                Console.WriteLine();
            }
        }
        else
        {
            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                for (int j = 0; j < int.Parse(input[0]); j++)
                {
                    //new_matrix[i, j] = matrix[dimensions[0] - 1 - j, i];
                    //Console.Write(matrix[int.Parse(input[0]) - 1 - j, i]);
                    Console.Write(matrix[j, int.Parse(input[0]) - 1 - i]);
                    //Console.Write($"{i} {j} {int.Parse(input[0]) - 1 - j} {i}\n");
                }
                Console.WriteLine();
            }
        }

    }
}
    

