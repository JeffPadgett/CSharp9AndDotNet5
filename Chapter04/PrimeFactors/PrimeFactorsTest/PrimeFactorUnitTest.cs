using System;
using Xunit;
using PrimeFactorsLib;

namespace PrimeFactorsTest
{
    public class PrimeFactorUnitTest
    {
        [Fact]
        public void PrimeNumTestOne()
        {

            //arrange
            int num = 7;
            string expected = "7";

            //assign
            string actual = PrimeFactorGenerator.PrimeFactors(num);

            //assert
            Assert.Equal(expected, actual);
            
        }
    }
}
