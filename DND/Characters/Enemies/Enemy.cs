using DND.Render;

namespace DND.Characters.Enemies;

public class Enemy : Character
{
    public static List<Enemy> EnemiesList = [];

    public Enemy(int hp, int dmg, Room currentRoom, CharacterTypes characterType, int movementSpeed) : base(hp, dmg, currentRoom, characterType,movementSpeed) { }
    public virtual void Move(){}
    public virtual void Attack(Player player){}

    public void EnemyTurn(Player player)
    {
        Move();
        if (Player.PlayedTurns % 3 == 0)
        {
            Attack(player);
        }
    }
    
    public static class EnemyFactory
    {
        //prepsat new Room() na nejakou tu roomku zejo  
        
        public static Enemy CreateGoblin()
        {
            return new Goblin(50, 5, Room.Rooms[1], CharacterTypes.Goblin,2);
        }
        public static Enemy CreateOgre()
        {
            return new Enemy(100, 10, Room.Rooms[2],CharacterTypes.Ogre,1);
        }
        public static Enemy CreateDragon()
        {
            return new Enemy(200, 20, Room.Rooms[3], CharacterTypes.Goblin,0);
        }
        
        
        
    }
    
}