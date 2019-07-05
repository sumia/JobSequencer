using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSequencer
{
    public class Program
    {
        static void Main(string[] args)
        {
         
            //read input
            var input = "a =>\nb => c\nc => f\nd => a\ne => b\nf =>";
            var sequencer = new JobSequencer();
            sequencer.PrintInput(input);

            //check empty sequence
            var result = sequencer.SortJobs("");
            if (result != null && result.Length > 0)
            {
                foreach (var seq in result)
                {
                    Console.WriteLine(seq);
                }
            } else
            {
                Console.WriteLine("No output sequence.");
            }


            Console.WriteLine("Press any key to close.");
            Console.ReadKey();

        }
    }

    public class JobSequencer
    {
        List<KeyValuePair<char, char>> jobs = null;

        public JobSequencer()
        {
            jobs = new List<KeyValuePair<char, char>>();
        }

        public string[] SortJobs(string input)
        {
            return jobs.Select(x => x.Value.ToString()).ToArray();
        }

        public void SplitJobs()
        {

        }

        public void PrintInput(string input)
        {
            Console.WriteLine(input);
        }


    }
}
