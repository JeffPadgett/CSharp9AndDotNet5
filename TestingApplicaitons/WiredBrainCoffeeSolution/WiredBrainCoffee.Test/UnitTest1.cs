using System;
using WiredBrainCoffee.StackApp;
using Xunit;

namespace WiredBrainCoffee.Test
{
    public class SimpleStackShould
    {
        [Fact]
        public void DoesNotRemoveIndexElementFromStack()
        {
            //arrange
            SimpleStackTest<int> sut = new();
            //act
            sut.Push(12);
            sut.Push(1);
            sut.Push(4);
            sut.Pop();

            //assert
            Assert.Equal(4,sut.Items[2]);
        }
    }
}
