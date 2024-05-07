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
        public int Shift {  get; private set; }
        public Color CurrentPlayer {  get; private set; }
        public bool Finished { get; private set; }

        public MatchXadrez()
        {
            Tab = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.Branco;
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

        public void MakeGamble(Position origin, Position target)
        {
            ExecMove(origin, target);
            Shift++;
            ChangePlayer();
        }

        public void ValidatePositionOrigin(Position pos)
        {
            if (Tab.Pie(pos) == null)
            {
                throw new BoardException("Não Existe peça na posição de origem escolhida!");
            }
            if (CurrentPlayer != Tab.Pie(pos).Color) 
            {
                throw new BoardException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Pie(pos).TherePossibleMoves()){
                throw new BoardException("Não há movimentos possiveis para a peça de origem escolhida!");
            }
        }

        public void ValidadePositionTarget(Position origin, Position target) 
        {
            if (!Tab.Pie(origin).CanMoveFor(target))
            {
                throw new BoardException("Posição de destino invalida!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Branco)
            {
                CurrentPlayer = Color.Preto;
            }
            else
            {
                CurrentPlayer = Color.Branco;
            }
        }

        private void AddPies()
        {
            Tab.InsertPie(new Rook(Tab, Color.Branco), new PositionXadrez('c', 1).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Branco), new PositionXadrez('c', 2).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Branco), new PositionXadrez('d', 2).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Branco), new PositionXadrez('e', 2).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Branco), new PositionXadrez('e', 1).ToPosition());
            Tab.InsertPie(new King(Tab, Color.Branco), new PositionXadrez('d', 1).ToPosition());

            Tab.InsertPie(new Rook(Tab, Color.Preto), new PositionXadrez('c', 7).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Preto), new PositionXadrez('c', 8).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Preto), new PositionXadrez('d', 7).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Preto), new PositionXadrez('e', 7).ToPosition());
            Tab.InsertPie(new Rook(Tab, Color.Preto), new PositionXadrez('e', 8).ToPosition());
            Tab.InsertPie(new King(Tab, Color.Preto), new PositionXadrez('d', 8).ToPosition());
        }
    }
}
