using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSequencerNS
{

    public class JobSequencer
    {
        public JobSequencer()
        {
            
        }

        /// <summary>
        /// Main Calculation        
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> SortJobs(string input)
        {
            var jobSeq = new List<KeyValuePair<string, string>>();
            var output = new List<string>();

            //check empty
            if(input.Trim().Length == 0)
            {
                return output;
            }

            jobSeq = SplitJobs(input);
            PrintSequence(jobSeq);


            //select values
            output =  jobSeq.Select(x => ReverseString(x.Key + x.Value)).ToList();
            return output;
        }


    

        /// <summary>
        /// coverts string to key/value pair list
        /// </summary>
        /// <param name="input"></param>
        public List<KeyValuePair<string, string>> SplitJobs(string input)
        {
            var jobSeq = new List<KeyValuePair<string, string>>();

            var jobs = input.Split("\n");
            foreach(var seq in jobs)
            {
                var str = seq.Split("=>");
                var key = str.ElementAt(0).Trim();
                var val = str.Length == 2 ? str.ElementAt(1).Trim() : string.Empty;
                
         
                var pair = new KeyValuePair<string, string>(key, val);
                jobSeq.Add(pair);
            }

            return jobSeq;
        }

        public void PrintSequence(List<KeyValuePair<string, string>> jobSeq)
        {
            foreach(var item in jobSeq)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }

        public void PrintInput(string input)
        {
            Console.WriteLine(input);
        }

        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    }
}
