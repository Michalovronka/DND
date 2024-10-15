using DND.Render;

namespace DND.Characters.Enemies;

public class Goblin : Enemy
{
    private const int MinY = 3;
    private const int MaxY = Room.RoomHeight-3;
    private const int MinX = 3;
    private const int MaxX = 3;
    public Goblin(int hp, int dmg, Room currentRoom, CharacterTypes characterType, int movementSpeed) : base(hp, dmg, currentRoom, characterType, movementSpeed) { }

    public override void Attack(Player player)
    {
        if (CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] == 0) CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] = 7;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == 0) CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] = 7;
        if (CurrentRoom.RoomInfo[Position[0], Position[1] - 1] == 0) CurrentRoom.RoomInfo[Position[0], Position[1] - 1] = 7;
        if (CurrentRoom.RoomInfo[Position[0], Position[1] + 1] == 0) CurrentRoom.RoomInfo[Position[0], Position[1] + 1] = 7;

        if (CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] == player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]]
            || CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]]
            || CurrentRoom.RoomInfo[Position[0], Position[1] - 1]  == player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]]
            || CurrentRoom.RoomInfo[Position[0], Position[1] + 1]  == player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]])
        {
            Console.WriteLine("Goblin is attacking");
            Console.ReadKey();
            Hp -= player.Dmg;
            Console.ReadKey();
        }
    }

    public override void Move()
    {
        Console.WriteLine(Position[0] + Position[1]);
        Console.ReadKey();
            
        if (Position[0] == Room.RoomHeight / 2 && (Position[1] != MinX || Position[1] != MaxX)) {CurrentRoom.UpdatePosition(0, -MovementSpeed, this); return;}
        if (Position[0] == MinY && Position[1] > MinX) {CurrentRoom.UpdatePosition(1, -MovementSpeed, this); return;}
        if (Position[1] == MinX && Position[0] < MaxY) {CurrentRoom.UpdatePosition(0, MovementSpeed, this); return;}
        if (Position[0] == MaxX && Position[1] < MaxX) {CurrentRoom.UpdatePosition(1, MovementSpeed, this); return;}
        if (Position[1] == MaxX && Position[0] < MinY) {CurrentRoom.UpdatePosition(0, -MovementSpeed, this); return;}
    }
}