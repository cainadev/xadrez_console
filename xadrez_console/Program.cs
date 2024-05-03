using System;
using board;
using xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MatchXadrez match = new MatchXadrez();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadPositionXadrez().ToPosition();
                    Console.Write("Destino: ");
                    Position target = Screen.ReadPositionXadrez().ToPosition();

                    match.ExecMove(origin, target);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
