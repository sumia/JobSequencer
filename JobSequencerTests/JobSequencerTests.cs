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
        public void CheckJobDependancy()
        {

        }

        [Fact]
        public void CheckJobsNoSelfDependancy()
        {

        }

        [Fact]
        public void CheckJobsNoCircularDependancy()
        {

        }
    }
}
