using board;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board tab = new Board(8, 8);

            Screen.PrintBoard(tab);

        }
    }
}
