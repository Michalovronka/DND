using DND.Characters;
using DND.Characters.Actions;
using DND.Characters.Enemies;
using DND.Render;

namespace DND.UserInput;

/*
    ConsoleKeyInfo keyInfo = Console.ReadKey();  // This will print the character to the console
    char inputChar = keyInfo.KeyChar;  // Extract the character from the key press
    Console.WriteLine();  // Move to the next line after input
    Console.WriteLine($"You pressed: {inputChar}");
*/

//remake nejdriv check jestli wsad pak checkni cisla :)

public static class GameLoopMenu
{
    public static void GameMenu(Player player) 
    {
        
        Enemy enemy = player.CurrentRoom.GetEnemy(player);
        
        Console.Clear();
        player.CurrentRoom.RenderRoom();

        Console.Write("Player HP: "); RenderHp.RenderCharacterHp(player);
        Console.Write("Enemy HP: "); RenderHp.RenderCharacterHp(enemy);
        
        int actionsLength = Enum.GetNames(typeof(ActionTypes)).Length;

        for (int n = 0; n < actionsLength; n++)
        {
            Console.WriteLine($"{n + 1}. {Enum.GetName(typeof(ActionTypes), n)}");
        }

        bool isNumber = int.TryParse(Console.ReadKey().KeyChar.ToString(), out int decisionNumber);

        Console.WriteLine();
        
        if (isNumber && decisionNumber <= actionsLength && decisionNumber > 0)
        {
            ActionTypes actionTypes = (ActionTypes)(decisionNumber - 1);

            switch (actionTypes)
            {
                case ActionTypes.Move:
                    player.Move();
                    break;
                case ActionTypes.Attack:
                    player.Attack();
                    break;
                case ActionTypes.Heal:
                    player.Heal();
                    break;
                case ActionTypes.Dictionary:
                    ShowDictionary();
                    break;
                default:
                    Console.WriteLine("Good Job wasting a turn. :)");
                    break;
            }

            enemy.CurrentRoom.UpdateEnemyAttack(enemy);
            
            if(enemy.Position[0] < 0) return;
            if(enemy.IsDead) return;
            
            if (enemy.IsEnemyAlive(player))
            {
                enemy.EnemyTurn(player);
            }
        }
        //string good - $"{text, textLength}" 
        
    }

    public static void ShowDictionary()
    {
        Console.WriteLine();
        Console.WriteLine("Dictionary Of this Epic World");
        Console.WriteLine();
        Console.WriteLine("P - Player");
        Console.WriteLine("G - Goblin");
        Console.WriteLine("O - Ogre");
        Console.WriteLine("D - Dragon");
        Console.WriteLine("* - attack");
        Console.WriteLine("# - fire");
        Console.WriteLine();
        Console.ReadKey();
    }
}