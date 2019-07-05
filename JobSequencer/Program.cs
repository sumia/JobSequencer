using JobSequencerNS;
using System;

namespace JobSequencerP
{
    public class Program
    {
        static void Main(string[] args)
        {
         
            var sequencer = new JobSequencer();
            //sequencer.PrintInput(input);

            while(true) {
                Console.Write("Input: ");
                var input = Console.ReadLine();

                //check empty sequence
                var result = sequencer.SortJobs(input);
                if (result != null && result.Count > 0)
                {
                    foreach (var seq in result)
                    {
                        Console.WriteLine(seq);
                    }
                } else
                {
                    Console.WriteLine("No job sequence entered.");
                }

                Console.WriteLine("\n\n");
            }

            Console.WriteLine("Press any key to close.");
            Console.ReadKey();

        }
    }

}
