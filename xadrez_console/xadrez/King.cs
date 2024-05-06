using board;

namespace xadrez
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(color, board) { }

        public override string ToString()
        {
            return "R";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Tab.Pie(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Tab.NumberLines, Tab.NumberColumns];

            Position pos = new Position(0, 0);

            // Acima
            pos.DefineValue(Position.Line - 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // NE
            pos.DefineValue(Position.Line - 1, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // Direita
            pos.DefineValue(Position.Line, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // Sudeste
            pos.DefineValue(Position.Line + 1, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // Abaixo
            pos.DefineValue(Position.Line + 1, Position.Column);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // Sudoeste
            pos.DefineValue(Position.Line + 1, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // Esquerda
            pos.DefineValue(Position.Line, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            // Noroeste
            pos.DefineValue(Position.Line - 1, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }

    }
}
