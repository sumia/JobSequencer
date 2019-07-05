using JobSequencerNS;
using System;

namespace JobSequencerP
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
            if (result != null && result.Count > 0)
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

}
