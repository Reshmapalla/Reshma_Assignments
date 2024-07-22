using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extra_Assignment
{
    internal class Demo1
    {
        static void Main(string[] args)
        {
             
            
            Console.WriteLine("Provide Sentence from command line");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(new char[] { ' ', ',', '!', '?','.' } ,StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string,int> dict= new Dictionary<string,int>();
            foreach(string word in words)
            {
                string LowerCaseWord = word.ToLower();
                if(dict.ContainsKey(LowerCaseWord))
                {
                    dict[LowerCaseWord]++;

                }
                else
                {
                    dict[LowerCaseWord] = 1;
                }
            }
            foreach(KeyValuePair<string,int> pair in dict)
            {
                Console.WriteLine($"{pair.Key} {pair.Value}");
            }


            
        }
    }
}
