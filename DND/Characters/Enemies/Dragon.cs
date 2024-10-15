using DND.Render;

namespace DND.Characters.Enemies;


public class Dragon : Enemy
{
    private int dragonCharge;
    public Dragon(int hp, int dmg, Room currentRoom, CharacterTypes characterType, int movementSpeed, int attackTurn) : base(hp, dmg, currentRoom, characterType, movementSpeed)
    {
        AttackTurn = attackTurn;
    }

    public override void Attack(Player player)
    {
        
        dragonCharge++;       
        
        int playerInfo = player.CurrentRoom.RoomInfo[player.Position[0], player.Position[1]];
        
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == 0 ) CurrentRoom.RoomInfo[Position[0] + 1, Position[1]] = 8;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]+1] == 0) CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] = 8;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]+2] == 0) CurrentRoom.RoomInfo[Position[0], Position[1] - 1] = 8;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]-1] == 0) CurrentRoom.RoomInfo[Position[0], Position[1] + 1] = 8;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]-2] == 0) CurrentRoom.RoomInfo[Position[0], Position[1] + 1] = 8;
        
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == 3 ) player.Hp -= Dmg;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1] + 1] == 3) player.Hp -= Dmg;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1] + 2] == 3) player.Hp -= Dmg;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1] - 1] == 3) player.Hp -= Dmg;
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1] - 2] == 3) player.Hp -= Dmg;
        
        if (CurrentRoom.RoomInfo[Position[0] - 1, Position[1]] == playerInfo
            || CurrentRoom.RoomInfo[Position[0] - 1, Position[1]+1] == playerInfo
            || CurrentRoom.RoomInfo[Position[0]- 1, Position[1] +2]  == playerInfo
            || CurrentRoom.RoomInfo[Position[0]- 1, Position[1] -1]  == playerInfo 
            || CurrentRoom.RoomInfo[Position[0]- 1, Position[1] -2]  == playerInfo) 
            player.Hp -= Dmg;
        
        if(dragonCharge % 2 == 1) return;
        
        Random rnd = new Random();
        if (Hp > MaxHp / 2)
        {
            FireAttack(20, 30);
        }
        else
        {
            CurrentRoom.RoomInfo[Position[0], Position[1]-1] = 6;
            CurrentRoom.RoomInfo[Position[0], Position[1]+1] = 6;
        
            for (int y = 0; y< Room.RoomHeight; y++)
            for (int x = 0; x < Room.RoomWidth; x++)
            {
                if (CurrentRoom.RoomInfo[y, x] != 1 && CurrentRoom.RoomInfo[y, x] !=2 && ((y < 5 || y > Room.RoomHeight - 5) || (x < 5 || x > Room.RoomWidth - 5))) 
                    CurrentRoom.RoomInfo[y, x] = 8;
            }

            FireAttack(10, 15);
        }

        void FireAttack(int minNum, int maxNum)
        {
            int attacksNumber = rnd.Next(minNum, maxNum);
        
            for (int i = 0; i < attacksNumber; i++)
            {
                int y = rnd.Next(Room.RoomHeight);
                int x = rnd.Next(Room.RoomWidth);
                if (CurrentRoom.RoomInfo[y, x] == playerInfo)
                {  
                    player.Hp -= Dmg;
                }
                if (CurrentRoom.RoomInfo[y , x] == 0) CurrentRoom.RoomInfo[y,x] = 8;
            }
        }
        
        
    }
    
}