using JobSequencerNS;
using System;
using System.Collections.Generic;
using Xunit;

namespace JobSequencerTests
{
    public class UnitTest1
    {

        [Fact]
        public void Check()
        {
            //throw new NotImplementedException();
        }

        [Fact]
        public void CheckJobsEmptySequence()
        {
            var input = "";
         
            var sequencer = new JobSequencer();
            var actualOutput = sequencer.SortJobs(input);

            Assert.Empty(actualOutput);
        }


        /// <summary>
        /// Single Sequence
        /// </summary>
        [Fact]
        public void CheckJobsNoSignicantOrderSingle()
        {
            var input = "a =>";

            var sequencer = new JobSequencer();
            var actualOutput = sequencer.SortJobs(input);

            var expectedOutput = new List<string>(){ "a" };
            Assert.Equal(expectedOutput, actualOutput);
        }

        /// <summary>
        /// Multi sequence
        /// </summary>
        [Fact]
        public void CheckJobsNoSignicantOrderMulti()
        {
            var input = "a =>\nb=>\nc=>";
        
            var sequencer = new JobSequencer();
            var actualOutput = sequencer.SortJobs(input);

            var expectedOutput = new List<string>() { "bac" };
            Assert.NotStrictEqual(expectedOutput, actualOutput);
        }


        [Fact]
        public void CheckJobDependency()
        {
            var input = "a =>\nb=>c\nc=>";

            var sequencer = new JobSequencer();
            var actualOutput = sequencer.SortJobs(input);

            var expectedOutput = new List<string>() { "cb", "a" };
            Assert.NotStrictEqual(expectedOutput, actualOutput);
        }

        [Fact]
        public void CheckJobDependency_2()
        {
            var input = "a =>\nb=>c\nc=>f\nd => a\n e => b \n f=> ";

            var sequencer = new JobSequencer();
            var actualOutput = sequencer.SortJobs(input);

            var expectedOutput = new List<string>() { "fcbe", "ad" };
            Assert.NotStrictEqual(expectedOutput, actualOutput);
        }

        [Fact]
        public void CheckJobsNoSelfDependency()
        {
            var input = "a =>\nb=>\nc=>c";
            var sequencer = new JobSequencer();
            
            var ex = Assert.Throws<Exception>(() => sequencer.SortJobs(input));
            Assert.Equal("Jobs can’t depend on themselves.", ex.Message);
        }

        [Fact]
        public void CheckJobsNoCircularDependency()
        {
            var input = "a =>\nb=>c\nc=>f\nd=>a\ne =>\nf=>b";
            var sequencer = new JobSequencer();

            var ex = Assert.Throws<Exception>(() => sequencer.SortJobs(input));
            Assert.Equal("Jobs can’t have circular dependencies.", ex.Message);
        }
    }
}
