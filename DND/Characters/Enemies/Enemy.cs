namespace DND.Characters.Enemies;

public class Enemy : Character
{
    private EnemyTypes _enemyType;

    public Enemy(int hp, int dmg, EnemyTypes enemyType) : base(hp, dmg)
    {
        _enemyType = enemyType;
    }
    
    public static class Factory
    {
        public static Enemy CreateOgre()
        {
            return new Enemy( 100, 10, EnemyTypes.Ogre);
        }

        public static Enemy CreateGoblin()
        {
            return new Enemy(50, 5, EnemyTypes.Goblin);
        }
    }
    
}