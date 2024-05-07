using System;
using System.Collections.Generic;
using board;

namespace xadrez
{
    internal class MatchXadrez
    {
        public Board Tab { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;

        public MatchXadrez()
        {
            Tab = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.Branco;
            Finished = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            AddPies();
        }

        public void ExecMove(Position origin, Position target)
        {
            Piece p = Tab.RemovePie(origin);
            p.AddMoves();
            Piece capturedPie = Tab.RemovePie(target);
            Tab.InsertPie(p, target);
            if (capturedPie != null)
            {
                Captured.Add(capturedPie);
            }
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
            if (!Tab.Pie(pos).TherePossibleMoves())
            {
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

        public HashSet<Piece> CapturedPies(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured) 
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PieInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPies(color));
            return aux;
        }

        public void InsertNewPie(char column, int line, Piece pie)
        {
            Tab.InsertPie(pie, new PositionXadrez(column, line).ToPosition());
            Pieces.Add(pie);
        }

        private void AddPies()
        {
            InsertNewPie('c', 1, new Rook(Tab, Color.Branco));
            InsertNewPie('c', 2, new Rook(Tab, Color.Branco));
            InsertNewPie('d', 2, new Rook(Tab, Color.Branco));
            InsertNewPie('e', 2, new Rook(Tab, Color.Branco));
            InsertNewPie('e', 1, new Rook(Tab, Color.Branco));
            InsertNewPie('d', 1, new King(Tab, Color.Branco));

            InsertNewPie('c', 7, new Rook(Tab, Color.Preto));
            InsertNewPie('c', 8, new Rook(Tab, Color.Preto));
            InsertNewPie('d', 7, new Rook(Tab, Color.Preto));
            InsertNewPie('e', 7, new Rook(Tab, Color.Preto));
            InsertNewPie('e', 8, new Rook(Tab, Color.Preto));
            InsertNewPie('d', 8, new King(Tab, Color.Preto));
        }
    }
}
