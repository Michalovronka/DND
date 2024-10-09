using DND.Characters;
using DND.Characters.Actions;
namespace DND.UserInput;

public static class GameLoopMenu
{
    public static void GameMenu(Player player) 
    {
        int actionsLength = Enum.GetNames(typeof(ActionType)).Length;

        for (int n = 0; n < actionsLength; n++)
        {
            Console.WriteLine($"{n + 1}. {Enum.GetName(typeof(ActionType), n)}");
        }

        bool isNumber = int.TryParse(Console.ReadLine(), out int decisionNumber);

        if (isNumber && decisionNumber <= actionsLength && decisionNumber > 0)
        {
            ActionType actionType = (ActionType)(decisionNumber - 1);

            switch (actionType)
            {
                case ActionType.Move:
                    Console.WriteLine("Move");
                    Actions.Move(player);
                    break;
                case ActionType.Attack:
                    Console.WriteLine("Attack");
                    //Attack();
                    break;
                case ActionType.Heal:
                    Console.WriteLine("Heal");
                    //Heal();
                    break;
                default:
                    Console.WriteLine("Good Job wasting a turn. :)");
                    break;
            }


        }
        
        //string good - $"{text, textLength}" 
        Console.WriteLine("Not a valid Number");
    }
}