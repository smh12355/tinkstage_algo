namespace tinkoff_stage_algs;

class Program
{
    static void Main(string[] args)
    {
        third();
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
        var matrix = new int[dimensions[0],dimensions[1]];
        //var new_matrix = new int[dimensions[1], dimensions[0]];
        for (int i = 0; i < dimensions[0]; i++)
        {
            var array_data = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
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
        List<string> roots = new List<string>();
        for (int i = 0;i < amount;i++)
        {
            roots.Add(Console.ReadLine());
        }
    }
    
}
