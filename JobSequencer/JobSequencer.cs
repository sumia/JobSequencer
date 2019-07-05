using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JobSequencerNS
{

    public class JobSequencer
    {
        private Dictionary<string, string> jobSeq;

        public JobSequencer()
        {
            this.jobSeq = new Dictionary<string, string>();
        }

        /// <summary>
        /// Main Calculation        
        /// Input is splitted into jobs, grouped by order
        /// </summary>
        /// <param name="input">A single string representing ordered sequence of jobs</param>
        /// <returns>List of string with ordered job sequence</returns>
        public List<string> SortJobs(string input)
        {
            //clear previous data
            jobSeq.Clear();

            var output = new List<string>();
            //check for empty input
            if (input.Trim().Length == 0)
            {
                return output;
            }

            
            SplitJobs(input);
            OrderJob();
            //PrintSequence(jobSeq);


            //generate output
            output =  jobSeq.Select(x => ReverseString(x.Key + x.Value)).ToList();
            return output;
        }


        /// <summary>
        /// Finds job dependency and orders them based on the job needed to be completed first
        /// Throws error if a job depends on itself e.g. a => a
        /// Throws error it it has circular dependency e.g. a => b => c = a
        /// </summary>
        private void OrderJob()
        {
            for(int i=0; i< jobSeq.Count; i++)
            {
                var job = jobSeq.ElementAt(i);
            
                //check self dependency
                if (job.Key.Equals(job.Value))
                {
                    throw new Exception("Jobs can’t depend on themselves.");
                }

                //seq contains dependent jobs
                List<string> seq = new List<string>();
                var dependentJob = job.Value;
                while (!string.IsNullOrEmpty(dependentJob))
                {
                    //check circular dependency
                    if(seq.Contains(dependentJob))
                    {
                        throw new Exception("Jobs can’t have circular dependencies.");
                    }

                    //ok to add
                    seq.Add(dependentJob);

                    //try to find next dependenct job
                    var found = jobSeq.Where(x => x.Key.Equals(dependentJob)).FirstOrDefault();
                    dependentJob = found.Key != null ? found.Value : string.Empty;                    
                }

                //join the sequences together
                //[a,b,c] => abc
                var seqStr = string.Join("", seq);

                //removes the jobs that have been processed
                //taking the fact that two different jobs wont be depending on the same job
                //example: b=>c, a =>c has not been considered
                seq.ForEach(j => jobSeq.Remove(j));

                //assign dependent job to the main one
                jobSeq[job.Key] = seqStr;
            }

     
        }


        /// <summary>
        /// Coverts job string to key-value pair
        /// and stores in dictionary
        /// </summary>
        /// <param name="input"></param>
        private void SplitJobs(string input)
        {

            //var jobs = input.Split("\n");
            //replace all the spaces
            input = input.Replace(" ", "");

            //get each line of job sequence
            var jobs = Regex.Split(input, "([a-zA-Z]{1}=>[a-zA-Z]*(?!=>))");
            foreach(var seq in jobs)
            {
                if (seq.Equals("")) continue;
                var str = seq.Split("=>");
                var key = str.ElementAt(0).Trim();
                var val = str.Length == 2 ? str.ElementAt(1).Trim() : string.Empty;
                
                jobSeq.Add(key,val);
            }

        }


        /// <summary>
        /// Reverses input string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public void PrintSequence(Dictionary<string, string> jobSeq)
        {
            foreach (var item in jobSeq)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }

        public void PrintInput(string input)
        {
            Console.WriteLine(input);
        }

    }
}
