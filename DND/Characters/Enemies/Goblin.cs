using DND.Render;

namespace DND.Characters.Enemies;

public class Goblin : Enemy
{
    public Goblin(int hp, int dmg, Room currentRoom, CharacterTypes characterType, int movementSpeed) : base(hp, dmg, currentRoom, characterType, movementSpeed) { }

    public override void Attack(Player player)
    {
        
                // dodelej zejtra kryple 

        if (CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] == player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]]
            || CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]]
            || CurrentRoom.RoomInfo[Position[0], Position[1] - 1]  == player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]]
            || CurrentRoom.RoomInfo[Position[0], Position[1] + 1]  == player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]])
        {
            Console.WriteLine("wewewqewqeqwewqeqw");
            Console.ReadKey();
            Hp -= player.Dmg;
            Console.WriteLine("utooook");
            Console.ReadKey();
            return;
        }

        CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] = 7;
        CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] = 7;
        CurrentRoom.RoomInfo[Position[0], Position[1] - 1] = 7;
        CurrentRoom.RoomInfo[Position[0], Position[1] + 1] = 7;




    }

    public override void Move()
    {
        base.Move();
    }
}