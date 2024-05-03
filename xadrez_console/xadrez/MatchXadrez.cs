using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using board;

namespace xadrez
{
    internal class MatchXadrez
    {
        public Board Tab { get; private set; }
        private int Shift;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }

        public MatchXadrez()
        {
            Tab = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            AddPies();
        }

        public void ExecMove(Position origin, Position target)
        {
            Piece p = Tab.RemovePie(origin);
            p.AddMoves();
            Piece capturedPie = Tab.RemovePie(target);
            Tab.InsertPie(p, target);
        }

        private void AddPies()
        {
            Tab.InsertPie(new Rook(Tab, Color.White), new PositionXadrez('c', 1).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.White), new PositionXadrez('c', 2).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.White), new PositionXadrez('d', 2).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.White), new PositionXadrez('e', 2).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.White), new PositionXadrez('e', 1).ToPosition());
            Tab.InsertPie(new King(Tab, Color.White), new PositionXadrez('d', 1).ToPosition());

            Tab.InsertPie(new Rook(Tab, Color.Black), new PositionXadrez('c', 7).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Black), new PositionXadrez('c', 8).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Black), new PositionXadrez('d', 7).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Black), new PositionXadrez('e', 7).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Black), new PositionXadrez('e', 8).ToPosition());
            Tab.InsertPie(new King(Tab, Color.Black), new PositionXadrez('d', 8).ToPosition());
        }
    }
}
