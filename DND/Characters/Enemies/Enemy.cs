using DND.Render;

namespace DND.Characters.Enemies;

public class Enemy : Character
{
    public static readonly List<Enemy> EnemiesList = [];
    public bool IsDead = false;
    protected int MoveTurn;
    protected int AttackTurn;

    public Enemy(int hp, int dmg, Room currentRoom, CharacterTypes characterType, int movementSpeed) : base(hp, dmg, currentRoom, characterType, movementSpeed) { }
    public virtual void Move(){}
    public virtual void Attack(Player player){}

    public void EnemyTurn(Player player)
    {
        if(MoveTurn != 0 && Player.PlayedTurns % MoveTurn == 0) Move();
        if(Player.PlayedTurns % AttackTurn == 0) Attack(player);
    }
    
    public static class EnemyFactory
    {
        
        public static Enemy CreateGoblin()
        {
            return new Goblin(50, 10, Room.Rooms[1], CharacterTypes.Goblin,2, 1,3);
        }
        public static Enemy CreateOgre()
        {
            return new Ogre(100, 40, Room.Rooms[2],CharacterTypes.Ogre,1, 2,4);
        }
        public static Enemy CreateDragon()
        {
            return new Dragon(200, 30, Room.Rooms[3], CharacterTypes.Dragon,0, 4);
        }
        
    }

    public bool IsEnemyAlive(Player player)
    {
        if (Hp <= 0)
        {
            IsDead = true;
            GetLoot(player);
            CurrentRoom.RoomInfo[Position[0], Position[1]] = 0;
            CurrentRoom.UpdateDoors();
            return false;
        }

        return true;
    }

    public void GetLoot(Player player)
    {
        Random rnd = new Random();
        int num = rnd.Next(1, 101);
        Console.WriteLine("ENEMY HAS DIED");
        Console.ReadKey();
        switch (num)
        {
            case < 10:
                Console.WriteLine("You found Yasuo's Sword (+10dmg)!");
                Console.ReadKey();
                player.Dmg += 10;
                break;
            case < 20:
                Console.WriteLine("You found Huge Potion");
                Console.ReadKey();
                player.Inventory.Add(Potions.Huge);
                break;
            case < 70:
                Console.WriteLine("You found Medium Potion");
                Console.ReadKey();
                player.Inventory.Add(Potions.Medium);
                break;
            default:
                Console.WriteLine("You found Small Potion");
                Console.ReadKey();
                player.Inventory.Add(Potions.Small);
                break;
        }
        
    }
}