using DND.Render;

namespace DND.Characters;

public abstract class Character
{
    public decimal Hp;
    public decimal Dmg;
    public readonly int[] Position = new int[2];
    public Room CurrentRoom;
    public readonly CharacterTypes CharacterType;
    protected int MovementSpeed = 1;

    protected Character(decimal hp, decimal dmg, Room currentRoom, CharacterTypes characterType, int movementSpeed)
    {
        Hp = hp;
        Dmg = dmg;
        CurrentRoom = currentRoom;
        CharacterType = characterType;
        MovementSpeed = movementSpeed;
        Position[0] = Room.RoomHeight / 2; 
        Position[1] = Room.RoomWidth/2;
    }
    
}