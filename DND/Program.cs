using DND.Characters;
using DND.Characters.Enemies;
using DND.Render;
using DND.UserInput;

namespace DND;

class Program
{

    
    
    public static void Main(string[] args)
    {
        
        //udelej pro kazdou roomku enemaka 
        
        //moving - enemaci - enemaci attack - heal - roomky - roomky generovani
        
        Player player = new Player(100, 10, Room.Rooms[0], CharacterTypes.Player,1);
        
        Enemy goblin = Enemy.EnemyFactory.CreateGoblin();
        Enemy ogre = Enemy.EnemyFactory.CreateOgre();
        Enemy dragon = Enemy.EnemyFactory.CreateDragon();
        
        Enemy.EnemiesList.Add(goblin);
        Enemy.EnemiesList.Add(ogre);
        Enemy.EnemiesList.Add(dragon);
        
        Room.Rooms[0].UpdateRoomInfo(player);
        Room.Rooms[1].UpdateRoomInfo(goblin);
        Room.Rooms[2].UpdateRoomInfo(ogre);
        
        while (true)
        {
            GameLoopMenu.GameMenu(player);
            Player.PlayedTurns++;
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.Read();
    }
    

}