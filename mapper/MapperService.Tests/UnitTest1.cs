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
        public void OneToManyMapper_Add(int parentId, int childId)
        {
            var parent = new Parent(parentId);
            var child = new Child(childId);

            var oneToManyMapper = new OneToManyMapper();
            oneToManyMapper.parentList.Add(parent);
            oneToManyMapper.Add(parentId, childId);

            Assert.True(parent.children.Contains(childId), $"Children is not added to this parent");
        }

        [Theory]
        [InlineData(0,1)]
        public void OneToManyMapper_RemoveParent(int parentId, int childId)
        {
            var parent = new Parent(parentId);
            var child = new Child(childId);

            var oneToManyMapper = new OneToManyMapper();
            oneToManyMapper.parentList.Add(parent);
            oneToManyMapper.RemoveParent(parentId);

            Assert.True(oneToManyMapper.parentList.Count == 0, $"Parent was not removed from parentList");
        }

        [Theory]
        [InlineData(0)]
        public void OneToManyMapper_RemoveChild(int childId)
        {
            // var parent = new Parent(parentId);
            var child = new Child(childId);

            var oneToManyMapper = new OneToManyMapper();
            oneToManyMapper.childList.Add(child);
            oneToManyMapper.RemoveChild(childId);

            Assert.True(oneToManyMapper.childList.Count == 0, $"Child was not removed from childList");
        }
    }
}

