using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> SortJobs(string input)
        {
            //clear previous data
            jobSeq.Clear();

            var output = new List<string>();

            //check empty
            if(input.Trim().Length == 0)
            {
                return output;
            }

            
            SplitJobs(input);
            OrderJob();
            

            //PrintSequence(jobSeq);


            //select values
            output =  jobSeq.Select(x => ReverseString(x.Key + x.Value)).ToList();
            return output;
        }

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

                List<string> seq = new List<string>();
                var dependentJob = job.Value;
                while (!string.IsNullOrEmpty(dependentJob))
                {
                    if(seq.Contains(dependentJob))
                    {
                        throw new Exception("Jobs can’t have circular dependencies.");
                    }

                    seq.Add(dependentJob);
                    var found = jobSeq.Where(x => x.Key.Equals(dependentJob)).FirstOrDefault();
                    dependentJob = found.Key != null ? found.Value : string.Empty;                    
                }


                var seqStr = string.Join("", seq);
                seq.ForEach(j => jobSeq.Remove(j));

                jobSeq[job.Key] = seqStr;
            }

     
        }


        /// <summary>
        /// coverts string to key/value pair list
        /// </summary>
        /// <param name="input"></param>
        private void SplitJobs(string input)
        {

            var jobs = input.Split("\n");
            foreach(var seq in jobs)
            {
                var str = seq.Split("=>");
                var key = str.ElementAt(0).Trim();
                var val = str.Length == 2 ? str.ElementAt(1).Trim() : string.Empty;
                
                jobSeq.Add(key,val);
            }

        }

        public void PrintSequence(Dictionary<string, string> jobSeq)
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
