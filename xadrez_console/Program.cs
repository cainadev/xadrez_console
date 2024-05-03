using System;
using board;
using xadrez;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PositionXadrez pos = new PositionXadrez('c', 7);


            Console.WriteLine(pos);

            Console.WriteLine(pos.ToPosition());
        }
    }
}
