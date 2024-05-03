using board;
using xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board tab = new Board(8, 8);

            tab.InsertPie(new Rook(tab, Color.Black), new Position(0, 0));
            tab.InsertPie(new Rook(tab, Color.Black), new Position(1, 3));
            tab.InsertPie(new King(tab, Color.Black), new Position(2, 4));

            Screen.PrintBoard(tab);

        }
    }
}
