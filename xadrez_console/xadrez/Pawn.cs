using board;

namespace xadrez
{
    internal class Pawn : Piece
    {
        public Pawn(Board tab, Color color) : base(color, tab) { }

        public override string ToString()
        {
            return "P";
        }

        private bool IsRival(Position pos)
        {
            Piece p = Tab.Pie(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Tab.Pie(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Tab.NumberLines, Tab.NumberColumns];

            Position pos = new Position(0, 0);

            if (Color == Color.Branco)
            {
                pos.DefineValue(Position.Line - 1, Position.Column);
                if (Tab.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line - 2, Position.Column);
                if (Tab.ValidPosition(pos) && Free(pos) && NumberMoves == 0)
                {
                    mat[pos.Line, pos.Column] |= true;
                }
                pos.DefineValue(Position.Line - 1, Position.Column - 1);
                if (Tab.ValidPosition(pos) && IsRival(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line - 1, Position.Column + 1);
                if (Tab.ValidPosition(pos) && IsRival(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValue(Position.Line + 1, Position.Column);
                if (Tab.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line + 2, Position.Column);
                if (Tab.ValidPosition(pos) && Free(pos) && NumberMoves == 0)
                {
                    mat[pos.Line, pos.Column] |= true;
                }
                pos.DefineValue(Position.Line + 1, Position.Column - 1);
                if (Tab.ValidPosition(pos) && IsRival(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.DefineValue(Position.Line + 1, Position.Column + 1);
                if (Tab.ValidPosition(pos) && IsRival(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            return mat;
        }
    }
}
