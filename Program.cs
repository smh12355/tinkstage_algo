namespace tinkoff_stage_algs;

class Program
{
    static void Main(string[] args)
    {   
        var input_amount = int.Parse(Console.ReadLine());
        var input_list = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        var data = new List<int>();
        var counter_cicle = 0;
        var counter_marks = 0;
        foreach(var input in input_list)
        {
            
            if (input < 4)
            {
                counter_cicle = 0;
                counter_marks = 0;
                continue;
            }
            counter_cicle++;
            if (input is 5)
            {
                counter_marks++;
            }
            if (counter_cicle is 7)
            {
                data.Add(counter_marks);
                counter_marks = 0;
                counter_cicle = 0;
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
}
