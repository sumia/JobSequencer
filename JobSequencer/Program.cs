using JobSequencerNS;
using System;

namespace JobSequencerP
{
    public class Program
    {
        /// <summary>
        /// Author:Sumia Akter
        /// Dated: July 6, 2019
        // Solution Approach:
        /// * Since the problem is about ordering job sequences based on the dependency,
        ///     added a class which would do the task (Job Sequencer).
        /// * Added two main functions of Job sequencer, 
        ///     - parsing the input(SplitJobs) 
        ///     - and OrderJobs(grouping jobs depending on which is done first in a sequence)
        /// * Added unit tests for different test cases and then solved each one in turn.
        /// * Started with iterating each job
        ///     - does it have any dependency? 
        ///         # No, move the next one
        ///         # Yes, 
        ///             find all the dependencies till a leaf job is found, add them together, save it against the main job.
        ///             b=>c c=>f would become b=>cf. b cannot be added to the list yet
        ///                 since another job might be depending on b.
        ///             
        ///             Added the processed jobs to some other list to mark it as done.
        ///             Finally, processed jobs are removed from the list, reversed to get the right order and then returned to the caller.
        /// * In the end, continuously tested the code to make sure the input parsing is right
        ///     and the code output is as expected.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            var sequencer = new JobSequencer();
            //sequencer.PrintInput(input);

            while (true)
            {
                Console.Write("Input: ");
                var input = Console.ReadLine();

                //check empty sequence
                var result = sequencer.SortJobs(input);
                Console.WriteLine("Output:");
                if (result != null && result.Count > 0)
                {
                    foreach (var seq in result)
                    {
                        Console.WriteLine(seq);
                    }
                }
                else
                {
                    Console.WriteLine("No job sequence entered.");
                }

                Console.WriteLine();//just a new line added to the screen for a neat outputs
            }

            //Console.WriteLine("Press any key to close.");
            //Console.ReadKey();

        }
    }

}
