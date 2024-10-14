using DND.Characters.Enemies;
using DND.Render;

namespace DND.Characters;

//dej vsechno do static asi 
public class Player : Character
{
    private int _currentRoomIndex;
    
    public static int PlayedTurns = 0;  
    
    public Player(int hp, int dmg, Room currentRoom, CharacterTypes characterType, int movementSpeed) : base(hp, dmg, currentRoom,characterType,movementSpeed)
    {
        _currentRoomIndex= 0;
    }
    
    public void Move()
    {
        //dodelej abys moh back normalne
        Console.WriteLine("WASD");
        ConsoleKeyInfo keyInfo = Console.ReadKey();  
        char inputChar = keyInfo.KeyChar; 
        Console.WriteLine();
        Room room = CurrentRoom;
        
        switch (inputChar){
            case 'w':
                if (Position[0] - MovementSpeed >= 0 && room.RoomInfo[Position[0] - MovementSpeed,Position[1]] == 0) room.UpdatePosition(0, -MovementSpeed, this);
                if (Position[0] == 0)
                {
                    CurrentRoom = Room.Rooms[++_currentRoomIndex];
                    Position[0] = Room.RoomHeight-2;
                    Position[1] = Room.RoomWidth/2;
                    CurrentRoom.UpdateDoors();
                    CurrentRoom.UpdatePosition(0, 0, this);
                }
                break;
            case 'a':
                if(Position[1] - MovementSpeed >= 0 && room.RoomInfo[Position[0], Position[1]-MovementSpeed] == 0) room.UpdatePosition(1, -MovementSpeed, this);
                break;
            case 's':
                if(Position[0] - MovementSpeed < Room.RoomHeight && room.RoomInfo[Position[0]+MovementSpeed, Position[1]] == 0) room.UpdatePosition(0, MovementSpeed, this);
                break;
            case 'd':
                if(Position[1] - MovementSpeed < Room.RoomWidth && room.RoomInfo[Position[0], Position[1]+MovementSpeed] == 0) room.UpdatePosition(1, MovementSpeed, this);
                break;
        }
        Console.Clear();
        room.RenderRoom();
    }

    public void Attack()
    {

        Enemy enemy = CurrentRoom.GetEnemy(this);
            
        if (enemy.Position[0] > 0 
            && (CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] == enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1]]
            || CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1]]
            || CurrentRoom.RoomInfo[Position[0], Position[1] - 1]  == enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1]]
            || CurrentRoom.RoomInfo[Position[0], Position[1] + 1]  == enemy.CurrentRoom.RoomInfo[enemy.Position[0], enemy.Position[1]]))
        {
            enemy.Hp -= Dmg;
            Console.WriteLine("utooook");
            Console.ReadKey();
        }
       
        
    }
    
    
}