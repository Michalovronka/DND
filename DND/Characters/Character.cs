namespace DND.Characters;

public abstract class Character
{
    protected int Hp;
    protected int Dmg;

    protected Character(int hp, int dmg)
    {
        Hp = hp;
        Dmg = dmg;
    }
    
}