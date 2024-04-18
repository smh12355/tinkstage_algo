using System.Text;

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
                    //Console.Write(matrix[int.Parse(input[0]) - 1 - j, i]);
                    Console.Write($"{i} {j} {int.Parse(input[0]) - 1 - j} {i}\n");
                }
                //Console.WriteLine();
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
                    //Console.Write(matrix[j, int.Parse(input[0]) - 1 - i]);
                    Console.Write($"{i} {j} {int.Parse(input[0]) - 1 - j} {i}\n");
                }
                //Console.WriteLine();
            }
        }

        static void fourth_another()
        {
            var input = Console.ReadLine().Split().ToArray();
            var matrix_dict = new Dictionary<(int, int), (long, long)>();
            for (int i = 0; i < int.Parse(input[0]); i++)
            {
                var array_data = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
                for (int j = 0; j < int.Parse(input[0]); j++)
                {
                    matrix_dict.Add((i, j), (array_data[j], -1));
                }
            }
            var for_del = new List<(int, int)>();
            if (input[1] is "R")
            {
                for (int i = 0; i < int.Parse(input[0]); i++)
                {
                    for (int j = 0; j < int.Parse(input[0]); j++)
                    {
                        if (matrix_dict[(i, j)] == matrix_dict[(int.Parse(input[0]) - 1 - j, i)])
                        {
                            for_del.Add((i, j));
                        }
                        else
                        {
                            matrix_dict[(i, j)] = (matrix_dict[(i, j)].Item1, matrix_dict[(int.Parse(input[0]) - 1 - j, i)].Item1);
                        }
                    }
                }
                foreach (var item in for_del)
                {
                    matrix_dict.Remove(item);
                }
                var counter = 0;
                var output = new StringBuilder();
                foreach (var item in matrix_dict)
                {
                    counter++;
                    var key = matrix_dict.FirstOrDefault(x => x.Value.Item1 == item.Value.Item2);
                    var container = matrix_dict[key.Key].Item1;
                    matrix_dict[key.Key] = (matrix_dict[item.Key].Item1, matrix_dict[key.Key].Item2);
                    matrix_dict[item.Key] = (container, matrix_dict[item.Key].Item2);
                    output.Append($"{item.Key.Item1} {item.Key.Item2} {key.Key.Item1} {key.Key.Item2}");
                    output.Append(Environment.NewLine);
                    matrix_dict.Remove(item.Key);
                    if (matrix_dict.Count == 1)
                    {
                        break;
                    }
                }
                Console.WriteLine(counter);
                Console.Write(output.ToString());
            }
            else
            {
                for (int i = 0; i < int.Parse(input[0]); i++)
                {
                    for (int j = 0; j < int.Parse(input[0]); j++)
                    {
                        if (matrix_dict[(i, j)] == matrix_dict[(j, int.Parse(input[0]) - 1 - i)])
                        {
                            for_del.Add((i, j));
                        }
                        else
                        {
                            matrix_dict[(i, j)] = (matrix_dict[(i, j)].Item1, matrix_dict[(j, int.Parse(input[0]) - 1 - i)].Item1);
                        }
                    }
                }
                foreach (var item in for_del)
                {
                    matrix_dict.Remove(item);
                }
                var counter = 0;
                var output = new StringBuilder();
                foreach (var item in matrix_dict)
                {
                    counter++;
                    var key = matrix_dict.FirstOrDefault(x => x.Value.Item1 == item.Value.Item2);
                    var container = matrix_dict[key.Key].Item1;
                    matrix_dict[key.Key] = (matrix_dict[item.Key].Item1, matrix_dict[key.Key].Item2);
                    matrix_dict[item.Key] = (container, matrix_dict[item.Key].Item2);
                    output.Append($"{item.Key.Item1} {item.Key.Item2} {key.Key.Item1} {key.Key.Item2}");
                    output.Append(Environment.NewLine);
                    matrix_dict.Remove(item.Key);
                    if (matrix_dict.Count == 1)
                    {
                        break;
                    }
                }
                Console.WriteLine(counter);
                Console.Write(output.ToString());
            }
            
        }
        static void five()
        {
            var n = int.Parse(Console.ReadLine());
            var forest = new List<List<int>>();
            var dynamic_forest = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                dynamic_forest.Add(new int[] { -1, -1, -1 });
            }
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().ToArray();
                var input_list = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    if (input[j].ToString() is "W")
                    {
                        input_list.Add(-1);
                    }
                    else if (input[j].ToString() is ".")
                    {
                        input_list.Add(0);
                    }
                    else
                    {
                        input_list.Add(1);
                    }
                }
                forest.Add(input_list);
            }
            for (int i = 0; i < 3; i++)
            {
                dynamic_forest[0][i] = forest[0][i];
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if (j + k >= 0 && j + k < 3 && dynamic_forest[i - 1][j + k] != -1 && forest[i][j] != -1)
                        {
                            dynamic_forest[i][j] = Math.Max(dynamic_forest[i][j], dynamic_forest[i - 1][j + k] + forest[i][j]);
                        }
                    }
                }
            }
            var collected = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    collected = Math.Max(collected, dynamic_forest[i][j]);
                }
            }
            Console.Write(collected);
        }
        static void six()
        {
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; n > 0; i++)
            {
                  
            }
        }
    }
}

    

