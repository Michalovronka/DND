using DND.Characters;
using DND.Characters.Enemies;

namespace DND.Render;

public class Room
{
    public const int RoomHeight = 17;
    public const int RoomWidth = 27;
    
    public static readonly Room[] Rooms = CreateRooms();
    
    public readonly int [,] RoomInfo = new int[RoomHeight,RoomWidth];
    private static readonly Dictionary<int,string> RenderSymbols = new Dictionary<int, string>
    {
        { 0, "\u0020 \u0020" }, //empty space
        { 1, "---" }, //verical border
        { 2, "| |" }, //side border
        { 3, " P " }, //player
        { 4, " G " }, //goblin
        { 5, " O " }, //ogre
        { 6, " D " }, //dragon
        { 7, " * " }, //goblin, ogre attack
        { 8, " # " }, // dragon attack
    };

    public Room()
    {
        CreateRoomLayout();
    }

    public void RenderRoom() 
    {
        for (int y = 0; y < RoomHeight; y++)
        {
            for (int x = 0; x < RoomWidth; x++)
            {
                Console.Write(RenderSymbols[RoomInfo[y,x]]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }


    public Enemy GetEnemy(Player player)
    {
        for (int i = 4; i < 7; i++)
        {
            CharacterTypes enemyType = (CharacterTypes)i;
            Enemy enemy;
            switch (enemyType)
            {
                case CharacterTypes.Goblin:
                    enemy = Enemy.EnemiesList[0];
                    break;
                case CharacterTypes.Ogre:
                    enemy = Enemy.EnemiesList[1];
                    break;
                case CharacterTypes.Dragon:
                    enemy = Enemy.EnemiesList[2];
                    break;
                default:
                    Console.WriteLine("how did you get here");
                    continue;
            }
            if (player.CurrentRoom != enemy.CurrentRoom) continue;
            return enemy;
        }

        Enemy ghost = new Enemy(0, 0, player.CurrentRoom, CharacterTypes.Ghost, 0);
        ghost.Position[0] = -999;
        return ghost;
    }
    public void UpdateEnemyAttack(Enemy enemy)
    {
        switch (enemy.CharacterType)
        {
            case CharacterTypes.Goblin:
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 1, enemy.Position[1]] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 1, enemy.Position[1]] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 1, enemy.Position[1]] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 1, enemy.Position[1]] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] - 1] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] - 1] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] + 1] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] + 1] = 0;
                break;
            case CharacterTypes.Ogre:
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 1, enemy.Position[1]] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 1, enemy.Position[1]] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 1, enemy.Position[1]] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 1, enemy.Position[1]] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 2, enemy.Position[1]] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 2, enemy.Position[1]] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 2, enemy.Position[1]+1] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 2, enemy.Position[1]+1] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 2, enemy.Position[1]-1] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] + 2, enemy.Position[1]-1] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 2, enemy.Position[1]] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 2, enemy.Position[1]] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 2, enemy.Position[1]+1] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 2, enemy.Position[1]+1] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 2, enemy.Position[1]-1] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] - 2, enemy.Position[1]-1] = 0;
                
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] - 1] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] - 1] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] + 1] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] + 1] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] + 2] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] + 2] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] +1, enemy.Position[1] + 2] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] +1, enemy.Position[1] + 2] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] -1, enemy.Position[1] + 2] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] -1, enemy.Position[1] + 2] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] - 2] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1] - 2] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] +1, enemy.Position[1] - 2] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] +1, enemy.Position[1] - 2] = 0;
                if (enemy.CurrentRoom.RoomInfo[enemy.Position[0] -1, enemy.Position[1] - 2] == 7) enemy.CurrentRoom.RoomInfo[enemy.Position[0] -1, enemy.Position[1] - 2] = 0;
                break;
            case CharacterTypes.Dragon:
                break;
            default:
                return;
        }
    }
    
    public void UpdateDoors()
    {
        for (int x = RoomWidth / 2 - 2; x < RoomWidth / 2 + 3; x++)
        {
            if (RoomInfo[0,x] == 1) //Doors
            {
                RoomInfo[0, x] = 0;
                continue;
            }
            RoomInfo[0, x] = 1;
        }
        
    }

    public void UpdatePosition(int index, int direction, Character character)
    {
        RoomInfo[character.Position[0], character.Position[1]] = 0;
        character.Position[index] += direction;
        UpdateRoomInfo(character);
    }
    public void UpdateRoomInfo(Character character) 
    {
        RoomInfo[character.Position[0], character.Position[1]] = (int) character.CharacterType;
    }
    
    private void CreateRoomLayout()
    {
        for (int y = 0; y< RoomHeight; y++) 
        for (int x = 0; x < RoomWidth; x++)
        {
            if(RoomInfo[y, x] != 0) continue;
            if (y == 0 && x > RoomWidth / 2 - 3 && x < RoomWidth / 2 + 3) //Doors
            {
                RoomInfo[y, x] = 0;
                continue;
            }
            
            if (y == 0 || y == RoomHeight - 1) //UP and Down barrier
            {
                RoomInfo[y, x] = 1;
                continue;
            }

            if (x == 0 || x == RoomWidth - 1 ) //Left barrier
            {
                RoomInfo[y, x] = 2;
                continue;
            }

            RoomInfo[y, x] = 0;
        }
        
        //UpdateDoors();
    }
    
    private static Room[] CreateRooms()
    {
        Room[] rooms = new Room[4]; //spawn - goblin - ogre - Dragon
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i] = new Room();
        }
        return rooms;
    }
    
    
}