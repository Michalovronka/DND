using DND.Characters;
using DND.UserInput;

namespace DND;

class Program
{
    
    public 
    static void Main(string[] args)
    {

        Player player = new Player(200, 50);
        GameLoopMenu.GameMenu(player);

        Console.Read();
    }
}