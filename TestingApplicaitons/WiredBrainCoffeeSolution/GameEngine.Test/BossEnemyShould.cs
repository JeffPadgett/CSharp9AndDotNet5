using System;
using Xunit;

namespace GameEngine.Test
{
    public class BossEnemyShould
    {
        [Fact]
        public void HaveCorrectPower()
        {
            //arrange
            BossEnemy sut = new();

            //act

            //assert
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
            
        }

    }
}
