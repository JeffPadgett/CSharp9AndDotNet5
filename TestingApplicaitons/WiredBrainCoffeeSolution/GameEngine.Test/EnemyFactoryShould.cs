using System;
using Xunit;

namespace GameEngine.Test
{
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            //arrange
            EnemyFactory sut = new();

            //act
            Enemy enemy = sut.CreateEnemy("Zombie");

            //assert
            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            //arrange
            EnemyFactory sut = new();

            //act
            Enemy enemy = sut.CreateBossEnemy("Zombie King");

            //assert
            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateSeperateInstances()
        {
            //arrange
            EnemyFactory sut = new();

            //act
            Enemy bossEnemyFatKing = sut.CreateBossEnemy("Fat King");
            Enemy bossEnemyZombieKing = sut.CreateBossEnemy("Zombie King");

            //assert
            Assert.NotSame(bossEnemyFatKing, bossEnemyZombieKing);
        }

        [Fact]
        public void NotAllowNullName()
        {
            //arrange
            EnemyFactory sut = new();

            //assert
            Assert.Throws<ArgumentNullException>(() => sut.CreateBossEnemy(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemiesByThrowingException()
        {
            //arrange
            EnemyFactory sut = new();

            //act
            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.CreateBossEnemy("Zombie"));
            //assert
            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }

    }
}
