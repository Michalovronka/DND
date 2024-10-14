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
        Console.Clear();
        player.CurrentRoom.RenderRoom();
        
        int actionsLength = Enum.GetNames(typeof(ActionTypes)).Length;

        for (int n = 0; n < actionsLength; n++)
        {
            Console.WriteLine($"{n + 1}. {Enum.GetName(typeof(ActionTypes), n)}");
        }

        bool isNumber = int.TryParse(Console.ReadKey().KeyChar.ToString(), out int decisionNumber);

        if (isNumber && decisionNumber <= actionsLength && decisionNumber > 0)
        {
            ActionTypes actionTypes = (ActionTypes)(decisionNumber - 1);

            switch (actionTypes)
            {
                case ActionTypes.Move:
                    Console.WriteLine("Move");
                    player.Move();
                    break;
                case ActionTypes.Attack:
                    Console.WriteLine("Attack");
                    player.Attack();
                    break;
                case ActionTypes.Heal:
                    Console.WriteLine("Heal");
                    //Heal();
                    break;
                default:
                    Console.WriteLine("Good Job wasting a turn. :)");
                    break;
            }

            Enemy enemy = player.CurrentRoom.GetEnemy(player);
            if(enemy.Position[0] < 0) return;
            enemy.EnemyTurn(player);

        }
        
        else
        {
            Console.WriteLine("Not a valid Number");
        }
        //string good - $"{text, textLength}" 
        
    }
}