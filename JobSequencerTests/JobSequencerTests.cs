using JobSequencerNS;
using System;
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
            string[] output = null;

            var sequencer = new JobSequencer();
            output = sequencer.SortJobs(input);

            Assert.Empty(output);
        }

        [Fact]
        public void CheckJobsNoSignicantOrder()
        {

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
