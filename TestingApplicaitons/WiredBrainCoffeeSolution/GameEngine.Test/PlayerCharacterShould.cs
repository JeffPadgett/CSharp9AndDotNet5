using System;
using Xunit;

namespace GameEngine.Test
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //arrange
            PlayerCharacter sut = new();

            //act

            //assert
            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.StartsWith("Sarah", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssert()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "SARAH";
            sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", sut.FullName, ignoreCase: true) ;
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            //arrange
            PlayerCharacter sut = new();

            //act

            //assert
            Assert.Null(sut.Nickname);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            //arrange
            PlayerCharacter sut = new();

            //act

            //assert
            Assert.Null(sut.Nickname);
        }
    }



}
