using DND.Characters;

namespace DND.Render;

public static class RenderHp
{
    public static void RenderCharacterHp(Character character)
    {
        for (int i = 0; i < character.MaxHp/10; i++)
        {
            if (i * 10 >= character.Hp)
            {
                Console.Write(".");
                continue;
            }
            Console.Write("\u2665");
        }

        Console.WriteLine(character.Hp);
        
    }
}