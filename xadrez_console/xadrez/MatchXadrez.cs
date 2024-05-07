using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public bool Check;

        public MatchXadrez()
        {
            Tab = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.Branco;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            AddPies();
        }

        public Piece ExecMove(Position origin, Position target)
        {
            Piece p = Tab.RemovePie(origin);
            p.AddMoves();
            Piece capturedPie = Tab.RemovePie(target);
            Tab.InsertPie(p, target);
            if (capturedPie != null)
            {
                Captured.Add(capturedPie);
            }
            return capturedPie;
        }

        public void UntilMove(Position origin, Position target, Piece capturedPie)
        {
            Piece p = Tab.RemovePie(target);
            p.RemoveMoves();
            if (capturedPie != null)
            {
                Tab.InsertPie(capturedPie, target);
                Captured.Remove(capturedPie);
            }
            Tab.InsertPie(p, origin);
        }

        public void MakeGamble(Position origin, Position target)
        {
            Piece capturedPie = ExecMove(origin, target);

            if (IsCheck(CurrentPlayer))
            {
                UntilMove(origin, target, capturedPie);
                throw new BoardException("Você não pode se colocar em xeque!");
            }

            if (IsCheck(Rival(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (TestCheck(Rival(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Shift++;
                ChangePlayer();
            }
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

        private Color Rival(Color color)
        {
            if (color == Color.Branco)
            {
                return Color.Preto; 
            }
            else
            {
                return Color.Branco;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece x in PieInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece R = King(color);
            if (R == null)
            {
                throw new BoardException("Não tem rei da cor " + color + " no tabuleiro!");
            }

            foreach (Piece x in PieInGame(Rival(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[R.Position.Line, R.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheck(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach (Piece x in PieInGame(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 0; i < Tab.NumberLines; i++)
                {
                    for (int j = 0; j < Tab.NumberColumns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position target = new Position(i, j);
                            Piece capturedPie = ExecMove(origin, target);
                            bool Testcheck = IsCheck(color);
                            UntilMove(origin, target, capturedPie);
                            if (!Testcheck) { return false; }
                        }
                    }
                }
            }
            return true;
        }

        public void InsertNewPie(char column, int line, Piece pie)
        {
            Tab.InsertPie(pie, new PositionXadrez(column, line).ToPosition());
            Pieces.Add(pie);
        }

        private void AddPies()
        {
            InsertNewPie('a', 1, new Rook(Tab, Color.Branco));
            InsertNewPie('b', 1, new Horse(Tab, Color.Branco));
            InsertNewPie('c', 1, new Bishop(Tab, Color.Branco));
            InsertNewPie('d', 1, new Queen(Tab, Color.Branco));
            InsertNewPie('e', 1, new King(Tab, Color.Branco));
            InsertNewPie('f', 1, new Bishop(Tab, Color.Branco));
            InsertNewPie('g', 1, new Horse(Tab, Color.Branco));
            InsertNewPie('h', 1, new Rook(Tab, Color.Branco));
            InsertNewPie('a', 2, new Pawn(Tab, Color.Branco));
            InsertNewPie('b', 2, new Pawn(Tab, Color.Branco));
            InsertNewPie('c', 2, new Pawn(Tab, Color.Branco));
            InsertNewPie('d', 2, new Pawn(Tab, Color.Branco));
            InsertNewPie('e', 2, new Pawn(Tab, Color.Branco));
            InsertNewPie('f', 2, new Pawn(Tab, Color.Branco));
            InsertNewPie('g', 2, new Pawn(Tab, Color.Branco));
            InsertNewPie('h', 2, new Pawn(Tab, Color.Branco));

            InsertNewPie('a', 8, new Rook(Tab, Color.Preto));
            InsertNewPie('b', 8, new Horse(Tab, Color.Preto));
            InsertNewPie('c', 8, new Bishop(Tab, Color.Preto));
            InsertNewPie('d', 8, new Queen(Tab, Color.Preto));
            InsertNewPie('e', 8, new King(Tab, Color.Preto));
            InsertNewPie('f', 8, new Bishop(Tab, Color.Preto));
            InsertNewPie('g', 8, new Horse(Tab, Color.Preto));
            InsertNewPie('h', 8, new Rook(Tab, Color.Preto));
            InsertNewPie('a', 7, new Pawn(Tab, Color.Preto));
            InsertNewPie('b', 7, new Pawn(Tab, Color.Preto));
            InsertNewPie('c', 7, new Pawn(Tab, Color.Preto));
            InsertNewPie('d', 7, new Pawn(Tab, Color.Preto));
            InsertNewPie('e', 7, new Pawn(Tab, Color.Preto));
            InsertNewPie('f', 7, new Pawn(Tab, Color.Preto));
            InsertNewPie('g', 7, new Pawn(Tab, Color.Preto));
            InsertNewPie('h', 7, new Pawn(Tab, Color.Preto));

        }
    }
}
