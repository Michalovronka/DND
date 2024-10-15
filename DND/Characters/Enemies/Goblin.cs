using DND.Render;

namespace DND.Characters.Enemies;

public class Goblin : Enemy
{
    private const int MinY = 4;
    private const int MaxY = Room.RoomHeight-5;
    private const int MinX = 3;
    private const int MaxX = Room.RoomWidth-4;

    public Goblin(int hp, int dmg, Room currentRoom, CharacterTypes characterType, int movementSpeed, int moveTurn, int attackTurn) : base(hp, dmg, currentRoom, characterType, movementSpeed)
    {
        MoveTurn = moveTurn;
        AttackTurn = attackTurn;
    }

    public override void Attack(Player player)
    {
        int playerInfo = player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]];
        if (CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] == 0) CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] = 7;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == 0) CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] = 7;
        if (CurrentRoom.RoomInfo[Position[0], Position[1] - 1] == 0) CurrentRoom.RoomInfo[Position[0], Position[1] - 1] = 7;
        if (CurrentRoom.RoomInfo[Position[0], Position[1] + 1] == 0) CurrentRoom.RoomInfo[Position[0], Position[1] + 1] = 7;

        if (CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] == playerInfo
            || CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == playerInfo
            || CurrentRoom.RoomInfo[Position[0], Position[1] - 1]  == playerInfo
            || CurrentRoom.RoomInfo[Position[0], Position[1] + 1]  == playerInfo)
        {
            player.Hp -= Dmg;
        }
    }

    public override void Move()
    {
        
        if (Position[1] == Room.RoomWidth / 2 && !(Position[0] == MinY || Position[0] == MaxY)) {CurrentRoom.UpdatePosition(0, -MovementSpeed, this); return;}
        if (Position[0] == MinY && Position[1] > MinX && CurrentRoom.RoomInfo[Position[0],Position[1] - MovementSpeed] == 0) {CurrentRoom.UpdatePosition(1, -MovementSpeed, this); return;}
        if (Position[1] == MaxX && Position[0] > MinY && CurrentRoom.RoomInfo[Position[0]- MovementSpeed, Position[1]] == 0) {CurrentRoom.UpdatePosition(0, -MovementSpeed, this); return;}
        if (Position[1] == MinX && Position[0] < MaxY && CurrentRoom.RoomInfo[Position[0]+ MovementSpeed, Position[1]] == 0) {CurrentRoom.UpdatePosition(0, MovementSpeed, this); return;}
        if (Position[0] == MaxY && Position[1] < MaxX && CurrentRoom.RoomInfo[Position[0],Position[1] + MovementSpeed] == 0) {CurrentRoom.UpdatePosition(1, MovementSpeed, this);}
        
    }
}