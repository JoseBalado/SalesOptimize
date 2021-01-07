using System;
using Xunit;
using System.Linq;

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
            oneToManyMapper.childList.Add(child);
            oneToManyMapper.Add(parentId, childId);

            oneToManyMapper.RemoveParent(parentId);

            Assert.True(oneToManyMapper.parentList.Count == 0, $"Parent was not removed from parentList");
            Assert.True(oneToManyMapper.childList.Count == 0, $"Orphan child was not removed from childList");
        }

        [Theory]
        [InlineData(0, 1)]
        public void OneToManyMapper_RemoveChild(int parentId, int childId)
        {
            var parent = new Parent(parentId);
            var child = new Child(childId);
            var oneToManyMapper = new OneToManyMapper();

            oneToManyMapper.parentList.Add(parent);
            oneToManyMapper.childList.Add(child);
            oneToManyMapper.Add(parentId, childId);

            oneToManyMapper.RemoveChild(childId);

            Assert.True(oneToManyMapper.childList.Count == 0, $"Child was not removed from childList");
            Assert.True(parent.children.Count == 0, $"Child was not removed from childList");
        }

        [Theory]
        [InlineData(0, 1)]
        public void OneToManyMapper_GetChildren(int parentId, int childId)
        {
            var parent = new Parent(parentId);
            var child = new Child(childId);
            var oneToManyMapper = new OneToManyMapper();

            oneToManyMapper.parentList.Add(parent);
            oneToManyMapper.childList.Add(child);
            oneToManyMapper.Add(parentId, childId);

            var childList = oneToManyMapper.GetChildren(parentId);

            Assert.True(childList.Count() == 1, $"Value returned is not of type List");
        }

        [Fact]
        public void OneToManyMapper_GetChildrenEmpty()
        {
            var oneToManyMapper = new OneToManyMapper();
            var childList = oneToManyMapper.GetChildren(0);

            Assert.Empty(childList);
        }

        [Theory]
        [InlineData(2, 1)]
        public void OneToManyMapper_GetParent(int parentId, int childId)
        {
            var parent = new Parent(parentId);
            var child = new Child(childId);
            var oneToManyMapper = new OneToManyMapper();

            oneToManyMapper.parentList.Add(parent);
            oneToManyMapper.childList.Add(child);
            oneToManyMapper.Add(parentId, childId);

            int parentForChild = oneToManyMapper.GetParent(childId);

            Assert.Equal(parentForChild, parentId);
        }

        [Fact]
        public void OneToManyMapper_GetParent0()
        {
            var child = new Child(1);
            var oneToManyMapper = new OneToManyMapper();
            oneToManyMapper.childList.Add(child);

            int parentForChild = oneToManyMapper.GetParent(1);

            Assert.Equal(0, parentForChild);
        }
    }
}

