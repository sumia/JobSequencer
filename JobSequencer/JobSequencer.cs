using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSequencerNS
{

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
