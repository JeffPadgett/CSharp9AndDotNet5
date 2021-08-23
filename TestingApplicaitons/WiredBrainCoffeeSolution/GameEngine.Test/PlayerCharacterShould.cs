using System;
using Xunit;

namespace GameEngine.Test
{
    public class PlayerCharacterShould
    {
        private readonly PlayerCharacter _sut;

        public PlayerCharacterShould()
        {
            _sut = new();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.StartsWith("Sarah", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssert()
        {
            _sut.FirstName = "SARAH";
            _sut.LastName = "SMITH";

            Assert.Equal("Sarah Smith", _sut.FullName, ignoreCase: true) ;
        }


        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, x => x.Contains("Sword"));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }


    }



}
