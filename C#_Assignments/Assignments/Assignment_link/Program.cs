namespace LINQ_Assignments
{
    internal class linq1
    {
        static void Main(string[] args)
        {
            int[] n = { 1, 2, 4, 54, 565, 8, 34, 12, 354, 78, 7, 6, 9 };
            var result = from i in n
                         let x = i * i * i
                         where x > 100 && x < 1000
                         select i;

            /*
                        var result = n.Select(i => new { i, x = i * i * i })
                                 .Where(j => j.x > 100 && j.x < 1000)                      //METHOD SYNTAX IN LINQ
                                 .Select(j => j.i);*/

            foreach (var x in result)
            {
                Console.WriteLine(x);
            }


        }
    }
}