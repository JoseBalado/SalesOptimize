using System;
using Xunit;

namespace MapperService.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            var primeService = new PrimeService();
            bool result = primeService.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var primeService = new PrimeService();
            var result = primeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }

        [Theory]
        [InlineData(0,1)]
        public void OneToManyMapper_Add(int idParent, int idChild)
        {
            var parent = new Parent(idParent);
            var child = new Child(idChild);

            var oneToManyMapper = new OneToManyMapper();
            //void result = oneToManyMapper.Add(parent, child);

            Assert.False(false, $"{parent} should not be prime");
        }
    }
}

